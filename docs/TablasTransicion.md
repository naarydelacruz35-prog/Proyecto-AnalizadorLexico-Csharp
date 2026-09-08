# Tablas de transición

`L` representa letra, `D` dígito, `S` contenido válido de cadena y `E` una secuencia de escape.

Los reconocedores consumen primero la alternativa de mayor longitud. Para `/`, el orden real es `//`, `/*`, `/=` y `/`; para `!`, la transición con `=` se resuelve antes que la negación simple.

## 1. Identificadores
| Estado actual | Símbolo de entrada | Estado siguiente | Observación |
|---|---|---|---|
| q0 | L o _ | q1 | Inicio válido |
| q1 | L, D o _ | q1 | Continúa identificador |

## 2. Números
| Estado actual | Símbolo de entrada | Estado siguiente | Observación |
|---|---|---|---|
| q0 | D | q1 | Inicio entero |
| q1 | D | q1 | Entero |
| q1 | . | q2 | Separador decimal |
| q2 | D | q3 | Primer decimal obligatorio |
| q3 | D | q3 | Real |

Al encontrar otra marca decimal o una letra después del recorrido aceptado, el reconocedor consume la secuencia y devuelve un error, sin emitir tokens parciales.

## 3. Cadenas
| Estado actual | Símbolo de entrada | Estado siguiente | Observación |
|---|---|---|---|
| q0 | " | q1 | Apertura |
| q1 | S | q1 | Contenido distinto de salto y comilla |
| q1 | \\ | q2 | Inicio de escape |
| q2 | E | q1 | Escape consumido |
| q1 | " | q3 | Cierre y aceptación |

## 4. Caracteres
| Estado actual | Símbolo de entrada | Estado siguiente | Observación |
|---|---|---|---|
| q0 | ' | q1 | Apertura |
| q1 | carácter | q3 | Carácter simple |
| q1 | \\ | q2 | Inicio de escape |
| q2 | E | q3 | Escape consumido |
| q3 | ' | q4 | Cierre y aceptación |

## 5. Operadores aritméticos
| Estado actual | Símbolo de entrada | Estado siguiente | Observación |
|---|---|---|
| q0 | +, -, *, / o % | qA | Operador simple |
| qA | + o - | qA | Segundo signo para incremento/decremento |

## 6. Relacionales y asignación
| Estado actual | Símbolo de entrada | Estado siguiente | Observación |
|---|---|---|
| q0 | < o > | qR | Relacional simple |
| q0 | = | qAs | Asignación simple |
| q0 | ! | qN | Posible diferente de |
| qN | = | qR | Diferente de |
| q0 | +, -, * o / | qA | Posible asignación compuesta |
| qR | = | qR | <= o >= |
| qAs | = | qR | Igualdad |
| qA | = | qAs | Asignación compuesta |

## 7. Operadores lógicos
| Estado actual | Símbolo de entrada | Estado siguiente | Observación |
|---|---|---|
| q0 | ! | qL | Negación |
| q0 | & o \| | qP | Primer símbolo |
| qP | mismo símbolo | qL | && u || |

## 8. Comentarios
| Estado actual | Símbolo de entrada | Estado siguiente | Observación |
|---|---|---|
| q0 | / | q1 | Prefijo |
| q1 | / | qLinea | Comentario de línea |
| q1 | * | qBloque | Comentario de bloque |
| qLinea | texto | qLinea | Hasta salto de línea |
| qBloque | * | qAsterisco | Posible cierre |
| qBloque | otro | qBloque | Contenido |
| qAsterisco | / | qFinBloque | Cierre |
| qAsterisco | * | qAsterisco | Mantiene posible cierre |
| qAsterisco | otro | qBloque | Continúa contenido |

## 9. Delimitadores
| Estado actual | Símbolo de entrada | Estado siguiente | Observación |
|---|---|---|
| q0 | (, ), {, }, [, ], ;, , o . | q1 | Delimitador aceptado |
