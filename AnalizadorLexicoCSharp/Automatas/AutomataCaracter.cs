using AnalizadorLexicoCSharp.Models;

namespace AnalizadorLexicoCSharp.Automatas;

public class AutomataCaracter : IAutomata
{
    public string Nombre => "Caracteres";
    public string EstadoInicial => "q0";
    public IReadOnlyCollection<string> EstadosAceptacion { get; } = new[] { "q4" };
    public bool PuedeIniciar(char caracter) => caracter == '\'';
    public string ObtenerSiguienteEstado(string estadoActual, char caracter) => estadoActual switch
    {
        "q0" when caracter == '\'' => "q1",
        "q1" when caracter == '\\' => "q2",
        "q1" when caracter != '\'' && caracter != '\r' && caracter != '\n' => "q3",
        "q2" => "q3",
        "q3" when caracter == '\'' => "q4",
        _ => "rechazo"
    };

    public bool IntentarReconocer(string fuente, int inicio, out Reconocimiento reconocimiento)
    {
        reconocimiento = new Reconocimiento(0);
        if (!PuedeIniciar(fuente[inicio])) return false;

        int posicion = inicio + 1;
        if (posicion >= fuente.Length || fuente[posicion] == '\r' || fuente[posicion] == '\n')
        {
            reconocimiento = new Reconocimiento(posicion - inicio, descripcionError: "Carácter literal sin cerrar");
            return true;
        }

        if (fuente[posicion] == '\'')
        {
            reconocimiento = new Reconocimiento(2, descripcionError: "Carácter literal inválido");
            return true;
        }

        if (fuente[posicion] == '\\')
        {
            posicion++;
            if (posicion >= fuente.Length || !"ntr\\\"'0".Contains(fuente[posicion]))
            {
                reconocimiento = new Reconocimiento(posicion - inicio, descripcionError: "Carácter literal sin cerrar");
                return true;
            }
            posicion++;
        }
        else
        {
            posicion++;
        }

        if (posicion < fuente.Length && fuente[posicion] == '\'')
        {
            reconocimiento = new Reconocimiento(posicion - inicio + 1, TipoToken.TK_CARACTER);
            return true;
        }

        while (posicion < fuente.Length && fuente[posicion] != '\r' && fuente[posicion] != '\n') posicion++;
        reconocimiento = new Reconocimiento(posicion - inicio, descripcionError: "Carácter literal sin cerrar");
        return true;
    }
}
