using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;

namespace DSport
{
    public partial class Home : Form
    {
        // VARIABLES
        private string filePath;

        // CONSTRUCTOR
        public Home()
        {
            InitializeComponent();

            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database/DSport-database.xlsx");

            panel2.Width = 53;
            label2.Text = LoginRegister.GetName();

            CargarGraficoVentas();
        }

        // CARGA DEL HOME
        private void Home_Load(object sender, EventArgs e)
        {
            AplicarDegradado(panel2, LinearGradientMode.Vertical);
            AplicarDegradado(menuStrip1, LinearGradientMode.Horizontal);
        }

        // METODO PARA CARGAR LOS DATOS DEL GRAFICO
        public void CargarGraficoVentas()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("El archivo de la base de datos no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheetSales = workbook.Worksheet("sales");
                    var rows = worksheetSales.RowsUsed().Skip(2);

                    var ventasPorMes = rows
                        .Select(row => DateTime.TryParse(row.Cell(4).GetString(), out DateTime fecha) ? fecha : (DateTime?)null)
                        .Where(fecha => fecha.HasValue)
                        .GroupBy(fecha => fecha.Value.ToString("MM-yyyy"))
                        .Select(g => new { Mes = g.Key, Cantidad = g.Count() })
                        .OrderBy(g => g.Mes)
                        .ToList();

                    chart1.Series.Clear();
                    chart1.Titles.Clear();
                    chart1.ChartAreas[0].AxisX.Title = "Mes";
                    chart1.ChartAreas[0].AxisY.Title = "Ventas";
                    chart1.ChartAreas[0].AxisX.Interval = 1;

                    Title tituloPrincipal = new Title
                    {
                        Text = "CONOCE NUESTRAS VENTAS POR MES",
                        Font = new Font("Arial", 14, FontStyle.Bold),
                        ForeColor = Color.DarkRed,
                        Alignment = ContentAlignment.TopCenter
                    };
                    chart1.Titles.Add(tituloPrincipal);

                    Series series = new Series
                    {
                        Name = "Ventas por mes",
                        ChartType = SeriesChartType.Column,
                        Color = Color.Red,
                        IsValueShownAsLabel = true
                    };

                    foreach (var venta in ventasPorMes)
                    {
                        series.Points.AddXY(venta.Mes, venta.Cantidad);
                    }

                    chart1.ChartAreas[0].AxisY.Maximum = ventasPorMes.Max(v => v.Cantidad) + 1; 
                    chart1.ChartAreas[0].AxisY.Minimum = 0; 

                    chart1.Series.Add(series);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el gráfico de ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // METODOS PARA APLICAR DEGRADADOS TANTO AL MENU LATERAL COMO AL SUPERIOR
        public void AplicarDegradado(Control control, LinearGradientMode modo)
        {
            if (control.Width == 0 || control.Height == 0) return;

            Bitmap bmp = new Bitmap(control.Width, control.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new Rectangle(0, 0, control.Width, control.Height),
                    Color.Red,
                    Color.FromArgb(50, 50, 50),
                    modo))
                {
                    g.FillRectangle(brush, 0, 0, control.Width, control.Height);
                }
            }

            control.BackgroundImage = bmp;
            control.BackgroundImageLayout = ImageLayout.Stretch;
        }


        // EVENTO PARA EL MENU LATERAL
        private void button1_Click(object sender, EventArgs e)
        {
            if (panel2.Size.Width == 53)
            {
                button2.Location = new Point(12, 71);
                button3.Location = new Point(12, 120);
                button4.Location = new Point(12, 170);
                label3.Location = new Point(12, 230);
                button5.Location = new Point(12, 260);
                panel2.Width = 239;
            }
            else
            {
                button2.Location = new Point(12, 47);
                button3.Location = new Point(12, 82);
                button4.Location = new Point(12, 117);
                label3.Location = new Point(12, 155);
                button5.Location = new Point(12, 170);
                panel2.Width = 53;
            }

            AplicarDegradado(panel2, LinearGradientMode.Vertical);
        }

        // EVENTOS DE INICIALIZACION DE OTRAS "CLASES"
        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            panel3.Controls.Add(chart1);

            chart1.Size = new Size(panel3.Width - 20, panel3.Height - 20);
            chart1.Location = new Point(10, 10);

            chart1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            CargarGraficoVentas();

            panel3.PerformLayout();
            chart1.Invalidate();

            this.Text = "Inicio - DSport";
            button2.BackColor = Color.White;
            button3.BackColor = Color.Transparent;
            button4.BackColor = Color.Transparent;
            button5.BackColor = Color.Transparent;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Text = "Almacén - DSport";
            AbrirFormEnPanel(new Storage(this));
            button3.BackColor = Color.White;
            button2.BackColor = Color.Transparent;
            button4.BackColor = Color.Transparent;
            button5.BackColor = Color.Transparent;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Text = "Venta - DSport";
            AbrirFormEnPanel(new Sale());
            button4.BackColor = Color.White;
            button2.BackColor = Color.Transparent;
            button3.BackColor = Color.Transparent;
            button5.BackColor = Color.Transparent;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Text = "Historial de ventas - DSport";
            AbrirFormEnPanel(new HistorySales());
            button5.BackColor = Color.White;
            button2.BackColor = Color.Transparent;
            button3.BackColor = Color.Transparent;
            button4.BackColor = Color.Transparent;
        }

        // METODO PARA ABRIR LAS DEMAS CLASES EN EL MISMO PANEL DEL FORM PRINCIPAL
        public void AbrirFormEnPanel(object formhija)
        {
            if (this.panel3.Controls.Count > 0)
                this.panel3.Controls.Clear();
            Form Form2 = formhija as Form;
            Form2.TopLevel = false;
            Form2.Dock = DockStyle.Fill;
            Form2.FormBorderStyle = FormBorderStyle.None;
            this.panel3.Controls.Add(Form2);
            this.panel3.Tag = Form2;
            Form2.Show();
        }

        private void toolStripMenuItem1_DropDownOpened(object sender, EventArgs e)
        {
            toolStripMenuItem1.ForeColor = Color.Black;
        }
        private void toolStripMenuItem1_DropDownClosed(object sender, EventArgs e)
        {
            toolStripMenuItem1.ForeColor = Color.White;
        }
        private void ayudaToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            ayudaToolStripMenuItem.ForeColor = Color.White;
        }
        private void ayudaToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            ayudaToolStripMenuItem.ForeColor = Color.Black;
        }

        // EVENTO PARA CERRAR SESIÓN
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginRegister loginRegister = new LoginRegister();
            loginRegister.ShowDialog();
            this.Close();
        }

        // EVENTO PARA SALIR DEL PROGRAMA
        private void menuItemSalir_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }


    }
}
