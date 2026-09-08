namespace AnalizadorLexicoCSharp.Models;

public class ErrorLexico
{
    public string Lexema { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public int Linea { get; set; }
    public int Columna { get; set; }
}
