namespace AnalizadorLexicoCSharp.Services;

public class ArchivoService
{
    public string LeerTexto(string rutaArchivo) => File.ReadAllText(rutaArchivo);
}
