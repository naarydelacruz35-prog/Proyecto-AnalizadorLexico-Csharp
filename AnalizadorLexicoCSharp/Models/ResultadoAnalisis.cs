namespace AnalizadorLexicoCSharp.Models;

public sealed class ResultadoAnalisis
{
    public List<Token> Tokens { get; } = new();
    public List<ErrorLexico> Errores { get; } = new();
    public List<Simbolo> Simbolos { get; } = new();
    public int TotalLineas { get; set; }
}
