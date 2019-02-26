
Solicitudes
Crear Solicitud
Buscar Solicitud
Modificar Solicitud
Cancelar Solicitud
Reactivar Solicitud
Cotizaciones
Solicitar Cotizacion
Agregar Cotizacion
Partidas
Crear Partida
Buscar Partida
Modificar Partida
Cancelar Partida
Asociar Partida
Reactivar Partida
Adquisiciones
Registrar Adquisicion/Inventario
Buscar Adquisicion
Modificar Adquisicion
Eliminar Adquisicion
Modificar Inventario
Eliminar Inventario
Agregar Inventario
Asignaciones
Crear Asignacion
Buscar Asignacion
Modificar Asignacion
Eliminar Asignacion
Rendiciones
Crear Rendicion
Buscar Rendicion
ReGenerar Rendicion
Eliminar Rendicion
Dependencias
Buscar Dependencia
Crear Dependencia
Modificar Dependencia
Eliminar Dependencia
Reactivar Dependencia
Agentes
Crear Agente
Buscar Agente
Modificar Agente
Categorias
Crear Categoria
Modificar Categoria
Eliminar Categoria
Buscar Categoria
Reactivar Categoria
Proveedores
Crear Proveedor
Modificar Proveedor
Eliminar Proveedor
Buscar Proveedor
Reactivar Proveedor
Usuarios
Crear Usuario
Modificar Usuario
Eliminar Usuario
Reactivar Usuario
Buscar Usuario
Usuario Password
Backup y Restaurar
Restaurar BD
Backupear BD
Bitacora
Buscar Bitacora
Familias
Crear Familia
Modificar Familia
Buscar Familia
Eliminar Familia

Todos los botones listados anteriormente, los hace Javi. Para todos los demás controles que veas que hay en el software que estoy creando, hay que hacer lo siguiente:

Escribir este código con los reemplazos correspondientes para cada control:
Dictionary<string, string[]> dicbtnCrearSolicitud(*1) = new Dictionary<string, string[]>();
string[] IdiomabtnCrearSolicitud(*2) = { "Solicitud Crear(*3)" };
dicbtnCrearSolicitud(*1).Add("Idioma", IdiomabtnCrearSolicitud(*2));
this.btnCrearSolicitud(*4).Tag = dicbtnCrearSolicitud(*1);

(*1) = Nuevo nombre que empieza con “dic” y sigue con el nombre del control
(*2) = Idem anterior pero con “Idioma” adelante
(*3) = La traducción que tiene que tener el control en Español
(*4) = El nombre del control

Ejemplo:
Dictionary<string, string[]> dicbtnVolver = new Dictionary<string, string[]>();
string[] IdiomabtnVolver = { "Volver" };
dicbtnVolver.Add("Idioma", IdiomabtnVolver);
this.btnVolver.Tag = dicbtnVolver;
