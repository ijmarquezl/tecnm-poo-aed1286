using System;
using System.Collections.Generic;
using Hito2_HerenciaPolimorfismo;

Console.WriteLine("=================================================");
Console.WriteLine("   TEST HARNESS - HITO 2: POO (AED-1286)         ");
Console.WriteLine("   Herencia, Clases Abstractas e Interfaces      ");
Console.WriteLine("=================================================\n");

int fallos = 0;

// Test 1: Instanciacion y calculos de clases derivadas
try
{
    FiguraGeometrica c = new Circulo("Circulo Rojo", 5.0);
    FiguraGeometrica r = new Rectangulo("Rectangulo Azul", 4.0, 6.0);

    double areaEsperadaC = Math.PI * 25.0;
    if (Math.Abs(c.CalcularArea() - areaEsperadaC) > 0.001)
        throw new Exception("Calculo incorrecto en area de Circulo.");

    if (Math.Abs(r.CalcularArea() - 24.0) > 0.001)
        throw new Exception("Calculo incorrecto en area de Rectangulo.");

    Console.WriteLine("✅ Test 1: Clases derivadas calculan areas correctamente.");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Test 1 Fallo: {ex.Message}");
    fallos++;
}

// Test 2: Invariantes en clases derivadas
try
{
    new Circulo("Circulo Invalido", -2.0);
    Console.WriteLine("❌ Test 2 Fallo: Permitio crear Circulo con radio negativo.");
    fallos++;
}
catch (ArgumentException)
{
    Console.WriteLine("✅ Test 2: Invariante defendido en clase derivada.");
}

// Test 3: Polimorfismo en coleccion heterogenea
try
{
    var figuras = new List<FiguraGeometrica>
    {
        new Circulo("C1", 2.0),
        new Rectangulo("R1", 3.0, 5.0),
        new Circulo("C2", 3.0)
    };

    double sumaAreas = 0;
    foreach (var fig in figuras)
    {
        sumaAreas += fig.CalcularArea();
    }

    if (sumaAreas <= 0)
        throw new Exception("Error al procesar coleccion polimorfica.");
    Console.WriteLine("✅ Test 3: Polimorfismo dinamico operando en coleccion heterogenea.");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Test 3 Fallo: {ex.Message}");
    fallos++;
}

// Test 4: Implementacion de interfaz IDibujable
try
{
    IDibujable dibujable = new Rectangulo("R2", 2.0, 2.0);
    string representacion = dibujable.Dibujar();
    if (string.IsNullOrWhiteSpace(representacion))
        throw new Exception("El metodo Dibujar() no devolvio representacion valida.");
    Console.WriteLine("✅ Test 4: Contrato de interfaz IDibujable cumplido.");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Test 4 Fallo: {ex.Message}");
    fallos++;
}

Console.WriteLine($"\nRESUMEN: {4 - fallos}/4 pruebas superadas.");
if (fallos == 0)
    Console.WriteLine("🎉 Hito 2 acreditado a nivel de codigo.");
