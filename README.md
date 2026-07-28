# VetCare API

## Descripción

VetCare API es un proyecto desarrollado como parte del Proyecto Final del Diplomado de Programación con .NET.

Consiste en una API REST desarrollada con ASP.NET Core que permitirá administrar la información de una clínica veterinaria. El sistema facilitará el registro de propietarios, mascotas, veterinarios y citas médicas, permitiendo realizar operaciones CRUD y gestionar la información de forma organizada.

## Objetivo

Desarrollar una API REST que permita administrar los procesos básicos de una clínica veterinaria mediante el uso de ASP.NET Core, Entity Framework Core y SQLite, aplicando los conocimientos adquiridos durante el diplomado.

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
- Gestionar la información mediante operaciones CRUD.

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

## Tecnologías

Las herramientas y tecnologías que se utilizarán para el desarrollo del proyecto son:

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQLite
- Swagger / OpenAPI
- Git
- GitHub
- Visual Studio Code

## Organización del Equipo

| Integrante | Responsabilidad |
|------------|-----------------|
| Sergio Cantillo Rivas | Configuración del proyecto, GitHub y base de datos |
| Abdías Martínez De Arco | Desarrollo del módulo de Propietarios |
| Ronnie De La Hoz Fontalvo | Desarrollo del módulo de Mascotas |
| Santiago Caballero Castro | Desarrollo del módulo de Veterinarios |
| Isaac Caraballo Villalba | Desarrollo del módulo de Citas, documentación y pruebas |

## Estado del Proyecto

Proyecto en etapa de planeación.

Actualmente se está realizando el diseño de las entidades, relaciones y endpoints de la API como parte de la fase inicial del Proyecto Final del Diplomado de Programación con .NET.

## Integrantes

- Sergio Cantillo Rivas
- Abdías Martínez De Arco
- Ronnie De La Hoz Fontalvo
- Santiago Caballero Castro
- Isaac Caraballo Villalba
