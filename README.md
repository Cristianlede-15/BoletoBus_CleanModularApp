# Proyecto BoletosBus_CleanModularApp

## Descripción

Este proyecto es una aplicación de boletería de buses desarrollada utilizando una arquitectura clean y microservicios. La aplicación permite gestionar la venta de boletos de bus, incluyendo la reserva de asientos, el procesamiento de pagos y la gestión de clientes.

## Arquitectura

El proyecto está diseñado siguiendo los principios de la arquitectura clean, que separa las preocupaciones de la aplicación en diferentes capas, promoviendo así la mantenibilidad y escalabilidad del código. Además, la aplicación está dividida en varios microservicios, cada uno responsable de un dominio específico de la aplicación.

### Capas de la Arquitectura Clean

- **Domain**: Contiene las entidades y la lógica de negocio.
- **Application**: Contiene los casos de uso y la lógica de aplicación.
- **Infrastructure**: Contiene la implementación de los servicios y adaptadores.
- **Presentation**: Contiene la lógica de la interfaz de usuario y controladores de API.

### Microservicios

- **Asiento**: Gestiona la información de los asientos y su disponibilidad.
- **Bus**: Gestiona la información de los autobuses.
- **Cliente**: Gestiona la información de los clientes.

Cada microservicio sigue la estructura de la arquitectura clean, con sus propias capas.

## Requisitos

- [.NET Core](https://dotnet.microsoft.com/download) 3.1 o superior
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Configuración del Entorno de Desarrollo

1. Clonar el repositorio:

   ```bash
   git clone https://github.com/tu-usuario/BoletosBus_CleanModularApp.git
   cd BoletosBus_CleanModularApp
