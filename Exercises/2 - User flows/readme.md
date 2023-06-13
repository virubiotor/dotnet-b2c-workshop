# Creación de flujos de usuario predefinidos

Azure B2C permite dos posibilidades de definir la experiencia del usuario:
  - Flujos de usuario: políticas predefinidas y configurables que permiten gestionar el registro, login y edición del perfil de manera casi inmediata
  - Políticas custom: usadas para definir escenarios mas complejos o flujos completamente customizados los cuales no están soportados con flujos de usuario.

En este ejemplo veremos como definir un flujo de usuario predefinido que gestione el registro de un nuevo usuario.

## Creación del flujo de registro de usuario
1. Desde la página principal del portal de Azure, buscar y seleccionar `Azure AD B2C`
2. En el menu lateral, buscar el valor `Flujos de usuario` bajo la sección `Directivas`
3. Seleccionar la opcion `Nuevo flujo de usuario` y en el siguiente menú, el flujo de usuario deseado `Registrarse e iniciar sesión`
4. Elegir la versión del flujo recomendada. Los flujos legacy corresponden a la antigua versión v1 de Azure B2C y no reciben soporte ni actualizaciones.
5. Introducir un nombre para el flujo `SUSI_NOMBREAPELLIDOS`

**Es importante mencionar que Azure B2C proporciona un prefijo para estos flujos con el formato `B2C_1_`. Este prefijo permite distinguir entre flujos de usuario o custom policies (las cuales tienen como prefijo `B2C_1A_`)**
6. Seleccionar `Email signup` como proveedor de identidad (se podrían elegir otros proveedores de identidad como Google, Facebook, proveedores personalizados,...)
7. Mantener la autenticación multifactor activada
8. Bajo la sección `Atributos de usuario y notificaciones de token` seleccionar la opción `Mostrar mas` y marcar como `Recopilar atributo` y `Notificación de devolución` los siguientes valores:
 - Nombre para mostrar
 - Ciudad
 - Código postal
 - Puesto

**Azure B2C proporciona control total sobre que información/atributos se quieren registrar para cada usuario `Recopilar atributo` y que información se quiere devolver como parte del token de acceso `Notificación de devolución`**

9. Seleccionar `Crear` para registrar el fujo de usuario

## Prueba del flujo de registro de usuario
- Seleccionar el flujo creado en la sección anterior
- En el menú superior, click en `Ejecutar flujo de usuario`
- Seleccionar la aplicación web registrada en el ejercicio previo `WebApp-NOMBREAPELLIDO` y validar que la url de redirección corresponde a `https://jwt.ms`
- En la pestaña del navegador abierta, completar el fujo de registro. Tras la creación del mismo, el token generado con los atributos requeridos se muestra bajo la página `https://jwt.ms`. 