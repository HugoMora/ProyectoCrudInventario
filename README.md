# InventarioSolution

Este proyecto proporciona una aplicación ASP.NET Core MVC (.NET 6) para gestionar movimientos de inventario mediante una base de datos SQL Server local (BD_INVENTARIO) y stored procedures predefinidos.

---

## Prerrequisitos

- **SQL Server** (local) con base de datos `BD_INVENTARIO` creada.
- **.NET 6 SDK** instalado.
- **Visual Studio 2022** o **VS Code** con soporte para .NET.

---

## 1. Configurar la Base de Datos

1. Abrir **SQL Server Management Studio** (SSMS) o equivalente.
2. Conectar a la instancia local.
3. Crear la base de datos si no existe:
   ```sql
   CREATE DATABASE BD_INVENTARIO;
   GO
   ```
4. Abrir el script de procedimientos (`Procedures.docx`) o su versión `.sql` y ejecutar todo el contenido para crear los stored procedures:
   - `uConsultarInventario`
   - `uInsertarMovInventario`
   - `uActualizarMovInventario`
   - `uEliminarMovInventario`
   - (y cualquier otro definido en el documento)

5. (Opcional) Insertar datos de prueba:
   ```sql
   INSERT INTO MOV_INVENTARIO
     (COD_CIA, COMPANIA_VENTA_3, ALMACEN_VENTA, TIPO_MOVIMIENTO, TIPO_DOCUMENTO, NRO_DOCUMENTO, COD_ITEM_2, CANTIDAD, FECHA_TRANSACCION)
   VALUES
     ('01', '001', 'ALM1', 'IN', 'FA', '0001', 'ITEM001', 10, GETDATE()),
     ('01', '001', 'ALM2', 'OUT','FA', '0002', 'ITEM002',  5, GETDATE());
   ```

---

## 2. Ver registros actuales

En SSMS, ejecutar:
```sql
SELECT * FROM MOV_INVENTARIO;
```  
Deberías ver los registros insertados por el script de prueba.

---

## 3. Ejecutar la aplicación

1. Clonar o abrir la solución del proyecto `SolutionCrud.sln`.
2. Validar la cadena de conexión en **Web/appsettings.json**:
   ```json
   {
     "ConnectionStrings": {
       "cadenaSQL": "Server=(local); DataBase=DB_INVENTARIO;Integrated Security=true"
     }
   }
   ```
3. En Visual Studio, establece el proyecto **Web** como inicio.
4. Ejecuta la aplicación (`F5` en VS o `dotnet run` desde `Web/` en la CLI).
5. Navegar a `https://localhost`.

---

## 4. Uso de la aplicación

- **Listar**: la página principal muestra todos los movimientos.
- **Crear**: clic en **Nuevo Movimiento**, se abre un modal con el formulario.
- **Editar** / **Eliminar**: botones en cada fila para modificar o borrar.
- **Buscar**: usa el formulario de filtros en la parte superior para filtrar por campos (Cod Cia, Almacén, Tipo Mov., etc.).

---

