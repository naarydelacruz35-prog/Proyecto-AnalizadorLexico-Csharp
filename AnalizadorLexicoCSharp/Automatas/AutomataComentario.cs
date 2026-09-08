using AnalizadorLexicoCSharp.Models;

namespace AnalizadorLexicoCSharp.Automatas;

public class AutomataComentario : IAutomata
{
    public string Nombre => "Comentarios";
    public string EstadoInicial => "q0";
    public IReadOnlyCollection<string> EstadosAceptacion { get; } = new[] { "qLinea", "qFinBloque" };
    public bool PuedeIniciar(char caracter) => caracter == '/';
    public string ObtenerSiguienteEstado(string estadoActual, char caracter) => estadoActual switch
    {
        "q0" when caracter == '/' => "q1",
        "q1" when caracter == '/' => "qLinea",
        "q1" when caracter == '*' => "qBloque",
        "qLinea" when caracter != '\r' && caracter != '\n' => "qLinea",
        "qBloque" when caracter == '*' => "qAsterisco",
        "qBloque" => "qBloque",
        "qAsterisco" when caracter == '/' => "qFinBloque",
        "qAsterisco" when caracter == '*' => "qAsterisco",
        "qAsterisco" => "qBloque",
        _ => "rechazo"
    };

    public bool IntentarReconocer(string fuente, int inicio, out Reconocimiento reconocimiento)
    {
        reconocimiento = new Reconocimiento(0);
        if (inicio + 1 >= fuente.Length || fuente[inicio] != '/') return false;

        if (fuente[inicio + 1] == '/')
        {
            int posicion = inicio + 2;
            while (posicion < fuente.Length && fuente[posicion] != '\r' && fuente[posicion] != '\n') posicion++;
            reconocimiento = new Reconocimiento(posicion - inicio, TipoToken.TK_COMENTARIO_LINEA);
            return true;
        }
        if (fuente[inicio + 1] != '*') return false;

        int indice = inicio + 2;
        string estado = "qBloque";
        while (indice < fuente.Length)
        {
            estado = ObtenerSiguienteEstado(estado, fuente[indice]);
            indice++;
            if (estado == "qFinBloque")
            {
                reconocimiento = new Reconocimiento(indice - inicio, TipoToken.TK_COMENTARIO_BLOQUE);
                return true;
            }
        }
        reconocimiento = new Reconocimiento(indice - inicio, descripcionError: "Comentario de bloque sin cerrar");
        return true;
    }
}
