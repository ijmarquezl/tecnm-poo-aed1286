# Lección 3: Tipos de Valor Matemático y Sobrecarga de Operadores
Asignatura: Programación Orientada a Objetos (AED-1286)
Nivel: Conceptos Fundamentales desde Cero

---

## 1. El Problema: El Código Feo y Poco Natural

En la vida real y en matemáticas, cuando sumas dos entidades numéricas complejas (como vectores, números complejos o matrices), escribes una expresión natural:

C = A + B

Sin embargo, en muchos lenguajes o cuando no se diseña correctamente con POO, los programadores se ven obligados a escribir métodos verbosos como:

Matriz2D c = a.SumarCon(b);
Matriz2D r = a.MultiplicarPorEscalar(2.0);

Cuando una expresión matemática combina varias operaciones, el código se vuelve ilegible:
Matriz2D res = a.SumarCon(b).MultiplicarPorEscalar(3.0).RestarCon(d);

La Sobrecarga de Operadores resuelve este problema de raíz. Permite que tus propios tipos de datos u objetos personalizados redefinan el significado de los símbolos del lenguaje (+, -, *, ==) para que se comporten como si fueran tipos nativos de la computadora.

---

## 2. Las Dos Reglas de Oro en Álgebra de Objetos

### Regla A: Inmutabilidad (No destruyas los operandos originales)
Cuando en primaria calculas 5 + 3, el resultado es 8.
El número 5 no se convierte en 8, ni el número 3 deja de existir. El operador toma dos valores de entrada y genera un TERCER valor completamente nuevo.

En POO matricial aplica exactamente lo mismo:
- Si ejecutas: C = A + B;
- La matriz A debe permanecer intacta.
- La matriz B debe permanecer intacta.
- El operador suma debe crear, llenar y retornar una NUEVA instancia de Matriz2D.

Modificar los datos internos de A o B dentro de un operador es uno de los peores errores de diseño en desarrollo de software, ya que provoca efectos secundarios impredecibles en el resto del sistema.

### Regla B: Defensa de Dimensiones Incompatibles
En álgebra lineal no puedes sumar dos matrices arbitrarias.
Para que dos matrices puedan sumarse, deben tener idéntica cantidad de filas e idéntica cantidad de columnas.

Si un programador intenta sumar una matriz de 2x2 con una matriz de 3x3:
- El operador jamás debe ignorar el error.
- Jamás debe rellenar con ceros silenciosamente.
- Debe abortar la ejecución inmediatamente arrojando una excepción (InvalidOperationException), protegiendo el invariante matemático.

---

## 3. ¿Qué es un Indexador? (Acceso tipo arreglo)

Normalmente, para leer un valor dentro de un objeto usas métodos o propiedades:
double dato = miMatriz.ObtenerElemento(0, 1);

Un Indexador permite que el objeto en sí mismo sea tratado sintácticamente como si fuera un arreglo multidimensional:
miMatriz[0, 1] = 5.4;
double dato = miMatriz[0, 1];

Esto permite que la encapsulación proteja la memoria interna mientras expone una interfaz limpia y cómoda al desarrollador.

---

## 4. Preguntas de Autoevaluación
1. ¿Por qué el operador C = A + B debe devolver una nueva instancia en lugar de alterar los datos de A?
2. Si intentas sumar dos matrices de dimensiones incompatibles, ¿qué debe suceder conceptualmente?
3. ¿Cuál es la ventaja de legibilidad al usar indexadores en lugar de métodos Get/Set convencionales?
