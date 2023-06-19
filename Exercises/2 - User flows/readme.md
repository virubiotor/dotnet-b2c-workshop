# Creación de flujos de usuario predefinidos

Azure B2C ofrece dos opciones para definir la experiencia del usuario:
- Flujos de usuario: políticas predefinidas y configurables que permiten gestionar el registro, inicio de sesión y edición del perfil de manera rápida.
- Políticas personalizadas: se utilizan para escenarios más complejos o flujos totalmente personalizados que no están soportados por los flujos de usuario.

En este ejemplo, veremos cómo crear un flujo de usuario predefinido para gestionar el registro de nuevos usuarios.

## Creación del flujo de registro de usuario

Sigue estos pasos para crear el flujo de registro de usuario:

1. Desde la página principal del portal de Azure, busca y selecciona `Azure AD B2C`.
2. En el menú lateral, busca `Flujos de usuario` bajo la sección `Directivas`.
3. Selecciona la opción `Nuevo flujo de usuario` y luego elige el flujo de usuario deseado, en este caso, `Registrarse e iniciar sesión`.
4. Elige la versión del flujo recomendada. Los flujos legacy corresponden a la antigua versión v1 de Azure B2C y no reciben soporte ni actualizaciones.
5. Introduce un nombre para el flujo, por ejemplo, `SUSI_NOMBREAPELLIDOS`.

**Es importante mencionar que Azure B2C proporciona un prefijo para estos flujos con el formato `B2C_1_`. Este prefijo permite distinguir entre flujos de usuario y políticas personalizadas (que tienen un prefijo `B2C_1A_`).**

6. Selecciona `Email signup` como proveedor de identidad (también se pueden elegir otros proveedores como Google, Facebook o proveedores personalizados).
7. Mantén la autenticación multifactor activada.
8. En la sección `Atributos de usuario y notificaciones de token`, selecciona `Mostrar más` y marca como `Recopilar atributo` y `Notificación de devolución` los siguientes valores:
   - Nombre para mostrar
   - Ciudad
   - Código postal
   - Puesto

**Azure B2C te permite tener control total sobre qué información/atributos deseas recopilar para cada usuario (`Recopilar atributo`) y qué información deseas devolver como parte del token de acceso (`Notificación de devolución`).**

9. Haz clic en `Crear` para registrar el flujo de usuario.

## Prueba del flujo de registro de usuario

Sigue estos pasos para probar el flujo de registro de usuario:

- Selecciona el flujo creado en la sección anterior.
- En el menú superior, haz clic en `Ejecutar flujo de usuario`.
- Selecciona la aplicación web registrada en el ejercicio anterior, `WebApp-NOMBREAPELLIDO`, y asegúrate de que la URL de redirección corresponda a `https://jwt.ms`.
- Completa el flujo de registro en la pestaña del navegador que se abre. Después de crear el usuario, el token generado con los atributos requeridos se mostrará en la página `https://jwt.ms`.