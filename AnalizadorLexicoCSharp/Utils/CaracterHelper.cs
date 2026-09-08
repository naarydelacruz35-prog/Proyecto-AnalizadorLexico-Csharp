namespace AnalizadorLexicoCSharp.Utils;

public static class CaracterHelper
{
    public static bool EsLetra(char caracter) =>
        (caracter >= 'A' && caracter <= 'Z') || (caracter >= 'a' && caracter <= 'z');

    public static bool EsDigito(char caracter) => caracter >= '0' && caracter <= '9';

    public static bool EsInicioIdentificador(char caracter) => EsLetra(caracter) || caracter == '_';

    public static bool EsParteIdentificador(char caracter) => EsInicioIdentificador(caracter) || EsDigito(caracter);
}
