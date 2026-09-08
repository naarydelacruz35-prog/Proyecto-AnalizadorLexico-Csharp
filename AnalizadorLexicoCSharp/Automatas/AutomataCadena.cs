using AnalizadorLexicoCSharp.Models;

namespace AnalizadorLexicoCSharp.Automatas;

public class AutomataCadena : IAutomata
{
    public string Nombre => "Cadenas";
    public string EstadoInicial => "q0";
    public IReadOnlyCollection<string> EstadosAceptacion { get; } = new[] { "q3" };
    public bool PuedeIniciar(char caracter) => caracter == '"';
    public string ObtenerSiguienteEstado(string estadoActual, char caracter) => estadoActual switch
    {
        "q0" when caracter == '"' => "q1",
        "q1" when caracter == '\\' => "q2",
        "q1" when caracter != '"' && caracter != '\r' && caracter != '\n' => "q1",
        "q1" when caracter == '"' => "q3",
        "q2" => "q1",
        _ => "rechazo"
    };

    public bool IntentarReconocer(string fuente, int inicio, out Reconocimiento reconocimiento)
    {
        reconocimiento = new Reconocimiento(0);
        if (!PuedeIniciar(fuente[inicio])) return false;

        int posicion = inicio + 1;
        string estado = "q1";
        while (posicion < fuente.Length && fuente[posicion] != '\r' && fuente[posicion] != '\n')
        {
            char actual = fuente[posicion++];
            if (estado == "q1" && actual == '"')
            {
                reconocimiento = new Reconocimiento(posicion - inicio, TipoToken.TK_CADENA);
                return true;
            }
            if (estado == "q1" && actual == '\\')
            {
                estado = "q2";
            }
            else if (estado == "q2")
            {
                if (!"ntr\\\"'0".Contains(actual))
                {
                    reconocimiento = new Reconocimiento(posicion - inicio, descripcionError: "Secuencia de escape inválida en cadena");
                    return true;
                }
                estado = "q1";
            }
        }

        reconocimiento = new Reconocimiento(posicion - inicio, descripcionError: "Cadena sin cerrar");
        return true;
    }
}
