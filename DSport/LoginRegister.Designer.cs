namespace DSport
{
    partial class LoginRegister
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginRegister));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tBPassword = new System.Windows.Forms.TextBox();
            this.tBName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnChangeR = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tBEmailR = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tBPasswordR = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnChangeL = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tBNameR = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dSportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLeave = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreDSportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.btnLogIn);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tBPassword);
            this.panel2.Controls.Add(this.tBName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(139, 56);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel2.Size = new System.Drawing.Size(600, 354);
            this.panel2.TabIndex = 0;
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(36)))), ((int)(((byte)(44)))));
            this.btnLogIn.BackgroundImage = global::DSport.Properties.Resources.app_menu_background;
            this.btnLogIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogIn.FlatAppearance.BorderSize = 0;
            this.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.ForeColor = System.Drawing.Color.White;
            this.btnLogIn.Location = new System.Drawing.Point(59, 231);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(188, 41);
            this.btnLogIn.TabIndex = 6;
            this.btnLogIn.Text = "Iniciar sesión";
            this.toolTip1.SetToolTip(this.btnLogIn, "Iniciar sesión");
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Contraseña:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBPassword
            // 
            this.tBPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tBPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tBPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBPassword.ForeColor = System.Drawing.Color.Silver;
            this.tBPassword.Location = new System.Drawing.Point(59, 175);
            this.tBPassword.Name = "tBPassword";
            this.tBPassword.Size = new System.Drawing.Size(188, 26);
            this.tBPassword.TabIndex = 3;
            this.tBPassword.Text = "Example";
            this.toolTip1.SetToolTip(this.tBPassword, "Contraseña");
            this.tBPassword.UseSystemPasswordChar = true;
            this.tBPassword.Enter += new System.EventHandler(this.tBPassword_Enter);
            this.tBPassword.Leave += new System.EventHandler(this.tBPassword_Leave);
            // 
            // tBName
            // 
            this.tBName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tBName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBName.ForeColor = System.Drawing.Color.Silver;
            this.tBName.Location = new System.Drawing.Point(59, 112);
            this.tBName.Name = "tBName";
            this.tBName.Size = new System.Drawing.Size(188, 26);
            this.tBName.TabIndex = 2;
            this.tBName.Text = "Example";
            this.toolTip1.SetToolTip(this.tBName, "Nombre");
            this.tBName.Enter += new System.EventHandler(this.tBName_Enter);
            this.tBName.Leave += new System.EventHandler(this.tBName_Leave);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Iniciar sesión";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(36)))), ((int)(((byte)(45)))));
            this.panel3.BackgroundImage = global::DSport.Properties.Resources.app_menu_background;
            this.panel3.Controls.Add(this.btnChangeR);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(300, -2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(298, 354);
            this.panel3.TabIndex = 0;
            // 
            // btnChangeR
            // 
            this.btnChangeR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(36)))), ((int)(((byte)(44)))));
            this.btnChangeR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeR.FlatAppearance.BorderSize = 0;
            this.btnChangeR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeR.ForeColor = System.Drawing.Color.White;
            this.btnChangeR.Location = new System.Drawing.Point(25, 233);
            this.btnChangeR.Name = "btnChangeR";
            this.btnChangeR.Size = new System.Drawing.Size(188, 41);
            this.btnChangeR.TabIndex = 9;
            this.btnChangeR.Text = "¿No estás registrado todavía como empleado? Regístrate aquí";
            this.toolTip1.SetToolTip(this.btnChangeR, "Registrarse");
            this.btnChangeR.UseVisualStyleBackColor = false;
            this.btnChangeR.Click += new System.EventHandler(this.btnChangeR_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::DSport.Properties.Resources.logo_sinFondo_DSports;
            this.pictureBox1.Location = new System.Drawing.Point(97, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(25, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(259, 45);
            this.label5.TabIndex = 1;
            this.label5.Text = "¡Bienvenido/a! Estamos muy contentos de que estés de vuelta. Esperamos que te pod" +
    "amos ayudar a solucionar cualquier problema.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(21, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(263, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "¡Bienvenido/a de nuevo!";
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.tBEmailR);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.tBPasswordR);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.tBNameR);
            this.panel4.Controls.Add(this.btnRegister);
            this.panel4.Location = new System.Drawing.Point(139, 56);
            this.panel4.Name = "panel4";
            this.panel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel4.Size = new System.Drawing.Size(600, 354);
            this.panel4.TabIndex = 8;
            // 
            // tBEmailR
            // 
            this.tBEmailR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tBEmailR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tBEmailR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBEmailR.ForeColor = System.Drawing.Color.Silver;
            this.tBEmailR.Location = new System.Drawing.Point(351, 155);
            this.tBEmailR.Name = "tBEmailR";
            this.tBEmailR.Size = new System.Drawing.Size(188, 26);
            this.tBEmailR.TabIndex = 3;
            this.tBEmailR.Text = "example@email.com";
            this.toolTip1.SetToolTip(this.tBEmailR, "Email");
            this.tBEmailR.Enter += new System.EventHandler(this.tBEmailR_Enter);
            this.tBEmailR.Leave += new System.EventHandler(this.tBEmailR_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(348, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Contraseña:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBPasswordR
            // 
            this.tBPasswordR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tBPasswordR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tBPasswordR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBPasswordR.ForeColor = System.Drawing.Color.Silver;
            this.tBPasswordR.Location = new System.Drawing.Point(351, 214);
            this.tBPasswordR.Name = "tBPasswordR";
            this.tBPasswordR.Size = new System.Drawing.Size(188, 26);
            this.tBPasswordR.TabIndex = 4;
            this.tBPasswordR.Text = "Example";
            this.toolTip1.SetToolTip(this.tBPasswordR, "Contraseña");
            this.tBPasswordR.UseSystemPasswordChar = true;
            this.tBPasswordR.Enter += new System.EventHandler(this.tBPasswordR_Enter);
            this.tBPasswordR.Leave += new System.EventHandler(this.tBPasswordR_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(348, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Email:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(36)))), ((int)(((byte)(45)))));
            this.panel5.BackgroundImage = global::DSport.Properties.Resources.app_menu_background;
            this.panel5.Controls.Add(this.btnChangeL);
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(298, 354);
            this.panel5.TabIndex = 0;
            // 
            // btnChangeL
            // 
            this.btnChangeL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(36)))), ((int)(((byte)(44)))));
            this.btnChangeL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeL.FlatAppearance.BorderSize = 0;
            this.btnChangeL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeL.ForeColor = System.Drawing.Color.White;
            this.btnChangeL.Location = new System.Drawing.Point(25, 231);
            this.btnChangeL.Name = "btnChangeL";
            this.btnChangeL.Size = new System.Drawing.Size(158, 41);
            this.btnChangeL.TabIndex = 6;
            this.btnChangeL.Text = "¿Tienes ya cuenta de empleado? Inicia sesión aquí";
            this.toolTip1.SetToolTip(this.btnChangeL, "Iniciar sesión");
            this.btnChangeL.UseVisualStyleBackColor = false;
            this.btnChangeL.Click += new System.EventHandler(this.btnChangeL_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::DSport.Properties.Resources.logo_sinFondo_DSports;
            this.pictureBox2.Location = new System.Drawing.Point(97, 23);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(120, 88);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(25, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(259, 45);
            this.label9.TabIndex = 1;
            this.label9.Text = "¡Bienvenido/a! Estamos muy contentos de que estés de vuelta. Esperamos que te pod" +
    "amos ayudar a solucionar cualquier problema.";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(21, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(263, 24);
            this.label10.TabIndex = 0;
            this.label10.Text = "¡Bienvenido/a de nuevo!";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(351, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(188, 29);
            this.label8.TabIndex = 1;
            this.label8.Text = "Registrarse";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(348, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Nombre:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tBNameR
            // 
            this.tBNameR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tBNameR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tBNameR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBNameR.ForeColor = System.Drawing.Color.Silver;
            this.tBNameR.Location = new System.Drawing.Point(351, 99);
            this.tBNameR.Name = "tBNameR";
            this.tBNameR.Size = new System.Drawing.Size(188, 26);
            this.tBNameR.TabIndex = 2;
            this.tBNameR.Text = "Example";
            this.toolTip1.SetToolTip(this.tBNameR, "Nombre");
            this.tBNameR.Enter += new System.EventHandler(this.tBNameR_Enter);
            this.tBNameR.Leave += new System.EventHandler(this.tBNameR_Leave);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(36)))), ((int)(((byte)(44)))));
            this.btnRegister.BackgroundImage = global::DSport.Properties.Resources.app_menu_background;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(351, 278);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(188, 41);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "Registrarse";
            this.toolTip1.SetToolTip(this.btnRegister, "Registrarse");
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dSportToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(838, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dSportToolStripMenuItem
            // 
            this.dSportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemLeave});
            this.dSportToolStripMenuItem.Image = global::DSport.Properties.Resources.logo_sinFondo_DSports;
            this.dSportToolStripMenuItem.Name = "dSportToolStripMenuItem";
            this.dSportToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.dSportToolStripMenuItem.Text = "DSport";
            this.dSportToolStripMenuItem.ToolTipText = "DSport";
            this.dSportToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // menuItemLeave
            // 
            this.menuItemLeave.Image = global::DSport.Properties.Resources.icon_apagar;
            this.menuItemLeave.Name = "menuItemLeave";
            this.menuItemLeave.Size = new System.Drawing.Size(180, 22);
            this.menuItemLeave.Text = "Salir";
            this.menuItemLeave.Click += new System.EventHandler(this.menuItemLeave_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreDSportToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.helpToolStripMenuItem.Text = "Ayuda";
            this.helpToolStripMenuItem.ToolTipText = "Ayuda";
            // 
            // sobreDSportToolStripMenuItem
            // 
            this.sobreDSportToolStripMenuItem.Image = global::DSport.Properties.Resources.icon_pregunta;
            this.sobreDSportToolStripMenuItem.Name = "sobreDSportToolStripMenuItem";
            this.sobreDSportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sobreDSportToolStripMenuItem.Text = "Sobre DSport";
            // 
            // LoginRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::DSport.Properties.Resources.login_background1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(838, 441);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LoginRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar sesión - DSport";
            this.Load += new System.EventHandler(this.LoginRegister_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dSportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItemLeave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tBName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreDSportToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnChangeR;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tBEmailR;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnChangeL;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tBNameR;
        private System.Windows.Forms.TextBox tBPasswordR;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

