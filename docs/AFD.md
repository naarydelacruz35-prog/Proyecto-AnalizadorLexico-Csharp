# Diseños de AFD

Los AFD descritos son implementados por las clases de `Automatas/` mediante `IntentarReconocer`. La clasificación de una palabra reservada ocurre después de aceptar un identificador. Los escapes admitidos en cadenas y caracteres son `\n`, `\t`, `\r`, `\\`, `\"`, `\'` y `\0`.

## 1. Identificadores
Reconoce `(L|_)(L|D|_)*`. Inicial: `q0`. Aceptación: `q1`.

```mermaid
stateDiagram-v2
  [*] --> q0
  q0 --> q1: L o _
  q1 --> q1: L, D o _
```

## 2. Números
Reconoce enteros `D+` y reales `D+.D+`. Inicial: `q0`. Aceptación: `q1`, `q3`.

Una segunda marca decimal o letras a continuación de los dígitos se consume como una única secuencia errónea. Cuando hay letras, el error es identificador inválido; en los demás casos es número mal formado.

```mermaid
stateDiagram-v2
  [*] --> q0
  q0 --> q1: D
  q1 --> q1: D
  q1 --> q2: .
  q2 --> q3: D
  q3 --> q3: D
```

## 3. Cadenas
Reconoce texto entre comillas dobles y secuencias de escape. Inicial: `q0`. Aceptación: `q3`.

```mermaid
stateDiagram-v2
  [*] --> q0
  q0 --> q1: "
  q1 --> q1: S
  q1 --> q2: \\ 
  q2 --> q1: E
  q1 --> q3: "
```

## 4. Caracteres
Reconoce un carácter simple o escape entre comillas simples. Inicial: `q0`. Aceptación: `q4`.

```mermaid
stateDiagram-v2
  [*] --> q0
  q0 --> q1: '
  q1 --> q3: carácter
  q1 --> q2: \\ 
  q2 --> q3: E
  q3 --> q4: '
```

## 5. Operadores aritméticos
Reconoce `+`, `-`, `*`, `/`, `%`, `++` y `--`. Inicial: `q0`. Aceptación: `qA`.

```mermaid
stateDiagram-v2
  [*] --> q0
  q0 --> qA: + - * / %
  qA --> qA: + o - para ++ o --
```

## 6. Relacionales y asignación
Reconoce `==`, `!=`, `<`, `>`, `<=`, `>=`, `=`, `+=`, `-=`, `*=`, `/=`. Inicial: `q0`. Aceptación: `qR`, `qAs`.

```mermaid
stateDiagram-v2
  [*] --> q0
  q0 --> qR: < o >
  q0 --> qAs: =
  q0 --> qN: !
  qN --> qR: =
  q0 --> qA: + - * /
  qR --> qR: =
  qAs --> qR: =
  qA --> qAs: =
```

## 7. Operadores lógicos
Reconoce `&&`, `||` y `!`. Inicial: `q0`. Aceptación: `qL`.

Un `&` o `|` aislado llega a rechazo y se informa como carácter no reconocido.

```mermaid
stateDiagram-v2
  [*] --> q0
  q0 --> qL: !
  q0 --> qP: & o |
  qP --> qL: mismo símbolo
```

## 8. Comentarios
Reconoce comentarios de línea `//` y bloque `/*...*/`. Inicial: `q0`. Aceptación: `qLinea`, `qFinBloque`.

```mermaid
stateDiagram-v2
  [*] --> q0
  q0 --> q1: /
  q1 --> qLinea: /
  q1 --> qBloque: *
  qLinea --> qLinea: texto
  qBloque --> qAsterisco: *
  qBloque --> qBloque: contenido
  qAsterisco --> qFinBloque: /
  qAsterisco --> qAsterisco: *
  qAsterisco --> qBloque: otro
```

## 9. Delimitadores
Reconoce `(`, `)`, `{`, `}`, `[`, `]`, `;`, `,` y `.`. Inicial: `q0`. Aceptación: `q1`.

```mermaid
stateDiagram-v2
  [*] --> q0
  q0 --> q1: delimitador
```
