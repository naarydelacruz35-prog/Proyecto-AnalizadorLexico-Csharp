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
        lblTitulo = new Label();
        lblSubtitulo = new Label();
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
        lblTokensValor = new Label();
        lblErrores = new Label();
        lblErroresValor = new Label();
        lblLineas = new Label();
        lblLineasValor = new Label();
        lblArchivoValor = new Label();
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
        layoutPrincipal.ColumnCount = 1;
        layoutPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        layoutPrincipal.Controls.Add(panelEncabezado, 0, 0);
        layoutPrincipal.Controls.Add(panelAcciones, 0, 1);
        layoutPrincipal.Controls.Add(panelEditor, 0, 2);
        layoutPrincipal.Controls.Add(tabResultados, 0, 3);
        layoutPrincipal.Controls.Add(panelEstado, 0, 4);
        layoutPrincipal.Dock = DockStyle.Fill;
        layoutPrincipal.Location = new Point(0, 0);
        layoutPrincipal.Name = "layoutPrincipal";
        layoutPrincipal.Padding = new Padding(14);
        layoutPrincipal.RowCount = 5;
        layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
        layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
        layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 48F));
        layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 52F));
        layoutPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
        layoutPrincipal.Size = new Size(874, 715);
        layoutPrincipal.TabIndex = 0;
        // 
        // panelEncabezado
        // 
        panelEncabezado.BackColor = Color.FromArgb(43, 62, 80);
        panelEncabezado.Controls.Add(lblSubtitulo);
        panelEncabezado.Controls.Add(lblTitulo);
        panelEncabezado.Dock = DockStyle.Fill;
        panelEncabezado.Location = new Point(17, 17);
        panelEncabezado.Name = "panelEncabezado";
        panelEncabezado.Size = new Size(840, 52);
        panelEncabezado.TabIndex = 0;
        // 
        // lblTitulo
        // 
        lblTitulo.Dock = DockStyle.Top;
        lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.White;
        lblTitulo.Location = new Point(0, 0);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Padding = new Padding(16, 0, 0, 0);
        lblTitulo.Size = new Size(840, 31);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "ANALIZADOR LÉXICO C#";
        lblTitulo.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblSubtitulo
        // 
        lblSubtitulo.Dock = DockStyle.Fill;
        lblSubtitulo.Font = new Font("Segoe UI", 9F);
        lblSubtitulo.ForeColor = Color.FromArgb(220, 228, 236);
        lblSubtitulo.Name = "lblSubtitulo";
        lblSubtitulo.Padding = new Padding(18, 0, 0, 4);
        lblSubtitulo.TabIndex = 1;
        lblSubtitulo.Text = "Analizador para un subconjunto del lenguaje C#";
        lblSubtitulo.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // panelAcciones
        // 
        panelAcciones.Controls.Add(btnAbrirArchivo);
        panelAcciones.Controls.Add(btnAnalizar);
        panelAcciones.Controls.Add(btnLimpiar);
        panelAcciones.Dock = DockStyle.Fill;
        panelAcciones.Location = new Point(17, 75);
        panelAcciones.Name = "panelAcciones";
        panelAcciones.Padding = new Padding(0, 8, 0, 4);
        panelAcciones.Size = new Size(840, 40);
        panelAcciones.TabIndex = 1;
        // 
        // btnAbrirArchivo
        // 
        btnAbrirArchivo.Location = new Point(3, 11);
        btnAbrirArchivo.Name = "btnAbrirArchivo";
        btnAbrirArchivo.Size = new Size(75, 23);
        btnAbrirArchivo.TabIndex = 0;
        btnAbrirArchivo.Click += btnAbrirArchivo_Click;
        // 
        // btnAnalizar
        // 
        btnAnalizar.Location = new Point(84, 11);
        btnAnalizar.Name = "btnAnalizar";
        btnAnalizar.Size = new Size(75, 23);
        btnAnalizar.TabIndex = 1;
        btnAnalizar.Click += btnAnalizar_Click;
        // 
        // btnLimpiar
        // 
        btnLimpiar.Location = new Point(165, 11);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(75, 23);
        btnLimpiar.TabIndex = 2;
        btnLimpiar.Click += btnLimpiar_Click;
        // 
        // panelEditor
        // 
        panelEditor.Controls.Add(rtbCodigoFuente);
        panelEditor.Controls.Add(lblCodigoFuente);
        panelEditor.Dock = DockStyle.Fill;
        panelEditor.Location = new Point(17, 121);
        panelEditor.Name = "panelEditor";
        panelEditor.Padding = new Padding(0, 0, 0, 8);
        panelEditor.Size = new Size(840, 258);
        panelEditor.TabIndex = 2;
        // 
        // rtbCodigoFuente
        // 
        rtbCodigoFuente.AcceptsTab = true;
        rtbCodigoFuente.BorderStyle = BorderStyle.FixedSingle;
        rtbCodigoFuente.Dock = DockStyle.Fill;
        rtbCodigoFuente.Font = new Font("Consolas", 10F);
        rtbCodigoFuente.Location = new Point(0, 27);
        rtbCodigoFuente.Name = "rtbCodigoFuente";
        rtbCodigoFuente.Size = new Size(840, 223);
        rtbCodigoFuente.TabIndex = 0;
        rtbCodigoFuente.Text = "";
        rtbCodigoFuente.TextChanged += rtbCodigoFuente_TextChanged;
        rtbCodigoFuente.WordWrap = false;
        // 
        // lblCodigoFuente
        // 
        lblCodigoFuente.Dock = DockStyle.Top;
        lblCodigoFuente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblCodigoFuente.Location = new Point(0, 0);
        lblCodigoFuente.Name = "lblCodigoFuente";
        lblCodigoFuente.Size = new Size(840, 27);
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
        tabResultados.Location = new Point(17, 385);
        tabResultados.Name = "tabResultados";
        tabResultados.SelectedIndex = 0;
        tabResultados.Size = new Size(840, 280);
        tabResultados.TabIndex = 3;
        // 
        // tabTokens
        // 
        tabTokens.Controls.Add(dgvTokens);
        tabTokens.Location = new Point(4, 24);
        tabTokens.Name = "tabTokens";
        tabTokens.Padding = new Padding(3);
        tabTokens.Size = new Size(832, 252);
        tabTokens.TabIndex = 0;
        tabTokens.Text = "TOKENS";
        // 
        // dgvTokens
        // 
        dgvTokens.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
        dgvTokens.Location = new Point(0, 0);
        dgvTokens.Name = "dgvTokens";
        dgvTokens.Size = new Size(544, 249);
        dgvTokens.TabIndex = 0;
        // 
        // dataGridViewTextBoxColumn1
        // 
        dataGridViewTextBoxColumn1.HeaderText = "#";
        dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        dataGridViewTextBoxColumn1.DataPropertyName = "Numero";
        // 
        // dataGridViewTextBoxColumn2
        // 
        dataGridViewTextBoxColumn2.HeaderText = "Lexema";
        dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        dataGridViewTextBoxColumn2.DataPropertyName = "Lexema";
        // 
        // dataGridViewTextBoxColumn3
        // 
        dataGridViewTextBoxColumn3.HeaderText = "Tipo";
        dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
        dataGridViewTextBoxColumn3.DataPropertyName = "Tipo";
        // 
        // dataGridViewTextBoxColumn4
        // 
        dataGridViewTextBoxColumn4.HeaderText = "Línea";
        dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
        dataGridViewTextBoxColumn4.DataPropertyName = "Linea";
        // 
        // dataGridViewTextBoxColumn5
        // 
        dataGridViewTextBoxColumn5.HeaderText = "Columna";
        dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
        dataGridViewTextBoxColumn5.DataPropertyName = "Columna";
        // 
        // tabSimbolos
        // 
        tabSimbolos.Controls.Add(dgvSimbolos);
        tabSimbolos.Location = new Point(4, 24);
        tabSimbolos.Name = "tabSimbolos";
        tabSimbolos.Padding = new Padding(3);
        tabSimbolos.Size = new Size(832, 252);
        tabSimbolos.TabIndex = 1;
        tabSimbolos.Text = "TABLA DE SÍMBOLOS";
        // 
        // dgvSimbolos
        // 
        dgvSimbolos.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9 });
        dgvSimbolos.Location = new Point(0, 0);
        dgvSimbolos.Name = "dgvSimbolos";
        dgvSimbolos.Size = new Size(240, 150);
        dgvSimbolos.TabIndex = 0;
        // 
        // dataGridViewTextBoxColumn6
        // 
        dataGridViewTextBoxColumn6.HeaderText = "Nombre";
        dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
        dataGridViewTextBoxColumn6.DataPropertyName = "Nombre";
        // 
        // dataGridViewTextBoxColumn7
        // 
        dataGridViewTextBoxColumn7.HeaderText = "Tipo de token";
        dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
        dataGridViewTextBoxColumn7.DataPropertyName = "TipoToken";
        // 
        // dataGridViewTextBoxColumn8
        // 
        dataGridViewTextBoxColumn8.HeaderText = "Primera línea";
        dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
        dataGridViewTextBoxColumn8.DataPropertyName = "PrimeraLinea";
        // 
        // dataGridViewTextBoxColumn9
        // 
        dataGridViewTextBoxColumn9.HeaderText = "Tipo declarado";
        dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
        dataGridViewTextBoxColumn9.DataPropertyName = "TipoDeclarado";
        // 
        // tabErrores
        // 
        tabErrores.Controls.Add(dgvErrores);
        tabErrores.Location = new Point(4, 24);
        tabErrores.Name = "tabErrores";
        tabErrores.Padding = new Padding(3);
        tabErrores.Size = new Size(832, 252);
        tabErrores.TabIndex = 2;
        tabErrores.Text = "ERRORES";
        // 
        // dgvErrores
        // 
        dgvErrores.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn10, dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12, dataGridViewTextBoxColumn13 });
        dgvErrores.Location = new Point(0, 0);
        dgvErrores.Name = "dgvErrores";
        dgvErrores.Size = new Size(240, 150);
        dgvErrores.TabIndex = 0;
        // 
        // dataGridViewTextBoxColumn10
        // 
        dataGridViewTextBoxColumn10.HeaderText = "Lexema";
        dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
        dataGridViewTextBoxColumn10.DataPropertyName = "Lexema";
        // 
        // dataGridViewTextBoxColumn11
        // 
        dataGridViewTextBoxColumn11.HeaderText = "Descripción";
        dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
        dataGridViewTextBoxColumn11.DataPropertyName = "Descripcion";
        // 
        // dataGridViewTextBoxColumn12
        // 
        dataGridViewTextBoxColumn12.HeaderText = "Línea";
        dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
        dataGridViewTextBoxColumn12.DataPropertyName = "Linea";
        // 
        // dataGridViewTextBoxColumn13
        // 
        dataGridViewTextBoxColumn13.HeaderText = "Columna";
        dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
        dataGridViewTextBoxColumn13.DataPropertyName = "Columna";
        // 
        // panelEstado
        // 
        panelEstado.BackColor = Color.FromArgb(236, 240, 241);
        panelEstado.Controls.Add(lblTokens);
        panelEstado.Controls.Add(lblTokensValor);
        panelEstado.Controls.Add(lblErrores);
        panelEstado.Controls.Add(lblErroresValor);
        panelEstado.Controls.Add(lblLineas);
        panelEstado.Controls.Add(lblLineasValor);
        panelEstado.Controls.Add(lblArchivoValor);
        panelEstado.Dock = DockStyle.Fill;
        panelEstado.Location = new Point(17, 671);
        panelEstado.Name = "panelEstado";
        panelEstado.Size = new Size(840, 27);
        panelEstado.TabIndex = 4;
        // 
        // lblTokens
        // 
        lblTokens.Location = new Point(0, 0);
        lblTokens.Name = "lblTokens";
        lblTokens.Size = new Size(100, 23);
        lblTokens.TabIndex = 0;
        lblTokens.Text = "Tokens:";
        // 
        // lblTokensValor
        // 
        lblTokensValor.Location = new Point(0, 0);
        lblTokensValor.Name = "lblTokensValor";
        lblTokensValor.Size = new Size(100, 23);
        lblTokensValor.TabIndex = 1;
        // 
        // lblErrores
        // 
        lblErrores.Location = new Point(0, 0);
        lblErrores.Name = "lblErrores";
        lblErrores.Size = new Size(100, 23);
        lblErrores.TabIndex = 2;
        lblErrores.Text = "Errores:";
        // 
        // lblErroresValor
        // 
        lblErroresValor.Location = new Point(0, 0);
        lblErroresValor.Name = "lblErroresValor";
        lblErroresValor.Size = new Size(100, 23);
        lblErroresValor.TabIndex = 3;
        // 
        // lblLineas
        // 
        lblLineas.Location = new Point(0, 0);
        lblLineas.Name = "lblLineas";
        lblLineas.Size = new Size(100, 23);
        lblLineas.TabIndex = 4;
        lblLineas.Text = "Líneas:";
        // 
        // lblLineasValor
        // 
        lblLineasValor.Location = new Point(0, 0);
        lblLineasValor.Name = "lblLineasValor";
        lblLineasValor.Size = new Size(100, 23);
        lblLineasValor.TabIndex = 5;
        // 
        // lblArchivoValor
        // 
        lblArchivoValor.AutoSize = true;
        lblArchivoValor.Location = new Point(8, 7);
        lblArchivoValor.Name = "lblArchivoValor";
        lblArchivoValor.TabIndex = 6;
        lblArchivoValor.Text = "Archivo: sin archivo";
        // 
        // ofdCodigoFuente
        // 
        ofdCodigoFuente.Filter = "Archivos C# (*.cs)|*.cs|Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
        ofdCodigoFuente.Title = "Abrir código fuente";
        // 
        // FrmPrincipal
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(248, 249, 250);
        ClientSize = new Size(1200, 780);
        Controls.Add(layoutPrincipal);
        MinimumSize = new Size(1000, 650);
        Name = "FrmPrincipal";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Analizador Léxico C#";
        ConfigurarBoton(btnAbrirArchivo, "Abrir archivo", Color.FromArgb(52, 91, 130));
        ConfigurarBoton(btnAnalizar, "Analizar código", Color.FromArgb(35, 105, 75));
        ConfigurarBoton(btnLimpiar, "Limpiar", Color.FromArgb(100, 108, 115));
        ConfigurarGrilla(dgvTokens);
        ConfigurarGrilla(dgvSimbolos);
        ConfigurarGrilla(dgvErrores);
        dgvTokens.MultiSelect = false;
        dgvSimbolos.MultiSelect = false;
        dgvErrores.MultiSelect = false;
        ConfigurarEtiquetaEstado(lblTokens, "Tokens:", 250);
        ConfigurarEtiquetaEstado(lblTokensValor, "0", 305);
        ConfigurarEtiquetaEstado(lblErrores, "Errores:", 360);
        ConfigurarEtiquetaEstado(lblErroresValor, "0", 420);
        ConfigurarEtiquetaEstado(lblLineas, "Líneas:", 475);
        ConfigurarEtiquetaEstado(lblLineasValor, "0", 530);
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
