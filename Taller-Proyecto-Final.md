# Taller de Definición del Proyecto Final

## Proyecto

**VetCare API**

## Objetivo de Desarrollo Sostenible (ODS)

**ODS 3 - Salud y Bienestar**

---

# Actividad 1. Definición del problema

### ¿Qué problema desean resolver?

Muchas clínicas veterinarias pequeñas administran la información de sus pacientes mediante agendas físicas o archivos dispersos. Esto dificulta llevar un control de las mascotas, conocer su historial y organizar correctamente las citas médicas.

### ¿Quiénes se beneficiarían de la solución?

La solución beneficiará principalmente a las clínicas veterinarias, los médicos veterinarios y los propietarios de las mascotas, ya que podrán consultar y administrar la información de manera organizada desde un solo sistema.

### ¿Cómo ayudaría una API a resolver el problema?

La API permitirá centralizar toda la información de las mascotas y sus relaciones con propietarios, veterinarios y citas médicas, facilitando el registro, la consulta, la actualización y la eliminación de la información de forma rápida y organizada.

### ¿Qué relación tiene la propuesta con el ODS seleccionado?

El proyecto se relaciona con el **ODS 3 - Salud y Bienestar**, porque busca mejorar la organización de la atención veterinaria mediante el uso de herramientas tecnológicas que faciliten el cuidado de la salud de las mascotas.

---

### Producto esperado (Máximo 150 palabras)

VetCare API es una API REST que busca mejorar la administración de una clínica veterinaria. El sistema tendrá como recurso principal a la mascota, permitiendo almacenar su información y relacionarla con su propietario, el veterinario encargado y las citas médicas. Además, incorporará una funcionalidad de Inteligencia Artificial para generar recomendaciones generales sobre el cuidado de la mascota a partir de algunos datos registrados. De esta manera se busca facilitar la organización de la información, mejorar el seguimiento de los pacientes y apoyar el trabajo diario de las clínicas veterinarias. El proyecto está relacionado con el **ODS 3 - Salud y Bienestar**, ya que promueve el uso de la tecnología para contribuir al cuidado de la salud animal.

---

# Actividad 2. Funcionalidad general de la API

### Complete la siguiente frase

Nuestra API permitirá administrar la información de una clínica veterinaria, teniendo como recurso principal las mascotas y permitiendo gestionar propietarios, veterinarios, citas médicas y recomendaciones generales mediante Inteligencia Artificial.

## Funcionalidades principales

- Registrar mascotas.
- Consultar la información de una mascota.
- Actualizar la información de una mascota.
- Eliminar mascotas.
- Registrar propietarios.
- Registrar veterinarios.
- Programar citas médicas.
- Generar recomendaciones generales mediante Inteligencia Artificial.

### Funcionalidades por módulo

| Módulo | Funcionalidades |
|---------|-----------------|
| Mascotas | Registrar, consultar, actualizar y eliminar mascotas. |
| Propietarios | Registrar, consultar, actualizar y eliminar propietarios relacionados con las mascotas. |
| Veterinarios | Registrar, consultar, actualizar y eliminar veterinarios. |
| Citas | Programar, consultar, actualizar y cancelar citas médicas. |
| Inteligencia Artificial | Generar recomendaciones generales sobre el cuidado de una mascota. |

---

# Actividad 3. Recurso principal y modelo de datos

## Recurso principal

El recurso principal de nuestra API será **Mascota**, ya que representa el paciente principal de la clínica veterinaria. Toda la información del sistema estará relacionada con una mascota, incluyendo su propietario, el veterinario que la atiende y las citas médicas programadas.

## Modelos del sistema

El sistema estará compuesto por los siguientes modelos:

- Mascota (Recurso principal)
- Propietario
- Veterinario
- Cita

---

## Modelo: Mascota

| Campo | Tipo de dato | Obligatorio | Descripción |
|--------|--------------|-------------|-------------|
| Id | int | Sí | Identificador único de la mascota. |
| Nombre | string | Sí | Nombre de la mascota. |
| Especie | string | Sí | Especie de la mascota. |
| Raza | string | No | Raza de la mascota. |
| Edad | int | Sí | Edad de la mascota. |
| Sexo | string | Sí | Sexo de la mascota. |
| Peso | decimal | No | Peso aproximado de la mascota. |
| PropietarioId | int | Sí | Identificador del propietario. |

---

## Modelo: Propietario

| Campo | Tipo de dato | Obligatorio | Descripción |
|--------|--------------|-------------|-------------|
| Id | int | Sí | Identificador único del propietario. |
| Nombre | string | Sí | Nombre del propietario. |
| Apellido | string | Sí | Apellido del propietario. |
| Telefono | string | Sí | Número de contacto. |
| Correo | string | No | Correo electrónico. |

---

## Modelo: Veterinario

| Campo | Tipo de dato | Obligatorio | Descripción |
|--------|--------------|-------------|-------------|
| Id | int | Sí | Identificador único del veterinario. |
| Nombre | string | Sí | Nombre del veterinario. |
| Especialidad | string | Sí | Especialidad médica. |
| Telefono | string | No | Número de contacto. |
| Correo | string | No | Correo electrónico. |

---

## Modelo: Cita

| Campo | Tipo de dato | Obligatorio | Descripción |
|--------|--------------|-------------|-------------|
| Id | int | Sí | Identificador único de la cita. |
| Fecha | DateTime | Sí | Fecha y hora de la cita. |
| Motivo | string | Sí | Motivo de la consulta. |
| Diagnostico | string | No | Diagnóstico realizado por el veterinario. |
| Estado | string | Sí | Estado de la cita. |
| MascotaId | int | Sí | Mascota que será atendida. |
| VeterinarioId | int | Sí | Veterinario asignado. |

---

## Relaciones entre los modelos

- Un propietario puede tener una o varias mascotas.
- Una mascota pertenece a un solo propietario.
- Una mascota puede tener muchas citas.
- Un veterinario puede atender muchas citas.
- Cada cita pertenece a una única mascota y a un único veterinario.

### Diagrama de relaciones

```text
                 Propietario (1)
                       │
                       │
                       ▼
                 Mascota (N)
            (Recurso Principal)
                       │
                       │
                       ▼
                   Cita (N)
                       ▲
                       │
                       │
                Veterinario (1)

La Inteligencia Artificial (Groq API)
se aplicará únicamente a la Mascota
para generar recomendaciones generales
sobre su cuidado.
```

---

# Actividad 4. Endpoints principales

De acuerdo con el alcance definido para el proyecto, la **Mascota** será el recurso principal de la API. Los módulos de Propietarios, Veterinarios y Citas servirán como apoyo para la administración de la información y estarán relacionados con las mascotas.

## Recurso principal: Mascotas

| Método | Ruta | Descripción | Datos de entrada | Respuesta esperada |
|---------|------|-------------|------------------|--------------------|
| GET | /api/mascotas | Consultar todas las mascotas | No requiere | Lista de mascotas registradas |
| GET | /api/mascotas/{id} | Consultar una mascota por ID | Id de la mascota | Información de la mascota |
| POST | /api/mascotas | Registrar una nueva mascota | Datos de la mascota | Mascota registrada correctamente |
| PUT | /api/mascotas/{id} | Actualizar una mascota | Id y nuevos datos | Mascota actualizada correctamente |
| DELETE | /api/mascotas/{id} | Eliminar una mascota | Id de la mascota | Confirmación de eliminación |
| POST | /api/mascotas/{id}/analizar | Generar recomendaciones mediante Inteligencia Artificial | Id de la mascota | Recomendaciones generales para el cuidado de la mascota |

## Recursos relacionados

### Propietarios

CRUD básico para administrar los propietarios de las mascotas.

- GET /api/propietarios
- GET /api/propietarios/{id}
- POST /api/propietarios
- PUT /api/propietarios/{id}
- DELETE /api/propietarios/{id}

### Veterinarios

CRUD básico para administrar los veterinarios registrados.

- GET /api/veterinarios
- GET /api/veterinarios/{id}
- POST /api/veterinarios
- PUT /api/veterinarios/{id}
- DELETE /api/veterinarios/{id}

### Citas

CRUD básico para administrar las citas médicas de las mascotas.

- GET /api/citas
- GET /api/citas/{id}
- POST /api/citas
- PUT /api/citas/{id}
- DELETE /api/citas/{id}

## Consultas adicionales

Como funcionalidad complementaria, la API podrá incorporar algunos filtros para facilitar las consultas.

- GET /api/mascotas?especie=Perro
- GET /api/citas?fecha=2026-08-15
- GET /api/veterinarios?especialidad=Cirugía

Nota: En el desarrollo del proyecto se implementarán los CRUD básicos para las entidades relacionadas (Propietario, Veterinario y Cita), priorizando la implementación completa del módulo de Mascotas y su integración con Inteligencia Artificial.

---

# Actividad 5. Integración con Inteligencia Artificial

La funcionalidad de Inteligencia Artificial estará enfocada únicamente en el recurso principal del sistema: **Mascota**.

## ¿Qué información se enviará al modelo?

La API enviará al modelo de Inteligencia Artificial la información básica de la mascota, como:

- Especie.
- Raza.
- Edad.
- Peso.
- Motivo de la consulta o síntomas generales (si existen).

## ¿Qué deberá hacer el modelo?

El modelo analizará la información recibida y generará recomendaciones generales sobre el cuidado de la mascota, teniendo en cuenta los datos suministrados.

Estas recomendaciones serán únicamente informativas y no reemplazarán el diagnóstico realizado por un médico veterinario.

## ¿Qué respuesta deberá devolver?

El modelo devolverá:

- Un resumen de la situación de la mascota.
- Recomendaciones generales de cuidado.
- Sugerencias preventivas.
- Una advertencia indicando que la respuesta no reemplaza la atención profesional.

## ¿Dónde se almacenará el resultado?

Las recomendaciones generadas por la IA no se almacenarán permanentemente en la base de datos. Se mostrarán al usuario como respuesta de la consulta realizada.

## ¿Qué ocurrirá si la IA no responde?

Si el servicio de Inteligencia Artificial no está disponible, la API devolverá un mensaje indicando que no fue posible generar las recomendaciones en ese momento y solicitará intentar nuevamente más tarde.

---

## Ejemplo de entrada (JSON)

```json
{
  "especie": "Perro",
  "raza": "Labrador",
  "edad": 5,
  "peso": 28.5,
  "sintomas": "Pérdida de apetito y decaimiento"
}
```

---

## Respuesta esperada (JSON)

```json
{
  "resumen": "La mascota presenta síntomas generales que requieren valoración veterinaria.",
  "recomendaciones": [
    "Mantener hidratación constante.",
    "Evitar la automedicación.",
    "Programar una consulta veterinaria lo antes posible."
  ],
  "advertencia": "Estas recomendaciones son únicamente informativas y no reemplazan el diagnóstico de un médico veterinario."
}
```

---

# Actividad 6. Diagrama general del sistema

## Arquitectura general

```text
                     Usuario
                        │
                        ▼
             Swagger / Cliente HTTP
                        │
                        ▼
                ASP.NET Core Web API
                        │
        ┌───────────────┼───────────────┐
        │               │               │
        ▼               ▼               ▼
 Controllers      Services       Repositories
        │               │               │
        └───────────────┼───────────────┘
                        │
                        ▼
              Entity Framework Core
                │                 │
                ▼                 ▼
          Base de datos       Groq API
             SQLite      (Inteligencia Artificial)
```

### Descripción

El usuario realizará las solicitudes mediante Swagger o cualquier cliente HTTP.

La API recibirá las peticiones y las enviará a la lógica de negocio. Posteriormente, la información será almacenada o consultada mediante Entity Framework Core y SQLite.

Cuando el usuario solicite recomendaciones para una mascota, la API enviará la información necesaria al servicio de Inteligencia Artificial utilizando la API de Groq, la cual devolverá recomendaciones generales sobre el cuidado de la mascota.

---

# Distribución inicial de tareas

| Integrante | Rol | Primera tarea asignada |
|------------|-----|------------------------|
| Sergio Cantillo Rivas | Backend / Team Leader | Crear el proyecto, configurar la solución, GitHub, Entity Framework Core y la base de datos. |
| Abdías Martínez De Arco | API / IA | Integrar la API de Groq y desarrollar la funcionalidad de recomendaciones para mascotas. |
| Ronnie De La Hoz Fontalvo | BD / DTOs | Diseñar los modelos, DTOs, validaciones y relaciones entre las entidades. |
| Santiago Caballero Castro | Backend | Desarrollar los controladores y CRUD del módulo de Mascotas y Veterinarios. |
| Isaac Caraballo Villalba | Documentación / QA | Elaborar la documentación, realizar pruebas, capturas de Swagger y actualizar el README del proyecto. |
