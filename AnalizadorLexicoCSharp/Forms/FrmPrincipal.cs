using AnalizadorLexicoCSharp.Services;
using AnalizadorLexicoCSharp.Lexer;
using AnalizadorLexicoCSharp.Models;

namespace AnalizadorLexicoCSharp.Forms;

public partial class FrmPrincipal : Form
{
    private readonly ArchivoService archivoService = new();
    private string nombreArchivoActual = string.Empty;

    public FrmPrincipal()
    {
        InitializeComponent();
        ActualizarEstado();
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
            MessageBox.Show(this, "Ingrese o abra código fuente antes de analizar.", "Editor vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            rtbCodigoFuente.Focus();
            return;
        }

        LimpiarResultados();
        Resultado resultado = new AnalizadorLexico().Analizar(rtbCodigoFuente.Text);
        for (int i = 0; i < resultado.Tokens.Count; i++)
        {
            resultado.Tokens[i].Numero = i + 1;
        }

        dgvTokens.DataSource = resultado.Tokens;
        dgvSimbolos.DataSource = resultado.Simbolos;
        dgvErrores.DataSource = resultado.Errors;
        tabResultados.SelectedTab = tabTokens;
        ActualizarEstado(rtbCodigoFuente.Lines.Length);
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

}
