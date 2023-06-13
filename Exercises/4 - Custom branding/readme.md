# Personalización del branding
Azure B2C cuenta con distintos niveles de personalización de la interfaz presentada al usuario final en los flujos de usuario

## Personalización del branding de la compañía
1. Desde el menú lateral de la página principal del tenant de Azure B2C, acceder a `Company branding`
2. Si se muestra un mensaje `STATUS: Not configured`, hacer click en el boton `Configure` del menú superior
3. La página mostrada presenta una configuración general de las ventanas de login, registro y edición de contraseña.
4. En la sección `Sign-in page background image` seleccionar el archivo `background.png`
5. En la sección `Banner logo` seleccionar el archivo `banner.jpg`
6. Guardar los cambios con el botón `Save`
7. Lanzar cualquier flujo de usuario y validar que la interfaz ha cambiado acorde a los cambios realizados
8. Una vez validado, eliminar las customizaciones para futuros ejercicios

**Esta configuración es básica y aplica de manera global a todos los flujos de usuario, aunque se puede separar por idiomas.**

## Personalización del branding desde un flujo de usuario
1. Desde la página principal del tenant de Azure B2C seleccionar la opción `Flujos de usuario` bajo la sección `Directivas`
2. Seleccionar el flujo creado previamente `SUSI_NOMBREAPELLIDOS`
3. Seleccionar la opción `Diseños de página` desde el menú lateral, bajo la sección `Personalizar`
4. La página muestra diferentes configuraciones según el tipo de flujo de usuario creado. Al usar el flujo de login y registro, contamos con todas las pantallas de login, registro de usuario, autenticación multifactor, reseteo de contraseña...
5. Validar que la opción seleccionada es `Página unificada de inicio de sesión o de registro`
6. En la parte inferior de la página, activar la opción `Usar contenido de la página personalizada`. Esto nos permitirá utilizar un template para incluir HTML, CSS y Javascript personalizado para la página seleccionada, así como soporte multi-idioma.

Cabe destacar que Microsoft proporciona ciertas [guías sobre el uso de Javascript en estas personalizaciones](https://learn.microsoft.com/en-us/azure/active-directory-b2c/javascript-and-page-layout?pivots=b2c-user-flow#guidelines-for-using-javascript) y el uso de JQuery o Handlebards está limitado a [ciertas versiones](https://learn.microsoft.com/en-us/azure/active-directory-b2c/page-layout#jquery-and-handlebars-versions).

**IMPORTANTE: El diseño de las páginas está versionado (actualmente la última versión es la 2.1.10). Es recomendable fijar una versión concreta a la hora de utilizar personalizaciones para evitar que si se actualizan las versiones se puedan perder funcionalidades por posibles roturas de compatibilidad. Asimismo, es muy recomendable actualizar las versiones de nuestras páginas siempre que sea posible.**

7. Descargar la página desde la [web de Microsoft](https://learn.microsoft.com/en-us/azure/active-directory-b2c/customize-ui-with-html?pivots=b2c-user-flow) con el template `Classic` o utilizar el archivo `susi.html`
8. Modificar la página descargada para incluir como imagen de fondo `background.png` (línea 40). Podéis usar el [link](https://strworkshopb2c.blob.core.windows.net/main/background.png) o subir la imagen a algún lugar público (Azure storage, Drive, ...)
**IMPORTANTE: NO se debe modificar la estructura generada en los templates ya que es usada por B2C para generar dinámicamente los controles necesarios según el tipo de página. Se pueden añadir elementos pero nunca eliminarlos ni modificar los identificadores de los mismos**
13. Cambiar la url en `Custom page URI` para apuntar al template generado. Podéis usar el [link](https://strworkshopb2c.blob.core.windows.net/main/susi.cshtml) o subir la página a algún lugar público. Si se quiere habilitar el uso de Javascript en la página, acceder al menú de `Propiedades` bajo la sección `Configuración` y activar la opción `Habilitar JavaScript aplicando el diseño de página`
14. Guardar los cambios con el botón `Save`
15. Lanzar el flujo de usuario y validar los cambios

## Personalización de los idiomas y sus valores desde un flujo de usuario
1. Desde la página principal del tenant de Azure B2C seleccionar la opción `Flujos de usuario` bajo la sección `Directivas`
2. Seleccionar el flujo creado previamente `SUSI_NOMBREAPELLIDOS`
3. Seleccionar la opción `Idiomas` desde el menú lateral, bajo la sección `Personalizar`
4. Por defecto los flujos de usuario no soportan multi-idioma. Para activar el soporte hacer click en el botón `Habilitación de la personalización de idioma` de la barra superior
5. Tras habilitar el soporte multi-idioma, en la tabla inferior, bajo la sección `Todo` se muestran todos los idiomas con soporte por defecto en Azure B2C.
6. Buscar el valor `español`, hacer click sobre el y marcar la opción `Habilitado`
7. Marcar el valor `Predeterminado` a true para incluirlo como idioma por defecto
8. En la parte inferior a la opción `Predeterminado` se muestran las distintas páginas para las que se dispone de traducciones para el flujo correspondiente. Azure B2C ya proporciona en cada una de ellas unas traducciones por defecto, aunque se permite customizarlas.
9. Buscar la opción `Página unificada de inicio de sesión o de registro` y abrir el desplegable
10. Click en `Descargar valores predeterminados (es)` para descargar la lista de traducciones
11. Añadir al final del archivo una nueva entrada o utilizar el archivo `spanish.json`:
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