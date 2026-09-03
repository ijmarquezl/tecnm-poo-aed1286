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
        if (precio <= 0)
            throw new ArgumentException("Precio debe ser mayor a cero.");
        if (stock < 0)
            throw new ArgumentException("Stock no puede ser negativo.");

        Codigo = codigo.Trim().ToUpper();
        Nombre = nombre.Trim();
        Precio = precio;
        Stock = stock;
    }
}
