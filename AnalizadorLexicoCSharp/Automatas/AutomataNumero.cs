using AnalizadorLexicoCSharp.Utils;
using AnalizadorLexicoCSharp.Models;

namespace AnalizadorLexicoCSharp.Automatas;

public class AutomataNumero : IAutomata
{
    public string Nombre => "Numeros enteros y reales";
    public string EstadoInicial => "q0";
    public IReadOnlyCollection<string> EstadosAceptacion { get; } = new[] { "q1", "q3" };
    public bool PuedeIniciar(char caracter) => CaracterHelper.EsDigito(caracter);
    public string ObtenerSiguienteEstado(string estadoActual, char caracter) => estadoActual switch
    {
        "q0" when CaracterHelper.EsDigito(caracter) => "q1",
        "q1" when CaracterHelper.EsDigito(caracter) => "q1",
        "q1" when caracter == '.' => "q2",
        "q2" when CaracterHelper.EsDigito(caracter) => "q3",
        "q3" when CaracterHelper.EsDigito(caracter) => "q3",
        _ => "rechazo"
    };

    public bool IntentarReconocer(string fuente, int inicio, out Reconocimiento reconocimiento)
    {
        reconocimiento = new Reconocimiento(0);
        if (!PuedeIniciar(fuente[inicio])) return false;

        int posicion = inicio;
        while (posicion < fuente.Length && CaracterHelper.EsDigito(fuente[posicion])) posicion++;
        bool esReal = false;
        bool malFormado = false;

        if (posicion < fuente.Length && fuente[posicion] == '.')
        {
            int punto = posicion++;
            if (posicion < fuente.Length && CaracterHelper.EsDigito(fuente[posicion]))
            {
                esReal = true;
                while (posicion < fuente.Length && CaracterHelper.EsDigito(fuente[posicion])) posicion++;
            }
            else
            {
                malFormado = posicion < fuente.Length && fuente[posicion] == '.';
                if (!malFormado) posicion = punto;
            }
        }

        bool contieneIdentificador = posicion < fuente.Length && CaracterHelper.EsInicioIdentificador(fuente[posicion]);
        if (posicion < fuente.Length && (contieneIdentificador || fuente[posicion] == '.'))
        {
            malFormado = true;
            while (posicion < fuente.Length && (CaracterHelper.EsParteIdentificador(fuente[posicion]) || fuente[posicion] == '.')) posicion++;
        }

        reconocimiento = malFormado
            ? new Reconocimiento(posicion - inicio, descripcionError: contieneIdentificador ? "Identificador inválido" : "Número mal formado")
            : new Reconocimiento(posicion - inicio, esReal ? TipoToken.TK_NUM_REAL : TipoToken.TK_NUM_ENTERO);
        return true;
    }
}
