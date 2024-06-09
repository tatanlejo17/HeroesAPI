# Proyecto API REST en .NET 8 con Dapper y SQL Server

Este proyecto es una API RESTful construida con .NET 8, utilizando Dapper como ORM y SQL Server como base de datos. La API permite operaciones CRUD sobre una entidad de ejemplo `Product`.

## Tabla de Contenidos

- [Requisitos Previos](#requisitos-previos)
- [Configuración del Proyecto](#configuración-del-proyecto)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Configuración de la Base de Datos](#configuración-de-la-base-de-datos)
- [Ejecución del Proyecto](#ejecución-del-proyecto)
- [Uso de la API](#uso-de-la-api)
- [Pruebas](#pruebas)
- [Swagger](#swagger)
- [Mejores Prácticas](#mejores-prácticas)
- [Contribuciones](#contribuciones)
- [Licencia](#licencia)

## Requisitos Previos

- .NET SDK 8.0 o superior
- SQL Server
- Visual Studio Code o cualquier IDE compatible con .NET
- Postman (opcional, para pruebas de API)
- [Docker](https://www.docker.com/) (opcional, para ejecutar SQL Server en un contenedor)

## Configuración del Proyecto

### 1. Clonar el Repositorio

```bash
git clone https://github.com/tu_usuario/tu_repositorio.git
cd tu_repositorio
```

### 2. Restaurar las Dependencias

```bash
dotnet restore
```

### 2. Compilar y Ejecutar el Proyecto

```bash
dotnet build
dotnet run
```
