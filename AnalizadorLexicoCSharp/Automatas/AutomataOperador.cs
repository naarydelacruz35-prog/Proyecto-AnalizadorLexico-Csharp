using AnalizadorLexicoCSharp.Models;

namespace AnalizadorLexicoCSharp.Automatas;

public class AutomataOperador : IAutomata
{
    public string Nombre => "Operadores";
    public string EstadoInicial => "q0";
    public IReadOnlyCollection<string> EstadosAceptacion { get; } = new[] { "qA", "qR", "qL", "qAs" };
    public bool PuedeIniciar(char caracter) => "+-*/%<>=!&|".Contains(caracter);
    public string ObtenerSiguienteEstado(string estadoActual, char caracter) => estadoActual switch
    {
        "q0" when "+-*/%".Contains(caracter) => "qA",
        "q0" when "<>".Contains(caracter) => "qR",
        "q0" when caracter == '=' => "qAs",
        "q0" when caracter == '!' => "qL",
        "q0" when caracter == '&' || caracter == '|' => "qP",
        "qA" when caracter == '=' => "qAs",
        "qA" when caracter == '+' || caracter == '-' => "qA",
        "qR" when caracter == '=' => "qR",
        "qAs" when caracter == '=' => "qR",
        "qL" when caracter == '=' => "qR",
        "qP" when caracter == '&' || caracter == '|' => "qL",
        _ => "rechazo"
    };

    public bool IntentarReconocer(string fuente, int inicio, out Reconocimiento reconocimiento)
    {
        reconocimiento = new Reconocimiento(0);
        char actual = fuente[inicio];
        if (!PuedeIniciar(actual)) return false;

        char siguiente = inicio + 1 < fuente.Length ? fuente[inicio + 1] : '\0';
        switch (actual)
        {
            case '+':
            case '-':
                if (siguiente == actual) { reconocimiento = new Reconocimiento(2, TipoToken.TK_OP_ARITMETICO); return true; }
                if (siguiente == '=') { reconocimiento = new Reconocimiento(2, TipoToken.TK_ASIGNACION); return true; }
                reconocimiento = new Reconocimiento(1, TipoToken.TK_OP_ARITMETICO); return true;
            case '*':
                reconocimiento = new Reconocimiento(siguiente == '=' ? 2 : 1, siguiente == '=' ? TipoToken.TK_ASIGNACION : TipoToken.TK_OP_ARITMETICO); return true;
            case '/':
                reconocimiento = new Reconocimiento(siguiente == '=' ? 2 : 1, siguiente == '=' ? TipoToken.TK_ASIGNACION : TipoToken.TK_OP_ARITMETICO); return true;
            case '%':
                reconocimiento = new Reconocimiento(1, TipoToken.TK_OP_ARITMETICO); return true;
            case '=':
                reconocimiento = new Reconocimiento(siguiente == '=' ? 2 : 1, siguiente == '=' ? TipoToken.TK_OP_RELACIONAL : TipoToken.TK_ASIGNACION); return true;
            case '!':
                reconocimiento = new Reconocimiento(siguiente == '=' ? 2 : 1, siguiente == '=' ? TipoToken.TK_OP_RELACIONAL : TipoToken.TK_OP_LOGICO); return true;
            case '<':
            case '>':
                reconocimiento = new Reconocimiento(siguiente == '=' ? 2 : 1, TipoToken.TK_OP_RELACIONAL); return true;
            case '&':
            case '|':
                if (siguiente == actual) { reconocimiento = new Reconocimiento(2, TipoToken.TK_OP_LOGICO); return true; }
                reconocimiento = new Reconocimiento(1, descripcionError: "Carácter no reconocido"); return true;
            default:
                return false;
        }
    }
}
