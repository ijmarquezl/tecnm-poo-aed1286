i# Guía Práctica de C# (.NET 8): De la Sintaxis al Código
**Objetivo:** Aprender a escribir en C# las estructuras necesarias para resolver el Hito 1 sin conocimientos previos del lenguaje.

---

## 1. Tipos de Datos y Sintaxis Básica

En C#, toda instrucción termina con punto y coma (`;`). Los bloques de código se delimitan con llaves `{ }`.

### Tipos primitivos que usarás en este Hito:
| Tipo en C# | Para qué se usa | Ejemplo de valor |
| :--- | :--- | :--- |
| `int` | Números enteros (edades, cantidades) | `25`, `0`, `-3` |
| `decimal` | Moneda o cálculos financieros exactos | `100.50m`, `0.0m` *(Obligatorio terminar con sufijo `m`)* |
| `string` | Cadenas de texto | `"Ana"`, `"CTA-001"` |
| `bool` | Valores lógicos | `true`, `false` |

---

## 2. Anatomía de una Clase en C#

Crea una clase dentro de un archivo con el mismo nombre (ejemplo: `Persona.cs`):

```csharp
namespace Hito1_Encapsulamiento;

public class Persona
{
    // Aquí adentro se definen los campos, propiedades y métodos
}
```

### 3. Campos Privados vs. Propiedades Públicas
En C# no dejamos que el exterior toque las variables directamente. Usamos una combinación de Campo Privado (almacén) y Propiedad Pública (aduanero que revisa).

#### Paso 1: Declarar el Campo Privado
Por convención, inicia con guion bajo (_) y letra minúscula:

```csharp

private int _edad;

```
#### Paso 2: Declarar la Propiedad Pública con Validación
La propiedad lleva el mismo nombre pero con mayúscula inicial. Controla el acceso con get (lectura) y set (escritura):

```csharp
public int Edad
{
    get 
    {
        return _edad; // Devuelve el valor guardado
    }
    private set 
    {
        // 'value' representa el dato que intentan guardar
        if (value < 0 || value > 125)
        {
            // Detenemos la ejecución porque rompieron el invariante
            throw new ArgumentException("La edad debe estar entre 0 y 125 años.");
        }
        _edad = value; // Solo si cumple la regla, se guarda
    }
}
```

#### Auto-propiedades de solo lectura
Si un dato solo debe asignarse al nacer el objeto y nunca más modificarse (como el número de cuenta de un banco):

```csharp
public string NumeroCuenta { get; }
```
## 4. El Constructor y la Validación de Nacimiento
El constructor tiene el mismo nombre de la clase y no tiene tipo de retorno (ni siquiera void):

```csharp
public class Persona
{
    private string _nombre;
    private int _edad;

    // Propiedades...

    // Constructor
    public Persona(string nombre, int edad)
    {
        // Para validar textos vacíos usamos string.IsNullOrWhiteSpace:
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("El nombre no puede estar vacío.");
        }

        // Asignamos a través de la propiedad o directamente:
        Nombre = nombre.Trim(); // .Trim() elimina espacios sobrantes a los lados
        Edad = edad;           // Pasa por la validación de la propiedad Edad
    }
}
```

## 5. Sobrecarga de Constructores y Delegación con : this(...)
A veces quieres ofrecer dos formas de crear un objeto:

Con todos los datos iniciales.

Con datos mínimos, asignando valores por defecto seguros.

Nunca dupliques código de validación. Haz que el constructor secundario llame al constructor principal usando : this(...):

```csharp
public class CuentaBancaria
{
    public string NumeroCuenta { get; }
    public string Titular { get; }
    public decimal Saldo { get; private set; }

    // CONSTRUCTOR PRINCIPAL (El que valida todo)
    public CuentaBancaria(string numeroCuenta, string titular, decimal saldoInicial)
    {
        if (string.IsNullOrWhiteSpace(numeroCuenta))
            throw new ArgumentException("Número de cuenta requerido.");
        if (string.IsNullOrWhiteSpace(titular))
            throw new ArgumentException("Titular requerido.");
        if (saldoInicial < 0m)
            throw new ArgumentException("El saldo inicial no puede ser negativo.");

        NumeroCuenta = numeroCuenta.Trim();
        Titular = titular.Trim();
        Saldo = saldoInicial;
    }

    // CONSTRUCTOR SECUNDARIO (Delega al principal con saldo 0)
    public CuentaBancaria(string numeroCuenta, string titular)
        : this(numeroCuenta, titular, 0.0m)
    {
        // El cuerpo queda vacío; la delegación : this(...) hace todo el trabajo
    }
}
```

## 6. Métodos de Negocio y Lanzamiento de Excepciones
Para mutar o consultar el estado de un objeto se escriben métodos:

```csharp
public void Retirar(decimal monto)
{
    // Validación 1: Argumento inválido
    if (monto <= 0m)
    {
        throw new ArgumentException("El monto a retirar debe ser mayor a cero.");
    }

    // Validación 2: El argumento es positivo, pero el estado del objeto no lo permite
    if (monto > Saldo)
    {
        throw new InvalidOperationException("Fondos insuficientes para este retiro.");
    }

    Saldo -= monto; // Todo correcto, se descuenta el saldo
}
```

## 7. Comandos de Terminal en Codespaces
1. Entra al directorio del Hito:
```bash
cd Hito1_Encapsulamiento
```

2. Compila y ejecuta el Test Harness:
```bash
dotnet run
```

3. Si la terminal te muestra errores de compilación, lee la línea que te indica el compilador; usualmente es un punto y coma faltante o un nombre mal escrito.

