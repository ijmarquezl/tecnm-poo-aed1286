namespace Hito2_HerenciaPolimorfismo;

public abstract class FiguraGeometrica
{
    public string Nombre { get; }

    protected FiguraGeometrica(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre de la figura es obligatorio.");
        Nombre = nombre.Trim();
    }

    public abstract double CalcularArea();
    public abstract double CalcularPerimetro();
}
