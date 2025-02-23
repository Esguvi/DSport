using ClosedXML.Excel;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace DSport
{
    public partial class Storage : Form
    {
        // VARIABLES
        private Home home;

        // CONSTRUCTOR
        public Storage (Home homeRef)
        {
            InitializeComponent();
            home = homeRef;
            CargarProductos();
            home.AplicarDegradado(btnAceptar, LinearGradientMode.ForwardDiagonal);
        }

        private void Home_Load(object sender, EventArgs e)
        {
        }

        // METODO PARA CARGAR LOS PRODUCTOS EN EL FLOW LAYOUT PANEL
        public void CargarProductos()
        {
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.Controls.Clear();

            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database/DSport-database.xlsx");

                if (!File.Exists(filePath))
                {
                    MessageBox.Show($"El archivo de la base de datos no existe en la ruta: {filePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet("storage");

                    if (worksheet == null)
                    {
                        MessageBox.Show("No se encontró la hoja 'storage' en el archivo Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var rows = worksheet.RowsUsed();

                    foreach (var row in rows)
                    {
                        string idStr = row.Cell(1).GetString().Trim();
                        if (!int.TryParse(idStr, out int idProducto))
                        {
                            continue;
                        }

                        string nombreProducto = row.Cell(2).GetString().Trim();
                        if (string.IsNullOrEmpty(nombreProducto))
                        {
                            continue;
                        }

                        string imgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "productos", idProducto + ".jpg");
                        string defaultImgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "productos", "no_image.jpg");

                        Button btnProducto = new Button
                        {
                            Width = 140,
                            Height = 220,
                            Text = nombreProducto,
                            TextAlign = ContentAlignment.BottomCenter,
                            ImageAlign = ContentAlignment.TopCenter,
                            FlatStyle = FlatStyle.Flat,
                            BackColor = Color.Transparent,
                            Font = new Font("Arial", 10, FontStyle.Bold),
                            ForeColor = Color.Black,
                            Padding = new Padding(0, 150, 0, 10),
                            Cursor = Cursors.Hand
                        };

                        if (File.Exists(imgPath))
                        {
                            btnProducto.BackgroundImage = Image.FromFile(imgPath);
                        }
                        else if (File.Exists(defaultImgPath))
                        {
                            btnProducto.BackgroundImage = Image.FromFile(defaultImgPath);
                        }
                        else
                        {
                            btnProducto.BackgroundImage = Properties.Resources.logo_sinFondo_DSports1;
                        }

                        btnProducto.BackgroundImageLayout = ImageLayout.Zoom;

                        btnProducto.Click += (s, e) =>
                        {
                            Product productForm = new Product(home, idProducto, nombreProducto, imgPath);
                            home.AbrirFormEnPanel(productForm);
                            home.Text = "Producto: " + nombreProducto + " - DSport";
                        };
                        flowLayoutPanel1.Controls.Add(btnProducto);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                flowLayoutPanel1.ResumeLayout();
            }
        }
        
        // EVENTO QUE SE EJECUTA CUANDO SE PINCHA EN EL BOTON DE "AÑADIR PRODUCTO"
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            AddProduct addproductForm = new AddProduct(home);
            home.AbrirFormEnPanel(addproductForm);
            home.Text = "Añadir producto - DSport";
        }
    }
}
