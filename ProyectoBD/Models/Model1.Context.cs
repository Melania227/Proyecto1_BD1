﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoBD.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Proyecto_1Entities13 : DbContext
    {
        public Proyecto_1Entities13()
            : base("name=Proyecto_1Entities13")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<Automovil> Automovil { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<Detalle> Detalle { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Fabricante> Fabricante { get; set; }
        public virtual DbSet<Orden> Orden { get; set; }
        public virtual DbSet<Organizacion> Organizacion { get; set; }
        public virtual DbSet<Parte> Parte { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Proveidas_por> Proveidas_por { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Telefono_Persona> Telefono_Persona { get; set; }
        public virtual DbSet<Telefono_Proveedor> Telefono_Proveedor { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int spActualizaPrecioOrden(Nullable<int> iD_Orden, Nullable<decimal> precioIVAOrden, Nullable<decimal> precioMontoOrden, Nullable<decimal> precioMontoFinalOrden)
        {
            var iD_OrdenParameter = iD_Orden.HasValue ?
                new ObjectParameter("ID_Orden", iD_Orden) :
                new ObjectParameter("ID_Orden", typeof(int));
    
            var precioIVAOrdenParameter = precioIVAOrden.HasValue ?
                new ObjectParameter("PrecioIVAOrden", precioIVAOrden) :
                new ObjectParameter("PrecioIVAOrden", typeof(decimal));
    
            var precioMontoOrdenParameter = precioMontoOrden.HasValue ?
                new ObjectParameter("PrecioMontoOrden", precioMontoOrden) :
                new ObjectParameter("PrecioMontoOrden", typeof(decimal));
    
            var precioMontoFinalOrdenParameter = precioMontoFinalOrden.HasValue ?
                new ObjectParameter("PrecioMontoFinalOrden", precioMontoFinalOrden) :
                new ObjectParameter("PrecioMontoFinalOrden", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spActualizaPrecioOrden", iD_OrdenParameter, precioIVAOrdenParameter, precioMontoOrdenParameter, precioMontoFinalOrdenParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> spAdd_Only_Persona(Nullable<int> cedula, string nombre, string direccion, string ciudad, Nullable<int> estado)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var ciudadParameter = ciudad != null ?
                new ObjectParameter("Ciudad", ciudad) :
                new ObjectParameter("Ciudad", typeof(string));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spAdd_Only_Persona", cedulaParameter, nombreParameter, direccionParameter, ciudadParameter, estadoParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> spAddCliente(string direccion, string ciudad, Nullable<int> estado)
        {
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var ciudadParameter = ciudad != null ?
                new ObjectParameter("Ciudad", ciudad) :
                new ObjectParameter("Ciudad", typeof(string));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spAddCliente", direccionParameter, ciudadParameter, estadoParameter);
        }
    
        public virtual int spAddCliente_Organizacion_InDB(Nullable<long> cedulaJuridica, string nombre, string direccion, string ciudad, Nullable<int> estado, string nombreContacto, Nullable<int> telefono, string cargo, ObjectParameter returnMessage)
        {
            var cedulaJuridicaParameter = cedulaJuridica.HasValue ?
                new ObjectParameter("cedulaJuridica", cedulaJuridica) :
                new ObjectParameter("cedulaJuridica", typeof(long));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var ciudadParameter = ciudad != null ?
                new ObjectParameter("Ciudad", ciudad) :
                new ObjectParameter("Ciudad", typeof(string));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(int));
    
            var nombreContactoParameter = nombreContacto != null ?
                new ObjectParameter("nombreContacto", nombreContacto) :
                new ObjectParameter("nombreContacto", typeof(string));
    
            var telefonoParameter = telefono.HasValue ?
                new ObjectParameter("telefono", telefono) :
                new ObjectParameter("telefono", typeof(int));
    
            var cargoParameter = cargo != null ?
                new ObjectParameter("cargo", cargo) :
                new ObjectParameter("cargo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAddCliente_Organizacion_InDB", cedulaJuridicaParameter, nombreParameter, direccionParameter, ciudadParameter, estadoParameter, nombreContactoParameter, telefonoParameter, cargoParameter, returnMessage);
        }
    
        public virtual int spAddCliente_Persona_ConRestricciones(Nullable<int> cedula, string nombre, string direccion, string ciudad, Nullable<int> estado, ObjectParameter returnMessage)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var ciudadParameter = ciudad != null ?
                new ObjectParameter("Ciudad", ciudad) :
                new ObjectParameter("Ciudad", typeof(string));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAddCliente_Persona_ConRestricciones", cedulaParameter, nombreParameter, direccionParameter, ciudadParameter, estadoParameter, returnMessage);
        }
    
        public virtual int spAddCliente_Persona_InDB(Nullable<int> cedula, string nombre, string direccion, string ciudad, Nullable<int> estado)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("cedula", cedula) :
                new ObjectParameter("cedula", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var ciudadParameter = ciudad != null ?
                new ObjectParameter("Ciudad", ciudad) :
                new ObjectParameter("Ciudad", typeof(string));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("Estado", estado) :
                new ObjectParameter("Estado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAddCliente_Persona_InDB", cedulaParameter, nombreParameter, direccionParameter, ciudadParameter, estadoParameter);
        }
    
        public virtual int spAddTelefonoACliente(Nullable<int> cedula, Nullable<int> telefono)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(int));
    
            var telefonoParameter = telefono.HasValue ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAddTelefonoACliente", cedulaParameter, telefonoParameter);
        }
    
        public virtual int spAddTelefonoAProveedor(Nullable<int> iD_Proveedor, Nullable<int> telefono)
        {
            var iD_ProveedorParameter = iD_Proveedor.HasValue ?
                new ObjectParameter("ID_Proveedor", iD_Proveedor) :
                new ObjectParameter("ID_Proveedor", typeof(int));
    
            var telefonoParameter = telefono.HasValue ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAddTelefonoAProveedor", iD_ProveedorParameter, telefonoParameter);
        }
    
        public virtual int spAddUnaParte(string nombre, string marca, Nullable<int> iD_Fabricante, ObjectParameter outputMessage)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var marcaParameter = marca != null ?
                new ObjectParameter("Marca", marca) :
                new ObjectParameter("Marca", typeof(string));
    
            var iD_FabricanteParameter = iD_Fabricante.HasValue ?
                new ObjectParameter("ID_Fabricante", iD_Fabricante) :
                new ObjectParameter("ID_Fabricante", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAddUnaParte", nombreParameter, marcaParameter, iD_FabricanteParameter, outputMessage);
        }
    
        public virtual int spAssociateParteConAutomovil(Nullable<int> iD_Parte, Nullable<int> iD_Automovil, ObjectParameter outputMessage)
        {
            var iD_ParteParameter = iD_Parte.HasValue ?
                new ObjectParameter("ID_Parte", iD_Parte) :
                new ObjectParameter("ID_Parte", typeof(int));
    
            var iD_AutomovilParameter = iD_Automovil.HasValue ?
                new ObjectParameter("ID_Automovil", iD_Automovil) :
                new ObjectParameter("ID_Automovil", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAssociateParteConAutomovil", iD_ParteParameter, iD_AutomovilParameter, outputMessage);
        }
    
        public virtual int spAssociateParteConProveedor(Nullable<int> iD_Parte, Nullable<int> iD_Proveedor, Nullable<decimal> precio, Nullable<decimal> precioCliente, Nullable<int> porcionGanada, ObjectParameter outputMessage)
        {
            var iD_ParteParameter = iD_Parte.HasValue ?
                new ObjectParameter("ID_Parte", iD_Parte) :
                new ObjectParameter("ID_Parte", typeof(int));
    
            var iD_ProveedorParameter = iD_Proveedor.HasValue ?
                new ObjectParameter("ID_Proveedor", iD_Proveedor) :
                new ObjectParameter("ID_Proveedor", typeof(int));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(decimal));
    
            var precioClienteParameter = precioCliente.HasValue ?
                new ObjectParameter("PrecioCliente", precioCliente) :
                new ObjectParameter("PrecioCliente", typeof(decimal));
    
            var porcionGanadaParameter = porcionGanada.HasValue ?
                new ObjectParameter("PorcionGanada", porcionGanada) :
                new ObjectParameter("PorcionGanada", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spAssociateParteConProveedor", iD_ParteParameter, iD_ProveedorParameter, precioParameter, precioClienteParameter, porcionGanadaParameter, outputMessage);
        }
    
        public virtual int spChangetoSuspended_Organizacion(Nullable<long> cedulaJuridica)
        {
            var cedulaJuridicaParameter = cedulaJuridica.HasValue ?
                new ObjectParameter("CedulaJuridica", cedulaJuridica) :
                new ObjectParameter("CedulaJuridica", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spChangetoSuspended_Organizacion", cedulaJuridicaParameter);
        }
    
        public virtual int spChangetoSuspended_Persona(Nullable<int> cedula)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spChangetoSuspended_Persona", cedulaParameter);
        }
    
        public virtual int spDeleteParte(Nullable<int> iD_Parte, ObjectParameter outputMessage)
        {
            var iD_ParteParameter = iD_Parte.HasValue ?
                new ObjectParameter("ID_Parte", iD_Parte) :
                new ObjectParameter("ID_Parte", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spDeleteParte", iD_ParteParameter, outputMessage);
        }
    
        public virtual ObjectResult<Nullable<int>> spFindAutomovilParaParte(Nullable<int> iD_Parte)
        {
            var iD_ParteParameter = iD_Parte.HasValue ?
                new ObjectParameter("ID_Parte", iD_Parte) :
                new ObjectParameter("ID_Parte", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spFindAutomovilParaParte", iD_ParteParameter);
        }
    
        public virtual ObjectResult<string> spFindNombrePorID_Cliente(Nullable<int> iD_Cliente)
        {
            var iD_ClienteParameter = iD_Cliente.HasValue ?
                new ObjectParameter("ID_Cliente", iD_Cliente) :
                new ObjectParameter("ID_Cliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("spFindNombrePorID_Cliente", iD_ClienteParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> spFindPartePorModelo_Año(Nullable<int> añoFabricacion, string modelo)
        {
            var añoFabricacionParameter = añoFabricacion.HasValue ?
                new ObjectParameter("añoFabricacion", añoFabricacion) :
                new ObjectParameter("añoFabricacion", typeof(int));
    
            var modeloParameter = modelo != null ?
                new ObjectParameter("Modelo", modelo) :
                new ObjectParameter("Modelo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spFindPartePorModelo_Año", añoFabricacionParameter, modeloParameter);
        }
    
        public virtual ObjectResult<spFindProveedorDeParte_Result> spFindProveedorDeParte(string nombreParte)
        {
            var nombreParteParameter = nombreParte != null ?
                new ObjectParameter("NombreParte", nombreParte) :
                new ObjectParameter("NombreParte", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spFindProveedorDeParte_Result>("spFindProveedorDeParte", nombreParteParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> spFindProveedorParaParte(Nullable<int> iD_Parte)
        {
            var iD_ParteParameter = iD_Parte.HasValue ?
                new ObjectParameter("ID_Parte", iD_Parte) :
                new ObjectParameter("ID_Parte", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("spFindProveedorParaParte", iD_ParteParameter);
        }
    
        public virtual ObjectResult<spFindRelacionParteProveedor_Result> spFindRelacionParteProveedor(Nullable<int> iD_Parte, Nullable<int> iD_Proveedor)
        {
            var iD_ParteParameter = iD_Parte.HasValue ?
                new ObjectParameter("ID_Parte", iD_Parte) :
                new ObjectParameter("ID_Parte", typeof(int));
    
            var iD_ProveedorParameter = iD_Proveedor.HasValue ?
                new ObjectParameter("ID_Proveedor", iD_Proveedor) :
                new ObjectParameter("ID_Proveedor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spFindRelacionParteProveedor_Result>("spFindRelacionParteProveedor", iD_ParteParameter, iD_ProveedorParameter);
        }
    
        public virtual int spInsertDetalleINTOOrden(Nullable<int> iD_Orden, Nullable<int> iD_Parte, Nullable<int> iD_Proveedor, Nullable<int> cantidad, Nullable<decimal> precioPieza)
        {
            var iD_OrdenParameter = iD_Orden.HasValue ?
                new ObjectParameter("ID_Orden", iD_Orden) :
                new ObjectParameter("ID_Orden", typeof(int));
    
            var iD_ParteParameter = iD_Parte.HasValue ?
                new ObjectParameter("ID_Parte", iD_Parte) :
                new ObjectParameter("ID_Parte", typeof(int));
    
            var iD_ProveedorParameter = iD_Proveedor.HasValue ?
                new ObjectParameter("ID_Proveedor", iD_Proveedor) :
                new ObjectParameter("ID_Proveedor", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(int));
    
            var precioPiezaParameter = precioPieza.HasValue ?
                new ObjectParameter("PrecioPieza", precioPieza) :
                new ObjectParameter("PrecioPieza", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertDetalleINTOOrden", iD_OrdenParameter, iD_ParteParameter, iD_ProveedorParameter, cantidadParameter, precioPiezaParameter);
        }
    
        public virtual int spInsertOrdenEnFechaParaCliente(Nullable<System.DateTime> fecha, Nullable<int> iD_Cliente)
        {
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            var iD_ClienteParameter = iD_Cliente.HasValue ?
                new ObjectParameter("ID_Cliente", iD_Cliente) :
                new ObjectParameter("ID_Cliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertOrdenEnFechaParaCliente", fechaParameter, iD_ClienteParameter);
        }
    
        public virtual int spModify_Organizacion(Nullable<long> cedulaJuridica, string nombreOrganizacion, string ciudad, string direccion, Nullable<int> iD_Estado, string nombreContacto, Nullable<int> telefono, string cargo)
        {
            var cedulaJuridicaParameter = cedulaJuridica.HasValue ?
                new ObjectParameter("CedulaJuridica", cedulaJuridica) :
                new ObjectParameter("CedulaJuridica", typeof(long));
    
            var nombreOrganizacionParameter = nombreOrganizacion != null ?
                new ObjectParameter("NombreOrganizacion", nombreOrganizacion) :
                new ObjectParameter("NombreOrganizacion", typeof(string));
    
            var ciudadParameter = ciudad != null ?
                new ObjectParameter("Ciudad", ciudad) :
                new ObjectParameter("Ciudad", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var iD_EstadoParameter = iD_Estado.HasValue ?
                new ObjectParameter("ID_Estado", iD_Estado) :
                new ObjectParameter("ID_Estado", typeof(int));
    
            var nombreContactoParameter = nombreContacto != null ?
                new ObjectParameter("NombreContacto", nombreContacto) :
                new ObjectParameter("NombreContacto", typeof(string));
    
            var telefonoParameter = telefono.HasValue ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(int));
    
            var cargoParameter = cargo != null ?
                new ObjectParameter("Cargo", cargo) :
                new ObjectParameter("Cargo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spModify_Organizacion", cedulaJuridicaParameter, nombreOrganizacionParameter, ciudadParameter, direccionParameter, iD_EstadoParameter, nombreContactoParameter, telefonoParameter, cargoParameter);
        }
    
        public virtual int spModify_Persona(Nullable<int> cedula, string nombre, string ciudad, string direccion, Nullable<int> iD_Estado)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var ciudadParameter = ciudad != null ?
                new ObjectParameter("Ciudad", ciudad) :
                new ObjectParameter("Ciudad", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var iD_EstadoParameter = iD_Estado.HasValue ?
                new ObjectParameter("ID_Estado", iD_Estado) :
                new ObjectParameter("ID_Estado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spModify_Persona", cedulaParameter, nombreParameter, ciudadParameter, direccionParameter, iD_EstadoParameter);
        }
    
        public virtual int spModifyEstadoCliente(Nullable<int> iD_Cliente)
        {
            var iD_ClienteParameter = iD_Cliente.HasValue ?
                new ObjectParameter("ID_Cliente", iD_Cliente) :
                new ObjectParameter("ID_Cliente", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spModifyEstadoCliente", iD_ClienteParameter);
        }
    
        public virtual int spModifyGananciaProveedorDeParte(Nullable<int> iD_Parte, Nullable<int> iD_Proveedor, Nullable<int> ganancia)
        {
            var iD_ParteParameter = iD_Parte.HasValue ?
                new ObjectParameter("ID_Parte", iD_Parte) :
                new ObjectParameter("ID_Parte", typeof(int));
    
            var iD_ProveedorParameter = iD_Proveedor.HasValue ?
                new ObjectParameter("ID_Proveedor", iD_Proveedor) :
                new ObjectParameter("ID_Proveedor", typeof(int));
    
            var gananciaParameter = ganancia.HasValue ?
                new ObjectParameter("Ganancia", ganancia) :
                new ObjectParameter("Ganancia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spModifyGananciaProveedorDeParte", iD_ParteParameter, iD_ProveedorParameter, gananciaParameter);
        }
    
        public virtual int spModifyPrecioClienteINProveedorDeParte(Nullable<int> iD_Parte, Nullable<int> iD_Proveedor, Nullable<decimal> precioCliente)
        {
            var iD_ParteParameter = iD_Parte.HasValue ?
                new ObjectParameter("ID_Parte", iD_Parte) :
                new ObjectParameter("ID_Parte", typeof(int));
    
            var iD_ProveedorParameter = iD_Proveedor.HasValue ?
                new ObjectParameter("ID_Proveedor", iD_Proveedor) :
                new ObjectParameter("ID_Proveedor", typeof(int));
    
            var precioClienteParameter = precioCliente.HasValue ?
                new ObjectParameter("PrecioCliente", precioCliente) :
                new ObjectParameter("PrecioCliente", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spModifyPrecioClienteINProveedorDeParte", iD_ParteParameter, iD_ProveedorParameter, precioClienteParameter);
        }
    
        public virtual int spModifyPrecioProveedorDeParte(Nullable<int> iD_Parte, Nullable<int> iD_Proveedor, Nullable<decimal> precioProveedor, Nullable<int> ganancia)
        {
            var iD_ParteParameter = iD_Parte.HasValue ?
                new ObjectParameter("ID_Parte", iD_Parte) :
                new ObjectParameter("ID_Parte", typeof(int));
    
            var iD_ProveedorParameter = iD_Proveedor.HasValue ?
                new ObjectParameter("ID_Proveedor", iD_Proveedor) :
                new ObjectParameter("ID_Proveedor", typeof(int));
    
            var precioProveedorParameter = precioProveedor.HasValue ?
                new ObjectParameter("PrecioProveedor", precioProveedor) :
                new ObjectParameter("PrecioProveedor", typeof(decimal));
    
            var gananciaParameter = ganancia.HasValue ?
                new ObjectParameter("Ganancia", ganancia) :
                new ObjectParameter("Ganancia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spModifyPrecioProveedorDeParte", iD_ParteParameter, iD_ProveedorParameter, precioProveedorParameter, gananciaParameter);
        }
    
        public virtual int spModifyPrecioProveedorInProveedorDeParte(Nullable<int> iD_Parte, Nullable<int> iD_Proveedor, Nullable<decimal> precioProveedor)
        {
            var iD_ParteParameter = iD_Parte.HasValue ?
                new ObjectParameter("ID_Parte", iD_Parte) :
                new ObjectParameter("ID_Parte", typeof(int));
    
            var iD_ProveedorParameter = iD_Proveedor.HasValue ?
                new ObjectParameter("ID_Proveedor", iD_Proveedor) :
                new ObjectParameter("ID_Proveedor", typeof(int));
    
            var precioProveedorParameter = precioProveedor.HasValue ?
                new ObjectParameter("PrecioProveedor", precioProveedor) :
                new ObjectParameter("PrecioProveedor", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spModifyPrecioProveedorInProveedorDeParte", iD_ParteParameter, iD_ProveedorParameter, precioProveedorParameter);
        }
    
        public virtual int spModifyTelefonoAPersona(Nullable<int> cedula, Nullable<int> telefonoAnterior, Nullable<int> telefonoNuevo)
        {
            var cedulaParameter = cedula.HasValue ?
                new ObjectParameter("Cedula", cedula) :
                new ObjectParameter("Cedula", typeof(int));
    
            var telefonoAnteriorParameter = telefonoAnterior.HasValue ?
                new ObjectParameter("TelefonoAnterior", telefonoAnterior) :
                new ObjectParameter("TelefonoAnterior", typeof(int));
    
            var telefonoNuevoParameter = telefonoNuevo.HasValue ?
                new ObjectParameter("TelefonoNuevo", telefonoNuevo) :
                new ObjectParameter("TelefonoNuevo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spModifyTelefonoAPersona", cedulaParameter, telefonoAnteriorParameter, telefonoNuevoParameter);
        }
    
        public virtual ObjectResult<Nullable<decimal>> spPrecioTotalEnDetalle(Nullable<int> iD_Parte, Nullable<int> iD_Proveedor)
        {
            var iD_ParteParameter = iD_Parte.HasValue ?
                new ObjectParameter("ID_Parte", iD_Parte) :
                new ObjectParameter("ID_Parte", typeof(int));
    
            var iD_ProveedorParameter = iD_Proveedor.HasValue ?
                new ObjectParameter("ID_Proveedor", iD_Proveedor) :
                new ObjectParameter("ID_Proveedor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<decimal>>("spPrecioTotalEnDetalle", iD_ParteParameter, iD_ProveedorParameter);
        }
    }
}
