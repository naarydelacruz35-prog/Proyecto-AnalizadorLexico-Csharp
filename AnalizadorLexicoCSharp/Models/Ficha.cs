namespace AnalizadorLexicoCSharp.Models
{
    public class Ficha
    {
        public TipoToken Tipo { get; set; }
        public string Lexema { get; set; }
        public int Linea { get; set; }
        public int Columna { get; set; }

        public Ficha(TipoToken tipo, string lexema, int linea, int columna)
        {
            Tipo = tipo;
            Lexema = lexema;
            Linea = linea;
            Columna = columna;
        }
    }
}
