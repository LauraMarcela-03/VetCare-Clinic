# VetCare Clinic API

## Descripción

VetCare Clinic API es una aplicación desarrollada en ASP.NET Core para la gestión de una clínica veterinaria. Permite administrar propietarios, mascotas, veterinarios, citas médicas, procedimientos y registros médicos.

## Arquitectura

El proyecto sigue una arquitectura por capas:

* VetCare-Clinic.API → Exposición de endpoints REST.
* VetCare-Clinic.Domain → Entidades y lógica de negocio.
* VetCare-Clinic.DataAccess → Persistencia de datos mediante Entity Framework Core.

## Tecnologías

* .NET 9
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Swagger/OpenAPI

## Funcionalidades

* Gestión de propietarios (Owners)
* Gestión de mascotas (Pets)
* Gestión de veterinarios (Veterinarians)
* Gestión de citas (Appointments)
* Gestión de procedimientos (Procedures)
* Gestión de historias clínicas (Medical Records)

## Configuración

### Clonar repositorio

```bash
git clone <repository-url>
```

### Restaurar dependencias

```bash
dotnet restore
```

### Configurar base de datos

Actualizar la cadena de conexión en:

```json
appsettings.json
```

### Ejecutar migraciones

```bash
dotnet ef database update --project ../VetCare-Clinic.DataAccess --startup-project .
```

### Ejecutar la aplicación

```bash
dotnet run
```

## Swagger

Una vez iniciada la aplicación:

```text
https://localhost:{port}/swagger
```

## Endpoints Principales

* /api/owners
* /api/pets
* /api/veterinarians
* /api/appointments
* /api/procedures
* /api/medicalrecords

## Autores

Proyecto desarrollado como parte del Proyecto Final Grupal - VetCare Clinic.
 
