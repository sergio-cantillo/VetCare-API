# VetCare API

## Descripción

VetCare API es una API REST desarrollada con ASP.NET Core que tiene como objetivo facilitar la administración de una clínica veterinaria. El sistema permitirá registrar propietarios, mascotas, veterinarios y citas médicas, ofreciendo una forma organizada de almacenar y consultar la información.

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

- Registrar propietarios.
- Registrar mascotas.
- Registrar veterinarios.
- Programar citas médicas.
- Consultar la información registrada.
- Actualizar los datos existentes.
- Eliminar registros cuando sea necesario.
- Generar recomendaciones generales mediante Inteligencia Artificial.

## Entidades del Proyecto

El sistema estará conformado por las siguientes entidades principales:

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

### Propietarios

| Método | Endpoint | Descripción |
|---------|----------|-------------|
| GET | /api/propietarios | Obtener todos los propietarios |
| GET | /api/propietarios/{id} | Obtener un propietario por ID |
| POST | /api/propietarios | Registrar un propietario |
| PUT | /api/propietarios/{id} | Actualizar un propietario |
| DELETE | /api/propietarios/{id} | Eliminar un propietario |

### Mascotas

| Método | Endpoint | Descripción |
|---------|----------|-------------|
| GET | /api/mascotas | Obtener todas las mascotas |
| GET | /api/mascotas/{id} | Obtener una mascota por ID |
| POST | /api/mascotas | Registrar una mascota |
| PUT | /api/mascotas/{id} | Actualizar una mascota |
| DELETE | /api/mascotas/{id} | Eliminar una mascota |

### Veterinarios

| Método | Endpoint | Descripción |
|---------|----------|-------------|
| GET | /api/veterinarios | Obtener todos los veterinarios |
| GET | /api/veterinarios/{id} | Obtener un veterinario por ID |
| POST | /api/veterinarios | Registrar un veterinario |
| PUT | /api/veterinarios/{id} | Actualizar un veterinario |
| DELETE | /api/veterinarios/{id} | Eliminar un veterinario |

### Citas

| Método | Endpoint | Descripción |
|---------|----------|-------------|
| GET | /api/citas | Obtener todas las citas |
| GET | /api/citas/{id} | Obtener una cita por ID |
| POST | /api/citas | Registrar una cita |
| PUT | /api/citas/{id} | Actualizar una cita |
| DELETE | /api/citas/{id} | Eliminar una cita |

## Integración con Inteligencia Artificial

Como funcionalidad adicional, el proyecto integrará la API de Groq para generar recomendaciones generales relacionadas con el cuidado de las mascotas.

Por ejemplo, el usuario podrá enviar información básica como la especie de la mascota, su edad y algunos síntomas generales, y la IA responderá con recomendaciones orientativas sobre cuidados básicos.

Estas respuestas tendrán únicamente fines informativos y no reemplazarán el diagnóstico realizado por un médico veterinario.

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

| Integrante | Responsabilidad |
|------------|-----------------|
| Sergio Cantillo Rivas | Configuración del proyecto, GitHub y base de datos |
| Abdías Martínez De Arco | Desarrollo del módulo de Propietarios |
| Ronnie De La Hoz Fontalvo | Desarrollo del módulo de Mascotas |
| Santiago Caballero Castro | Desarrollo del módulo de Veterinarios |
| Isaac Caraballo Villalba | Desarrollo del módulo de Citas, documentación y pruebas |

## Estado Actual

Proyecto en etapa de planeación.

El proyecto se encuentra actualmente en la etapa de planeación. Se ha definido el alcance, las entidades principales, las relaciones entre ellas, los endpoints de la API y las tecnologías que serán utilizadas durante el desarrollo.

Una vez aprobada la propuesta por el Profesor, se iniciará la implementación del proyecto.

## Arquitectura del Proyecto

La API será desarrollada siguiendo una estructura organizada para facilitar el trabajo en equipo y el mantenimiento del código.

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
