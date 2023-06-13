# Uso de atributos custom en B2C
Azure B2C permite personalizar la información que se recoje de los usuarios en el proceso de registro así como control total sobre que atributos se incluyen en el token de acceso generado.

Azure B2C cuenta con un listado de atributos de usuario globales. Después en cada uno de los distintos flujos de usuario se controla que atributos se quieren almacenar y que atributos (no tienen por qué ser los mismos) se quieren exponer como claims en el token.

## Definición de atributos custom
1. Desde el menú lateral de la página principal del tenant de Azure B2C, acceder a `Atributos de usuario`
2. En esta página se encuentra un listado global de todos los atributos definidos, los cuales pueden ser atributos predefinidos por el propio Azure B2C o customizados (identificados por la columna `Tipo de datos`)

**IMPORTANTE: Como buena práctica, no se debería almacenar información sensible de los usuarios. Es interesante mencionar que estos atributos pueden ser consumidos desde el API de Graph de Microsoft**

3. Seleccionar `Agregar` en el menú superior
4. Introducir la información correspondiente al nuevo atributo:
  - Nombre: nombre del atributo. Coincide con el nombre del claim generado si se incluye como parte del Access Token (departmentNOMBREAPELLIDOS)
  - Tipo de datos: tipo de dato del atributo. Si se recoje este atributo desde el registro del usuario, también se controla cómo se muestra el control asociado (string)
  - Descripción: Descripción del atributo, únicamente a nivel informativo. Nunca es mostrado al usuario
5. Pulsar el botón `Crear`
6. Identificar el nuevo atributo en el listado de atributos de B2C y validar el tipo del mismo en la columna `Tipo de atributo`

## Uso de un atributo custom en un flujo de usuario
1. Desde la página principal del tenant de Azure B2C seleccionar la opción `Flujos de usuario` bajo la sección `Directivas`
2. Seleccionar el flujo creado previamente `SUSI_NOMBREAPELLIDOS`
3. Acceder a la sección `Atributos de usuario`, seleccionar el atributo `departmentNOMBREAPELLIDOS` y guardar los cambios
4. Acceder a la sección `Notificaciones de la aplicación`,  seleccionar el atributo `departmentNOMBREAPELLIDOS` y guardar los cambios
5. Ejecutar nuevamente el flujo con el botón `Ejecutar flujo de usuario` y validar que tanto en el registro como en el token se incluyen esos datos.
**Los atributos custom se devuelven en el token con el formato `extension_valor`**