# Lección 1: El Pensamiento Orientado a Objetos (POO)
**Asignatura:** Programación Orientada a Objetos (AED-1286)  
**Nivel:** Fundamentos Conceptuales desde Cero  

---

## 1. ¿Por qué cambiar la forma de programar?

En tus materias iniciales de programación, aprendiste a programar de forma **secuencial** o **estructurada**:
1. Tenías un bloque principal donde declarabas variables sueltas (`nombre`, `edad`, `saldo`).
2. Escribías funciones que recibían esas variables y las modificaban.

### El problema de ese enfoque
Imagina un sistema para una clínica médica. Si tienes variables sueltas:
* Una función podría modificar la `edad` a `-15`.
* Otra función podría borrar el `nombre` mientras el paciente está en quirófano.
* Nada en el código impide que los datos terminen con valores imposibles o corruptos.

El paradigma de **Programación Orientada a Objetos (POO)** nació para resolver esto unificando los datos y las operaciones que pueden manipularlos dentro de una misma frontera.

---

## 2. Los Dos Conceptos Fundamentales: Molde vs. Realidad

### ¿Qué es una Clase?
Una **Clase** es simplemente un molde o plano arquitectónico. No existe físicamente en la memoria como una entidad viva; es la definición formal de lo que algo debe ser y cómo debe comportarse.
* *Ejemplo:* El plano de una casa no es la casa. En el plano no puedes dormir ni resguardarte de la lluvia; solo dice cuántas ventanas y puertas tendrá la casa cuando alguien la construya.

### ¿Qué es un Objeto?
Un **Objeto** (o instancia) es la entidad real, viva, construida en la memoria de la computadora a partir del molde.
* *Ejemplo:* Con el mismo plano arquitectónico (Clase), puedes construir tres casas reales (Objetos): la casa de la calle 5, la casa de la esquina y la casa pintada de verde. Cada una tiene sus propias paredes y puertas independientes.

---

## 3. Las Tres Reglas de Oro del Hito 1

### Regla A: El Invariante de Dominio (La defensa de la realidad)
Un **invariante** es una regla de la realidad que un objeto jamás debe romper:
* Un ser humano no puede tener una edad menor a cero ni de trescientos años.
* Un producto en una tienda no puede tener un precio negativo.
* Una cuenta bancaria de débito no puede permitir que retires dinero que no tienes.

En POO bien diseñado, **el objeto es el único responsable de defender sus invariantes**. Si alguien intenta darle datos absurdos, el objeto debe rechazar la orden de inmediato.

### Regla B: Encapsulamiento (La caja fuerte)
Encapsular significa esconder las piezas mecánicas internas y ofrecer al exterior solo una botonera segura.
* *Ejemplo cotidiano:* Cuando manejas un automóvil, no metes las manos al motor para inyectar gasolina manualmente en las bujías. Presionas el pedal del acelerador (interfaz pública). El motor controla la inyección de forma segura sin exponer los engranes (estado privado).
* **El peligro:** Si dejas los datos abiertos al público, cualquier programador descuidado puede corromper el sistema asignando valores directos sin pasar por ninguna revisión.

### Regla C: El Constructor (El certificado de nacimiento)
El **Constructor** es un bloque de código especial que se ejecuta única y exclusivamente en el instante en que el objeto es creado.
* Su misión es una sola: asegurar que el objeto **nazca completo, sano y con datos válidos**.
* Si al intentar crear una `Persona` te entregan un nombre vacío o una edad negativa, el constructor debe **abortar el nacimiento**. Es preferible cancelar la creación de un objeto antes que tener un objeto zombi rondando por la memoria con datos corruptos.

---

## 4. Resumen Visual del Flujo

```text
[ Datos Externos ] 
        │
        ▼ (Pasan por el Constructor / Interfaz Pública)
┌──────────────────────────────────────┐
│  CLASE (La Caja Fuerte)             │
│   • Revisa invariantes (¿edad >= 0?) │
│   • Si es válido  -> Guarda en campo │
│   • Si es inválido -> Lanza Alerta   │
└──────────────────────────────────────┘

```

---
### 5. Preguntas de Autoevaluación
¿Cuál es la diferencia exacta entre una Clase y un Objeto?

Si un objeto permite que su saldo sea negativo por descuido del programador, ¿qué principio de POO se violó?

¿Por qué un constructor debe rechazar valores erróneos en lugar de guardar un valor por defecto sin avisar?
