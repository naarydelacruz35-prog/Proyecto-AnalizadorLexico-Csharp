namespace AnalizadorLexicoCSharp.Lexer;

public static class PalabrasReservadas
{
    private static readonly HashSet<string> palabras = new(StringComparer.Ordinal)
    {
        "if", "else", "while", "for", "int", "float", "double", "char", "bool", "string",
        "void", "return", "class", "static", "true", "false", "break", "continue", "switch", "case"
    };

    private static readonly HashSet<string> tipos = new(StringComparer.Ordinal)
    {
        "int", "float", "double", "char", "bool", "string"
    };

    public static bool EsPalabraReservada(string lexema) => palabras.Contains(lexema);
    public static bool EsTipoDeclarable(string lexema) => tipos.Contains(lexema);
}
