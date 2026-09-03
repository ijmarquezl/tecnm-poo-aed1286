using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Hito4_ExcepcionesPersistencia;

public class RepositorioProductos
{
    private readonly List<Producto> _productos = new();
    private readonly string _rutaArchivo;

    public RepositorioProductos(string rutaArchivo)
    {
        _rutaArchivo = rutaArchivo;
    }

    // TODO: Implementar Registrar(Producto p)
    // Validar si ya existe el codigo y lanzar ProductoDuplicadoException.

    // TODO: Implementar Obtener(string codigo)
    // Si no existe, lanzar ProductoNoEncontradoException.

    // TODO: Implementar GuardarEnDisco() usando JsonSerializer.Serialize y File.WriteAllText.

    // TODO: Implementar CargarDesdeDisco() usando File.ReadAllText y JsonSerializer.Deserialize.
}
