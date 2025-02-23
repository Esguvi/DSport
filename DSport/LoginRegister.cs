using ClosedXML.Excel;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace DSport
{
    public partial class LoginRegister : Form
    {
        // DECLARACIÓN DE VARIABLES
        string nameUser, mailUser, passwordUser;

        public static string NameUserLogged { get; private set; }
        public static int UserID { get; private set; }

        public static string GetName()
        {
            return NameUserLogged;
        }

        private void SetUserID(int userID)
        {
            UserID = userID;
        }


        public LoginRegister()
        {
            InitializeComponent();

            panel4.Visible = false;

            // PROPIEDADES PARA EL BOTON DE CAMBIAR A REGISTRARSE
            btnChangeR.Size = new Size(250, 50);
            GraphicsPath roundedPath = new GraphicsPath();
            int borderRadius = 20;
            roundedPath.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            roundedPath.AddArc(btnChangeR.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
            roundedPath.AddArc(btnChangeR.Width - borderRadius, btnChangeR.Height - borderRadius, borderRadius, borderRadius, 0, 90);
            roundedPath.AddArc(0, btnChangeR.Height - borderRadius, borderRadius, borderRadius, 90, 90);
            roundedPath.CloseFigure();
            btnChangeR.Region = new Region(roundedPath);
            btnChangeR.FlatStyle = FlatStyle.Flat;
            btnChangeR.FlatAppearance.BorderSize = 0;
            btnChangeR.TextAlign = ContentAlignment.MiddleCenter;
            btnChangeR.BackColor = Color.FromArgb(223, 36, 45);
            btnChangeR.ForeColor = Color.White;


            // PROPIEDADES PARA CAMBIAR AL BOTON DE INICIAR SESION
            btnChangeL.Size = new Size(250, 50);
            roundedPath = new GraphicsPath();
            borderRadius = 20;
            roundedPath.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            roundedPath.AddArc(btnChangeL.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
            roundedPath.AddArc(btnChangeL.Width - borderRadius, btnChangeL.Height - borderRadius, borderRadius, borderRadius, 0, 90);
            roundedPath.AddArc(0, btnChangeR.Height - borderRadius, borderRadius, borderRadius, 90, 90);
            roundedPath.CloseFigure();
            btnChangeL.Region = new Region(roundedPath);
            btnChangeL.FlatStyle = FlatStyle.Flat;
            btnChangeL.FlatAppearance.BorderSize = 0;
            btnChangeL.TextAlign = ContentAlignment.MiddleCenter;
            btnChangeL.BackColor = Color.FromArgb(223, 36, 45);
            btnChangeL.ForeColor = Color.White;

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void tBName_Enter(object sender, EventArgs e)
        {
            if (tBName.Text == "Example")
            {
                tBName.ForeColor = Color.Black;
                tBName.Text = "";
            }
        }

        private void tBName_Leave(object sender, EventArgs e)
        {
            if (tBName.Text == "" || tBName.Text == " ")
            {
                tBName.ForeColor = Color.Silver;
                tBName.Text = "Example";
            }
        }

        private void tBPassword_Enter(object sender, EventArgs e)
        {
            if (tBPassword.Text == "Example")
            {
                tBPassword.ForeColor = Color.Black;
                tBPassword.Text = "";
            }
        }

        private void tBPassword_Leave(object sender, EventArgs e)
        {
            if (tBPassword.Text == "" || tBPassword.Text == " ")
            {
                tBPassword.ForeColor = Color.Silver;
                tBPassword.Text = "Example";
            }
        }

        private void tBNameR_Enter(object sender, EventArgs e)
        {
            if (tBNameR.Text == "Example")
            {
                tBNameR.ForeColor = Color.Black;
                tBNameR.Text = "";
            }
        }

        private void tBNameR_Leave(object sender, EventArgs e)
        {
            if (tBNameR.Text == "" || tBName.Text == " ")
            {
                tBNameR.ForeColor = Color.Silver;
                tBNameR.Text = "Example";
            }
        }

        private void tBEmailR_Enter(object sender, EventArgs e)
        {
            if (tBEmailR.Text == "example@email.com")
            {
                tBEmailR.ForeColor = Color.Black;
                tBEmailR.Text = "";
            }
        }

        private void tBEmailR_Leave(object sender, EventArgs e)
        {
            if (tBEmailR.Text == "" || tBName.Text == " ")
            {
                tBEmailR.ForeColor = Color.Silver;
                tBEmailR.Text = "example@email.com";
            }
        }

        private void tBPasswordR_Enter(object sender, EventArgs e)
        {
            if (tBPasswordR.Text == "Example")
            {
                tBPasswordR.ForeColor = Color.Black;
                tBPasswordR.Text = "";
            }
        }

        private void tBPasswordR_Leave(object sender, EventArgs e)
        {
            if (tBPasswordR.Text == "" || tBPassword.Text == " ")
            {
                tBPasswordR.ForeColor = Color.Silver;
                tBPasswordR.Text = "Example";
            }
        }

        private void menuItemLeave_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        // BOTON INICIAR SESIÓN
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (!tBName.Text.Equals("Example") && !tBPassword.Text.Equals("Example"))
            {
                nameUser = tBName.Text;
                passwordUser = tBPassword.Text;

                try
                {
                    string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database/DSport-database.xlsx");

                    using (var workbook = new XLWorkbook(filePath))
                    {
                        var worksheet = workbook.Worksheet("Users");
                        var rows = worksheet.RowsUsed();

                        bool usuarioEncontrado = false;
                        int idUser = 0;

                        foreach (var row in rows)
                        {
                            string nombre = row.Cell("B").GetValue<string>();
                            string password = row.Cell("D").GetValue<string>();

                            if (nombre == nameUser && password == passwordUser)
                            {
                                idUser = row.Cell("A").GetValue<int>();
                                usuarioEncontrado = true;
                                break;
                            }
                        }

                        if (usuarioEncontrado)
                        {
                            UserID = idUser;
                            NameUserLogged = nameUser;

                            this.Hide();
                            Home home = new Home();
                            home.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Alguno de los datos introducidos es incorrecto. Inténtalo de nuevo.", "¡Datos no válidos!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("No has introducido ningún dato.", "¡Datos no introducidos!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BOTÓN REGISTRARSE
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!tBNameR.Text.Equals("Example") && !tBEmailR.Text.Equals("example@email.com") && !tBPasswordR.Text.Equals("Example"))
            {
                nameUser = tBNameR.Text;
                mailUser = tBEmailR.Text;
                passwordUser = tBPasswordR.Text;

                try
                {
                    string rutaArchivo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database/DSport-database.xlsx");

                    using (var libro = new XLWorkbook(rutaArchivo))
                    {
                        var hoja = libro.Worksheet("Users");
                        var filas = hoja.RowsUsed();

                        int ultimoId = 0;

                        foreach (var fila in filas)
                        {
                            int idActual;
                            if (int.TryParse(fila.Cell("A").GetString(), out idActual))
                            {
                                if (idActual > ultimoId)
                                {
                                    ultimoId = idActual;
                                }
                            }
                        }

                        int siguienteId = ultimoId + 1;
                        bool correoExiste = false;

                        foreach (var fila in filas)
                        {
                            if (fila.Cell("C").GetValue<string>() == mailUser)
                            {
                                correoExiste = true;
                                break;
                            }
                        }

                        if (correoExiste)
                        {
                            MessageBox.Show("Este correo electrónico ya está en uso. Por favor, utiliza otro.", "¡Correo electrónico no válido!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            int filaNuevaNumero = filas.Count() + 1;
                            var nuevaFila = hoja.Row(filaNuevaNumero);

                            while (!nuevaFila.IsEmpty())
                            {
                                filaNuevaNumero++;
                                nuevaFila = hoja.Row(filaNuevaNumero);
                            }

                            nuevaFila.Cell("A").Value = siguienteId;
                            nuevaFila.Cell("B").Value = nameUser;
                            nuevaFila.Cell("C").Value = mailUser;
                            nuevaFila.Cell("D").Value = passwordUser;

                            libro.Save();

                            MessageBox.Show("Registro exitoso. Ahora puedes iniciar sesión con tu nuevo correo.", "¡Registro exitoso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("No has introducido ningún dato.", "¡Datos no introducidos!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ACCION DEL BOTON PARA CAMBIAR A REGISTRARSE
        private void btnChangeR_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel4.Visible = true;
            this.Text = "Registrarse - DSport";
        }

        // ACCION DEL BOTON PARA CAMBIAR A INICIAR SESIÓN
        private void btnChangeL_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel2.Visible = true;
            this.Text = "Iniciar sesión - DSport";
        }

        private void LoginRegister_Load(object sender, EventArgs e)
        {
        }

    }
}
