# Guía Práctica de C# (.NET 8): Operadores e Indexadores
Objetivo: Implementar arreglos bidimensionales, indexadores y sobrecarga de operadores estáticos en C#.

---

## 1. Arreglos Multidimensionales en C#

En C#, una matriz bidimensional nativa se declara con una coma dentro de los corchetes [,].
No confundir con los arreglos escalonados (jagged arrays [][]).

Ejemplo de declaración e instanciación interna:
private readonly double[,] _datos;

public Matriz2D(int filas, int columnas)
{
    if (filas <= 0 || columnas <= 0)
        throw new ArgumentException("Las dimensiones deben ser mayores a cero.");

    Filas = filas;
    Columnas = columnas;
    _datos = new double[filas, columnas]; // Matriz en memoria inicializada en ceros
}

---

## 2. Sintaxis de un Indexador con 'this'

El indexador se declara utilizando la palabra reservada 'this' seguida de los parámetros de acceso entre corchetes:

public double this[int fila, int columna]
{
    get
    {
        return _datos[fila, columna];
    }
    set
    {
        _datos[fila, columna] = value;
    }
}

O en su versión compacta de expresión:
public double this[int fila, int columna]
{
    get => _datos[fila, columna];
    set => _datos[fila, columna] = value;
}

---

## 3. Anatomía de la Sobrecarga de Operadores

En C#, todo operador sobrecargado cumple con tres reglas obligatorias de sintaxis:
1. Debe ser público (public).
2. Debe ser estático (static): Pertenece al tipo de dato, no a una instancia particular.
3. Utiliza la palabra clave 'operator' seguida del símbolo a sobrecargar.

Firma general:
public static TipoRetorno operator +(TipoParametro1 a, TipoParametro2 b)

---

## 4. Implementación del Operador Suma (+) entre Matrices

El operador recibe los dos operandos por parámetro, valida sus dimensiones y devuelve una nueva matriz:

public static Matriz2D operator +(Matriz2D a, Matriz2D b)
{
    // 1. Validar invariante dimensional
    if (a.Filas != b.Filas || a.Columnas != b.Columnas)
    {
        throw new InvalidOperationException("No se pueden sumar matrices con dimensiones incompatibles.");
    }

    // 2. Crear una nueva matriz para el resultado
    Matriz2D resultado = new Matriz2D(a.Filas, a.Columnas);

    // 3. Sumar elemento por elemento
    for (int i = 0; i < a.Filas; i++)
    {
        for (int j = 0; j < a.Columnas; j++)
        {
            resultado[i, j] = a[i, j] + b[i, j];
        }
    }

    // 4. Retornar la nueva instancia inmutable
    return resultado;
}

---

## 5. Implementación de Multiplicación por Escalar (*)

Un operador puede recibir parámetros de diferente tipo. En este caso, una Matriz y un double:

public static Matriz2D operator *(Matriz2D a, double escalar)
{
    Matriz2D resultado = new Matriz2D(a.Filas, a.Columnas);

    for (int i = 0; i < a.Filas; i++)
    {
        for (int j = 0; j < a.Columnas; j++)
        {
            resultado[i, j] = a[i, j] * escalar;
        }
    }

    return resultado;
}

---

## 6. Comprobación y Ejecución

Para validar tu implementación en la terminal de Codespaces:

cd Hito3_SobrecargaOperadores
dotnet run

El Test Harness de Program.cs ejecutará las 4 pruebas de álgebra lineal:
1. Instanciación y lectura con indexador.
2. Suma correcta de matrices 2x2.
3. Rechazo estricto de suma entre matrices de dimensiones distintas.
4. Multiplicación por escalar.
