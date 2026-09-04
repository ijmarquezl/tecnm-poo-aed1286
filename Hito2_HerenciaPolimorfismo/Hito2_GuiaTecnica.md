# Guía Práctica de C# (.NET 8): Herencia y Polimorfismo
**Objetivo:** Implementar herencia, clases abstractas, contratos de interfaz y llamadas al constructor base en C#.

---

## 1. Sintaxis de Herencia en C#

En C#, tanto la herencia de clases como la implementación de interfaces se especifican con el operador dos puntos (`:`).

```csharp
// La clase Derivada hereda de ClaseBase e implementa IContrato
public class Derivada : ClaseBase, IContrato
{
}
```

## 2. Invocación del Constructor Padre con : base(...)
Cuando una clase derivada nace, primero debe nacer su clase padre.

Si la clase base exige datos en su constructor, la clase hija debe recibirlos y transferírselos usando : base(...):

```csharp


// CLASE BASE
public abstract class FiguraGeometrica
{
    public string Nombre { get; }

    // Constructor protegido: solo sus clases hijas pueden invocarlo
    protected FiguraGeometrica(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
            throw new ArgumentException("El nombre es requerido.");
        Nombre = nombre.Trim();
    }
}

// CLASE DERIVADA
public class Circulo : FiguraGeometrica
{
    public double Radio { get; }

    // Recibe 'nombre' y 'radio', pero le pasa 'nombre' a FiguraGeometrica
    public Circulo(string nombre, double radio) : base(nombre)
    {
        if (radio <= 0)
            throw new ArgumentException("El radio debe ser mayor a cero.");
        Radio = radio;
    }
}
```

## 3. Métodos Abstractos y la Palabra Clave override
Cuando una clase base declara un método como abstract, no lleva llaves { }, sino punto y coma.

La clase hija está obligada a implementarlo usando explícitamente la palabra clave override:

```csharp

public abstract class FiguraGeometrica
{
    // Solo declaramos la firma (el "qué", no el "cómo")
    public abstract double CalcularArea();
}

public class Circulo : FiguraGeometrica
{
    public double Radio { get; }

    public Circulo(string nombre, double radio) : base(nombre)
    {
        Radio = radio;
    }

    // Usamos 'override' para cumplir con el contrato de la clase padre
    public override double CalcularArea()
    {
        return Math.PI * Radio * Radio;
    }
}
```

```note
Nota técnica en C#: Si olvidas escribir override, el compilador de C# arrojará un error indicando que no estás implementando el miembro abstracto de la base.
```

## 4. Definición e Implementación de una Interfaz
Por convención estándar en el ecosistema .NET, todas las interfaces inician con la letra I mayúscula (ejemplo: IDibujable, IDisposable).

Definir la Interfaz (IDibujable.cs):
```csharp

namespace Hito2_HerenciaPolimorfismo;

public interface IDibujable
{
    // No lleva modificador 'public' dentro de la interfaz; es pública por defecto
    string Dibujar();
}
```

Implementar la Interfaz en una Clase:
```csharp


public class Rectangulo : FiguraGeometrica, IDibujable
{
    public double Base { get; }
    public double Altura { get; }

    public Rectangulo(string nombre, double ancho, double alto) : base(nombre)
    {
        if (ancho <= 0 || alto <= 0)
            throw new ArgumentException("Las dimensiones deben ser mayores a cero.");
        Base = ancho;
        Altura = alto;
    }

    public override double CalcularArea() => Base * Altura;
    public override double CalcularPerimetro() => (Base * 2) + (Altura * 2);

    // Cumplimiento del contrato IDibujable
    public string Dibujar()
    {
        return $"Dibujando un rectangulo de {Base}x{Altura}";
    }
}
```

## 5. Polimorfismo Dinámico en Colecciones (List<T>)
Para almacenar objetos de distintas clases derivadas bajo una misma lista, utiliza el tipo base abstracto como tipo genérico:

```csharp

using System.Collections.Generic;

// Colección heterogénea: acepta Circulo, Rectangulo o cualquier subclase
List<FiguraGeometrica> figuras = new List<FiguraGeometrica>();

figuras.Add(new Circulo("C1", 5.0));
figuras.Add(new Rectangulo("R1", 4.0, 6.0));

// El polimorfismo despacha la llamada correcta automáticamente
foreach (FiguraGeometrica f in figuras)
{
    Console.WriteLine($"{f.Nombre} tiene un área de: {f.CalcularArea()}");
}
```

## 6. Comprobación y Ejecución

Dentro de la terminal de Codespaces:
```bash


cd Hito2_HerenciaPolimorfismo
dotnet run
```

Una vez que completes los archivos Circulo.cs y Rectangulo.cs respetando estas reglas, el Test Harness evaluará las 4 aserciones polimórficas y mostrará las pruebas en verde.
