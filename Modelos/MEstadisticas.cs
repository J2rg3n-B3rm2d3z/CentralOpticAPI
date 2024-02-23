namespace CentralOpticAPI.Modelos
{
    public class MEstadisticas
    {
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        
    }

    public class MEstadisticasIngresoProductoTipo
    {
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Tipo_Producto { get; set; }
    }

    public class MEstProductoVendido
    {
        public string Codigo_Producto { get; set; }
        public string Descripcion { get; set; }
        public string Tipo_Producto { get; set; }
        public int Total { get; set; }

    }

    public class MEstProductoVendidoPorTipo
    {
        public string Codigo_Producto { get; set; }
        public string Descripcion { get; set; }
        public int Total { get; set; }

    }

    public class MEstClienteRecurrente
    {
        public string Cedula { get; set; }
        public string Cliente { get; set; }
        public int Veces_Facturadas { get; set; }

    }

    public class MEstProveedorRecurrente
    {
        public int Codigo_Proveedor { get; set; }
        public string Nombre_Empresa { get; set; }
        public int Total_Productos { get; set; }

    }

    public class MEstProductoAdquirido
    {
        public string Codigo_Producto { get; set; }
        public string Descripcion { get; set; }
        public string Tipo_Producto { get; set; }
        public int Total_Productos { get; set; }

    }

    public class MEstLaboratorioRecurrente
    {
        public int Codigo_Laboratorio { get; set; }
        public string Nombre { get; set; }
        public int Cantidad_Pedidos { get; set; }

    }

    public class MEstProductoPedidos
    {
        public string Codigo_Producto { get; set; }
        public string Descripcion { get; set; }
        public string Tipo_Producto { get; set; }
        public int Veces_Pedidas { get; set; }

    }

    public class MEstPacienteRecurrente
    {
        public string Cliente { get; set; }
        public int Edad {  get; set; }
        public int Examenes_Realizados { get; set; }

    }

    public class MEstEdadesRecurrente
    {
        public int Edad { get; set; }
        public int Cantidad_Pacientes { get; set; }

    }

    public class MEstTipoPagoPreferido
    {
        public string Tipo_Pago { get; set; }
        public int Frecuencia_de_uso { get; set; }

    }

    public class MEstEmpleadoFactura
    {
        public int Numero_Empleado { get; set; }
        public string Empleado { get; set; }
        public int Facturas_Emitidas { get; set; }

    }

    public class MEstEmpleadoExamen
    {
        public int Numero_Empleado { get; set; }
        public string Empleado { get; set; }
        public int Examenes_Realizados { get; set; }

    }

    public class MEstEmpleadoOrdenes
    {
        public int Numero_Empleado { get; set; }
        public string Empleado { get; set; }
        public int Pedidos_Realizados { get; set; }

    }

    public class MEstRolesFrecuentes
    {
        public string Rol { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad_Usuarios { get; set; }

    }
    public class MEstIngresosVsGastos
    { 
        public string Codigo_Producto { get; set; }
        public string Descripcion { get; set; }
        public string Tipo_Producto { get; set; }
        public int Cantidad_Actual { get; set; }
        public int Cantidades_Vendidas { get; set; }
        public decimal Costo_Venta { get; set; }
        public decimal Total_Vendido { get; set; }
        public int Cantidad_Obtenida { get; set; }
        public decimal Costo_Obtencion { get; set; }
        public int Cantidad_Pedidos { get; set; }
        public decimal Costo_Pedido { get; set; }
        public decimal Costo_Total { get; set; }
        public decimal Beneficios { get; set; }

    }

    public class MEstIngresosVsGastosTotal
    {
        public int Cantidades_Vendidas { get; set; }
        public decimal Costo_Venta { get; set; }
        public decimal Total_Vendido { get; set; }
        public int Cantidad_Obtenida { get; set; }
        public decimal Costo_Obtencion { get; set; }
        public int Cantidad_Pedidos { get; set; }
        public decimal Costo_Pedido { get; set; }
        public decimal Costo_Total { get; set; }
        public decimal Beneficios { get; set; }

    }
}
