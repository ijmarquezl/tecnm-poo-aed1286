using System;
using Hito1_Encapsulamiento;

Console.WriteLine("=================================================");
Console.WriteLine("   TEST HARNESS - HITO 1: POO (AED-1286)         ");
Console.WriteLine("   Clases, Encapsulamiento y Constructores       ");
Console.WriteLine("=================================================\n");

int fallos = 0;

// Test 1: Persona válida y mutación controlada
try
{
    var p = new Persona("Ana Lopez", 20);
    p.CumplirAnios();
    if (p.Edad != 21)
        throw new Exception("CumplirAnios no incremento la edad.");
    Console.WriteLine("✅ Test 1: Persona valida y mutacion controlada.");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Test 1 Fallo: {ex.Message}");
    fallos++;
}

// Test 2: Invariante de edad negativa (ArgumentException)
try
{
    var pInvalida = new Persona("Carlos", -5);
    Console.WriteLine("❌ Test 2 Fallo: Se permitio crear persona con edad negativa.");
    fallos++;
}
catch (ArgumentException)
{
    Console.WriteLine("✅ Test 2: Invariante defendido (rechazo edad negativa).");
}

// Test 3: Cuenta con constructor por delegacion (: this)
try
{
    var c1 = new CuentaBancaria("CTA-001", "Ana Lopez");
    if (c1.Saldo != 0.0m)
        throw new Exception("El saldo inicial por defecto debe ser 0.0m.");
    Console.WriteLine("✅ Test 3: Delegacion de constructores opero correctamente.");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Test 3 Fallo: {ex.Message}");
    fallos++;
}

// Test 4: Bloqueo de sobregiro (InvalidOperationException)
try
{
    var c2 = new CuentaBancaria("CTA-002", "Pedro Ruiz", 500.0m);
    c2.Retirar(600.0m);
    Console.WriteLine("❌ Test 4 Fallo: Se permitio retiro mayor al saldo.");
    fallos++;
}
catch (InvalidOperationException)
{
    Console.WriteLine("✅ Test 4: Invariante defendido (rechazo sobregiro).");
}

Console.WriteLine($"\nRESUMEN: {4 - fallos}/4 pruebas superadas.");
if (fallos == 0)
    Console.WriteLine("🎉 Hito 1 acreditado a nivel de codigo.");
