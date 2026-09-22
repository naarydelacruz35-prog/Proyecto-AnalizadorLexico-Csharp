using System;

namespace AnalizadorLexicoCSharp.Automatas
{
    public class AutomataAFD
    {
        public bool EsIdentificador(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return false;

            if (!(char.IsLetter(texto[0]) || texto[0] == '_'))
                return false;

            for (int i = 1; i < texto.Length; i++)
            {
                if (!(char.IsLetterOrDigit(texto[i]) || texto[i] == '_'))
                    return false;
            }

            return true;
        }

        public bool EsNumero(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return false;

            for (int i = 0; i < texto.Length; i++)
            {
                if (!char.IsDigit(texto[i]))
                    return false;
            }

            return true;
        }

        public bool EsCadena(string texto)
        {
            if (texto.Length < 2)
                return false;

            return texto.StartsWith("\"") &&
                   texto.EndsWith("\"");
        }

        public bool EsOperador(char c)
        {
            return "+-*/%<>=!&|".Contains(c.ToString());
        }

        public bool EsDelimitador(char c)
        {
            return "(){}[];,. ".Contains(c) && c != ' ';
        }

        public bool EsPalabraReservada(string texto)
        {
            string[] reservadas =
            {
                "if", "else", "while", "for",
                "int", "float", "double", "char",
                "bool", "string", "void", "return",
                "class", "static", "true", "false",
                "break", "continue", "switch", "case"
            };

            foreach (string palabra in reservadas)
            {
                if (texto == palabra)
                    return true;
            }

            return false;
        }
    }
}