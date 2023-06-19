# Creación de aplicación de prueba

En este ejemplo se creará una aplicación web que permitirá realizar las validaciones de los ejemplos presentados en este taller.

## Pasos para la creación de la aplicación

1. Desde el portal de Azure, buscar y acceder a `Azure AD B2C`.
2. En el menú lateral, seleccionar `Registros de aplicaciones`.
3. Elegir la opción `Nuevo registro`.
4. Introducir el nombre de la aplicación, por ejemplo `WebApp-NOMBREAPELLIDO`.
5. En el menú `Tipos de cuenta compatibles`, seleccionar la opción `Cuentas en cualquier proveedor de identidades o directorio de la organización (para autenticar usuarios con flujos de usuario)`.
6. Bajo el menú `Url de redirección`, elegir la opción `Web` e introducir `https://jwt.ms` como URL de redirección. Elegimos la opción `Web` ya que usaremos un secreto en el flujo de autenticación. <br><br> **IMPORTANTE: Azure B2C define las aplicaciones Web como aplicaciones que realizan la mayor parte de gestiones en el servidor**.
7. En la sección de `Permisos`, marcar el checkbox `Conceda consentimiento del administrador a los permisos openid y offline_access.` <br>  El permiso (scope en el estándar OIDC) `openid` indica que la aplicación usará OIDC para verificar la identidad del usuario, mientras que `offline_access` habilita que la aplicación pueda utilizar tokens de refresco.
8. Seleccionar `Registrar`.

<br>

## Creación de un secreto para la aplicación de ejemplo

1. Bajo la aplicación creada en el paso anterior, seleccionar el menú `Certificados y secretos`.
2. Click en `Nuevo secreto de cliente`.
3. Incluir una descripción que permita identificar al secreto y una validez del mismo (mantener el valor por defecto si se desea).
4. Click en `Agregar`.
5. Registrar el valor del secreto (bajo la columna `Valor`). <br> **IMPORTANTE: Este valor no volverá a ser mostrado una vez se abandone la página, si se pierde será necesario regenerar el secreto**.

<br>

## Habilitar el flujo implícito

Para habilitar el flujo implícito, sigue estos pasos:

- Selecciona la opción "Autenticación" en la sección "Administrar".
- En la sección "Flujos de concesión implícita e híbridos", marca los siguientes valores:
  - Tokens de acceso.
  - Tokens de id.
- Haz clic en "Guardar" para registrar los cambios.

<br>

**IMPORTANTE: Se usa un flujo implícito para que la aplicación https://jwt.ms sea capaz de generar un token de acceso y mostrarlo por pantalla. Pero el flujo implícito está desaconsejado para entornos productivos -> [Enlace](https://www.taithienbo.com/why-the-implicit-flow-is-no-longer-recommended-for-protecting-a-public-client/)**
