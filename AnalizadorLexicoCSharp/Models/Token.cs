namespace AnalizadorLexicoCSharp.Models;

public class Token
{
    public int Numero { get; set; }
    public string Lexema { get; set; } = string.Empty;
    public TipoToken Tipo { get; set; }
    public int Linea { get; set; }
    public int Columna { get; set; }
}
