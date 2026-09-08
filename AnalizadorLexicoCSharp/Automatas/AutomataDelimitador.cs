using AnalizadorLexicoCSharp.Models;

namespace AnalizadorLexicoCSharp.Automatas;

public class AutomataDelimitador : IAutomata
{
    public string Nombre => "Delimitadores";
    public string EstadoInicial => "q0";
    public IReadOnlyCollection<string> EstadosAceptacion { get; } = new[] { "q1" };
    public bool PuedeIniciar(char caracter) => "(){}[];, .".Replace(" ", string.Empty).Contains(caracter);
    public string ObtenerSiguienteEstado(string estadoActual, char caracter) =>
        estadoActual == "q0" && PuedeIniciar(caracter) ? "q1" : "rechazo";

    public bool IntentarReconocer(string fuente, int inicio, out Reconocimiento reconocimiento)
    {
        reconocimiento = new Reconocimiento(0);
        if (!PuedeIniciar(fuente[inicio])) return false;
        reconocimiento = new Reconocimiento(1, TipoToken.TK_DELIMITADOR);
        return true;
    }
}
