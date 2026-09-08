using AnalizadorLexicoCSharp.Automatas;
using AnalizadorLexicoCSharp.Models;

namespace AnalizadorLexicoCSharp.Lexer;

public class AnalizadorLexico
{
    private readonly AutomataComentario automataComentario = new();
    private readonly AutomataCadena automataCadena = new();
    private readonly AutomataCaracter automataCaracter = new();
    private readonly AutomataIdentificador automataIdentificador = new();
    private readonly AutomataNumero automataNumero = new();
    private readonly AutomataOperador automataOperador = new();
    private readonly AutomataDelimitador automataDelimitador = new();

    public IReadOnlyList<IAutomata> Automatas { get; }

    public AnalizadorLexico()
    {
        Automatas = new IAutomata[]
        {
            automataIdentificador, automataNumero, automataCadena, automataCaracter,
            automataOperador, automataComentario, automataDelimitador
        };
    }

    public ResultadoAnalisis Analizar(string fuente)
    {
        ResultadoAnalisis resultado = new();
        int posicion = 0;
        int linea = 1;
        int columna = 1;

        while (posicion < fuente.Length)
        {
            if (char.IsWhiteSpace(fuente[posicion]))
            {
                int longitudEspacio = fuente[posicion] == '\r' && posicion + 1 < fuente.Length && fuente[posicion + 1] == '\n' ? 2 : 1;
                Avanzar(fuente, ref posicion, ref linea, ref columna, longitudEspacio);
                continue;
            }

            int lineaInicio = linea;
            int columnaInicio = columna;
            if (IntentarReconocer(fuente, posicion, out Reconocimiento reconocimiento))
            {
                string lexema = fuente.Substring(posicion, reconocimiento.Longitud);
                if (reconocimiento.Tipo.HasValue)
                {
                    TipoToken tipo = reconocimiento.Tipo.Value;
                    if (tipo == TipoToken.TK_IDENTIFICADOR && PalabrasReservadas.EsPalabraReservada(lexema)) tipo = TipoToken.TK_PALABRA_RESERVADA;
                    resultado.Tokens.Add(new Token { Numero = resultado.Tokens.Count + 1, Lexema = lexema, Tipo = tipo, Linea = lineaInicio, Columna = columnaInicio });
                }
                else
                {
                    resultado.Errores.Add(new ErrorLexico { Lexema = lexema, Descripcion = reconocimiento.DescripcionError ?? "Error léxico", Linea = lineaInicio, Columna = columnaInicio });
                }
                Avanzar(fuente, ref posicion, ref linea, ref columna, reconocimiento.Longitud);
                continue;
            }

            resultado.Errores.Add(new ErrorLexico { Lexema = fuente[posicion].ToString(), Descripcion = "Carácter no reconocido", Linea = lineaInicio, Columna = columnaInicio });
            Avanzar(fuente, ref posicion, ref linea, ref columna, 1);
        }

        resultado.TotalLineas = fuente.Length == 0 ? 0 : linea - (TerminaConSaltoDeLinea(fuente) ? 1 : 0);
        CrearTablaSimbolos(resultado);
        return resultado;
    }

    private bool IntentarReconocer(string fuente, int posicion, out Reconocimiento reconocimiento)
    {
        IAutomata[] orden = { automataComentario, automataCadena, automataCaracter, automataIdentificador, automataNumero, automataOperador, automataDelimitador };
        foreach (IAutomata automata in orden)
        {
            if (automata.IntentarReconocer(fuente, posicion, out reconocimiento)) return true;
        }
        reconocimiento = new Reconocimiento(0);
        return false;
    }

    private static void Avanzar(string fuente, ref int posicion, ref int linea, ref int columna, int longitud)
    {
        int limite = posicion + longitud;
        while (posicion < limite)
        {
            if (fuente[posicion] == '\r')
            {
                posicion++;
                if (posicion < limite && fuente[posicion] == '\n') posicion++;
                linea++;
                columna = 1;
            }
            else if (fuente[posicion] == '\n')
            {
                posicion++;
                linea++;
                columna = 1;
            }
            else
            {
                posicion++;
                columna++;
            }
        }
    }

    private static void CrearTablaSimbolos(ResultadoAnalisis resultado)
    {
        Services.TablaSimbolos tabla = new();
        for (int indice = 0; indice < resultado.Tokens.Count; indice++)
        {
            Token token = resultado.Tokens[indice];
            if (token.Tipo != TipoToken.TK_IDENTIFICADOR) continue;
            string tipoDeclarado = indice > 0 && resultado.Tokens[indice - 1].Tipo == TipoToken.TK_PALABRA_RESERVADA && PalabrasReservadas.EsTipoDeclarable(resultado.Tokens[indice - 1].Lexema)
                ? resultado.Tokens[indice - 1].Lexema
                : "-";
            tabla.Agregar(new Simbolo { Nombre = token.Lexema, TipoToken = token.Tipo, PrimeraLinea = token.Linea, TipoDeclarado = tipoDeclarado });
        }
        resultado.Simbolos.AddRange(tabla.Simbolos);
    }

    private static bool TerminaConSaltoDeLinea(string fuente) => fuente[^1] == '\r' || fuente[^1] == '\n';
}
