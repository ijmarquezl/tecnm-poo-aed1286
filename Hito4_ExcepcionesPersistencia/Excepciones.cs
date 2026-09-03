using System;

namespace Hito4_ExcepcionesPersistencia;

public class ProductoDuplicadoException : Exception
{
    public ProductoDuplicadoException(string codigo) 
        : base($"Ya existe un producto registrado con el codigo: {codigo}") { }
}

public class ProductoNoEncontradoException : Exception
{
    public ProductoNoEncontradoException(string codigo) 
        : base($"No se encontro ningun producto con el codigo: {codigo}") { }
}
