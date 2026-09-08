namespace AnalizadorLexicoCSharp.Automatas;

public interface IAutomata
{
    string Nombre { get; }
    string EstadoInicial { get; }
    IReadOnlyCollection<string> EstadosAceptacion { get; }
    bool PuedeIniciar(char caracter);
    string ObtenerSiguienteEstado(string estadoActual, char caracter);
    bool IntentarReconocer(string fuente, int inicio, out Reconocimiento reconocimiento);
}
