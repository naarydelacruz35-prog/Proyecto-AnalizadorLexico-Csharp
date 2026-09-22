using System.Collections.Generic;

namespace AnalizadorLexicoCSharp.Models
{
    public class TablaSimbolos
    {
        public class InfoSimbolo
        {
            public string Nombre { get; set; }
            public TipoToken TipoToken { get; set; }
            public int PrimeraLinea { get; set; }
            public string TipoDeclarado { get; set; }

            public InfoSimbolo(
                string nombre,
                TipoToken tipoToken,
                int primeraLinea,
                string tipoDeclarado)
            {
                Nombre = nombre;
                TipoToken = tipoToken;
                PrimeraLinea = primeraLinea;
                TipoDeclarado = tipoDeclarado;
            }
        }

        private Dictionary<string, InfoSimbolo> tabla;

        public TablaSimbolos()
        {
            tabla = new Dictionary<string, InfoSimbolo>();
        }

        public void Agregar(
            string nombre,
            int linea,
            string tipoDeclarado = "")
        {
            if (!tabla.ContainsKey(nombre))
            {
                tabla.Add(
                    nombre,
                    new InfoSimbolo(
                        nombre,
                        TipoToken.IDENTIFICADOR,
                        linea,
                        tipoDeclarado
                    )
                );
            }
        }

        public bool Existe(string nombre)
        {
            return tabla.ContainsKey(nombre);
        }

        public List<InfoSimbolo> ObtenerTodos()
        {
            return new List<InfoSimbolo>(tabla.Values);
        }

        public void Limpiar()
        {
            tabla.Clear();
        }
    }
}
