# Personalización del branding

Azure B2C permite personalizar la interfaz presentada al usuario final en los flujos de usuario a través de diferentes niveles de personalización.

## Personalización del branding de la compañía

Sigue estos pasos para personalizar el branding de la compañía:

1. Desde el menú lateral de la página principal del tenant de Azure B2C, accede a `Company branding`.
2. Si aparece el mensaje `STATUS: Not configured`, haz clic en el botón `Configure` del menú superior.
3. En la página mostrada, encontrarás una configuración general de las ventanas de inicio de sesión, registro y edición de contraseña.
4. En la sección `Sign-in page background image`, selecciona el archivo `background.png`.
5. En la sección `Banner logo`, selecciona el archivo `banner.jpg`.
6. Guarda los cambios con el botón `Save`.
7. Lanza cualquier flujo de usuario y valida que la interfaz ha cambiado según los cambios realizados.
8. Una vez validado, elimina las personalizaciones para futuros usos.

**Esta configuración es básica y se aplica de manera global a todos los flujos de usuario, aunque se puede separar por idiomas.**

## Personalización del branding desde un flujo de usuario

Sigue estos pasos para personalizar el branding desde un flujo de usuario:

1. Desde la página principal del tenant de Azure B2C, selecciona la opción `Flujos de usuario` en la sección `Directivas`.
2. Selecciona el flujo creado previamente, `SUSI_NOMBREAPELLIDOS`.
3. En el menú lateral, selecciona `Diseños de página` bajo la sección `Personalizar`.
4. La página mostrará diferentes configuraciones según el tipo de flujo de usuario creado. En el caso del `flujo de inicio de sesión y registro`, encontrarás todas las pantallas correspondientes, como inicio de sesión, registro de usuario, autenticación multifactor y restablecimiento de contraseña.
5. Verifica que la opción seleccionada es `Página unificada de inicio de sesión o de registro`.
6. En la parte inferior de la página, activa la opción `Usar contenido de la página personalizada`. Esto permitirá utilizar un template para incluir HTML, CSS y Javascript personalizado en la página seleccionada, así como proporcionar soporte multi-idioma.

Microsoft proporciona [guías sobre el uso de Javascript en estas personalizaciones](https://learn.microsoft.com/en-us/azure/active-directory-b2c/javascript-and-page-layout?pivots=b2c-user-flow#guidelines-for-using-javascript), y el uso de JQuery o Handlebards está limitado a [ciertas versiones](https://learn.microsoft.com/en-us/azure/active-directory-b2c/page-layout#jquery-and-handlebars-versions).

**IMPORTANTE: El diseño de las páginas está versionado (actualmente la última versión es la 2.1.10). Es recomendable fijar una versión concreta al utilizar personalizaciones para evitar posibles roturas de compatibilidad. Además, se recomienda actualizar las versiones de las páginas siempre que sea posible.**

7. Descarga la página desde la [web de Microsoft](https://learn.microsoft.com/en-us/azure/active-directory-b2c/customize-ui-with-html?pivots=b2c-user-flow) con el template `Classic`, o utiliza el archivo `susi.html`.
8. Modifica la página descargada para incluir como imagen de fondo `background.png` (línea 40). Puedes utilizar [este enlace](https://strworkshopb2c.blob.core.windows.net/main/background.png) o subir la imagen a algún lugar público (Azure Storage, Drive, etc.).
**IMPORTANTE: No se debe modificar la estructura generada en los templates, ya que es utilizada por B2C para generar dinámicamente los controles necesarios según el tipo de página. Se pueden añadir elementos, pero nunca eliminarlos ni modificar sus identificadores.**
13. Cambia la URL en `Custom page URI` para que apunte al template generado. Puedes utilizar [este enlace](https://strworkshopb2c.blob.core.windows.net/main/susi.cshtml) o subir la página a algún lugar público. Si deseas habilitar el uso de Javascript en la página, accede al menú de `Propiedades` bajo la sección `Configuración` y activa la opción `Habilitar JavaScript aplicando el diseño de página`.
14. Guarda los cambios con el botón `Save`.
15. Lanza el flujo de usuario y valida los cambios.

## Personalización de los idiomas y sus valores desde un flujo de usuario

Sigue estos pasos para personalizar los idiomas y sus valores desde un flujo de usuario:

1. Desde la página principal del tenant de Azure B2C, selecciona la opción `Flujos de usuario` en la sección `Directivas`.
2. Selecciona el flujo creado previamente, `SUSI_NOMBREAPELLIDOS`.
3. En el menú lateral, selecciona `Idiomas` bajo la sección `Personalizar`.
4. Por defecto, los flujos de usuario no admiten multi-idioma. Para activar el soporte, haz clic en el botón `Habilitación de la personalización de idioma` en la barra superior.
5. Después de habilitar el soporte multi-idioma, en la tabla inferior, bajo la sección `Todo`, se mostrarán todos los idiomas compatibles por defecto en Azure B2C.
6. Busca el valor `español`, haz clic en él y marca la opción `Habilitado`.
7. Marca el valor `Predeterminado` como verdadero para establecerlo como idioma por defecto.
8. En la parte inferior de la opción `Predeterminado`, se muestran las distintas páginas para las que se dispone de traducciones en el flujo correspondiente. Azure B2C ya proporciona traducciones por defecto en cada una de ellas, pero se pueden personalizar.
9. Busca la opción `Página de registro de cuenta local` y abre el desplegable.
10. Haz clic en `Descargar valores predeterminados (es)` para descargar la lista de traducciones.
11. Modifica la entrada con el identificador `"ElementId": "extension_departmentNOMBREAPELLIDOS"` correspondiente a la propiedad `DisplayName` o utiliza el archivo `spanish.json`:
```json
{
    "ElementType": "ClaimType",
    "ElementId": "extension_departmentNOMBREAPELLIDOS",
    "StringId": "DisplayName",
    "Override": true,
    "Value": "Nombre del departamento"
}

```
12. Subir el archivo modificado
13. Guardar los cambios con el botón `Guardar`
14. Ejecutar el flujo con la opcion `Ejecutar flujo de usuario`
15. Una vez seleccionada la aplicación, identificar una nueva pestaña `Localización` donde se permite indicar el idioma del flujo a probar
16. Activar la opción `Especificar ui_locales`
17. Marcar como idioma `es - español`
18. Lanzar el flujo. Todo el flujo ha sido traducido automáticamente al idioma especificado
19. Click en `Registrarse ahora`
20. En la página de registro, validar que el campo del atributo `departmentNOMBREAPELLIDOS` contiene el valor introducido en el fichero de recursos