#nullable enable

namespace AnalizadorLexicoCSharp.Forms;

partial class FrmPrincipal
{
    private System.ComponentModel.IContainer? components = null;
    private Label lblTitulo = null!;
    private Label lblSubtitulo = null!;
    private Label lblCodigoFuente = null!;
    private RichTextBox rtbCodigoFuente = null!;
    private Button btnAbrirArchivo = null!;
    private Button btnAnalizar = null!;
    private Button btnLimpiar = null!;
    private TabControl tabResultados = null!;
    private TabPage tabTokens = null!;
    private TabPage tabSimbolos = null!;
    private TabPage tabErrores = null!;
    private DataGridView dgvTokens = null!;
    private DataGridView dgvSimbolos = null!;
    private DataGridView dgvErrores = null!;
    private OpenFileDialog ofdCodigoFuente = null!;
    private Label lblTokens = null!;
    private Label lblTokensValor = null!;
    private Label lblErrores = null!;
    private Label lblErroresValor = null!;
    private Label lblLineas = null!;
    private Label lblLineasValor = null!;
    private Label lblArchivoValor = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        layoutPrincipal = new TableLayoutPanel();
        panelEncabezado = new Panel();
        lblSubtitulo = new Label();
        lblTitulo = new Label();
        panelAcciones = new FlowLayoutPanel();
        btnAbrirArchivo = new Button();
        btnAnalizar = new Button();
        btnLimpiar = new Button();
        panelEditor = new Panel();
        rtbCodigoFuente = new RichTextBox();
        lblCodigoFuente = new Label();
        tabResultados = new TabControl();
        tabTokens = new TabPage();
        dgvTokens = new DataGridView();
        dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
        tabSimbolos = new TabPage();
        dgvSimbolos = new DataGridView();
        dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
        tabErrores = new TabPage();
        dgvErrores = new DataGridView();
        dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
        panelEstado = new Panel();
        lblTokens = new Label();
        lblArchivoValor = new Label();
        lblTokensValor = new Label();
        lblErrores = new Label();
        lblErroresValor = new Label();
        lblLineas = new Label();
        lblLineasValor = new Label();
        ofdCodigoFuente = new OpenFileDialog();
        layoutPrincipal.SuspendLayout();
        panelEncabezado.SuspendLayout();
        panelAcciones.SuspendLayout();
        panelEditor.SuspendLayout();
        tabResultados.SuspendLayout();
        tabTokens.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvTokens).BeginInit();
        tabSimbolos.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvSimbolos).BeginInit();
        tabErrores.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvErrores).BeginInit();
        panelEstado.SuspendLayout();
        SuspendLayout();
        // 
        // layoutPrincipal
        // 
        layoutPrincipal.BackColor = Color.White;
        layoutPrincipal.ColumnCount = 1;
        layoutPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPrincipal.Controls.Add(panelEncabezado, 0, 0);
        layoutPrincipal.Controls.Add(panelAcciones, 0, 1);
        layoutPrincipal.Controls.Add(panelEditor, 0, 2);
        layoutPrincipal.Controls.Add(tabResultados, 0, 3);
        layoutPrincipal.Controls.Add(panelEstado, 0, 4);
        layoutPrincipal.Dock = DockStyle.Fill;
        layoutPrincipal.Location = new Point(0, 0);
        layoutPrincipal.Margin = new Padding(4, 5, 4, 5);
        layoutPrincipal.Name = "layoutPrincipal";
        layoutPrincipal.Padding = new Padding(20, 23, 20, 23);
        layoutPrincipal.RowCount = 5;
        layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 97F));
        layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 77F));
        layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 48F));
        layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 52F));
        layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
        layoutPrincipal.Size = new Size(1714, 1050);
        layoutPrincipal.TabIndex = 0;
        // 
        // panelEncabezado
        // 
        panelEncabezado.BackColor = Color.FromArgb(43, 62, 80);
        panelEncabezado.Controls.Add(lblSubtitulo);
        panelEncabezado.Controls.Add(lblTitulo);
        panelEncabezado.Dock = DockStyle.Fill;
        panelEncabezado.Location = new Point(24, 28);
        panelEncabezado.Margin = new Padding(4, 5, 4, 5);
        panelEncabezado.Name = "panelEncabezado";
        panelEncabezado.Size = new Size(1666, 87);
        panelEncabezado.TabIndex = 0;
        // 
        // lblSubtitulo
        // 
        lblSubtitulo.BackColor = Color.FromArgb(255, 192, 192);
        lblSubtitulo.Dock = DockStyle.Fill;
        lblSubtitulo.Font = new Font("Perpetua", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblSubtitulo.ForeColor = Color.Black;
        lblSubtitulo.Location = new Point(0, 52);
        lblSubtitulo.Margin = new Padding(4, 0, 4, 0);
        lblSubtitulo.Name = "lblSubtitulo";
        lblSubtitulo.Padding = new Padding(26, 0, 0, 7);
        lblSubtitulo.Size = new Size(1666, 35);
        lblSubtitulo.TabIndex = 1;
        lblSubtitulo.Text = "Analizador para un subconjunto del lenguaje C#";
        lblSubtitulo.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblTitulo
        // 
        lblTitulo.BackColor = Color.FromArgb(255, 192, 192);
        lblTitulo.Dock = DockStyle.Top;
        lblTitulo.Font = new Font("Showcard Gothic", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblTitulo.ForeColor = Color.Black;
        lblTitulo.Location = new Point(0, 0);
        lblTitulo.Margin = new Padding(4, 0, 4, 0);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Padding = new Padding(23, 0, 0, 0);
        lblTitulo.Size = new Size(1666, 52);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "ANALIZADOR LÉXICO C#";
        lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // panelAcciones
        // 
        panelAcciones.Controls.Add(btnAbrirArchivo);
        panelAcciones.Controls.Add(btnAnalizar);
        panelAcciones.Controls.Add(btnLimpiar);
        panelAcciones.Dock = DockStyle.Fill;
        panelAcciones.Location = new Point(24, 125);
        panelAcciones.Margin = new Padding(4, 5, 4, 5);
        panelAcciones.Name = "panelAcciones";
        panelAcciones.Padding = new Padding(0, 13, 0, 7);
        panelAcciones.Size = new Size(1666, 67);
        panelAcciones.TabIndex = 1;
        // 
        // btnAbrirArchivo
        // 
        btnAbrirArchivo.BackColor = Color.FromArgb(192, 255, 255);
        btnAbrirArchivo.Location = new Point(4, 18);
        btnAbrirArchivo.Margin = new Padding(4, 5, 4, 5);
        btnAbrirArchivo.Name = "btnAbrirArchivo";
        btnAbrirArchivo.Size = new Size(139, 38);
        btnAbrirArchivo.TabIndex = 0;
        btnAbrirArchivo.Text = "Abrir Archivo";
        btnAbrirArchivo.UseVisualStyleBackColor = false;
        btnAbrirArchivo.Click += btnAbrirArchivo_Click;
        // 
        // btnAnalizar
        // 
        btnAnalizar.BackColor = Color.FromArgb(192, 255, 255);
        btnAnalizar.Location = new Point(151, 18);
        btnAnalizar.Margin = new Padding(4, 5, 4, 5);
        btnAnalizar.Name = "btnAnalizar";
        btnAnalizar.Size = new Size(107, 38);
        btnAnalizar.TabIndex = 1;
        btnAnalizar.Text = "Analizar";
        btnAnalizar.UseVisualStyleBackColor = false;
        btnAnalizar.Click += btnAnalizar_Click;
        // 
        // btnLimpiar
        // 
        btnLimpiar.BackColor = Color.FromArgb(192, 255, 255);
        btnLimpiar.Location = new Point(266, 18);
        btnLimpiar.Margin = new Padding(4, 5, 4, 5);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(107, 38);
        btnLimpiar.TabIndex = 2;
        btnLimpiar.Text = "Limpiar";
        btnLimpiar.UseVisualStyleBackColor = false;
        btnLimpiar.Click += btnLimpiar_Click;
        // 
        // panelEditor
        // 
        panelEditor.Controls.Add(rtbCodigoFuente);
        panelEditor.Controls.Add(lblCodigoFuente);
        panelEditor.Dock = DockStyle.Fill;
        panelEditor.Location = new Point(24, 202);
        panelEditor.Margin = new Padding(4, 5, 4, 5);
        panelEditor.Name = "panelEditor";
        panelEditor.Padding = new Padding(0, 0, 0, 13);
        panelEditor.Size = new Size(1666, 359);
        panelEditor.TabIndex = 2;
        // 
        // rtbCodigoFuente
        // 
        rtbCodigoFuente.AcceptsTab = true;
        rtbCodigoFuente.BorderStyle = BorderStyle.FixedSingle;
        rtbCodigoFuente.Dock = DockStyle.Fill;
        rtbCodigoFuente.Font = new Font("Consolas", 10F);
        rtbCodigoFuente.Location = new Point(0, 45);
        rtbCodigoFuente.Margin = new Padding(4, 5, 4, 5);
        rtbCodigoFuente.Name = "rtbCodigoFuente";
        rtbCodigoFuente.Size = new Size(1666, 301);
        rtbCodigoFuente.TabIndex = 0;
        rtbCodigoFuente.Text = "";
        rtbCodigoFuente.WordWrap = false;
        rtbCodigoFuente.TextChanged += rtbCodigoFuente_TextChanged;
        // 
        // lblCodigoFuente
        // 
        lblCodigoFuente.Dock = DockStyle.Top;
        lblCodigoFuente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblCodigoFuente.Location = new Point(0, 0);
        lblCodigoFuente.Margin = new Padding(4, 0, 4, 0);
        lblCodigoFuente.Name = "lblCodigoFuente";
        lblCodigoFuente.Size = new Size(1666, 45);
        lblCodigoFuente.TabIndex = 1;
        lblCodigoFuente.Text = "Código fuente";
        lblCodigoFuente.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // tabResultados
        // 
        tabResultados.Controls.Add(tabTokens);
        tabResultados.Controls.Add(tabSimbolos);
        tabResultados.Controls.Add(tabErrores);
        tabResultados.Dock = DockStyle.Fill;
        tabResultados.Font = new Font("Segoe UI", 9F);
        tabResultados.Location = new Point(24, 571);
        tabResultados.Margin = new Padding(4, 5, 4, 5);
        tabResultados.Name = "tabResultados";
        tabResultados.SelectedIndex = 0;
        tabResultados.Size = new Size(1666, 390);
        tabResultados.TabIndex = 3;
        // 
        // tabTokens
        // 
        tabTokens.Controls.Add(dgvTokens);
        tabTokens.Location = new Point(4, 34);
        tabTokens.Margin = new Padding(4, 5, 4, 5);
        tabTokens.Name = "tabTokens";
        tabTokens.Padding = new Padding(4, 5, 4, 5);
        tabTokens.Size = new Size(1658, 352);
        tabTokens.TabIndex = 0;
        tabTokens.Text = "TOKENS";
        // 
        // dgvTokens
        // 
        dgvTokens.ColumnHeadersHeight = 34;
        dgvTokens.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
        dgvTokens.Location = new Point(22, 0);
        dgvTokens.Margin = new Padding(4, 5, 4, 5);
        dgvTokens.MultiSelect = false;
        dgvTokens.Name = "dgvTokens";
        dgvTokens.RowHeadersWidth = 62;
        dgvTokens.Size = new Size(777, 414);
        dgvTokens.TabIndex = 0;
        // 
        // dataGridViewTextBoxColumn1
        // 
        dataGridViewTextBoxColumn1.DataPropertyName = "Numero";
        dataGridViewTextBoxColumn1.HeaderText = "#";
        dataGridViewTextBoxColumn1.MinimumWidth = 8;
        dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        dataGridViewTextBoxColumn1.Width = 150;
        // 
        // dataGridViewTextBoxColumn2
        // 
        dataGridViewTextBoxColumn2.DataPropertyName = "Lexema";
        dataGridViewTextBoxColumn2.HeaderText = "Lexema";
        dataGridViewTextBoxColumn2.MinimumWidth = 8;
        dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        dataGridViewTextBoxColumn2.Width = 150;
        // 
        // dataGridViewTextBoxColumn3
        // 
        dataGridViewTextBoxColumn3.DataPropertyName = "Tipo";
        dataGridViewTextBoxColumn3.HeaderText = "Tipo";
        dataGridViewTextBoxColumn3.MinimumWidth = 8;
        dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
        dataGridViewTextBoxColumn3.Width = 150;
        // 
        // dataGridViewTextBoxColumn4
        // 
        dataGridViewTextBoxColumn4.DataPropertyName = "Linea";
        dataGridViewTextBoxColumn4.HeaderText = "Línea";
        dataGridViewTextBoxColumn4.MinimumWidth = 8;
        dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
        dataGridViewTextBoxColumn4.Width = 150;
        // 
        // dataGridViewTextBoxColumn5
        // 
        dataGridViewTextBoxColumn5.DataPropertyName = "Columna";
        dataGridViewTextBoxColumn5.HeaderText = "Columna";
        dataGridViewTextBoxColumn5.MinimumWidth = 8;
        dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
        dataGridViewTextBoxColumn5.Width = 150;
        // 
        // tabSimbolos
        // 
        tabSimbolos.Controls.Add(dgvSimbolos);
        tabSimbolos.Location = new Point(4, 34);
        tabSimbolos.Margin = new Padding(4, 5, 4, 5);
        tabSimbolos.Name = "tabSimbolos";
        tabSimbolos.Padding = new Padding(4, 5, 4, 5);
        tabSimbolos.Size = new Size(1658, 352);
        tabSimbolos.TabIndex = 1;
        tabSimbolos.Text = "TABLA DE SÍMBOLOS";
        // 
        // dgvSimbolos
        // 
        dgvSimbolos.ColumnHeadersHeight = 34;
        dgvSimbolos.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9 });
        dgvSimbolos.Location = new Point(0, 0);
        dgvSimbolos.Margin = new Padding(4, 5, 4, 5);
        dgvSimbolos.MultiSelect = false;
        dgvSimbolos.Name = "dgvSimbolos";
        dgvSimbolos.RowHeadersWidth = 62;
        dgvSimbolos.Size = new Size(343, 250);
        dgvSimbolos.TabIndex = 0;
        // 
        // dataGridViewTextBoxColumn6
        // 
        dataGridViewTextBoxColumn6.DataPropertyName = "Nombre";
        dataGridViewTextBoxColumn6.HeaderText = "Nombre";
        dataGridViewTextBoxColumn6.MinimumWidth = 8;
        dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
        dataGridViewTextBoxColumn6.Width = 150;
        // 
        // dataGridViewTextBoxColumn7
        // 
        dataGridViewTextBoxColumn7.DataPropertyName = "TipoToken";
        dataGridViewTextBoxColumn7.HeaderText = "Tipo de token";
        dataGridViewTextBoxColumn7.MinimumWidth = 8;
        dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
        dataGridViewTextBoxColumn7.Width = 150;
        // 
        // dataGridViewTextBoxColumn8
        // 
        dataGridViewTextBoxColumn8.DataPropertyName = "PrimeraLinea";
        dataGridViewTextBoxColumn8.HeaderText = "Primera línea";
        dataGridViewTextBoxColumn8.MinimumWidth = 8;
        dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
        dataGridViewTextBoxColumn8.Width = 150;
        // 
        // dataGridViewTextBoxColumn9
        // 
        dataGridViewTextBoxColumn9.DataPropertyName = "TipoDeclarado";
        dataGridViewTextBoxColumn9.HeaderText = "Tipo declarado";
        dataGridViewTextBoxColumn9.MinimumWidth = 8;
        dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
        dataGridViewTextBoxColumn9.Width = 150;
        // 
        // tabErrores
        // 
        tabErrores.Controls.Add(dgvErrores);
        tabErrores.Location = new Point(4, 34);
        tabErrores.Margin = new Padding(4, 5, 4, 5);
        tabErrores.Name = "tabErrores";
        tabErrores.Padding = new Padding(4, 5, 4, 5);
        tabErrores.Size = new Size(1658, 352);
        tabErrores.TabIndex = 2;
        tabErrores.Text = "ERRORES";
        // 
        // dgvErrores
        // 
        dgvErrores.ColumnHeadersHeight = 34;
        dgvErrores.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn10, dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12, dataGridViewTextBoxColumn13 });
        dgvErrores.Location = new Point(0, 0);
        dgvErrores.Margin = new Padding(4, 5, 4, 5);
        dgvErrores.MultiSelect = false;
        dgvErrores.Name = "dgvErrores";
        dgvErrores.RowHeadersWidth = 62;
        dgvErrores.Size = new Size(343, 250);
        dgvErrores.TabIndex = 0;
        // 
        // dataGridViewTextBoxColumn10
        // 
        dataGridViewTextBoxColumn10.DataPropertyName = "Lexema";
        dataGridViewTextBoxColumn10.HeaderText = "Lexema";
        dataGridViewTextBoxColumn10.MinimumWidth = 8;
        dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
        dataGridViewTextBoxColumn10.Width = 150;
        // 
        // dataGridViewTextBoxColumn11
        // 
        dataGridViewTextBoxColumn11.DataPropertyName = "Descripcion";
        dataGridViewTextBoxColumn11.HeaderText = "Descripción";
        dataGridViewTextBoxColumn11.MinimumWidth = 8;
        dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
        dataGridViewTextBoxColumn11.Width = 150;
        // 
        // dataGridViewTextBoxColumn12
        // 
        dataGridViewTextBoxColumn12.DataPropertyName = "Linea";
        dataGridViewTextBoxColumn12.HeaderText = "Línea";
        dataGridViewTextBoxColumn12.MinimumWidth = 8;
        dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
        dataGridViewTextBoxColumn12.Width = 150;
        // 
        // dataGridViewTextBoxColumn13
        // 
        dataGridViewTextBoxColumn13.DataPropertyName = "Columna";
        dataGridViewTextBoxColumn13.HeaderText = "Columna";
        dataGridViewTextBoxColumn13.MinimumWidth = 8;
        dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
        dataGridViewTextBoxColumn13.Width = 150;
        // 
        // panelEstado
        // 
        panelEstado.BackColor = Color.FromArgb(236, 240, 241);
        panelEstado.Controls.Add(lblTokens);
        panelEstado.Controls.Add(lblArchivoValor);
        panelEstado.Controls.Add(lblTokensValor);
        panelEstado.Controls.Add(lblErrores);
        panelEstado.Controls.Add(lblErroresValor);
        panelEstado.Controls.Add(lblLineas);
        panelEstado.Controls.Add(lblLineasValor);
        panelEstado.Dock = DockStyle.Fill;
        panelEstado.Location = new Point(24, 971);
        panelEstado.Margin = new Padding(4, 5, 4, 5);
        panelEstado.Name = "panelEstado";
        panelEstado.Size = new Size(1666, 51);
        panelEstado.TabIndex = 4;
        // 
        // lblTokens
        // 
        lblTokens.Location = new Point(4, 6);
        lblTokens.Margin = new Padding(4, 0, 4, 0);
        lblTokens.Name = "lblTokens";
        lblTokens.Size = new Size(143, 38);
        lblTokens.TabIndex = 0;
        lblTokens.Text = "Tokens:";
        // 
        // lblArchivoValor
        // 
        lblArchivoValor.AutoSize = true;
        lblArchivoValor.Location = new Point(181, 13);
        lblArchivoValor.Margin = new Padding(4, 0, 4, 0);
        lblArchivoValor.Name = "lblArchivoValor";
        lblArchivoValor.Size = new Size(165, 25);
        lblArchivoValor.TabIndex = 6;
        lblArchivoValor.Text = "Archivo: sin archivo";
        // 
        // lblTokensValor
        // 
        lblTokensValor.Location = new Point(0, 0);
        lblTokensValor.Margin = new Padding(4, 0, 4, 0);
        lblTokensValor.Name = "lblTokensValor";
        lblTokensValor.Size = new Size(124, 38);
        lblTokensValor.TabIndex = 1;
        // 
        // lblErrores
        // 
        lblErrores.Location = new Point(0, 0);
        lblErrores.Margin = new Padding(4, 0, 4, 0);
        lblErrores.Name = "lblErrores";
        lblErrores.Size = new Size(143, 38);
        lblErrores.TabIndex = 2;
        lblErrores.Text = "Errores:";
        // 
        // lblErroresValor
        // 
        lblErroresValor.Location = new Point(0, 0);
        lblErroresValor.Margin = new Padding(4, 0, 4, 0);
        lblErroresValor.Name = "lblErroresValor";
        lblErroresValor.Size = new Size(143, 38);
        lblErroresValor.TabIndex = 3;
        // 
        // lblLineas
        // 
        lblLineas.Location = new Point(0, 0);
        lblLineas.Margin = new Padding(4, 0, 4, 0);
        lblLineas.Name = "lblLineas";
        lblLineas.Size = new Size(143, 38);
        lblLineas.TabIndex = 4;
        lblLineas.Text = "Líneas:";
        // 
        // lblLineasValor
        // 
        lblLineasValor.Location = new Point(0, 0);
        lblLineasValor.Margin = new Padding(4, 0, 4, 0);
        lblLineasValor.Name = "lblLineasValor";
        lblLineasValor.Size = new Size(143, 38);
        lblLineasValor.TabIndex = 5;
        // 
        // ofdCodigoFuente
        // 
        ofdCodigoFuente.Filter = "Archivos C# (*.cs)|*.cs|Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
        ofdCodigoFuente.Title = "Abrir código fuente";
        // 
        // FrmPrincipal
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(248, 249, 250);
        ClientSize = new Size(1714, 1050);
        Controls.Add(layoutPrincipal);
        Margin = new Padding(4, 5, 4, 5);
        MinimumSize = new Size(1419, 1006);
        Name = "FrmPrincipal";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Analizador Léxico C#";
        layoutPrincipal.ResumeLayout(false);
        panelEncabezado.ResumeLayout(false);
        panelAcciones.ResumeLayout(false);
        panelEditor.ResumeLayout(false);
        tabResultados.ResumeLayout(false);
        tabTokens.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvTokens).EndInit();
        tabSimbolos.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvSimbolos).EndInit();
        tabErrores.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvErrores).EndInit();
        panelEstado.ResumeLayout(false);
        panelEstado.PerformLayout();
        ResumeLayout(false);
    }

    private static void ConfigurarBoton(Button boton, string texto, Color color)
    {
        boton.BackColor = color;
        boton.FlatAppearance.BorderSize = 0;
        boton.FlatStyle = FlatStyle.Flat;
        boton.ForeColor = Color.White;
        boton.Margin = new Padding(0, 0, 8, 0);
        boton.Size = new Size(118, 30);
        boton.Text = texto;
        boton.UseVisualStyleBackColor = false;
    }

    private static void ConfigurarGrilla(DataGridView grilla)
    {
        grilla.AllowUserToAddRows = false;
        grilla.AllowUserToDeleteRows = false;
        grilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        grilla.BackgroundColor = Color.White;
        grilla.BorderStyle = BorderStyle.Fixed3D;
        grilla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(230, 235, 239);
        grilla.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        grilla.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 235, 239);
        grilla.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
        grilla.Dock = DockStyle.Fill;
        grilla.EnableHeadersVisualStyles = false;
        grilla.ReadOnly = true;
        grilla.RowHeadersVisible = false;
        grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
    }

    private static void ConfigurarEtiquetaEstado(Label etiqueta, string texto, int izquierda)
    {
        etiqueta.AutoSize = true;
        etiqueta.Location = new Point(izquierda, 8);
        etiqueta.Text = texto;
    }

    private TableLayoutPanel layoutPrincipal = null!;
    private Panel panelEncabezado = null!;
    private FlowLayoutPanel panelAcciones = null!;
    private Panel panelEditor = null!;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1 = null!;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2 = null!;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3 = null!;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4 = null!;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5 = null!;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6 = null!;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7 = null!;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8 = null!;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9 = null!;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10 = null!;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11 = null!;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12 = null!;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13 = null!;
    private Panel panelEstado = null!;
}
