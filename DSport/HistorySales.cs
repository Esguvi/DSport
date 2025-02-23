using ClosedXML.Excel;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DSport
{
    public partial class HistorySales : Form
    {
        // VARIABLES
        private string filePath;

        // CONSTRUCTOR
        public HistorySales()
        {
            InitializeComponent();
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database/DSport-database.xlsx");
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;

            dateTimePicker1.MaxDate = DateTime.Now; 
            dateTimePicker1.Value = DateTime.Now;

            CargarHistorialVentas();

            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // METODO PARA CARGAR EL HISTORIAL DE VENTAS
        private void CargarHistorialVentas()
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
                    var worksheetSales = workbook.Worksheet("sales");
                    var worksheetUsers = workbook.Worksheet("users");
                    var worksheetStorage = workbook.Worksheet("storage");

                    var rows = worksheetSales.RowsUsed().Skip(2); 
                    DataTable dt = new DataTable();

                    dt.Columns.Add("ID Venta");
                    dt.Columns.Add("Empleado");
                    dt.Columns.Add("Producto");
                    dt.Columns.Add("Fecha");
                    dt.Columns.Add("Cantidad");
                    dt.Columns.Add("Total");

                    foreach (var row in rows)
                    {
                        DateTime fechaVenta;
                        var fechaCelda = row.Cell(4);

                        string fechaStr = fechaCelda.GetString();
                        if (!DateTime.TryParse(fechaStr, out fechaVenta))
                        {
                            MessageBox.Show($"Error al convertir la fecha en la fila {row.RowNumber()}.\n" + $"Valor encontrado: {fechaStr}\n" + "Verifique si el valor está en un formato de fecha correcto.", "Error de conversión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            continue; 
                        }

                        string idUsuario = row.Cell(2).GetString();
                        string nombreUsuario = BuscarNombreUsuario(worksheetUsers, idUsuario);

                        string idProducto = row.Cell(3).GetString();
                        string nombreProducto = BuscarNombreProducto(worksheetStorage, idProducto);

                        dt.Rows.Add(
                            row.Cell(1).GetValue<int>(),
                            nombreUsuario,
                            nombreProducto,
                            fechaVenta.ToString("dd/MM/yyyy HH:mm"),
                            row.Cell(5).GetValue<int>(),
                            row.Cell(6).GetValue<decimal>().ToString("C")
                        );
                    }

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el historial de ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // METODO PARA QUE PODAMOS RECOGER EL NOMBRE DE EMPLEADO EN VEZ DE LA ID Y ASÍ SE MUESTRE EL NOMBRE
        private string BuscarNombreUsuario(IXLWorksheet worksheet, string idUsuario)
        {
            var rows = worksheet.RowsUsed().Skip(1); 
            foreach (var row in rows)
            {
                if (row.Cell(1).GetString() == idUsuario)
                {
                    return row.Cell(2).GetString(); 
                }
            }
            return "Usuario no encontrado";
        }

        // METODO PARA QUE PODAMOS RECOGER EL NOMBRE DEL PRODUCTO EN VEZ DE LA ID Y ASÍ SE MUESTRE EL PRODUCTO
        private string BuscarNombreProducto(IXLWorksheet worksheet, string idProducto)
        {
            var rows = worksheet.RowsUsed().Skip(1); 
            foreach (var row in rows)
            {
                if (row.Cell(1).GetString() == idProducto) 
                {
                    return row.Cell(2).GetString(); 
                }
            }
            return "Producto no encontrado";
        }

        // METODO PARA RECOGER EL VALOR DE LA FECHA SELECCIONADA EN EL DATE TIME PICKER
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            FiltrarPorFecha(dateTimePicker1.Value.Date);
        }

        // METODO PARA FILTRAR EL HISTORIAL DE VENTAS SEGUN LA FECHA SELECCIONADA
        private void FiltrarPorFecha(DateTime fechaSeleccionada)
        {
            try
            {
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheetSales = workbook.Worksheet("sales");
                    var worksheetUsers = workbook.Worksheet("users");
                    var worksheetStorage = workbook.Worksheet("storage");

                    var rows = worksheetSales.RowsUsed().Skip(2);
                    DataTable dt = new DataTable();

                    dt.Columns.Add("ID Venta");
                    dt.Columns.Add("Usuario");
                    dt.Columns.Add("Producto");
                    dt.Columns.Add("Fecha");
                    dt.Columns.Add("Cantidad");
                    dt.Columns.Add("Total");

                    foreach (var row in rows)
                    {
                        DateTime fechaVenta;
                        var fechaCelda = row.Cell(4);

                        if (!fechaCelda.TryGetValue<DateTime>(out fechaVenta))
                        {
                            string fechaStr = fechaCelda.GetString();
                            if (DateTime.TryParse(fechaStr, out fechaVenta) == false)
                            {
                                continue;
                            }
                        }

                        string idUsuario = row.Cell(2).GetString();
                        string nombreUsuario = BuscarNombreUsuario(worksheetUsers, idUsuario);

                        string idProducto = row.Cell(3).GetString();
                        string nombreProducto = BuscarNombreProducto(worksheetStorage, idProducto);

                        if (fechaVenta.Date == fechaSeleccionada)
                        {
                            dt.Rows.Add(
                                row.Cell(1).GetValue<int>(),
                                nombreUsuario,
                                nombreProducto,
                                fechaVenta.ToString("dd/MM/yyyy HH:mm"),
                                row.Cell(5).GetValue<int>(),
                                row.Cell(6).GetValue<decimal>().ToString("C")
                            );
                        }
                    }

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar el historial de ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

    }
}
