# Uso de atributos custom en B2C

Azure B2C permite personalizar la información que se recoje de los usuarios en el proceso de registro, así como tener un control total sobre qué atributos se incluyen en el token de acceso generado.

Azure B2C cuenta con un listado de atributos de usuario globales. Además, en cada uno de los distintos flujos de usuario se puede controlar qué atributos se desean almacenar y qué atributos (que no necesariamente deben ser los mismos) se quieren exponer como claims en el token.

## Definición de atributos custom

Sigue estos pasos para definir un atributo custom:

1. Desde el menú lateral de la página principal del tenant de Azure B2C, accede a `Atributos de usuario`.
2. En esta página se encuentra un listado global de todos los atributos definidos, que pueden ser atributos predefinidos por Azure B2C o atributos personalizados (identificados por la columna `Tipo de datos`).

**IMPORTANTE: Como buena práctica, no se debería almacenar información sensible de los usuarios. También es interesante mencionar que estos atributos pueden ser consumidos desde el API de Graph de Microsoft.**

3. Haz clic en `Agregar` en el menú superior.
4. Completa la información correspondiente al nuevo atributo:
   - Nombre: nombre del atributo. Coincide con el nombre del claim generado si se incluye como parte del Access Token (`departmentNOMBREAPELLIDOS`).
   - Tipo de datos: tipo de dato del atributo. Si se recoje este atributo desde el registro del usuario, también se controla cómo se muestra el control asociado (`string`).
   - Descripción: descripción del atributo, únicamente a nivel informativo. No se muestra al usuario.
5. Haz clic en el botón `Crear`.
6. Identifica el nuevo atributo en el listado de atributos de B2C y valida el tipo en la columna `Tipo de atributo`.

## Uso de un atributo custom en un flujo de usuario

Sigue estos pasos para usar un atributo custom en un flujo de usuario:

1. Desde la página principal del tenant de Azure B2C, selecciona la opción `Flujos de usuario` bajo la sección `Directivas`.
2. Selecciona el flujo creado previamente, `SUSI_NOMBREAPELLIDOS`.
3. Accede a la sección `Atributos de usuario`, selecciona el atributo `departmentNOMBREAPELLIDOS` y guarda los cambios.
4. Accede a la sección `Notificaciones de la aplicación`, selecciona el atributo `departmentNOMBREAPELLIDOS` y guarda los cambios.
5. Ejecuta nuevamente el flujo con el botón `Ejecutar flujo de usuario` y valida que tanto en el registro como en el token se incluyen esos datos.

**Los atributos custom se devuelven en el token con el formato `extension_valor`.**
