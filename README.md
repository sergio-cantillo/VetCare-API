# VetCare API

## Descripción

VetCare API es una API REST desarrollada con ASP.NET Core que tiene como objetivo facilitar la administración de una clínica veterinaria.

El recurso principal del sistema será la mascota, permitiendo gestionar toda la información relacionada con sus propietarios, veterinarios y citas médicas de forma organizada.

Este proyecto será desarrollado como trabajo final del Diplomado de Programación con .NET y busca aplicar los conocimientos adquiridos durante los diferentes módulos, incluyendo programación orientada a objetos, desarrollo de APIs REST, acceso a bases de datos mediante Entity Framework Core, documentación con Swagger e integración con Inteligencia Artificial.

## Objetivo General

Desarrollar una API REST que permita administrar la información de una clínica veterinaria mediante operaciones CRUD, utilizando ASP.NET Core, Entity Framework Core y SQLite, incorporando además una funcionalidad basada en Inteligencia Artificial para brindar recomendaciones generales sobre el cuidado de las mascotas.

## Problema que busca solucionar

Muchas clínicas veterinarias pequeñas administran la información de sus pacientes mediante agendas físicas o archivos dispersos, lo que dificulta el control de las mascotas, el seguimiento de las citas y la organización de la información.

VetCare API busca ofrecer una solución que permita centralizar estos datos mediante una API REST, facilitando la gestión de propietarios, mascotas, veterinarios y citas médicas de forma organizada y segura.

## Objetivo de Desarrollo Sostenible (ODS)

Este proyecto se relaciona con el **ODS 3 - Salud y Bienestar**, ya que busca mejorar la organización de la atención veterinaria y contribuir al cuidado de la salud de las mascotas mediante el uso de herramientas tecnológicas.

## Alcance del Proyecto

El sistema permitirá administrar la información de una clínica veterinaria mediante una API REST.

Las funcionalidades principales serán:

- Registrar y administrar mascotas como recurso principal.
- Asociar cada mascota con su propietario.
- Registrar veterinarios.
- Programar citas médicas para las mascotas.
- Consultar la información registrada.
- Actualizar los datos existentes.
- Eliminar registros cuando sea necesario.
- Generar recomendaciones generales mediante Inteligencia Artificial para las mascotas.

## Entidades del Proyecto

El sistema estará conformado por las siguientes entidades principales:

El recurso principal del sistema será la **Mascota**, mientras que Propietario, Veterinario y Cita serán entidades relacionadas que apoyarán la administración de la información.

| Entidad | Descripción |
|----------|-------------|
| Propietario | Persona responsable de una o varias mascotas registradas en la clínica. |
| Mascota | Animal que recibe atención médica en la clínica veterinaria. |
| Veterinario | Profesional encargado de atender las consultas y procedimientos médicos. |
| Cita | Registro de una consulta médica programada para una mascota con un veterinario. |

## Relaciones entre las Entidades

Las relaciones del sistema serán las siguientes:

- Un propietario puede tener una o varias mascotas.
- Una mascota pertenece a un solo propietario.
- Un veterinario puede atender muchas citas.
- Una mascota puede tener muchas citas.
- Cada cita corresponde a una única mascota y a un único veterinario.

### Representación de las relaciones

```text
Propietario (1)
      │
      └─────────────── (N) Mascota
                             │
                             │ (1)
                             │
                             └─────────────── (N) Cita
                                                ▲
                                                │
                                                │ (N)
                                                │
                                         Veterinario (1)
```

## Endpoints Planeados

Siguiendo la recomendación del proyecto, la entidad principal de la API será **Mascota**. Los demás módulos (Propietarios, Veterinarios y Citas) funcionarán como recursos relacionados para mantener una estructura sencilla y facilitar el desarrollo del proyecto.

### Recurso Principal: Mascotas

| Método | Endpoint | Descripción |
|---------|----------|-------------|
| GET | /api/mascotas | Obtener todas las mascotas |
| GET | /api/mascotas/{id} | Obtener una mascota por ID |
| POST | /api/mascotas | Registrar una nueva mascota |
| PUT | /api/mascotas/{id} | Actualizar la información de una mascota |
| DELETE | /api/mascotas/{id} | Eliminar una mascota |
| POST | /api/mascotas/{id}/analizar | Generar recomendaciones mediante Inteligencia Artificial |

## Recursos Relacionados

Los siguientes módulos contarán con operaciones CRUD básicas para complementar la administración de las mascotas.

### Propietarios

| Método | Endpoint | Descripción |
|---------|----------|-------------|
| GET | /api/propietarios | Obtener propietarios |
| GET | /api/propietarios/{id} | Obtener un propietario |
| POST | /api/propietarios | Registrar un propietario |
| PUT | /api/propietarios/{id} | Actualizar un propietario |
| DELETE | /api/propietarios/{id} | Eliminar un propietario |

### Veterinarios

| Método | Endpoint | Descripción |
|---------|----------|-------------|
| GET | /api/veterinarios | Obtener veterinarios |
| GET | /api/veterinarios/{id} | Obtener un veterinario |
| POST | /api/veterinarios | Registrar un veterinario |
| PUT | /api/veterinarios/{id} | Actualizar un veterinario |
| DELETE | /api/veterinarios/{id} | Eliminar un veterinario |

### Citas

| Método | Endpoint | Descripción |
|---------|----------|-------------|
| GET | /api/citas | Obtener citas |
| GET | /api/citas/{id} | Obtener una cita |
| POST | /api/citas | Registrar una cita |
| PUT | /api/citas/{id} | Actualizar una cita |
| DELETE | /api/citas/{id} | Eliminar una cita |


## Integración con Inteligencia Artificial

Como funcionalidad adicional, el proyecto integrará la API de Groq para analizar la información básica de una mascota.

El usuario podrá enviar datos como la especie, edad y síntomas generales. La Inteligencia Artificial generará recomendaciones orientativas sobre cuidados básicos, posibles causas y sugerencias para acudir a un médico veterinario cuando sea necesario.

Estas respuestas tendrán únicamente fines informativos y no reemplazarán el diagnóstico realizado por un profesional.

## Recurso Principal

La entidad principal del proyecto será **Mascota**.

Las entidades Propietario, Veterinario y Cita servirán como apoyo para organizar la información relacionada con cada mascota y facilitar la administración de la clínica veterinaria.

## Tecnologías

| Tecnología | Versión | Uso |
|------------|----------|------------------------------|
| .NET SDK | 8 LTS | Plataforma de desarrollo |
| C# | 12 | Lenguaje de programación |
| ASP.NET Core | 8 | Desarrollo de la API |
| Entity Framework Core | 8 | Acceso a la base de datos |
| SQLite | - | Base de datos |
| Groq API | - | Integración de Inteligencia Artificial |
| Swagger / OpenAPI | - | Documentación y pruebas de la API |
| Git | - | Control de versiones |
| GitHub | - | Repositorio del proyecto |
| Visual Studio Code | - | Editor de código |

## Organización del Equipo

| Integrante | Rol | Responsabilidad |
|------------|-----|-----------------|
| Sergio Cantillo Rivas | Backend / Team Leader | Arquitectura del proyecto, configuración inicial, GitHub, base de datos y coordinación del equipo. |
| Abdías Martínez De Arco | API / IA | Integración con Groq API, HttpClient y recomendaciones mediante Inteligencia Artificial. |
| Ronnie De La Hoz Fontalvo | BD / DTOs | Diseño de modelos, DTOs, validaciones, relaciones y consultas. |
| Santiago Caballero Castro | Backend | Desarrollo de controladores y operaciones CRUD de la API. |
| Isaac Caraballo Villalba | Docs / QA | Documentación, Swagger, pruebas, capturas y validación del proyecto. |

## Estado Actual

El proyecto se encuentra en la etapa de planeación.

Hasta el momento se ha definido el problema que se desea resolver, el objetivo general, el alcance del proyecto, las entidades, las relaciones entre ellas, los endpoints principales, la integración con Inteligencia Artificial, las tecnologías que se utilizarán y la distribución inicial del trabajo del equipo.

Una vez el proyecto sea aprobado por el profesor, se iniciará la fase de implementación.

## Arquitectura del Proyecto

La API seguirá una arquitectura por capas para facilitar el mantenimiento del código y el trabajo colaborativo entre los integrantes del equipo.

Inicialmente contará con los siguientes módulos:

- Controllers
- Models
- DTOs
- Data
- Services
- Repositories
- Interfaces
- Mappings
- AI

## Integrantes

- Sergio Cantillo Rivas
- Abdías Martínez De Arco
- Ronnie De La Hoz Fontalvo
- Santiago Caballero Castro
- Isaac Caraballo Villalba
