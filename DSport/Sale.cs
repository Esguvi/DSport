using ClosedXML.Excel;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DSport
{
    public partial class Sale : Form
    {
        // VARIABLES
        private string filePath;
        private decimal precioUnitario = 0;
        private string imgPath = "";
        private string idProductoSeleccionado = "";
        private int stockDisponible = 0;

        // CONSTRUCTOR
        public Sale()
        {
            InitializeComponent();
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database/DSport-database.xlsx");
            CargarProductos();

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            Home home = new Home();
            home.AplicarDegradado(button1, LinearGradientMode.ForwardDiagonal);

            pictureBox1.BackgroundImage = Properties.Resources.no_image;
        }

        // METODO PARA CARGAR LOS PRODUCTOS
        public void CargarProductos()
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show($"El archivo de la base de datos no existe en la ruta: {filePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet("storage");

                    if (worksheet == null)
                    {
                        MessageBox.Show("No se encontró la hoja 'storage' en el archivo Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var rows = worksheet.RowsUsed();

                    comboBox1.Items.Clear();
                    foreach (var row in rows.Skip(2))
                    {
                        string nombreProducto = row.Cell(2).GetString().Trim();
                        comboBox1.Items.Add(nombreProducto);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // COMPROBACION DE ELEMENTO SELECCIONADO EN EL COMBOBOX
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                CargarDetallesProducto(comboBox1.SelectedItem.ToString());
            }
        }

        // CARGAR DETALLES DEL PRODUCTO SELECCIONADO EN EL COMBOBOX
        private void CargarDetallesProducto(string nombreProducto)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("El archivo de la base de datos no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet("storage");
                    var rows = worksheet.RowsUsed();

                    foreach (var row in rows.Skip(1))
                    {
                        if (row.Cell(2).GetString().Trim() == nombreProducto)
                        {
                            idProductoSeleccionado = row.Cell(1).GetString().Trim();
                            string marca = row.Cell(3).GetString().Trim();
                            precioUnitario = row.Cell(4).GetValue<decimal>();
                            stockDisponible = row.Cell(5).GetValue<int>();

                            label3.Text = marca;
                            numericUpDown1.Value = 1;
                            numericUpDown1.Maximum = stockDisponible;
                            ActualizarPrecioTotal();

                            imgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "productos", idProductoSeleccionado + ".jpg");
                            CargarImagen(imgPath);
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalles del producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ACTUALIZAR PRECIO TOTAL SEGUN CANTIDAD A VENDER
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            ActualizarPrecioTotal();
        }

        // ACTUALIZAR PRECIO TOTAL A MEDIDA QUE SE AÑADAN PRODUCTOS
        private void ActualizarPrecioTotal()
        {
            decimal total = precioUnitario * numericUpDown1.Value;
            label2.Text = total.ToString("C");
        }

        // CARGAR IMAGEN DEL PRODUCTO SELECCIONADO
        private void CargarImagen(string ruta)
        {
            if (File.Exists(ruta))
            {
                pictureBox1.BackgroundImage = Image.FromFile(ruta);

            }
            else
            {
                pictureBox1.Image = Properties.Resources.no_image;
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        // METODO PARA CUANDO SE PINCHE EN EL BOTON DE REALIZAR VENTA
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecciona un producto para realizar la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int cantidad = (int)numericUpDown1.Value;
            if (cantidad > stockDisponible)
            {
                MessageBox.Show("No hay suficiente stock disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var storageSheet = workbook.Worksheet("storage");
                    var salesSheet = workbook.Worksheet("sales");

                    var rowToUpdate = storageSheet.RowsUsed().Skip(1)
                        .FirstOrDefault(r => r.Cell(1).GetString().Trim() == idProductoSeleccionado);
                    if (rowToUpdate != null)
                    {
                        rowToUpdate.Cell(5).Value = stockDisponible - cantidad;
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el stock del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var lastRow = salesSheet.LastRowUsed();
                    var newRow = salesSheet.Row(lastRow.RowNumber() + 1);
                    newRow.Cell(1).Value = ObtenerNuevoIDVenta();
                    newRow.Cell(2).Value = LoginRegister.UserID.ToString();
                    newRow.Cell(3).Value = idProductoSeleccionado;
                    newRow.Cell(4).Value = DateTime.Now;
                    newRow.Cell(5).Value = cantidad;
                    newRow.Cell(6).Value = precioUnitario * cantidad;

                    workbook.Save();
                }

                MessageBox.Show("¡Venta realizada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProductos();
                LimpiarFormularioVenta();
                Home home = new Home();
                home.CargarGraficoVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // OBTENEMOS NUEVO ID A PARTIR DEL ÚLTIMO QUE HAYA EN EL WORKSHEET DE "SALES"
        private int ObtenerNuevoIDVenta()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database/DSport-database.xlsx");

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet("sales");
                var lastRow = worksheet.LastRowUsed();
                int lastID = (int)(lastRow?.Cell(1)?.Value ?? 0);
                return lastID + 1;
            }
        }

        // LIMPIAMOS LOS DATOS UNA VEZ SE HAYA VENDIDO EL PRODUCTO
        private void LimpiarFormularioVenta()
        {
            comboBox1.Text = ""; 
            numericUpDown1.Value = 0;
            label3.Text = "--";
            label2.Text = "0€";

            pictureBox1.BackgroundImage = Properties.Resources.no_image;
        }




    }
}
