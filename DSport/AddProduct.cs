using ClosedXML.Excel;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace DSport
{
    public partial class AddProduct : Form
    {
        // VARIABLES
        private Home home;

        // CONSTRUCTOR
        public AddProduct(Home homeRef)
        {
            InitializeComponent();
            home = homeRef;
            home.AplicarDegradado(button1, LinearGradientMode.ForwardDiagonal);
            home.AplicarDegradado(button2, LinearGradientMode.ForwardDiagonal);
        }

        private void Home_Load(object sender, EventArgs e)
        {
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        // EVENTO QUE SE HACE CUANDO SE PINCHA EN EL BOTON DE "SELECCIONAR IMAGEN"
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Seleccionar imagen del producto - DSport";
            openFileDialog1.Filter = "Archivos de imagen (*.jpg)|*.jpg";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog1.FileName;
                pictureBox1.BackgroundImage = Image.FromFile(selectedImagePath);

                int newProductId = ObtenerNuevoIDProducto();
                string newImageName = $"{newProductId}.jpg";

                string newImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "productos", newImageName);
                File.Copy(selectedImagePath, newImagePath, true);
            }
        }

        // METODO PARA OBTENER LA ULTIMA ID DE LA BASE DE DATOS (+1)
        private int ObtenerNuevoIDProducto()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database/DSport-database.xlsx");

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet("storage");
                var lastRow = worksheet.LastRowUsed();

                if (lastRow == null) return 1;

                int lastID = (int)(lastRow.Cell(1)?.Value ?? 0);
                return lastID + 1;
            }
        }

        // EVENTO QUE SE HACE CUANDO SE PINCHA EN "ACEPTAR"
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
                int newProductId = ObtenerNuevoIDProducto();

                string nombre = textBox2.Text;
                string marca = textBox3.Text;
                decimal precio = decimal.Parse(textBox1.Text);
                int stock = (int)numericUpDown1.Value;

                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet("storage");
                    var lastRow = worksheet.LastRowUsed();
                    var newRow = worksheet.Row(lastRow.RowNumber() + 1);

                    newRow.Cell(1).Value = newProductId; 
                    newRow.Cell(2).Value = nombre;   
                    newRow.Cell(3).Value = marca;       
                    newRow.Cell(4).Value = precio;      
                    newRow.Cell(5).Value = stock;      

                    workbook.Save();
                }

                MessageBox.Show("Producto añadido con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al añadir el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // METODO PARA LIMPIAR LOS CAMPOS UNA VEZ AÑADIDO EL PRODUCTO
        private void LimpiarFormulario()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Clear();
            numericUpDown1.Value = 0;
            pictureBox1.BackgroundImage = null;
        }

        // EVENTO QUE SE HACE CUANDO SE PINCHA EN EL BOTON DE "VOLVER"
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Storage almacen = new Storage(home);
            home.AbrirFormEnPanel(almacen);
            home.Text = "Almacén - DSport";
        }

    }
}
