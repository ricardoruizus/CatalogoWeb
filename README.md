# Catálogo Web de Series y Películas 
### Desarrollar una página web en C# con .NET usando ASP.NET Core MVC, aplicando Programación Orientada a Objetos y arquitectura por capas.

## Funcionalidades obligatorias

### El sistema deberá permitir:

Registrar series o películas.

Mostrar el catálogo en una tabla.

Buscar por título.

Filtrar por tipo: Serie o Película.

Filtrar por género.

Editar un registro.

Eliminar un registro.

Marcar como visto o pendiente.

Mostrar estadísticas básicas.

## Datos mínimos
### Cada registro debe tener:

Id

Título

Tipo: Serie / Película

Género

Año de estreno

Plataforma

Estado: Vista / Pendiente

Calificación del 1 al 5

Reseña breve

## Estructura por capas sugerida
CatalogoWeb │ ├── CatalogoWeb.Presentation │   ├── Controllers │   └── Views │ ├── CatalogoWeb.Entities │   └── Contenido.cs │ ├── CatalogoWeb.Business │   └── ContenidoService.cs │ └── CatalogoWeb.Data     └── ContenidoRepository.cs

## Páginas mínimas
### El proyecto debe incluir:

Inicio	Presentación del sistema
Catálogo	Tabla con series y películas
Agregar	Formulario para registrar contenido
Editar	Formulario para modificar contenido
Detalles	Información completa del registro
Estadísticas	Total de películas, series, vistas y pendientes

## Reglas de negocio
### En la capa de lógica deberán validar:

El título no puede estar vacío.

El tipo solo puede ser Serie o Película.

El año no puede ser mayor al actual.

La calificación debe estar entre 1 y 5.

No se debe registrar contenido duplicado.

No se puede editar o eliminar un registro inexistente.

## Investigación requerida
### Deben investigar cada uno de los siguientes puntos para elaborar

#### Programación Orientada a Objetos
Clase

Objeto

Propiedades

Métodos

Encapsulamiento

Herencia

Polimorfismo

Abstracción

Constructores

Modificadores de acceso

#### Arquitectura por capas
Qué es

Para qué sirve

Ventajas

Capa de presentación

Capa de negocio

Capa de datos

Capa de entidades

## Requisitos técnicos sugeridos
Usar C#.

Usar .NET.

Usar ASP.NET Core MVC.

Usar HTML, CSS y Bootstrap.

Mostrar datos en tablas.

Usar formularios web.

Separar correctamente el código por capas.

No colocar toda la lógica dentro del controlador.

Puede usar almacenamiento en memoria, JSON o SQLite.

## Entregables
Documento de investigación sobre POO.

Documento de investigación sobre arquitectura por capas.

Proyecto web funcional.

Video corto demostrando y explicando el sistema.

Explicación de cómo aplicaron POO.

Explicación de cómo organizaron el proyecto por capas.

Importante:  Cada quien debera hacer el video explicando con sus propias palabras el sistema aunque el sistema lo hayan realizado en equipos.

## Rúbrica sugerida
Investigación de POO	15%
Investigación de arquitectura por capas	15%
Diseño visual de la página	15%
CRUD funcional	20%
Separación por capas	20%
Validaciones	10%
Presentación y explicación	5%

## Puntos extras opcionales 
Guardar datos en SQLite. 2pts.

Agregar póster o imagen. 1pt.

Agregar filtro por plataforma. 1pt.

Agregar modo oscuro. 2pts.

Agregar top 5 mejor calificadas. 1pt.

Exportar catálogo a PDF o Excel. 2pts.

Agregar login básico de administrador, diferente al del usuario normal. 1pt.
