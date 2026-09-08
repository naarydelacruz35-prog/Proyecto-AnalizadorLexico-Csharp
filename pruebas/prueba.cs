class Prueba
{
    static void Main()
    {
        int edad = 20;
        double promedio = 12.5;
        string nombre = "Amizaily";
        char letra = 'A';
        bool activo = true;

        // Prueba de operadores relacionales y lógicos
        if (edad >= 18 && activo)
        {
            edad++;
            promedio += 1.5;
        }
        else
        {
            edad--;
        }

        /* Comentario
           de bloque */

        while (edad < 25)
        {
            edad += 1;
        }

        return;
    }
}