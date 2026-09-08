# Arquitectura

La interfaz se limita a cargar, solicitar el análisis y presentar datos. `AnalizadorLexico` coordina los AFD mediante `IAutomata.IntentarReconocer`, mantiene línea y columna y produce un `ResultadoAnalisis` con tokens, errores, símbolos y total de líneas. `TablaSimbolos` evita nombres duplicados y `ArchivoService` concentra la lectura de archivos.

```mermaid
classDiagram
  FrmPrincipal --> ArchivoService
  FrmPrincipal --> AnalizadorLexico
  AnalizadorLexico --> IAutomata
  AnalizadorLexico --> Token
  AnalizadorLexico --> ErrorLexico
  AnalizadorLexico --> ResultadoAnalisis
  AnalizadorLexico --> PalabrasReservadas
  TablaSimbolos --> Simbolo
  IAutomata <|.. AutomataIdentificador
  IAutomata <|.. AutomataNumero
  IAutomata <|.. AutomataCadena
  IAutomata <|.. AutomataCaracter
  IAutomata <|.. AutomataOperador
  IAutomata <|.. AutomataComentario
  IAutomata <|.. AutomataDelimitador
  class FrmPrincipal
  class AnalizadorLexico
  class Token
  class ErrorLexico
  class ResultadoAnalisis
  class Simbolo
  class TablaSimbolos
  class IAutomata
  class AutomataIdentificador
  class AutomataNumero
  class AutomataCadena
  class AutomataCaracter
  class AutomataOperador
  class AutomataComentario
  class AutomataDelimitador
  class PalabrasReservadas
  class ArchivoService
```
