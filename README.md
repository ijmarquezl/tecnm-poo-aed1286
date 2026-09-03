# Programación Orientada a Objetos (AED-1286)
## Programa de Acompañamiento y Regularización Académica
**Tecnológico Nacional de México — Campus Cancún**  
**Docente:** Academia de Sistemas y Computación  
**Plataforma de Trabajo:** GitHub Codespaces / .NET 8 SDK  

---

### Calendario de Entregas y Defensas (Septiembre - Octubre)

| Hito | Periodo | Temas Cubiertos | Fecha Límite de Entrega | Ponderación |
| :--- | :--- | :--- | :--- | :--- |
| **Hito 1** | 07 sep – 15 sep | Temas 1 y 2: Clases, Encapsulamiento, Invariantes y Constructores | **15 sep (23:59 h)** | 25% |
| **Hito 2** | 16 sep – 25 sep | Temas 3 y 4: Herencia, Clases Abstractas e Interfaces | **25 sep (23:59 h)** | 25% |
| **Hito 3** | 26 sep – 05 oct | Subtemas 2.7 y 4.4: Sobrecarga de Operadores y Genéricos | **05 oct (23:59 h)** | 25% |
| **Hito 4** | 06 oct – 13 oct | Temas 5 y 6: Excepciones de Negocio y Persistencia en Archivos | **13 oct (23:59 h)** | 25% |
| **Cierre** | 14 oct – 16 oct | Auditoría final de código, defensas orales y asentado de actas | **16 de octubre** | Calificación Final |

---

### Criterios de Acreditación por Hito

* **50% Test Harness Automatizado:** El proyecto debe compilar limpiamente y superar todas las pruebas unitarias del `Program.cs` (`dotnet run`).
* **30% Defensa Técnica Oral (10 min):** Modificaciones en vivo del código y justificación de conceptos teóricos.
* **20% Bitácora de Auditoría:** Reporte en Markdown con diagramas conceptuales y justificación técnica.

---

### Instrucciones de Ejecución en Codespaces

1. Abre este repositorio en **GitHub Codespaces**.
2. Entra a la carpeta del hito a trabajar:
   ```bash
   cd Hito1_Encapsulamiento
   dotnet run
   ```
3. Trabaja en tus clases y verifica que el Test Harness termine con 0 fallos.

---

## 🛠️ Guía de Inicio Rápido para el Estudiante

Sigue estrictamente estos pasos para configurar tu espacio de trabajo y realizar tus entregas:

### 1. Clonar el repositorio mediante Fork
1. En la parte superior derecha de esta página, haz clic en el botón **Fork**.
2. Selecciona tu cuenta personal de GitHub como destino y haz clic en **Create fork**.
3. Asegúrate de trabajar a partir de este momento dentro de **tu copia personal** (`tu-usuario/tecnm-poo-aed1286`).

---

### 2. Abrir el entorno en GitHub Codespaces
No necesitas instalar nada en tu computadora local. El entorno ya incluye el SDK de .NET 8:
1. En la página principal de **tu fork**, haz clic en el botón verde **`<> Code`**.
2. Selecciona la pestaña **Codespaces**.
3. Haz clic en **Create codespace on main**.
4. Espera de 1 a 2 minutos a que el contenedor termine de construirse e inicie VS Code en tu navegador.

---

### 3. Flujo de Trabajo en cada Hito
Abre la terminal integrada en Codespaces (`Ctrl + ~` o menú *Terminal -> New Terminal*) y ubícate en la carpeta correspondiente:

```bash
# Ejemplo para trabajar en el Hito 1:
cd Hito1_Encapsulamiento

# Ejecutar el Test Harness para comprobar tus cambios:
dotnet run
Resuelve los archivos de clase solicitados (.cs) hasta que la consola muestre 0 fallos.

Completa las preguntas de reflexión técnica dentro de la bitácora (*_Auditoria.md).
```
### 4. Guardar y Entregar Evidencias
Al terminar cada hito, sincroniza tus cambios desde la terminal de Codespaces:

```bash


git add .
git commit -m "feat: hito 1 completado con pruebas en verde"
git push origin main
```

Mecanismo de entrega:

1. Ve a la pestaña Pull requests de tu repositorio en GitHub.

2. Haz clic en New pull request hacia el repositorio principal del docente.

3. Asigna como título: Entrega Hito X - [Tu Nombre Completo] - [No. Control].

4. En la descripción, confirma que las pruebas automatizadas pasaron en verde y solicita tu horario de defensa oral.
