using System;
using System.Collections.Generic;
using System.Text;
using AnalizadorLexicoCSharp.Automatas;
using AnalizadorLexicoCSharp.Models;

namespace AnalizadorLexicoCSharp.Lexer
{
    public class AnalizadorLexico
    {
        private string codigo;
        private int posicion;
        private int linea;
        private int columna;

        private readonly AutomataAFD automata;

        private readonly HashSet<string> palabrasReservadas =
            new HashSet<string>
            {
                "if", "else", "while", "for",
                "int", "float", "double", "char",
                "bool", "string", "void", "return",
                "class", "static", "true", "false",
                "break", "continue", "switch", "case"
            };

        public AnalizadorLexico()
        {
            automata = new AutomataAFD();
        }

        public Resultado Analizar(string codigoFuente)
        {
            codigo = codigoFuente ?? "";
            posicion = 0;
            linea = 1;
            columna = 1;

            Resultado resultado = new Resultado();

            while (!FinDelCodigo())
            {
                char actual = Actual();

                if (actual == ' ' || actual == '\t' || actual == '\r')
                {
                    Avanzar();
                    continue;
                }

                if (actual == '\n')
                {
                    Avanzar();
                    continue;
                }

                int lineaInicio = linea;
                int columnaInicio = columna;

                if (char.IsLetter(actual) || actual == '_')
                {
                    LeerIdentificador(resultado, lineaInicio, columnaInicio);
                }
                else if (char.IsDigit(actual))
                {
                    LeerNumero(resultado, lineaInicio, columnaInicio);
                }
                else if (actual == '"')
                {
                    LeerCadena(resultado, lineaInicio, columnaInicio);
                }
                else if (actual == '\'')
                {
                    LeerCaracter(resultado, lineaInicio, columnaInicio);
                }
                else if (actual == '/')
                {
                    LeerBarraComentario(resultado, lineaInicio, columnaInicio);
                }
                else if (actual == '+' || actual == '-' ||
                         actual == '*' || actual == '%' ||
                         actual == '=' || actual == '!' ||
                         actual == '<' || actual == '>' ||
                         actual == '&' || actual == '|')
                {
                    LeerOperador(resultado, lineaInicio, columnaInicio);
                }
                else if ("(){}[];,.".Contains(actual.ToString()))
                {
                    resultado.Tokens.Add(
                        new Ficha(
                            TipoToken.DELIMITADOR,
                            actual.ToString(),
                            lineaInicio,
                            columnaInicio));

                    Avanzar();
                }
                else
                {
                    string caracter = actual.ToString();

                    resultado.Errors.Add(
                        new ErrorLexico(
                            caracter,
                            lineaInicio,
                            columnaInicio,
                            "Carácter no reconocido."));

                    Avanzar();
                }
            }

            return resultado;
        }

        private void LeerIdentificador(
            Resultado resultado,
            int lineaInicio,
            int columnaInicio)
        {
            StringBuilder lexema = new StringBuilder();

            while (!FinDelCodigo())
            {
                char c = Actual();

                if (char.IsLetterOrDigit(c) || c == '_')
                {
                    lexema.Append(c);
                    Avanzar();
                }
                else
                {
                    break;
                }
            }

            string texto = lexema.ToString();

            TipoToken tipo;

            if (palabrasReservadas.Contains(texto))
            {
                tipo = TipoToken.PALABRA_RESERVADA;
            }
            else
            {
                tipo = TipoToken.IDENTIFICADOR;

                string tipoDeclarado = ObtenerTipoDeclaradoAnterior();

                resultado.Simbolos.Agregar(
                    texto,
                    lineaInicio,
                    tipoDeclarado);
            }

            resultado.Tokens.Add(
                new Ficha(
                    tipo,
                    texto,
                    lineaInicio,
                    columnaInicio));
        }

        private string ObtenerTipoDeclaradoAnterior()
        {
            return "";
        }

        private void LeerNumero(
            Resultado resultado,
            int lineaInicio,
            int columnaInicio)
        {
            StringBuilder lexema = new StringBuilder();

            while (!FinDelCodigo() && char.IsDigit(Actual()))
            {
                lexema.Append(Actual());
                Avanzar();
            }

            if (!FinDelCodigo() && Actual() == '.')
            {
                lexema.Append('.');
                Avanzar();

                if (FinDelCodigo() || !char.IsDigit(Actual()))
                {
                    while (!FinDelCodigo() &&
                           (char.IsDigit(Actual()) || Actual() == '.'))
                    {
                        lexema.Append(Actual());
                        Avanzar();
                    }

                    resultado.Errors.Add(
                        new ErrorLexico(
                            lexema.ToString(),
                            lineaInicio,
                            columnaInicio,
                            "Número mal formado."));

                    return;
                }

                while (!FinDelCodigo() && char.IsDigit(Actual()))
                {
                    lexema.Append(Actual());
                    Avanzar();
                }

                if (!FinDelCodigo() && Actual() == '.')
                {
                    while (!FinDelCodigo() &&
                           (char.IsDigit(Actual()) || Actual() == '.'))
                    {
                        lexema.Append(Actual());
                        Avanzar();
                    }

                    resultado.Errors.Add(
                        new ErrorLexico(
                            lexema.ToString(),
                            lineaInicio,
                            columnaInicio,
                            "Número mal formado."));

                    return;
                }

                resultado.Tokens.Add(
                    new Ficha(
                        TipoToken.NUMERO_REAL,
                        lexema.ToString(),
                        lineaInicio,
                        columnaInicio));

                return;
            }

            if (!FinDelCodigo() &&
                (char.IsLetter(Actual()) || Actual() == '_'))
            {
                while (!FinDelCodigo() &&
                       (char.IsLetterOrDigit(Actual()) || Actual() == '_'))
                {
                    lexema.Append(Actual());
                    Avanzar();
                }

                resultado.Errors.Add(
                    new ErrorLexico(
                        lexema.ToString(),
                        lineaInicio,
                        columnaInicio,
                        "Identificador inválido: no puede comenzar con un dígito."));

                return;
            }

            resultado.Tokens.Add(
                new Ficha(
                    TipoToken.NUMERO_ENTERO,
                    lexema.ToString(),
                    lineaInicio,
                    columnaInicio));
        }

        private void LeerCadena(
            Resultado resultado,
            int lineaInicio,
            int columnaInicio)
        {
            StringBuilder lexema = new StringBuilder();

            lexema.Append(Actual());
            Avanzar();

            bool cerrada = false;

            while (!FinDelCodigo())
            {
                char c = Actual();

                if (c == '"')
                {
                    lexema.Append(c);
                    Avanzar();
                    cerrada = true;
                    break;
                }

                if (c == '\n')
                {
                    break;
                }

                if (c == '\\')
                {
                    lexema.Append(c);
                    Avanzar();

                    if (!FinDelCodigo())
                    {
                        lexema.Append(Actual());
                        Avanzar();
                    }
                }
                else
                {
                    lexema.Append(c);
                    Avanzar();
                }
            }

            if (!cerrada)
            {
                resultado.Errors.Add(
                    new ErrorLexico(
                        lexema.ToString(),
                        lineaInicio,
                        columnaInicio,
                        "Cadena sin cerrar."));

                return;
            }

            resultado.Tokens.Add(
                new Ficha(
                    TipoToken.CADENA,
                    lexema.ToString(),
                    lineaInicio,
                    columnaInicio));
        }

        private void LeerCaracter(
            Resultado resultado,
            int lineaInicio,
            int columnaInicio)
        {
            StringBuilder lexema = new StringBuilder();

            lexema.Append(Actual());
            Avanzar();

            bool valido = false;

            if (FinDelCodigo() || Actual() == '\n')
            {
                resultado.Errors.Add(
                    new ErrorLexico(
                        lexema.ToString(),
                        lineaInicio,
                        columnaInicio,
                        "Carácter literal sin cerrar."));

                return;
            }

            if (Actual() == '\\')
            {
                lexema.Append(Actual());
                Avanzar();

                if (!FinDelCodigo())
                {
                    lexema.Append(Actual());
                    Avanzar();
                }
            }
            else
            {
                lexema.Append(Actual());
                Avanzar();
            }

            if (!FinDelCodigo() && Actual() == '\'')
            {
                lexema.Append(Actual());
                Avanzar();
                valido = true;
            }

            if (!valido)
            {
                while (!FinDelCodigo() &&
                       Actual() != '\n' &&
                       Actual() != '\'')
                {
                    lexema.Append(Actual());
                    Avanzar();
                }

                if (!FinDelCodigo() && Actual() == '\'')
                {
                    lexema.Append(Actual());
                    Avanzar();
                }

                resultado.Errors.Add(
                    new ErrorLexico(
                        lexema.ToString(),
                        lineaInicio,
                        columnaInicio,
                        "Carácter literal sin cerrar o mal formado."));

                return;
            }

            resultado.Tokens.Add(
                new Ficha(
                    TipoToken.CARACTER,
                    lexema.ToString(),
                    lineaInicio,
                    columnaInicio));
        }

        private void LeerBarraComentario(
            Resultado resultado,
            int lineaInicio,
            int columnaInicio)
        {
            Avanzar();

            if (!FinDelCodigo() && Actual() == '/')
            {
                StringBuilder lexema = new StringBuilder();
                lexema.Append("//");
                Avanzar();

                while (!FinDelCodigo() && Actual() != '\n')
                {
                    lexema.Append(Actual());
                    Avanzar();
                }

                resultado.Tokens.Add(
                    new Ficha(
                        TipoToken.COMENTARIO_LINEA,
                        lexema.ToString(),
                        lineaInicio,
                        columnaInicio));

                return;
            }

            if (!FinDelCodigo() && Actual() == '*')
            {
                StringBuilder lexema = new StringBuilder();
                lexema.Append("/*");
                Avanzar();

                bool cerrado = false;

                while (!FinDelCodigo())
                {
                    char c = Actual();

                    if (c == '*' &&
                        SiguienteDisponible() &&
                        Siguiente() == '/')
                    {
                        lexema.Append('*');
                        Avanzar();

                        lexema.Append('/');
                        Avanzar();

                        cerrado = true;
                        break;
                    }

                    lexema.Append(c);
                    Avanzar();
                }

                if (!cerrado)
                {
                    resultado.Errors.Add(
                        new ErrorLexico(
                            lexema.ToString(),
                            lineaInicio,
                            columnaInicio,
                            "Comentario de bloque sin cerrar."));

                    return;
                }

                resultado.Tokens.Add(
                    new Ficha(
                        TipoToken.COMENTARIO_BLOQUE,
                        lexema.ToString(),
                        lineaInicio,
                        columnaInicio));

                return;
            }

            resultado.Tokens.Add(
                new Ficha(
                    TipoToken.OPERADOR_ARITMETICO,
                    "/",
                    lineaInicio,
                    columnaInicio));
        }

        private void LeerOperador(
            Resultado resultado,
            int lineaInicio,
            int columnaInicio)
        {
            char actual = Actual();
            char siguiente = SiguienteDisponible() ? Siguiente() : '\0';

            string lexema = actual.ToString();
            TipoToken tipo = TipoToken.OPERADOR_ARITMETICO;

            if (actual == '=')
            {
                if (siguiente == '=')
                {
                    lexema = "==";
                    tipo = TipoToken.OPERADOR_RELACIONAL;
                    Avanzar();
                    Avanzar();
                }
                else
                {
                    tipo = TipoToken.ASIGNACION;
                    Avanzar();
                }
            }
            else if (actual == '!')
            {
                if (siguiente == '=')
                {
                    lexema = "!=";
                    tipo = TipoToken.OPERADOR_RELACIONAL;
                    Avanzar();
                    Avanzar();
                }
                else
                {
                    tipo = TipoToken.OPERADOR_LOGICO;
                    Avanzar();
                }
            }
            else if (actual == '<' || actual == '>')
            {
                tipo = TipoToken.OPERADOR_RELACIONAL;

                if (siguiente == '=')
                {
                    lexema += "=";
                    Avanzar();
                    Avanzar();
                }
                else
                {
                    Avanzar();
                }
            }
            else if (actual == '&')
            {
                if (siguiente == '&')
                {
                    lexema = "&&";
                    tipo = TipoToken.OPERADOR_LOGICO;
                    Avanzar();
                    Avanzar();
                }
                else
                {
                    resultado.Errors.Add(
                        new ErrorLexico(
                            "&",
                            lineaInicio,
                            columnaInicio,
                            "Operador lógico mal formado. Se esperaba &&."));

                    Avanzar();
                    return;
                }
            }
            else if (actual == '|')
            {
                if (siguiente == '|')
                {
                    lexema = "||";
                    tipo = TipoToken.OPERADOR_LOGICO;
                    Avanzar();
                    Avanzar();
                }
                else
                {
                    resultado.Errors.Add(
                        new ErrorLexico(
                            "|",
                            lineaInicio,
                            columnaInicio,
                            "Operador lógico mal formado. Se esperaba ||."));

                    Avanzar();
                    return;
                }
            }
            else if (actual == '+' || actual == '-')
            {
                if (siguiente == actual)
                {
                    lexema += actual;
                    tipo = TipoToken.OPERADOR_ARITMETICO;
                    Avanzar();
                    Avanzar();
                }
                else if (siguiente == '=')
                {
                    lexema += "=";
                    tipo = TipoToken.ASIGNACION;
                    Avanzar();
                    Avanzar();
                }
                else
                {
                    tipo = TipoToken.OPERADOR_ARITMETICO;
                    Avanzar();
                }
            }
            else if (actual == '*' || actual == '/')
            {
                if (siguiente == '=')
                {
                    lexema += "=";
                    tipo = TipoToken.ASIGNACION;
                    Avanzar();
                    Avanzar();
                }
                else
                {
                    tipo = TipoToken.OPERADOR_ARITMETICO;
                    Avanzar();
                }
            }
            else if (actual == '%')
            {
                tipo = TipoToken.OPERADOR_ARITMETICO;
                Avanzar();
            }

            resultado.Tokens.Add(
                new Ficha(
                    tipo,
                    lexema,
                    lineaInicio,
                    columnaInicio));
        }

        private bool FinDelCodigo()
        {
            return posicion >= codigo.Length;
        }

        private char Actual()
        {
            return codigo[posicion];
        }

        private char Siguiente()
        {
            return codigo[posicion + 1];
        }

        private bool SiguienteDisponible()
        {
            return posicion + 1 < codigo.Length;
        }

        private void Avanzar()
        {
            if (FinDelCodigo())
                return;

            if (codigo[posicion] == '\n')
            {
                linea++;
                columna = 1;
            }
            else
            {
                columna++;
            }

            posicion++;
        }
    }
}