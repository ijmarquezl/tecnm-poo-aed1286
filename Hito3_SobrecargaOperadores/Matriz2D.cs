namespace Hito3_SobrecargaOperadores;

public class Matriz2D
{
    private readonly double[,] _datos;
    public int Filas { get; }
    public int Columnas { get; }

    public Matriz2D(int filas, int columnas)
    {
        if (filas <= 0 || columnas <= 0)
            throw new ArgumentException("Las dimensiones deben ser mayores a cero.");
        Filas = filas;
        Columnas = columnas;
        _datos = new double[filas, columnas];
    }

    public double this[int i, int j]
    {
        get => _datos[i, j];
        set => _datos[i, j] = value;
    }

    // TODO: Sobrecargar operador suma (+)
    // public static Matriz2D operator +(Matriz2D a, Matriz2D b)
    // Validar a.Filas == b.Filas && a.Columnas == b.Columnas; si no, lanzar InvalidOperationException.

    // TODO: Sobrecargar operador multiplicacion escalar (*)
    // public static Matriz2D operator *(Matriz2D a, double escalar)
}
