# SocialNetworkAPI

Este repositorio contiene la prueba técnica que incluye tres proyectos:

## Proyectos

### 1. SocialNetworkAPI

Es una API Web desarrollada en .NET Core. Permite interactuar con una red social simulada a través de los siguientes endpoints:
- **/api/Controlador/post**: Publicar mensajes.
- **/api/Controlador/follow**: Seguir a un usuario.
- **/api/Controlador/dashboard**: Obtener el dashboard de un usuario.

### 2. SocialNetworkConsole

Una aplicación de consola que sirve como cliente para interactuar con la API Web desarrollada en el proyecto `SocialNetworkAPI`. Esta aplicación puede usarse para realizar llamadas a los endpoints de la API desde la línea de comandos.

### 3. SocialNetworkAPI.Tests

Este proyecto contiene pruebas unitarias para la API Web. Utiliza xUnit y Moq para verificar que los casos de uso de la API se comporten según lo esperado. Las pruebas incluyen:
- Verificación de funcionalidad de seguimiento de usuarios.
- Verificación de publicación de mensajes.
- Verificación de la obtención de posts en el dashboard de un usuario.
