# Analizador Léxico para C#

Proyecto universitario de Lenguajes Formales y de Programación para el diseño de un analizador léxico de un subconjunto de C#.

## Objetivo

Analizar código de un subconjunto de C#, emitir tokens con posición, registrar errores léxicos recuperables y construir una tabla de símbolos de identificadores.

## Tecnología

- C# con .NET 9
- Windows Forms
- Visual Studio 2022 o posterior

## Estructura

```text
AnalizadorLexicoCSharp/
  Automatas/     AFD y contrato común
  Forms/         Interfaz Windows Forms
  Lexer/         Coordinador del análisis y palabras reservadas
  Models/        Token, símbolo, error, resultado y tipos
  Services/      Lectura de archivos y tabla de símbolos
  Utils/         Utilidades de caracteres
docs/            Diseño de AFD, transiciones, arquitectura y plan
```

## Funcionamiento

`AnalizadorLexico` coordina los autómatas de identificadores, números, cadenas, caracteres, operadores, comentarios y delimitadores. No utiliza expresiones regulares.

- Reconoce las palabras reservadas, operadores y delimitadores definidos para el proyecto aplicando coincidencia más larga.
- Conserva número, lexema, tipo, línea y columna de cada token; considera CRLF como un único salto de línea.
- Informa identificadores inválidos, números mal formados, cadenas y caracteres sin cerrar, comentarios de bloque sin cerrar y caracteres no reconocidos.
- Presenta tokens, símbolos y errores en la interfaz. La tabla de símbolos evita duplicados y asocia el tipo declarado cuando lo precede inmediatamente.

Los archivos de `pruebas/` cubren casos básicos, medios, errores y operadores.

## Abrir en Visual Studio

1. Abra `AnalizadorLexicoCSharp.sln`.
2. Seleccione el proyecto `AnalizadorLexicoCSharp` como proyecto de inicio.
3. Ejecute con `F5`.

## Compilar

Desde la carpeta que contiene la solución, ejecute:

```powershell
dotnet build AnalizadorLexicoCSharp.sln
```
