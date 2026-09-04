# Lección 4: Manejo Robusto de Errores y Persistencia en Disco
Asignatura: Programación Orientada a Objetos (AED-1286)
Nivel: Conceptos Fundamentales desde Cero

---

## 1. El Problema: El Software Frágil y Olvidadizo

Hasta el Hito 3, tu software vivía únicamente en la memoria RAM:
1. Si apagabas la computadora o cerrabas el programa, todos los datos creados se desvanecían por completo.
2. Si algo salía mal (un dato corrupto o una falla de disco), el programa simplemente colapsaba o mostraba códigos de error confusos que nadie entendía.

En el mundo profesional, un sistema debe cumplir dos requisitos obligatorios:
- Resiliencia: Saber recuperarse con elegancia cuando ocurre un imprevisto.
- Persistencia: Ser capaz de guardar su estado en un medio no volátil (disco duro) para que los datos sobrevivan a los reinicios.

---

## 2. Excepciones de Negocio: Darle Voz al Dominio

¿Qué es una excepción?
Es una señal de alerta que interrumpe el flujo normal del programa cuando sucede una situación extraordinaria que el código actual no puede resolver por sí mismo.

El error de usar excepciones genéricas:
Muchos programadores novatos lanzan la clase Exception para todo:
throw new Exception("Error");

Esto es un pésimo diseño porque el código que recibe la falla no sabe si el problema fue:
- Que falló la conexión a internet.
- Que el disco duro está lleno.
- O que un usuario intentó registrar un producto con un código que ya existía.

La solución en POO: Jerarquías de Excepciones Propias
Creamos clases de error que representan situaciones concretas de nuestro negocio:
- ProductoDuplicadoException
- ProductoNoEncontradoException

Esto permite atrapar de forma quirúrgica solo el error que sabemos manejar, dejando que el resto del sistema continúe operando con total estabilidad.

---

## 3. Persistencia y Serialización (El Puente Memoria-Disco)

¿Qué es la Serialización?
La memoria RAM almacena objetos como redes complejas de punteros y bloques binarios. Un archivo en disco, en cambio, es solo una secuencia plana de bytes o caracteres.

- Serializar: Es tomar un objeto vivo en memoria RAM y traducirlo a un formato de texto estándar (como JSON) para escribirlo en un archivo físico.
- Deserializar: Es leer ese archivo de texto plano desde el disco y reconstruir los objetos vivos idénticos dentro de la memoria RAM.

---

## 4. La Regla de Oro: Manejo Seguro de Recursos Externos
Cuando interactúas con el disco duro, estás pidiendo recursos prestados al Sistema Operativo:
- El archivo puede no existir.
- El archivo puede estar bloqueado por otro proceso.
- Puede cortarse la energía en medio de la escritura.

Por esta razón, toda operación de entrada/salida (I/O) debe estar envuelta en bloques de protección que garanticen que los archivos no queden abiertos, corruptos o bloqueados.

---

## 5. Preguntas de Autoevaluación
1. ¿Por qué es una mala práctica lanzar 'throw new Exception()' en lugar de crear una excepción específica como ProductoNoEncontradoException?
2. ¿Cuál es la diferencia conceptual entre Serialización y Deserialización?
3. ¿Por qué los datos que residen solo en memoria RAM no son suficientes para un sistema de información real?
