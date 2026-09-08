using AnalizadorLexicoCSharp.Models;

namespace AnalizadorLexicoCSharp.Services;

public class TablaSimbolos
{
    private readonly List<Simbolo> simbolos = new();

    public IReadOnlyList<Simbolo> Simbolos => simbolos;

    public void Agregar(Simbolo simbolo)
    {
        if (simbolos.All(actual => actual.Nombre != simbolo.Nombre)) simbolos.Add(simbolo);
    }

    public void Limpiar() => simbolos.Clear();
}
