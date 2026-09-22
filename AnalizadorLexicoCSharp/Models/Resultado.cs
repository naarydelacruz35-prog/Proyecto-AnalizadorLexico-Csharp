using AnalizadorLexicoCSharp.Services;
using System.Collections.Generic;

namespace AnalizadorLexicoCSharp.Models
{
    public class Resultado
    {
        public List<Ficha> Tokens { get; set; }
        public List<ErrorLexico> Errors { get; set; }
        public TablaSimbolos Simbolos { get; set; }

        public int TotalTokens
        {
            get { return Tokens.Count; }
        }

        public int TotalErrores
        {
            get { return Errors.Count; }
        }

        public Resultado()
        {
            Tokens = new List<Ficha>();
            Errors = new List<ErrorLexico>();
            Simbolos = new TablaSimbolos();
        }
    }
}
