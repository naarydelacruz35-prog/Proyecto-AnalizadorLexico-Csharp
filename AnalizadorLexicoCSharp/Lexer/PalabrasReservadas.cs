using System;
using System.Collections.Generic;
using System.IO;

namespace AnalizadorLexicoCSharp.Lexer
{
    public static class PalabrasReservadas
    {
        private static readonly Dictionary<string, string> palabras =
            CargarPalabras();

        private static Dictionary<string, string> CargarPalabras()
        {
            string ruta = Path.Combine(
                AppContext.BaseDirectory,
                "palabras_reservadas.txt"
            );

            if (!File.Exists(ruta))
            {
                throw new FileNotFoundException(
                    "No se encontró el archivo de palabras reservadas.",
                    ruta
                );
            }

            Dictionary<string, string> resultado =
                new Dictionary<string, string>(StringComparer.Ordinal);

            foreach (string linea in File.ReadAllLines(ruta))
            {
                string[] partes = linea.Split('|');

                if (partes.Length != 2)
                    continue;

                string palabra = partes[0].Trim();
                string categoria = partes[1].Trim();

                if (palabra.Length > 0)
                {
                    resultado[palabra] = categoria;
                }
            }

            return resultado;
        }

        public static bool EsPalabraReservada(string lexema)
        {
            return palabras.ContainsKey(lexema);
        }

        public static bool EsTipoDeclarable(string lexema)
        {
            return palabras.TryGetValue(lexema, out string? categoria)
                && categoria == "TIPO";
        }
    }
}
