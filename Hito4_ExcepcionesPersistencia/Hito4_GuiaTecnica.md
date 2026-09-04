# Guía Práctica de C# (.NET 8): Excepciones Personalizadas y Serialización JSON
Objetivo: Crear excepciones propias heredando de Exception y persistir colecciones en disco usando System.Text.Json.

---

## 1. Creación de Excepciones Propias en C#

Toda excepción personalizada en C# debe heredar directamente de la clase base Exception.
Se define un constructor que recibe los datos relevantes y se los transfiere al constructor de la clase base mediante ': base(...)':

using System;

namespace Hito4_ExcepcionesPersistencia;

public class ProductoDuplicadoException : Exception
{
    public ProductoDuplicadoException(string codigo) 
        : base($"Ya existe un producto registrado con el codigo: {codigo}")
    {
    }
}

public class ProductoNoEncontradoException : Exception
{
    public ProductoNoEncontradoException(string codigo) 
        : base($"No se encontro ningun producto con el codigo: {codigo}")
    {
    }
}

---

## 2. La Entidad de Dominio (Producto.cs)

Una entidad simple e inmutable para almacenar los datos de cada artículo del catálogo:

namespace Hito4_ExcepcionesPersistencia;

public class Producto
{
    public string Codigo { get; }
    public string Nombre { get; }
    public decimal Precio { get; }
    public int Stock { get; }

    public Producto(string codigo, string nombre, decimal precio, int stock)
    {
        if (string.IsNullOrWhiteSpace(codigo))
            throw new ArgumentException("Codigo obligatorio.");
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("Nombre obligatorio.");
        if (precio <= 0m)
            throw new ArgumentException("Precio debe ser mayor a cero.");
        if (stock < 0)
            throw new ArgumentException("Stock no puede ser negativo.");

        Codigo = codigo.Trim().ToUpper();
        Nombre = nombre.Trim();
        Precio = precio;
        Stock = stock;
    }
}

---

## 3. Métodos del Repositorio en Memoria (Colección List<T>)

Dentro de RepositorioProductos.cs manejas una lista privada:

private readonly List<Producto> _productos = new();

Para registrar defendiendo la regla de no duplicados:
public void Registrar(Producto p)
{
    // Buscamos si ya existe alguien con el mismo código
    bool existe = _productos.Exists(x => x.Codigo == p.Codigo);
    if (existe)
    {
        throw new ProductoDuplicadoException(p.Codigo);
    }

    _productos.Add(p);
}

Para consultar defendiendo la regla de existencia:
public Producto Obtener(string codigo)
{
    string codigoBuscado = codigo?.Trim().ToUpper() ?? "";
    Producto? encontrado = _productos.Find(x => x.Codigo == codigoBuscado);

    if (encontrado == null)
    {
        throw new ProductoNoEncontradoException(codigo);
    }

    return encontrado;
}

---

## 4. Persistencia en Disco con System.Text.Json

En .NET 8 no necesitas instalar librerías externas; utilizas System.Text.Json y System.IO.

### Guardar la lista completa en un archivo JSON:

public void GuardarEnDisco()
{
    // Opciones para que el JSON quede formateado y legible (con saltos de línea)
    var opciones = new JsonSerializerOptions { WriteIndented = true };

    // Convertimos la lista de objetos a texto JSON
    string json = JsonSerializer.Serialize(_productos, opciones);

    // Escribimos el texto en el archivo físico
    File.WriteAllText(_rutaArchivo, json);
}

### Leer y restaurar los objetos desde el archivo:

public void CargarDesdeDisco()
{
    if (!File.Exists(_rutaArchivo))
    {
        return; // Si el archivo aún no existe en disco, no hay nada que cargar
    }

    // Leemos todo el texto del archivo
    string json = File.ReadAllText(_rutaArchivo);

    // Reconstruimos la lista de objetos Producto
    var productosCargados = JsonSerializer.Deserialize<List<Producto>>(json);

    if (productosCargados != null)
    {
        _productos.Clear();
        _productos.AddRange(productosCargados);
    }
}

---

## 5. Comprobación y Cierre del Curso

Para validar tu implementación en la terminal de Codespaces:

cd Hito4_ExcepcionesPersistencia
dotnet run

El Test Harness verificará de forma consecutiva:
1. Inserción exitosa de un producto en la lista.
2. Captura obligatoria de ProductoDuplicadoException ante claves repetidas.
3. Captura obligatoria de ProductoNoEncontradoException ante consultas inválidas.
4. Serialización al archivo en disco, recarga en una nueva instancia y validación de fidelidad de datos.
