namespace AnalizadorLexicoCSharp.Models;

public class Simbolo
{
    public string Nombre { get; set; } = string.Empty;
    public TipoToken TipoToken { get; set; }
    public int PrimeraLinea { get; set; }
    public string TipoDeclarado { get; set; } = string.Empty;
}
