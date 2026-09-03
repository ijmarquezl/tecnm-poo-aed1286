using System;
using Hito3_SobrecargaOperadores;

Console.WriteLine("=================================================");
Console.WriteLine("   TEST HARNESS - HITO 3: POO (AED-1286)         ");
Console.WriteLine("   Sobrecarga de Operadores y Matrices 2D        ");
Console.WriteLine("=================================================\n");

int fallos = 0;

// Test 1: Creacion y lectura de matriz
try
{
    var m = new Matriz2D(2, 2);
    m[0, 0] = 1.0; m[0, 1] = 2.0;
    m[1, 0] = 3.0; m[1, 1] = 4.0;
    if (m[1, 0] != 3.0)
        throw new Exception("Fallo en el indexador de la matriz.");
    Console.WriteLine("✅ Test 1: Matriz instanciada e indexada correctamente.");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Test 1 Fallo: {ex.Message}");
    fallos++;
}

// Test 2: Sobrecarga del operador suma (+)
try
{
    var a = new Matriz2D(2, 2);
    a[0, 0] = 1.0; a[0, 1] = 1.0;
    a[1, 0] = 2.0; a[1, 1] = 2.0;

    var b = new Matriz2D(2, 2);
    b[0, 0] = 3.0; b[0, 1] = 4.0;
    b[1, 0] = 5.0; b[1, 1] = 6.0;

    Matriz2D c = a + b;
    if (c[0, 0] != 4.0 || c[1, 1] != 8.0)
        throw new Exception("Resultado incorrecto en la suma de matrices.");
    Console.WriteLine("✅ Test 2: Sobrecarga de operador (+) verificada.");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Test 2 Fallo: {ex.Message}");
    fallos++;
}

// Test 3: Bloqueo de suma con dimensiones incompatibles
try
{
    var m1 = new Matriz2D(2, 2);
    var m2 = new Matriz2D(3, 3);
    var resultado = m1 + m2;
    Console.WriteLine("❌ Test 3 Fallo: Permitio sumar matrices de distinta dimension.");
    fallos++;
}
catch (InvalidOperationException)
{
    Console.WriteLine("✅ Test 3: Invariante defendido (rechazo suma incompatible).");
}

// Test 4: Sobrecarga de multiplicacion por escalar (*)
try
{
    var a = new Matriz2D(2, 2);
    a[0, 0] = 2.0; a[0, 1] = 3.0;
    a[1, 0] = 4.0; a[1, 1] = 5.0;

    Matriz2D r = a * 2.0;
    if (r[0, 0] != 4.0 || r[1, 1] != 10.0)
        throw new Exception("Multiplicacion escalar incorrecta.");
    Console.WriteLine("✅ Test 4: Sobrecarga de operador (*) escalar verificada.");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Test 4 Fallo: {ex.Message}");
    fallos++;
}

Console.WriteLine($"\nRESUMEN: {4 - fallos}/4 pruebas superadas.");
if (fallos == 0)
    Console.WriteLine("🎉 Hito 3 acreditado a nivel de codigo.");
