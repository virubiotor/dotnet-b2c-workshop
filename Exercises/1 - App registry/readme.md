# Creación de aplicación de test
En este ejemplo se creará una aplicación web la cual permitirá realizar las validaciones de los ejemplos de este taller
1. Desde el portal de Azure, buscar y acceder a `Azure AD B2C`
2. En el menu lateral, seleccionar `Registros de aplicaciones`
3. Elegir la opción `Nuevo registro`
4. Introducir el nombre de la aplicación, por ejemplo `WebApp-NOMBREAPELLIDO`
5. En el menú `Tipos de cuenta compatibles`, seleccionar la opción `Cuentas en cualquier proveedor de identidades o directorio de la organización (para autenticar usuarios con flujos de usuario)`
6. Bajo el menú `Url de redirección` elegir la opción `Web` e introducir `https://jwt.ms` como url de redirección (Elegimos la opción `Web` ya que usaremos un secreto en el flujo de autenticación)
**IMPORTANTE: Azure B2C define las aplicaciones Web como aplicaciones que realizan la mayor parte de gestiones en el servidor**
7. En la sección de `Permisos`, marcar el checkbox `Conceda consentimiento del administrador a los permisos openid y offline_access.`
  - El permiso (scope en el estándar OIDC) `openid` indica que la aplicación usará OIDC para verificar la identidad del usuario, mientras que `offline_access` habilita que la aplicación pueda utilizar tokens de refresco
8. Seleccionar `Registrar`

## Creación de un secreto para la aplicación de ejemplo
1. Bajo la aplicación creada en el paso anterior, seleccionar el menú `Certificados y secretos`
2. Click en `Nuevo secreto de cliente`
3. Incluir una descripción que permita identificar al secreto y una validez del mismo (mantener el valor por defecto si se desea)
4. Click en `Agregar`
5. Registrar el valor del secreto (bajo la columna `Valor`). **IMPORTANTE: Este valor no volverá a ser mostrado una vez se abandone la página, si se pierde será necesario regenerar el secreto**

## Habilitar el flujo implícito
- Seleccionar la opción `Autenticación` bajo la sección `Administrar`
- En la sección `Flujos de concesión implícita e híbridos`, marcar los valores `Tokens de acceso` y `Tokens de id.`
- Click en `Guardar` para registrar los cambios

**IMPORTANTE: Se usa un flujo implícito para que la aplicación https://jwt.ms sea capaz de generar un token de acceso y mostrarlo por pantalla. Pero el flujo implícito está desaconsejado para entornos productivos -> https://www.taithienbo.com/why-the-implicit-flow-is-no-longer-recommended-for-protecting-a-public-client/**