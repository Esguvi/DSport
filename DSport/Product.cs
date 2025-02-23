using ClosedXML.Excel;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DSport
{
    public partial class Product : Form
    {
        // VARIABLES
        private Home home;
        private int idProducto;
        private string nombreProducto;
        private string imgPath;
        private string marca;
        private decimal precio;
        private int stock;

        // CONSTRUCTOR
        public Product(Home homeRef, int idProducto, string nombreProducto, string imgPath)
        {
            InitializeComponent();
            this.idProducto = idProducto;
            this.nombreProducto = nombreProducto;
            this.imgPath = imgPath;
            home = homeRef;
            CargarDetallesProducto();
            MostrarProducto();

            home.AplicarDegradado(button1, LinearGradientMode.ForwardDiagonal);
        }

        // METODO PARA CARGAR LOS DETALLES DEL PRODUCTO
        private void CargarDetallesProducto()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database/DSport-database.xlsx");

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

                    foreach (var row in rows.Skip(1))
                    {
                        string idStr = row.Cell(1).GetString().Trim();
                        if (!int.TryParse(idStr, out int id))
                        {
                            continue;
                        }

                        if (id == idProducto)
                        {
                            marca = row.Cell(3).GetString().Trim();
                            precio = row.Cell(4).GetValue<decimal>();
                            stock = row.Cell(5).GetValue<int>();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar detalles del producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // METODO PARA MOSTRAR EL PRODUCTO
        private void MostrarProducto()
        {
            label2.Text = nombreProducto;
            label3.Text = marca;
            textBox1.Text = precio.ToString();
            numericUpDown1.Value = stock;

            if (File.Exists(imgPath))
            {
                pictureBox1.BackgroundImage = Image.FromFile(imgPath);
            }
            else
            {
                pictureBox1.BackgroundImage = Properties.Resources.logo_sinFondo_DSports1;
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        // EVENTO QUE SE HACE CUANDO SE PINCHA EN EL BOTON DEL LÁPIZ
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            numericUpDown1.Enabled = true;
            button2.Visible = false;
            button4.Visible = true;
        }

        // EVENTO QUE SE HACE CUANDO SE PINCHA EN EL BOTON DE LA X (PARA CANCELAR EDICION"
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            numericUpDown1.Enabled = false;
            button4.Visible = false;
            button2.Visible = true;
        }

        // METODO QUE SE HACE CUANDO SE REALIZAN CAMBIOS Y SE PINCHA EN EL BOTON DE "GUARDAR CAMBIOS"
        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database/DSport-database.xlsx");

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
                    var rows = worksheet.RowsUsed();

                    foreach (var row in rows.Skip(1))
                    {
                        string idStr = row.Cell(1).GetString().Trim();
                        if (!int.TryParse(idStr, out int id))
                        {
                            continue;
                        }

                        if (id == idProducto)
                        {
                            row.Cell(4).Value = decimal.Parse(textBox1.Text);
                            row.Cell(5).Value = (int)numericUpDown1.Value;
                            break;
                        }
                    }

                    workbook.Save();
                }

                MessageBox.Show("Cambios guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // EVENTO QUE SE HACE CUANDO SE PINCHA EN EL BOTON DE "VOLVER"
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Storage almacen = new Storage(home);
            home.AbrirFormEnPanel(almacen);
            home.Text = "Almacén - DSport";
        }

        // EVENTO QUE SE HACE CUANDO SE PINCHA EN EL BOTON DE "VOLVER"
        private void button3_Click(object sender, EventArgs e)
        {
            Storage almacen = new Storage(home);
            home.AbrirFormEnPanel(almacen);
            home.Text = "Almacén - DSport";
        }
    }
}
