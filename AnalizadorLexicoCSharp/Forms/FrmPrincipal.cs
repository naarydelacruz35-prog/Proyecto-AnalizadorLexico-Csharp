using AnalizadorLexicoCSharp.Services;
using AnalizadorLexicoCSharp.Lexer;
using AnalizadorLexicoCSharp.Models;
using System.Diagnostics;

namespace AnalizadorLexicoCSharp.Forms;

public partial class FrmPrincipal : Form
{
    private readonly ArchivoService archivoService = new();
    private string nombreArchivoActual = string.Empty;
    private long tiempoAnalisisMs;
    private TabPage tabEstadisticas = null!;
    private DataGridView dgvEstadisticas = null!;
    private Button btnExportar = null!;
    private SaveFileDialog sfdExportar = null!;

    public FrmPrincipal()
    {
        InitializeComponent();

        CrearPestanaEstadisticas();
        CrearBotonExportar();

        ActualizarEstado();
    }
    private void CrearPestanaEstadisticas()
    {
        tabEstadisticas = new TabPage("Estadísticas");

        dgvEstadisticas = new DataGridView
        {
            Dock = DockStyle.Fill,
            ReadOnly = true,
            AllowUserToAddRows = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            RowHeadersVisible = false,
            BackgroundColor = Color.White
        };

        dgvEstadisticas.Columns.Add("Categoria", "Categoría de token");
        dgvEstadisticas.Columns.Add("Cantidad", "Cantidad");

        tabEstadisticas.Controls.Add(dgvEstadisticas);

        tabResultados.TabPages.Add(tabEstadisticas);
    }
    private void CrearBotonExportar()
    {
        btnExportar = new Button
        {
            Name = "btnExportar",
            Text = "Exportar CSV",
            Width = 130,
            Height = 38,
            Margin = new Padding(8),
            BackColor = Color.SeaGreen,
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand
        };

        btnExportar.Click += btnExportar_Click;

        panelAcciones.Controls.Add(btnExportar);

        sfdExportar = new SaveFileDialog
        {
            Title = "Guardar resultados del análisis",
            Filter = "Archivo CSV (*.csv)|*.csv",
            DefaultExt = "csv",
            AddExtension = true,
            FileName = "Resultados_Analizador"
        };
    }
        private void btnExportar_Click(object? sender, EventArgs e)
    {
        bool hayResultados =
            dgvTokens.Rows.Count > 0 ||
            dgvSimbolos.Rows.Count > 0 ||
            dgvErrores.Rows.Count > 0;

        if (!hayResultados)
        {
            MessageBox.Show(
                this,
                "Primero debes analizar un código fuente.",
                "No hay resultados",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (sfdExportar.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        try
        {
            using var escritor = new System.IO.StreamWriter(
                sfdExportar.FileName,
                false,
                new System.Text.UTF8Encoding(true));

            escritor.WriteLine("RESULTADOS DEL ANALIZADOR LÉXICO");
            escritor.WriteLine();

            EscribirGrillaCSV(escritor, "TOKENS", dgvTokens);
            EscribirGrillaCSV(escritor, "TABLA DE SÍMBOLOS", dgvSimbolos);
            EscribirGrillaCSV(escritor, "ERRORES LÉXICOS", dgvErrores);

            MessageBox.Show(
                this,
                "Los resultados se exportaron correctamente.",
                "Exportación completada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                this,
                $"No fue posible exportar los resultados.\n{ex.Message}",
                "Error de exportación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void EscribirGrillaCSV(
        System.IO.StreamWriter escritor,
        string titulo,
        DataGridView grilla)
    {
        escritor.WriteLine(titulo);

        // Escribir los encabezados de las columnas.
        for (int columna = 0; columna < grilla.Columns.Count; columna++)
        {
            if (columna > 0)
            {
                escritor.Write(",");
            }

            escritor.Write(
                EscaparCSV(grilla.Columns[columna].HeaderText));
        }

        escritor.WriteLine();

        // Escribir los datos de cada fila.
        foreach (DataGridViewRow fila in grilla.Rows)
        {
            if (fila.IsNewRow)
            {
                continue;
            }

            for (int columna = 0; columna < grilla.Columns.Count; columna++)
            {
                if (columna > 0)
                {
                    escritor.Write(",");
                }

                string valor = fila.Cells[columna].Value?.ToString() ?? "";

                escritor.Write(EscaparCSV(valor));
            }

            escritor.WriteLine();
        }

        escritor.WriteLine();
    }

    private string EscaparCSV(string valor)
    {
        valor = valor.Replace("\"", "\"\"");

        return $"\"{valor}\"";
    }
    
    private void btnAbrirArchivo_Click(object? sender, EventArgs e)
    {
        if (ofdCodigoFuente.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        try
        {
            rtbCodigoFuente.Text = archivoService.LeerTexto(ofdCodigoFuente.FileName);
            nombreArchivoActual = Path.GetFileName(ofdCodigoFuente.FileName);
            LimpiarResultados();
            ActualizarEstado();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, $"No fue posible abrir el archivo.\n{ex.Message}", "Error al abrir archivo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnAnalizar_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(rtbCodigoFuente.Text))
        {
            MessageBox.Show(
                this,
                "Ingrese o abra código fuente antes de analizar.",
                "Editor vacío",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            rtbCodigoFuente.Focus();
            return;
        }

        LimpiarResultados();

        try
        {
            Stopwatch cronometro = Stopwatch.StartNew();

            Resultado resultado = new AnalizadorLexico()
                .Analizar(rtbCodigoFuente.Text);

            cronometro.Stop();

            tiempoAnalisisMs = cronometro.ElapsedMilliseconds;

            for (int i = 0; i < resultado.Tokens.Count; i++)
            {
                resultado.Tokens[i].Numero = i + 1;
            }

            dgvTokens.DataSource = resultado.Tokens;
            dgvSimbolos.DataSource = resultado.Simbolos.ObtenerTodos();
            dgvErrores.DataSource = resultado.Errors;
            

            tabResultados.SelectedTab = tabTokens;

            ActualizarEstado(rtbCodigoFuente.Lines.Length);
        }

        catch (Exception ex)
        {
            MessageBox.Show(
                this,
                $"Ocurrió un error durante el análisis.\n{ex.Message}",
                "Error de análisis",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            LimpiarResultados();
            ActualizarEstado();
        }
    }

    private void btnLimpiar_Click(object? sender, EventArgs e)
    {
        rtbCodigoFuente.Clear();
        nombreArchivoActual = string.Empty;
        LimpiarResultados();
        ActualizarEstado();
        rtbCodigoFuente.Focus();
    }

    private void rtbCodigoFuente_TextChanged(object? sender, EventArgs e)
    {
        if (dgvTokens.DataSource is not null) LimpiarResultados();
        ActualizarEstado();
    }

    private void LimpiarResultados()
    {
        dgvTokens.DataSource = null;
        dgvSimbolos.DataSource = null;
        dgvErrores.DataSource = null;
    }

    private void ActualizarEstado(int? lineasAnalizadas = null)
    {
        int lineas = lineasAnalizadas ?? (string.IsNullOrEmpty(rtbCodigoFuente.Text) ? 0 : rtbCodigoFuente.Lines.Length);
        lblTokensValor.Text = dgvTokens.Rows.Count.ToString();
        lblErroresValor.Text = dgvErrores.Rows.Count.ToString();
        lblLineasValor.Text = lineas.ToString();
        lblArchivoValor.Text = string.IsNullOrEmpty(nombreArchivoActual) ? "Archivo: sin archivo" : $"Archivo: {nombreArchivoActual}";
    }
    private void MostrarEstadisticas(Resultado resultado)
    {
        dgvEstadisticas.Rows.Clear();

        var estadisticas = resultado.Tokens
            .GroupBy(token => token.Tipo)
            .OrderBy(grupo => grupo.Key.ToString());

        foreach (var grupo in estadisticas)
        {
            dgvEstadisticas.Rows.Add(
                grupo.Key.ToString(),
                grupo.Count()
            );
        }

        dgvEstadisticas.Rows.Add(
            "TOTAL DE TOKENS",
            resultado.Tokens.Count
        );

        dgvEstadisticas.Rows.Add(
            "TOTAL DE ERRORES",
            resultado.Errors.Count
        );

        dgvEstadisticas.Rows.Add(
            "TIEMPO DE ANÁLISIS (ms)",
            tiempoAnalisisMs
        );
    }
    private void CrearPestañaEstadisticas()
    {
        tabEstadisticas = new TabPage("Estadísticas");

        dgvEstadisticas = new DataGridView
        {
            Dock = DockStyle.Fill,
            ReadOnly = true,
            AllowUserToAddRows = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            RowHeadersVisible = false,
            BackgroundColor = Color.White
        };

        dgvEstadisticas.Columns.Add("Categoria", "Categoría de token");
        dgvEstadisticas.Columns.Add("Cantidad", "Cantidad");

        tabEstadisticas.Controls.Add(dgvEstadisticas);

        tabResultados.TabPages.Add(tabEstadisticas);
    }

}
