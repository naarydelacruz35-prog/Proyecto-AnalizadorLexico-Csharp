using AnalizadorLexicoCSharp.Models;

namespace AnalizadorLexicoCSharp.Automatas;

public sealed class Reconocimiento
{
    public Reconocimiento(int longitud, TipoToken? tipo = null, string? descripcionError = null)
    {
        Longitud = longitud;
        Tipo = tipo;
        DescripcionError = descripcionError;
    }

    public int Longitud { get; }
    public TipoToken? Tipo { get; }
    public string? DescripcionError { get; }
}
