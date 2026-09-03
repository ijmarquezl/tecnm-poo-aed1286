using System;
using System.IO;
using Hito4_ExcepcionesPersistencia;

Console.WriteLine("=================================================");
Console.WriteLine("   TEST HARNESS - HITO 4: POO (AED-1286)         ");
Console.WriteLine("   Excepciones de Negocio y Persistencia I/O     ");
Console.WriteLine("=================================================\n");

int fallos = 0;
string archivoPrueba = "catalogo_prueba.json";
if (File.Exists(archivoPrueba))
    File.Delete(archivoPrueba);

var servicio = new RepositorioProductos(archivoPrueba);

// Test 1: Insercion valida de entidad de dominio
try
{
    servicio.Registrar(new Producto("P001", "Laptop Gamer", 15000m, 5));
    if (servicio.Obtener("P001").Stock != 5)
        throw new Exception("No se recupero el producto correctamente.");
    Console.WriteLine("✅ Test 1: Entidad de dominio registrada con exito.");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Test 1 Fallo: {ex.Message}");
    fallos++;
}

// Test 2: Excepcion personalizada de clave duplicada
try
{
    servicio.Registrar(new Producto("P001", "Laptop Duplicada", 12000m, 2));
    Console.WriteLine("❌ Test 2 Fallo: Se permitio producto con codigo duplicado.");
    fallos++;
}
catch (ProductoDuplicadoException)
{
    Console.WriteLine("✅ Test 2: Excepcion personalizada ProductoDuplicadoException capturada.");
}

// Test 3: Excepcion personalizada de no encontrado
try
{
    servicio.Obtener("P999");
    Console.WriteLine("❌ Test 3 Fallo: No arrojo excepcion ante codigo inexistente.");
    fallos++;
}
catch (ProductoNoEncontradoException)
{
    Console.WriteLine("✅ Test 3: Excepcion personalizada ProductoNoEncontradoException capturada.");
}

// Test 4: Persistencia y recuperacion desde archivo en disco
try
{
    servicio.GuardarEnDisco();
    if (!File.Exists(archivoPrueba))
        throw new Exception("No se creo el archivo fisico en disco.");

    var servicioLectura = new RepositorioProductos(archivoPrueba);
    servicioLectura.CargarDesdeDisco();

    var prodRecuperado = servicioLectura.Obtener("P001");
    if (prodRecuperado.Precio != 15000m)
        throw new Exception("Los datos recuperados del archivo no coinciden.");

    Console.WriteLine("✅ Test 4: Serializacion y deserializacion I/O completada con exito.");
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Test 4 Fallo: {ex.Message}");
    fallos++;
}
finally
{
    if (File.Exists(archivoPrueba))
        File.Delete(archivoPrueba);
}

Console.WriteLine($"\nRESUMEN: {4 - fallos}/4 pruebas superadas.");
if (fallos == 0)
    Console.WriteLine("🎉 Hito 4 acreditado a nivel de codigo. Proyecto concluido.");
