using AnalizadorLexicoCSharp.Utils;
using AnalizadorLexicoCSharp.Models;

namespace AnalizadorLexicoCSharp.Automatas;

public class AutomataIdentificador : IAutomata
{
    public string Nombre => "Identificadores";
    public string EstadoInicial => "q0";
    public IReadOnlyCollection<string> EstadosAceptacion { get; } = new[] { "q1" };
    public bool PuedeIniciar(char caracter) => CaracterHelper.EsInicioIdentificador(caracter);
    public string ObtenerSiguienteEstado(string estadoActual, char caracter) => estadoActual switch
    {
        "q0" when PuedeIniciar(caracter) => "q1",
        "q1" when CaracterHelper.EsParteIdentificador(caracter) => "q1",
        _ => "rechazo"
    };

    public bool IntentarReconocer(string fuente, int inicio, out Reconocimiento reconocimiento)
    {
        reconocimiento = new Reconocimiento(0);
        if (!PuedeIniciar(fuente[inicio])) return false;

        int posicion = inicio;
        string estado = EstadoInicial;
        while (posicion < fuente.Length)
        {
            string siguiente = ObtenerSiguienteEstado(estado, fuente[posicion]);
            if (siguiente == "rechazo") break;
            estado = siguiente;
            posicion++;
        }

        reconocimiento = new Reconocimiento(posicion - inicio, TipoToken.TK_IDENTIFICADOR);
        return true;
    }
}
