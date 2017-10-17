using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;

namespace Crear_Base_de_Datos
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            Servidores ser = new Servidores();
            this.Hide();
            ser.ShowDialog();
            txtNombre.Focus();
        }
        private void BttCrear_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection("Server=" + Servidores.Servidor + "; " + "database=master; integrated security=yes");
            try
            {
                cnn.Open();
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                cnn = new SqlConnection("Server=" + Servidores.Servidor2 + "; " + "database=master; integrated security=yes");
            }
            String cadena1 = "CREATE DATABASE " + txtNombre.Text;
            String tabla1 = "Use " + txtNombre.Text + ";" +
                "CREATE TABLE [dbo].[Tipo de Usuarios](" +
                "[Número] [int] IDENTITY(1,1) NOT NULL," +
                "[Id Tipo Usuario]  AS('TU' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Nombre] [varchar](15) NOT NULL," +
                "[Clave] [varchar](15) NOT NULL," +
                "CONSTRAINT [PK_Tipo de Usuarios] PRIMARY KEY ([Id Tipo Usuario]))";
            String tabla2 = "CREATE TABLE [dbo].[Usuarios](" +
                "[Número] [int] IDENTITY(1,1) NOT NULL," +
                "[Id Usuario]  AS('US' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Nombres] [varchar](50) NOT NULL," +
                "[Apellidos] [varchar](50) NOT NULL," +
                "[Contraseña] [varchar](max) NOT NULL," +
                "[Correo] [varchar](50) NOT NULL," +
                "[FK Tipo Usuario] [varchar](5) NOT NULL references [Tipo de Usuarios]([Id Tipo Usuario])," +
                "CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id Usuario]))";
            String tabla3 = "CREATE TABLE [dbo].[Tipo de Socio](" +
                 "[Número] [int] IDENTITY(1,1) NOT NULL," +
                "[id Tipo de Socio]  AS('TS' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Nombre Tipo Socio] [varchar](50) NOT NULL," +
                "CONSTRAINT[PK_Tipo de Socio] PRIMARY KEY ([id Tipo de Socio]))";
            String tabla4 = "CREATE TABLE [Tipo de Transacción](" +
                "[Número][int] IDENTITY(1, 1) NOT NULL," +
                "[id Tipo de Transacción]  AS('TT' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL primary key," +
                "[Tipo de Transacción] varchar(20) unique NOT NULL)";
            String tabla5 = "CREATE TABLE Transacciones(" +
                 "[Número][int] IDENTITY(1, 1) NOT NULL," +
                "[id Transacción]  AS('TR' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL primary key," +
                "[ID Usuario Transacción] varchar(5) references [Usuarios]([Id Usuario]), " +
                "[FK Tipo de Transacción] [varchar](5) NOT NULL references [Tipo de Transacción]([id Tipo de Transacción])," +
                "[Fecha de Transacción] datetime NOT NULL)";
            String tabla6 = "CREATE TABLE [dbo].[Tipo de Ahorro](" +
                "[Número][int] IDENTITY(1, 1) NOT NULL," +
                "[id Tipo Ahorro]  AS('TA' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Nombre] [varchar](20) NOT NULL," +
                "[Tasa de Interés] [decimal](10, 2) NOT NULL," +
                "CONSTRAINT[PK_Tipo de Ahorro] PRIMARY KEY ([id Tipo Ahorro]))";
            String tabla7 = "CREATE TABLE [dbo].[Ocupación](" +
                "[Número][int] IDENTITY(1, 1) NOT NULL," +
                "[Id Ocupación]  AS('OC' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Nombre de la Empresa] [varchar](60) NOT NULL," +
                "CONSTRAINT[PK_Ocupación] PRIMARY KEY ([Id Ocupación]))";
            String tabla8 = "CREATE TABLE [dbo].[Asociado](" +
                "[Número][int] IDENTITY(1, 1) NOT NULL," +
                "[Código Asociado]  AS('AS' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[FK Tipo Socio] [varchar](5) NOT NULL," +
                "[Nombres] [varchar](50) NOT NULL," +
                "[Apellidos] [varchar](50) NOT NULL," +
                "[DUI] [varchar](10) NOT NULL," +
                "[NIT] [varchar](17) NOT NULL," +
                "[Dirección] [varchar](100) NULL," +
                "[Fecha de Nacimiento] [datetime] NOT NULL," +
                "[Fecha de Asociación] [datetime] NOT NULL," +
                "[Fecha de Desasociación] [datetime] NULL," +
                "[Estado] [varchar](10) NOT NULL, " +
                "[FK Ocupación] [varchar](5) NOT NULL," +
                "CONSTRAINT [PK_Asociado] PRIMARY KEY ([Código Asociado])," +
                "CONSTRAINT [FK Tipo Socio] FOREIGN KEY ([FK Tipo Socio])" +
                "REFERENCES [Tipo de Socio]([id Tipo de Socio])," +
                "CONSTRAINT [FK Ocupación] FOREIGN KEY ([FK Ocupación])" +
                "REFERENCES Ocupación([Id Ocupación]))";
            String tabla9 = "CREATE TABLE [dbo].[Aportaciones](" +
                "[Número] [int] IDENTITY(1,1) NOT NULL," +
                "[id Aportación]  AS('AP' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Aportación] [smallmoney] NOT NULL," +
                "[FK Asociado] [varchar](5) NOT NULL," +
                "[FK Transacción] [varchar](5) references [Transacciones]([id Transacción])," +
                "CONSTRAINT[PK_Aportaciones] PRIMARY KEY([id Aportación])," +
                "CONSTRAINT [FK Asociado] FOREIGN KEY ([FK Asociado])" +
                "REFERENCES Asociado([Código Asociado]))";
            String tabla10 = "CREATE TABLE[dbo].[Ahorro](" +
                "[Número] [int] IDENTITY(1,1) NOT NULL," +
                "[id Ahorro]  AS('AH' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Estado] [varchar](1) NOT NULL," +
                "[FK Tipo Ahorro] [varchar](5) NOT NULL," +
                "[FK Código de Asociado] [varchar](5) NOT NULL," +
                "CONSTRAINT [PK_Ahorro] PRIMARY KEY ([id Ahorro])," +
                "CONSTRAINT [FK Tipo Ahorro] FOREIGN KEY ([FK Tipo Ahorro])" +
                "REFERENCES [Tipo de Ahorro]([id Tipo Ahorro])," +
                "CONSTRAINT [FK Código de Asociado] FOREIGN KEY ([FK Código de Asociado])" +
                "REFERENCES Asociado([Código Asociado]))";
            String tabla11 = "CREATE TABLE [dbo].[Retiros](" +
                "[Número][int] IDENTITY(1, 1) NOT NULL," +
                "[id Retiro]  AS('RE' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Retiro] [smallmoney] NOT NULL," +
                "[Número de Cheque] [varchar](8) NOT NULL," +
                "[FK Ahorro] [varchar](5) NOT NULL," +
                "[FK Transacción] [varchar](5) references [Transacciones]([id Transacción])," +
                "CONSTRAINT[PK_Retiros] PRIMARY KEY ([id Retiro])," +
                "CONSTRAINT [FK Ahorro] FOREIGN KEY ([FK Ahorro])" +
                "REFERENCES Ahorro([id Ahorro]))";
            String tabla12 = "CREATE TABLE [dbo].[Abono](" +
                "[Número][int] IDENTITY(1,1) NOT NULL," +
                "[id Abono]  AS('AB' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Abono] [smallmoney] NOT NULL," +
                "[FK Ahorro] [varchar](5) NOT NULL," +
                "[FK Transacción] [varchar](5) references [Transacciones]([id Transacción])," +
                "CONSTRAINT [PK Abono] PRIMARY KEY ([id Abono])," +
                "CONSTRAINT [FK Abono] FOREIGN KEY ([FK Ahorro])" +
                "references Ahorro([id Ahorro]))";
            String tabla13 = "CREATE TABLE [dbo].[Tipos de Teléfonos](" +
                "[Número][int] IDENTITY(1, 1) NOT NULL," +
                "[id Tipo de Teléfono]  AS('TF' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Tipo de Teléfono] [varchar](50) NOT NULL," +
                "CONSTRAINT [PK Tipo de Teléfono] PRIMARY KEY ([id Tipo de Teléfono]))";
            String tabla14 = "CREATE TABLE [dbo].[Teléfono](" +
                "[Número][int] identity(1,1) NOT NULL," +
                "[id Teléfono] AS('TE' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Teléfono][varchar](10) NOT NULL," +
                "[FK Tipo de Teléfono][varchar](5) NOT NULL references [Tipos de Teléfonos]([id Tipo de Teléfono])," +
                "CONSTRAINT [PK Teléfono] PRIMARY KEY ([id Teléfono]))";
            String tabla15 = "CREATE TABLE [dbo].[Contacto](" +
                "[FK Teléfono] [varchar](5) NOT NULL references[Teléfono]([id Teléfono])," +
                "[FK Código Asociado] [varchar](5) NOT NULL references Asociado([Código Asociado]))";
            String tabla16 = "Create table [dbo].[Pago](" +
                "[Número][int] identity(1, 1) NOT NULL," +
                "[id Pago] AS('PA' + right('000' + Convert([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Pago] [smallmoney] NOT NULL," +
                "[Número de Cuota] [int] NOT NULL," +
                "[Intereses] [smallmoney] NOT NULL," +
                "[Capital] [smallmoney] NOT NULL," +
                "[Saldo] [smallmoney] NOT NULL," +
                "[FK Transacción] [varchar](5) references [Transacciones]([id Transacción])," +
                 "CONSTRAINT [PK Pago] PRIMARY KEY ([id Pago]))";
            String tabla17 = "Create table [dbo].[Forma de Pago](" +
                "[Número] [int] identity(1, 1) NOT NULL," +
                "[id Forma de Pago] AS('FP' + right('000' + Convert([varchar](3), [Número]), (3))) PERSISTED NOT NULL," +
                "[Nombre] [varchar](50) NOT NULL unique," +
                "CONSTRAINT [PK_Forma de Pago] PRIMARY KEY ([id Forma de Pago]))";
            String tabla18 = "Create table [dbo].[Tipo de Préstamo](" +
                "[Número] [int] identity(1,1) NOT NULL," +
                "[id Tipo de Préstamo] AS('TP' + right('000'+Convert([varchar](3), [Número]), (3))) PERSISTED NOT NULL," +
                "[Tipo de Préstamo] [varchar](50) NOT NULL Unique," +
                "[Tasa de Interés] [decimal](10, 2) NOT NULL," +
                "CONSTRAINT [PK_Tipo de Préstamo] PRIMARY KEY ([id Tipo de Préstamo]))";
            String tabla19 = "Create table [Préstamos](" +
                "[Número] [int] identity(1,1)," +
                "[id Préstamos] AS('PP-' + right('000000'+Convert([varchar](6), [Número]), (6))) PERSISTED NOT NULL PRIMARY KEY," +
                "[Código Asociado] [varchar](5) NOT NULL references [Asociado]([Código Asociado])," +
                "[id Forma de Pago] [varchar](5) references[Forma de Pago]([id Forma de Pago]) NOT NULL," +
                "[id Tipo de Préstamo] [varchar](5) references [Tipo de Préstamo]([id Tipo de Préstamo]) NOT NULL," +
                "[Fecha de Otorgamiento] [datetime] NOT NULL," +
                "[Cuotas] [int] NOT NULL," +
                "[Monto del Préstamo] [smallmoney] NOT NULL," +
                "[Cuota Mensual] [smallmoney] NOT NULL," +
                "[FK Transacción] [varchar](5) references [Transacciones]([id Transacción])," +
                "[Estado] [varchar](10) NOT NULL)";
            String tabla20 = "Create Table [Información](" +
                "[id Pago] [varchar](5) references [Pago]([id Pago])NOT NULL," +
                "[id Préstamo] [varchar](9) references [Préstamos]([id Préstamos])NOT NULL," +
                "[Mora] [smallmoney]," +
                "[Fecha Límite][datetime] NOT NULL)";
            String tabla21 = "Create Procedure[Insertar Asociado]" +
                "@FK_Tipo_Socio varchar(50), " +
                "@Nombres varchar(80), " +
                "@Apellidos varchar(80), " +
                "@DUI varchar(10), " +
                "@NIT varchar(17), " +
                "@Residencia varchar(100), " +
                "@Fecha_Nacimiento datetime, " +
                "@Fecha_Asociación datetime, " +
                "@FK_Ocupacion varchar(30) " +
                "As " +
                "Begin Tran Asociado " +
                "Begin try " +
                "Declare @ID_Tipo_Socio as varchar(5) " +
                "Declare @ID_Ocupación as varchar(5) " +
                "set @ID_Tipo_Socio = (Select[id Tipo de Socio] From[Tipo de Socio] where[Nombre Tipo Socio] = @FK_Tipo_Socio) " +
                "set @ID_Ocupación = (Select[Id Ocupación] From[Ocupación] where[Nombre de la Empresa] = @FK_Ocupacion) " +
                "Insert into Asociado values(@ID_Tipo_Socio, @Nombres, @Apellidos, @DUI, @NIT, @Residencia, @Fecha_Nacimiento, @Fecha_Asociación, null, 'ACTIVO', @ID_Ocupación) " +
                "Commit tran Asociado " +
                "End try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback tran Asociado " +
                "End Catch ";
            //Cambiado los nombres para cargar las variables y añadiendo campos
            String tabla22 = "Create Procedure[Cargar Asociados] " +
                "@Código_Asociado varchar(5) " +
                "As " +
                "Begin Tran Cargar_Asociados " +
                "Begin Try " +
                "Select [Tipo de Socio].[Nombre Tipo Socio] AS 'Tipo de Asociación', Nombres AS 'Name', Apellidos AS 'LName',DUI AS 'DDui', NIT AS 'DNit', " +
                "Dirección AS 'Residencia', [Fecha de Nacimiento] AS 'FNacimiento', [Fecha de Asociación] AS 'FAsociación', [Fecha de Desasociación] AS 'FDesasociación', " +
                "Ocupación.[Nombre de la Empresa] AS 'Trabajo' From Asociado inner join [Tipo de Socio] on [Tipo de Socio].[id Tipo de Socio]=Asociado.[FK Tipo Socio] " +
                "inner join Ocupación on Ocupación.[Id Ocupación] = Asociado.[FK Ocupación] where [Código Asociado] = @Código_Asociado " +
                "Commit Tran Cargar_Asociados " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Cargar_Asociados " +
                "End Catch";
            String tabla23 = "Create Procedure[Insertar Teléfono] " +
                "@Tipo_Teléfono varchar(50),  " +
                "@Teléfono varchar(9), " +
                "@DUI varchar(10) " +
                "As " +
                "Begin Tran Teléfono " +
                "Begin Try " +
                "Declare @ID_Asociado varchar(5) " +
                "Declare @ID_Tipo_Teléfono varchar(5) " +
                "Declare @ID_Teléfono varchar(5) " +
                "Begin " +
                "Set @ID_Asociado = (Select[Código Asociado] From Asociado where @DUI = DUI)  " +
                "Set @ID_Tipo_Teléfono = (Select[id Tipo de Teléfono] From[Tipos de Teléfonos] where @Tipo_Teléfono =[Tipo de Teléfono]) " +
                "Insert into Teléfono values(@Teléfono, @ID_Tipo_Teléfono) " +
                "set @ID_Teléfono = (Select Max([id Teléfono]) From Teléfono) " +
                "Insert into Contacto values(@ID_Teléfono, @ID_Asociado) " +
                "Commit Tran Teléfono " +
                "End " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Teléfono " +
                "End Catch";
            String tabla24 = "Create Procedure[Cargar Teléfonos] " +
                "@Código_Asociado varchar(5) " +
                "As " +
                "Begin Tran Cargar_Teléfonos " +
                "Begin Try " +
                "Select Teléfono.Teléfono AS 'Número de Teléfono',[Tipos de Teléfonos].[Tipo de Teléfono]  From Teléfono " +
                "inner join Contacto on Teléfono.[id Teléfono]=Contacto.[FK Teléfono] inner join [Tipos de Teléfonos] on [Tipos de Teléfonos].[id Tipo de Teléfono] = Teléfono.[FK Tipo de Teléfono] " +
                "where Contacto.[FK Código Asociado] = @Código_Asociado " +
                "Commit Tran Cargar_Teléfonos " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Cargar_Teléfonos " +
                "End Catch ";
            String tabla25 = "Create Procedure[Modificar Teléfonos] " +
                "@Tipo_Telefono varchar(50), " +
                "@ID_Teléfono varchar(5), " +
                "@Teléfono varchar(10), " +
                "@Código_Asociado varchar(5) " +
                "As " +
                "Begin Tran Mod_Tel " +
                "Begin Try " +
                "If(Select [Tipos de Teléfonos].[Tipo de Teléfono] From[Tipos de Teléfonos] inner join Teléfono " +
                "on[Tipos de Teléfonos].[id Tipo de Teléfono] = Teléfono.[FK Tipo de Teléfono] where Teléfono.[id Teléfono] = @ID_Teléfono) " +
                "= @Tipo_Telefono " +
                "Begin " +
                "Update Teléfono set Teléfono = @Teléfono where @ID_Teléfono =[id Teléfono] " +
                "Commit Tran Mod_Tel " +
                "End; " +
                "Else " +
                "Declare @ID_Tipo_Teléfono as varchar(5) " +
                "set @ID_Tipo_Teléfono = (Select[id Tipo de Teléfono] From[Tipos de Teléfonos] where[Tipo de Teléfono] = @Tipo_Telefono) " +
                "Update Teléfono set Teléfono = @Teléfono, [FK Tipo de Teléfono] = @ID_Tipo_Teléfono where @ID_Teléfono = [id Teléfono] " +
                "Commit Tran Mod_Tel " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Mod_Tel " +
                "End Catch";
            String tabla26 = "Create Procedure[Eliminar Teléfono] " +
                "@ID_Teléfono varchar(5) " +
                "As   " +
                "Begin Tran Del_Teléfono " +
                "Begin Try " +
                "Begin " +
                "Delete From Contacto where @ID_Teléfono = [FK Teléfono] " +
                "Commit Tran Del_Teléfono " +
                "End " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Del_Teléfono " +
                "End Catch ";
            String tabla27 = "Create Procedure[Nueva Cuenta Ahorro] " +
                "@FK_Tipo_Ahorro varchar(20), " +
                "@FK_Asociado varchar(5) " +
                "As " +
                "Begin Tran Ahorro " +
                "Begin try " +
                "Declare @ID_Tipo_Ahorro as varchar(5) " +
                "Declare @Contar_Activos as int " +
                "set @ID_Tipo_Ahorro = (Select[id Tipo Ahorro] From[Tipo de Ahorro] where Nombre = @FK_Tipo_Ahorro) " +
                "set @Contar_Activos = (Select COUNT([id Ahorro]) from Ahorro where [FK Código de Asociado] = @FK_Asociado AND Estado = 'A') " +
                "if @Contar_Activos < 3 " +
                "Begin " +
                "Insert into Ahorro values('ACTIVO',@ID_Tipo_Ahorro,@FK_Asociado) " +
                "Commit tran Asociado " +
                "End " +
                "else " +
                "Begin  " +
                "Print 'El usuario ya tiene 3 cuentas de ahorro activas' " +
                "End " +
                "End try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback tran Asociado " +
                "End Catch ";
            //Cambiado para que se muestre el dui //Nombre Cambiado
            String tabla28 = "Create Procedure[Ahorro DVG] " +
                "As " +
                "Begin Tran Ahorro_DVG " +
                "Begin Try " +
                "Select Ahorro.[id Ahorro] as 'Código de Ahorro',(Asociado.Nombres+' ' +Asociado.Apellidos) as 'Persona Asociada', Asociado.DUI as 'Dui' ,[Tipo de Ahorro].Nombre as 'Tipo de Ahorro' From Asociado inner join Ahorro " +
                "on Ahorro.[FK Código de Asociado] = Asociado.[Código Asociado] inner join [Tipo de Ahorro] on Ahorro.[FK Tipo Ahorro]=[Tipo de Ahorro].[id Tipo Ahorro] " +
                "where Ahorro.Estado = 'ACTIVO' " +
                "Commit Tran Ahorro_DVG " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Cargar_Ahorros " +
                "End Catch";
            String tabla29 = "Create Procedure[dbo].[Realizar Aportación] " +
                "@Aportación smallmoney, " +
                "@Fecha_Aportación datetime,  " +
                "@ID_Asociado varchar(5), " +
                "@Id_Usuario varchar(5) " +
                "As " +
                "Begin Tran Aportación " +
                "Begin try " +
                "If Exists(Select Aportaciones.[id Aportación] from Aportaciones inner join Transacciones on Aportaciones.[FK Transacción]= Transacciones.[id Transacción] " +
                "where MONTH(Transacciones.[Fecha de Transacción])= MONTH(GETDATE())AND YEAR(Transacciones.[Fecha de Transacción]) = YEAR(GETDATE()) " +
                "AND Aportaciones.[FK Asociado]= @ID_Asociado) " +
                "Begin " +
                "Print 'Ya se realizó aportación mensual' " +
                "Rollback tran Asociado " +
                "End " +
                "Else " +
                "Declare @id_Transación varchar(5) " +
                "Insert into Transacciones values(@Id_Usuario, 'TT001',@Fecha_Aportación) " +
                "set @id_Transación = (Select MAX([id Transacción]) From Transacciones) " +
                "Insert into Aportaciones values(@Aportación, @ID_Asociado, @id_Transación) " +
                "Commit tran Asociado " +
                "End try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback tran Asociado " +
                "End Catch ";
            String tabla30 = "Create Procedure[Cargar Aportaciones] " +
                "@Código_Asociado varchar(5) " +
                "As " +
                "Begin Tran C_Aportaciones " +
                "Begin Try " +
                "Select Aportaciones.Aportación as ' Monto de la Aportación',Transacciones.[Fecha de Transacción] as 'Fecha de Aportación' From Aportaciones inner join Transacciones on Aportaciones.[FK Transacción] =" +
                "Transacciones.[id Transacción] where @Código_Asociado = Aportaciones.[FK Asociado] " +
                "Commit Tran C_Aportaciones " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran C_Aportaciones " +
                "End Catch";
            String tabla31 = "Create Procedure[Suma Aportaciones] " +
                "@Código_Asociado varchar(5) " +
                "As " +
                "Begin Tran S_Aportaciones " +
                "Begin Try " +
                "Select SUM(Aportación) AS 'Suma de Aportaciones' From Aportaciones where @Código_Asociado = [FK Asociado] " +
                "Commit Tran S_Aportaciones " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran S_Aportaciones  " +
                "End Catch ";
            //Cambio para visualizar más campos en la consulta
            String tabla32 = "Create Procedure[Cargar Pagos] " +
                "@ID_Préstamo varchar(9) " +
                "As " +
                "Begin Tran Cargar_Pagos " +
                "Begin Try " +
                "Select Pago.[Número de Cuota] as 'No Pago', Pago.Pago as 'Monto Cancelado', Pago.Intereses as 'Pago a Intereses', Pago.Capital as 'Pago a Capital', Información.Mora as 'Mora por retraso', Pago.Saldo as 'Saldo restante', Transacciones.[Fecha de Transacción] as 'Fecha de Pago', Información.[Fecha Límite] as 'Fecha Límite de Pago' From Pago " +
                "inner join Información on Pago.[id Pago] = Información.[id Pago] Inner join Préstamos on Información.[id Préstamo] = Préstamos.[id Préstamos] " +
                "inner join Transacciones on Préstamos.[FK Transacción] = Transacciones.[id Transacción] where Préstamos.[id Préstamos]=@ID_Préstamo " +
                "Commit Tran Cargar_Pagos " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Cargar_Pagos " +
                "End Catch ";
            //Se realizó cambio para que no pida el id del usuario
            String tabla33 = "Create Procedure[Abonar] " +
                "@Abono smallmoney, " +
                "@Fecha_Abono datetime, " +
                "@FK_Ahorro varchar(40) " +
                "As " +
                "Begin Tran Abono " +
                "Begin Try " +
                "Declare @id_Transación varchar(5) " +
                "Declare @Id_Usuario varchar(5) " +
                "set @Id_Usuario = (Select Ahorro.[FK Código de Asociado] from Ahorro where [id Ahorro]=@FK_Ahorro) " +
                "Insert into Transacciones values(@Id_Usuario, 'TT002',@Fecha_Abono) " +
                "set @id_Transación = (Select MAX([id Transacción]) From Transacciones) " +
                "Insert into Abono values(@Abono, @FK_Ahorro, @id_Transación) " +
                "Commit Tran Abono " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback tran Abono " +
                "End Catch ";
            String tabla34 = "Create Procedure[Cargar Abonos] " +
                "@ID_Ahorro varchar(5) " +
                "As " +
                "Begin Tran Cargar_Abono " +
                "Begin Try " +
                "Select Abono.Abono as 'Monto Abonado',Transacciones.[Fecha de Transacción] as 'Fecha de Abono' From Abono inner join Transacciones on Abono.[FK Transacción] = Transacciones.[id Transacción] " +
                "where[FK Ahorro] = @ID_Ahorro " +
                "Commit Tran Cargar_Abono " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Cargar_Abono " +
                "End Catch";
            String tabla35 = "Create Procedure[Suma Abonos] " +
                "@ID_Ahorro varchar(5) " +
                "As " +
                "Begin Tran Disponibles_Abono " +
                "Begin Try " +
                "Select SUM(Abono) AS 'Suma de Abonos' From Abono where[FK Ahorro] = @ID_Ahorro " +
                "Commit Tran Disponibles_Abono  " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Disponibles_Abono " +
                "End Catch";
            String tabla36 = "Create Procedure[Realizar Retiros] " +
                "@Retiro smallmoney, " +
                "@Fecha_Retiro date, " +
                "@Número_Cheque varchar(8), " +
                "@FK_Ahorro varchar(30), " +
                "@Id_Usuario varchar(5) " +
                "As " +
                "Begin Try " +
                "Begin Tran Retiro " +
                "Declare @id_Transación varchar(5) " +
                "Insert into Transacciones values(@Id_Usuario, 'TT005',@Fecha_Retiro) " +
                "set @id_Transación = (Select MAX([id Transacción]) From Transacciones) " +
                "Insert into Retiros values(@Retiro,@Número_Cheque, @FK_Ahorro, @id_Transación) " +
                "Commit Tran Retiro " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback tran Retiro " +
                "End Catch ";
            String tabla37 = "Create Procedure[Cargar Retiros] " +
                "@ID_Ahorro varchar(5) " +
                "As " +
                "Begin Tran Cargar_Retiro " +
                "Begin Try " +
                "Select Retiros.Retiro as 'Monto Retirado',Transacciones.[Fecha de Transacción] as 'Fecha de Retiro' From Retiros inner join Transacciones on Retiros.[FK Transacción] = Transacciones.[id Transacción] " +
                "where[FK Ahorro] = @ID_Ahorro " +
                "Commit Tran Cargar_Retiro " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Cargar_Retiro " +
                "End Catch ";
            String tabla38 = "Create Procedure[Suma Retiros] " +
                "@ID_Ahorro varchar(5) " +
                "As " +
                "Begin Tran Disponibles_Retiro " +
                "Begin Try " +
                "Select SUM(Retiro) AS 'Suma de Retiros' From Retiros where[FK Ahorro] = @ID_Ahorro " +
                "Commit Tran Disponibles_Retiro " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Disponibles_Retiro " +
                "End Catch ";
            //Cambiado por el n de cuota
            String tabla39 = "Create Procedure[Realizar Pago] " + 
                "@ID_Préstamo varchar(9), "+
                "@Pago smallmoney, " +
                "@Id_Usuario varchar(5),  " +
                "@Intereses smallmoney, " +
                "@Capital smallmoney,  " +
                "@Saldo smallmoney, " +
                "@Mora smallmoney,  " +
                "@Fecha_Límite datetime, " +
                "@Fecha_Pago datetime " +
                "As Begin Tran Pago " +
                "Begin Try " +
                "Declare @ID_Pago varchar(5)  " +
                "Declare @id_Transación varchar(5) " +
                "Declare @No_Cuota int " +
                "Insert into Transacciones values(@Id_Usuario, 'TT004', @Fecha_Pago) " +
                "set @id_Transación = (Select MAX([id Transacción]) From Transacciones)  " +
                "Set @No_Cuota = (Select MAX(Pago.[Número de Cuota]) From Pago inner join Información on Información.[id Pago] = Pago.[id Pago] inner join Préstamos on Préstamos.[id Préstamos] = Información.[id Préstamo] " +
                "Where Préstamos.[Código Asociado]=@ID_Préstamo)  " +
                "Insert into Pago values(@Pago, @No_Cuota + 1, @Intereses, @Capital, @Saldo, @id_Transación) " +
                "Set @ID_Pago = (Select Max([id Pago])From Pago)  " +
                "Insert into Información values(@ID_Pago, @ID_Préstamo, @mora, @Fecha_Límite) " +
                "Commit Tran Pago " +
                "End Try Begin Catch Print ERROR_MESSAGE(); Rollback Tran Pago End Catch ";
            String tabla41 = "Create Procedure[Cargar Saldo] " +
                "@ID_Préstamo varchar(9) " +
                "As " +
                "Begin Tran Cargar_Saldo " +
                "Begin Try " +
                "Select Min(Pago.Saldo) AS 'Pago Mínimo' From Pago inner join Información on Pago.[id Pago] = Información.[id Pago] inner join Préstamos " +
                "on Información.[id Préstamo] = Préstamos.[id Préstamos] where Préstamos.[id Préstamos]=@ID_Préstamo " +
                "Commit Tran Cargar_Saldo " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Cargar_Saldo " +
                "End Catch ";
            String tabla42 = "Create Trigger[Préstamo Cancelado] " +
                "On Información For Insert " +
                "As " +
                "Begin Transaction " +
                "Begin Try " +
                "Declare @Pago_Ultimo smallmoney " +
                "Select @Pago_Ultimo = Pago.Saldo From inserted " +
                "inner join Pago on Pago.[id Pago] = inserted.[id Pago] " +
                "inner join Préstamos on Préstamos.[id Préstamos] = inserted.[id Préstamo] " +
                "If(@Pago_Ultimo) = 0 " +
                "Begin  " +
                "Update Préstamos set Estado = 'CANCELADO' " +
                "From Préstamos inner join Información on Préstamos.[id Préstamos] = Información.[id Préstamo] " +
                "inner join inserted on Información.[id Pago] = inserted.[id Pago] " +
                "where Información.[id Pago] = inserted.[id Pago] " +
                "Commit Transaction " +
                "End " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE() " +
                "Rollback Transaction " +
                "End Catch ";
                //Modificación
            String tabla43 = "Create Procedure[Cargar Préstamo] " +
                "@ID_Préstamo varchar(9) " +
                 "As " +
                 "Begin Tran Cargar_P " +
                "Begin Try " +
                "Select Asociado.[Código Asociado] AS 'Código_A', (Asociado.Nombres + ' ' + Asociado.Apellidos) AS 'Nombre',[Forma de Pago].Nombre AS 'FormaP'," +
                " [Tipo de Préstamo].[Tipo de Préstamo]As 'TipoP', [Tipo de Préstamo].[Tasa de Interés] As Interés, Préstamos.[Monto del Préstamo] AS Monto, " +
                "Transacciones.[Fecha de Transacción] AS FechaT, Préstamos.Cuotas AS NCuotas, Préstamos.[Cuota Mensual] AS PCuotas, Préstamos.Estado AS Estado " +
                "From Asociado inner join [Forma de Pago] on [Forma de Pago].[id Forma de Pago] = [id Forma de Pago] inner join Préstamos on " +
                "Asociado.[Código Asociado] = Préstamos.[Código Asociado] inner join [Tipo de Préstamo] on Préstamos.[id Tipo de Préstamo] " +
                "= [Tipo de Préstamo].[id Tipo de Préstamo] inner join Transacciones on Préstamos.[FK Transacción] = Transacciones.[id Transacción] " +
                "where Préstamos.[id Préstamos]= @ID_Préstamo " +
                "Commit Tran Cargar_P " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Cargar_P " +
                "End Catch ";
            String tabla44 = "Create Procedure[Préstamo DVG] " +
                "As " +
                "Begin Tran Pres " +
                "Begin Try " +
                "Select Préstamos.[id Préstamos] as 'Código de Préstamo', (Asociado.Nombres + ' ' + Asociado.Apellidos) as 'Nombre', Asociado.DUI as 'Dui', [Tipo de Préstamo].[Tipo de Préstamo] " +
                "From Asociado inner join Préstamos on Asociado.[Código Asociado] = Préstamos.[Código Asociado] inner join [Tipo de Préstamo] " +
                "on Préstamos.[id Tipo de Préstamo] = [Tipo de Préstamo].[id Tipo de Préstamo] " +
                "Commit Tran Pres " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Pres " +
                "End Catch";
            //Cambiado para que muestre además el dui y el tipo de asociación
            String tabla45 = "Create Procedure[Asociado DVG]" +
                "As " +
                "Begin Tran Aso " +
                "Begin Try " +
                "Select Asociado.[Código Asociado] as 'Código', (Asociado.Nombres + ' ' + Asociado.Apellidos) as 'Persona Asociada',Asociado.DUI as 'Dui',[Tipo de Socio].[Nombre Tipo Socio] as 'Tipo Asociación'From Asociado inner join [Tipo de Socio] on [Tipo de Socio].[id Tipo de Socio]=Asociado.[FK Tipo Socio]where Asociado.[Estado] = 'Activo' " +
                "Commit Tran Aso " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Aso " +
                "End Catch";
            String tabla46 = "Create Procedure [Cargar Tipo Préstamo] As Begin Tran Pre Begin Try " +
                "Select[Tipo de Préstamo].[Tipo de Préstamo] AS 'TipoP',[Tipo de Préstamo].[Tasa de Interés] AS 'Interés' from[Tipo de Préstamo] " +
                "Commit Tran Pre End Try Begin Catch Print ERROR_MESSAGE(); " +
                "Rollback Tran Pre End Catch";
            String tabla47 = "Create Procedure [Cargar Tipo Socio] As Begin Tran Aso Begin Try " +
                "Select [Tipo de Socio].[Nombre Tipo Socio] AS 'TipoS' from [Tipo de Socio] " +
                "Commit Tran Aso End Try Begin Catch Print ERROR_MESSAGE(); Rollback Tran Aso End Catch";
            String tabla48 = "Create Procedure [Cargar Tipo Ahorro] As Begin Tran Aho Begin Try " +
                "Select [Tipo de Ahorro].Nombre AS 'TipoA',[Tipo de Ahorro].[Tasa de Interés] AS 'Interés' from [Tipo de Ahorro] " +
                "Commit Tran Aho End Try Begin Catch Print ERROR_MESSAGE(); Rollback Tran Aho End Catch";
            String tabla49 = "create Procedure[dbo].[Recuperar Contraseña] " +
                "@Correo varchar(50), " +
                "@Contraseña varchar(MAX) " +
                "As " +
                "Begin Tran Mod_Tel " +
                "Begin Try " +
                "Begin Update Usuarios set Contraseña = @Contraseña where @Correo =[Correo] " +
                "Commit " +
                "Tran Mod_Tel End;" +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Mod_Tel " +
                "End Catch ";
            String tabla50 =
                "create Procedure[ModificarDatos] " +
                "@Id varchar(5), " +
                "@Correo varchar(50), " +
                "@Nombre varchar(50), " +
                "@Apellido varchar(50), " +
                "@Contraseña varchar(MAX) " +
                "As " +
                "Begin Try " +
                "if exists(select Contraseña from Usuarios where Usuarios.[Id Usuario] = @Id) " +
                "Begin " +
                "update Usuarios set Correo = @Correo, Nombres = @Nombre, Apellidos = @Apellido, Contraseña = @Contraseña where[Id Usuario] = @Id; " +
                "End " +
                "Else " +
                "Begin " +
                "Print 'Ocurrió un problema al actualizar los datos.' " +
                "End " +
                "End Try " +
                "Begin Catch " +
                "Catch: " +
                "Begin " +
                "print ERROR_MESSAGE(); " +
                "End " +
                "End Catch";
            String tabla51 =
                "create Procedure[dbo].[InicioDeSesión] " +
                "@Correo varchar(50) " +
                "As " +
                "Begin Try " +
                "if exists(select * from Usuarios where Usuarios.Correo = @Correo) " +
                "Begin " +
                "select * from Usuarios where Correo = @Correo; " +
                "End " +
                "Else " +
                "Begin " +
                "Print 'No se encontró ningún usuario con esta dirección de e-mail.'; " +
                "End " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "End Catch";
            String tabla52 =
                "create Procedure[dbo].[Nuevo Usuario] " +
                "@Correo varchar(50), " +
                "@Nombre varchar(50), " +
                "@Apellido varchar(50), " +
                "@Contraseña varchar(MAX), " +
                "@Tipo_Usuario varchar(5) " +
                "As " +
                "Begin Try " +
                "if not exists(select * from Usuarios where Usuarios.Correo = @Correo) " +
                "Begin " +
                "insert into Usuarios values(@Nombre, @Apellido, @Contraseña, @Correo, @Tipo_Usuario); " +
                "End " +
                "Else " +
                "Begin " +
                "print 'Ya hay una cuenta creada con esta dirección de e-mail.'; " +
                "End " +
                "End Try " +
                "Begin Catch " +
                "Catch:  " +
                "Begin " +
                "print ERROR_MESSAGE(); " +
                "End " +
                "End Catch";
            String tabla53 =
                "Create procedure [Cargar Ocupaciones] " +
                "As " +
                "Begin " +
                "Select [Nombre de la Empresa] As 'Trabajo' from Ocupación " +
                "End";
            //Aqui se cambió para tener la referencia "TipoT"
            String tabla54 =
                "Create procedure [Cargar Tipo Teléfono] " +
                "As " +
                "Begin " +
                "Select [Tipos de Teléfonos].[Tipo de Teléfono] as 'TipoT' From [Tipos de Teléfonos] " +
                "End";
            //Faltaba este procedimiento
            String tabla55 = "Create Procedure[Cargar Ahorros] " +
                "@Código_Ahorro varchar(5) " +
               "As " +
               "Begin Tran Cargar_Ahorros " +
               "Begin Try " +
               "Select Asociado.[Código Asociado] as 'Código_A', (Asociado.Nombres+' ' + Asociado.Apellidos) as 'Nombre', Ahorro.Estado as 'Est',  [Tipo de Ahorro].Nombre as 'TipoA', [Tipo de Ahorro].[Tasa de Interés] as 'Interés' from Ahorro inner join Asociado " +
               "on Ahorro.[FK Código de Asociado] = Asociado.[Código Asociado] inner join [Tipo de Ahorro] on Ahorro.[FK Tipo Ahorro]=[Tipo de Ahorro].[id Tipo Ahorro] " +
               "where Ahorro.[id Ahorro] = @Código_Ahorro " +
               "Commit Tran Cargar_Ahorros " +
               "End Try " +
               "Begin Catch " +
               "Print ERROR_MESSAGE(); " +
               "Rollback Tran Cargar_Ahorros " +
               "End Catch";
#warning Verificar cantidad de préstamos que se pueden otorgar
            //Faltaba este procedimiento
            String tabla56 = "Create Procedure[Nuevo Préstamo] " +
                "@FK_Tipo_Préstamo varchar(20), " +
                "@FK_Asociado varchar(5), " +
                "@Forma_Pago varchar(5), " +
                "@NCuotas int, " +
                "@Monto smallmoney, " +
                "@Cuota smallmoney, " +
                "@Usuario varchar(5) " +
                "As Begin Tran Préstamo Begin try " +
                "Declare @ID_Tipo_Préstamo as varchar(5) " +
                "Declare @Contar_Emergencia as int " +
                "Declare @Contar_Normal as int " +
                "Declare @Id_Transacción as varchar(5) " +
                "set @ID_Tipo_Préstamo = (Select [id Tipo de Préstamo] From [Tipo de Préstamo] where [Tipo de Préstamo] = @FK_Tipo_Préstamo) " +
                "set @Contar_Emergencia = (Select COUNT(Préstamos.[id Préstamos]) from Préstamos inner join [Tipo de Préstamo] on [Tipo de Préstamo].[id Tipo de Préstamo] = Préstamos.[id Tipo de Préstamo] where Préstamos.[Código Asociado] = @FK_Asociado AND Estado = 'ACTIVO' AND [Tipo de Préstamo].[Tipo de Préstamo] = 'Emergencia') " +
                "set @Contar_Normal = (Select COUNT(Préstamos.[id Préstamos]) from Préstamos inner join [Tipo de Préstamo] on [Tipo de Préstamo].[id Tipo de Préstamo] = Préstamos.[id Tipo de Préstamo] where Préstamos.[Código Asociado] = @FK_Asociado AND Estado = 'ACTIVO' AND [Tipo de Préstamo].[Tipo de Préstamo] <> 'Emergencia') " +
                "IF (@FK_Tipo_Préstamo <> 'Emergencia' AND @Contar_Normal < 2 ) OR (@FK_Tipo_Préstamo = 'Emergencia' AND @Contar_Emergencia < 1) " +
                "	BEGIN " +
                "	Insert into Transacciones values(@Usuario, 'TT003', GETDATE()) " +
                "	Set @Id_Transacción = (Select MAX([id Transacción]) from Transacciones) " +
                "	Insert into Préstamos values(@FK_Asociado, @Forma_Pago,@ID_Tipo_Préstamo,GETDATE(),@NCuotas,@Monto,@Cuota,@Id_Transacción,'ACTIVO') " +
                "	Commit tran Préstamo " +
                "END " +
                "ELSE " +
                "BEGIN " +
                "	Print 'El usuario ya ha superado máximo de préstamos permitidos para este tipo de préstamo' " +
                "   return 0 " +
                "END " +
                "End try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "return 0 " +
                "Rollback tran Préstamo " +
                "End Catch";
            //Añadido para el combobox
            String tabla57 = "Create Procedure [dbo].[Cargar Tipo Pagos] " +
                "As Begin Tran Tipo_Pagos " +
                "Begin Try " +
                "Select[Forma de Pago].Nombre AS 'FormaP', [Forma de Pago].[id Forma de Pago] as 'Id' from[Forma de Pago] " +
                "Commit Tran Tipo_pagos End Try Begin Catch Print ERROR_MESSAGE(); Rollback Tran Pre End Catch";
            //Añadido para conseguir el límite anterior
            String tabla58 = "Create Procedure [Conseguir Límite] "+
                "@Id_Préstamo varchar(9) " +
                "As Begin Tran Pago " +
                "Begin Try " +
                "Declare @NPagos int " +
                "Set @NPagos = (Select Count(Pago.[Número de Cuota]) From Pago inner join Información on Información.[id Pago] = Pago.[id Pago] inner join Préstamos on Préstamos.[id Préstamos] = Información.[id Préstamo] " +
                "where Préstamos.[id Préstamos] = @Id_Préstamo) " +
                "IF @NPagos > 0 " +
                "begin " +
                "    Select Información.[Fecha Límite] as 'Límite' from Pago inner Join Información on Información.[id Pago] = Pago.[id Pago] where Pago.[Número de Cuota] = @NPagos " +
                "END " +
                "ELSE " +
                "begin " +
                "    Select Préstamos.[Fecha de Otorgamiento] as 'Límite' from Préstamos where Préstamos.[id Préstamos]= @Id_Préstamo " +
                "END " +
                "Commit tran Pago " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "return 0 " +
                "Rollback Tran Pago " +
                "End Catch";
            String Usuario1 =
                "CREATE LOGIN Master_ACOPEDH " +
                "WITH PASSWORD = 'AUREO112358' " +
                "USE " + txtNombre.Text + ";" +
                "CREATE USER Master_ACOPEDH FOR LOGIN Master_ACOPEDH ";
            String Usuario2 =
                "CREATE LOGIN Administrador " +
                "WITH PASSWORD = 'ACOPEDH365' " +
                "USE " + txtNombre.Text + ";" +
                "CREATE USER Administrador FOR LOGIN Administrador";
            String Usuario3 =
                "CREATE LOGIN Usuario " +
                "WITH PASSWORD = 'User123' " +
                "USE " + txtNombre.Text + ";" +
                "CREATE USER Usuario FOR LOGIN Usuario ";
            String Usuario4 =
                "CREATE LOGIN InicioSesion " +
                "WITH PASSWORD = 'In112358' " +
                "USE " + txtNombre.Text + ";" +
                "CREATE USER InicioSesion FOR LOGIN InicioSesion ";
            String permisosMaster_ACOPEDH =
                "Use " + txtNombre.Text + ";" +
                "Exec sp_addrolemember N'db_owner',N'Master_ACOPEDH' ";
            String permisosAdministrador =
                "Use " + txtNombre.Text + ";" +
                "grant select, update, references, insert on object :: Ahorro " +
                "to Administrador with grant option " +
                "grant select, update, references, insert on object :: [Tipo de Ahorro]" +
                "to Administrador with grant option " +
                "grant select, references, insert on object :: Retiros " +
                "to Administrador with grant option " +
                "grant select, references, insert on object :: Abono " +
                "to Administrador with grant option " +
                "grant select, update, references, insert on object :: Ocupación " +
                "to Administrador with grant option " +
                "grant select, update, insert,references, insert on object :: Asociado " +
                "to Administrador with grant option " +
                "grant select, references, insert on object :: Aportaciones " +
                "to Administrador with grant option " +
                "grant select, update, references, insert on object :: [Tipos de Teléfonos] " +
                "to Administrador with grant option " +
                "grant select, update, references, insert on object :: [Contacto] " +
                "to Administrador with grant option " +
                "grant select, update, references, insert on object :: [Teléfono] " +
                "to Administrador with grant option " +
                "grant select, update, references, insert on object :: Usuarios " +
                "to Administrador with grant option " +
                "grant select, update, references, insert on object :: [Tipo de Socio] " +
                "to Administrador with grant option " +
                "grant select on object :: [Tipo de Usuarios] " +
                "to Administrador with grant option " +
                "grant select, references, insert on object :: [Pago] " +
                "to Administrador with grant option " +
                "grant select, update, references, insert on object :: [Préstamos] " +
                "to Administrador with grant option " +
                "grant select, update, references, insert on object :: [Retiros] " +
                "to Administrador with grant option " +
                "grant select, update, references, insert on object :: [Tipo de Préstamo] " +
                "to Administrador with grant option " +
                "grant select, update, references, insert on object :: [Tipo de Transacción] " +
                "to Administrador with grant option " +
                "grant select, update, references, insert on object :: [Forma de Pago] " +
                "to Administrador with grant option " +
                "grant select, references, insert on object :: [Transacciones] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Insertar Asociado] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Cargar Asociados] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Ahorro DVG] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Cargar Ahorros] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Cargar Abonos] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Cargar Aportaciones] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Cargar Pagos] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Cargar Préstamo] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Cargar Retiros] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Cargar Saldo] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Cargar Teléfonos] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Eliminar Teléfono] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Insertar Asociado] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Insertar Teléfono] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Modificar Teléfonos] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Nueva Cuenta Ahorro] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Realizar Aportación] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Realizar Pago] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Realizar Retiros] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Suma Abonos] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Suma Aportaciones] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Suma Retiros] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Cargar Tipo Préstamo] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Cargar Tipo Socio] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Cargar Tipo Ahorro] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Nuevo Usuario] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Nuevo Préstamo] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Cargar Tipo Pagos] " +
                  "to Administrador with grant option " +
                "grant execute on object :: [Conseguir Límite] " +
                  "to Administrador with grant option ";
            String permisosUsuario =
                 "Use " + txtNombre.Text + ";" +
                 "Exec sp_addrolemember N'db_datareader',N'Usuario' " +
                "grant execute on object :: [ModificarDatos] " +
                "to Usuario with grant option " +
                "grant execute on object :: [Nuevo Usuario] " +
                "to Usuario with grant option ";
            String permisosInicioSesión =
                 "Use " + txtNombre.Text + ";" +
                 "grant select, insert on object :: Usuarios " +
                 "to InicioSesion " +
                 "grant select on object :: [Tipo de Usuarios] " +
                 "to InicioSesion " +
                 "grant execute on object :: [Recuperar Contraseña] " +
                 "to InicioSesion " +
                "grant execute on object :: [InicioDeSesión] " +
                "to InicioSesion " +
                "grant execute on object :: [Nuevo Usuario] " +
                "to InicioSesion";
            String crearusuarios =
                 "Use " + txtNombre.Text + ";" +
                 "insert into [Tipo de Usuarios] values" +
                 "('Master_ACOPEDH', 'AUREO112358')," +
                 "('Administrador', 'ACOPEDH365')," +
                 "('Usuario', 'User123')," +
                 "('InicioSesion', 'In112358')";
            String crearsocios =
                "insert into [Tipo de Socio] values ('Asociado'), ('Fundador')";
            String creartrabajos =
                "insert into Ocupación values ('PDDH')";
            String crearpagos =
                "insert into [Forma de Pago] values ('Descuento a Planilla'), ('Pago Voluntario')";
            String crearahorros =
                "insert into [Tipo de Ahorro] values ('A la Vista',0),('Vacaciones',0),('Navideño',0),('Escolar',0)";
            String crearpréstamos =
                "insert into [Tipo de Préstamo] values ('Personal',17),('Emergencia',17)";
            String insertartiposdetransacciones =
                "insert into [Tipo de Transacción] values ('Aportación'),('Abono'), ('Préstamo'), ('Pago'), ('Retiro')";
            //Añadido, la inserción de teléfonos
            String insertartiposdeteléfonos =
                 "insert into [Tipos de Teléfonos] values ('Celular'),('Casa'), ('Trabajo'), ('Fax')";
            SqlCommand cmd = new SqlCommand(cadena1, cnn);
            SqlCommand cmd1 = new SqlCommand(tabla1, cnn);
            SqlCommand cmd2 = new SqlCommand(tabla2, cnn);
            SqlCommand cmd3 = new SqlCommand(tabla3, cnn);
            SqlCommand cmd4 = new SqlCommand(tabla4, cnn);
            SqlCommand cmd5 = new SqlCommand(tabla5, cnn);
            SqlCommand cmd6 = new SqlCommand(tabla6, cnn);
            SqlCommand cmd7 = new SqlCommand(tabla7, cnn);
            SqlCommand cmd8 = new SqlCommand(tabla8, cnn);
            SqlCommand cmd9 = new SqlCommand(tabla9, cnn);
            SqlCommand cmd10 = new SqlCommand(tabla10, cnn);
            SqlCommand cmd11 = new SqlCommand(tabla11, cnn);
            SqlCommand cmd12 = new SqlCommand(tabla12, cnn);
            SqlCommand cmd13 = new SqlCommand(tabla13, cnn);
            SqlCommand cmd14 = new SqlCommand(tabla14, cnn);
            SqlCommand cmd15 = new SqlCommand(tabla15, cnn);
            SqlCommand cmd16 = new SqlCommand(tabla16, cnn);
            SqlCommand cmd17 = new SqlCommand(tabla17, cnn);
            SqlCommand cmd18 = new SqlCommand(tabla18, cnn);
            SqlCommand cmd19 = new SqlCommand(tabla19, cnn);
            SqlCommand cmd20 = new SqlCommand(tabla20, cnn);
            SqlCommand cmd21 = new SqlCommand(tabla21, cnn);
            SqlCommand cmd22 = new SqlCommand(tabla22, cnn);
            SqlCommand cmd23 = new SqlCommand(tabla23, cnn);
            SqlCommand cmd24 = new SqlCommand(tabla24, cnn);
            SqlCommand cmd25 = new SqlCommand(tabla25, cnn);
            SqlCommand cmd26 = new SqlCommand(tabla26, cnn);
            SqlCommand cmd27 = new SqlCommand(tabla27, cnn);
            SqlCommand cmd28 = new SqlCommand(tabla28, cnn);
            SqlCommand cmd29 = new SqlCommand(tabla29, cnn);
            SqlCommand cmd30 = new SqlCommand(tabla30, cnn);
            SqlCommand cmd31 = new SqlCommand(tabla31, cnn);
            SqlCommand cmd32 = new SqlCommand(tabla32, cnn);
            SqlCommand cmd33 = new SqlCommand(tabla33, cnn);
            SqlCommand cmd34 = new SqlCommand(tabla34, cnn);
            SqlCommand cmd35 = new SqlCommand(tabla35, cnn);
            SqlCommand cmd36 = new SqlCommand(tabla36, cnn);
            SqlCommand cmd37 = new SqlCommand(tabla37, cnn);
            SqlCommand cmd38 = new SqlCommand(tabla38, cnn);
            SqlCommand cmd39 = new SqlCommand(tabla39, cnn);
            SqlCommand cmd41 = new SqlCommand(tabla41, cnn);
            SqlCommand cmd42 = new SqlCommand(tabla42, cnn);
            SqlCommand cmd43 = new SqlCommand(tabla43, cnn);
            SqlCommand cmd44 = new SqlCommand(tabla44, cnn);
            SqlCommand cmd45 = new SqlCommand(tabla45, cnn);
            SqlCommand cmd46 = new SqlCommand(tabla46, cnn);
            SqlCommand cmd47 = new SqlCommand(tabla47, cnn);
            SqlCommand cmd48 = new SqlCommand(tabla48, cnn);
            SqlCommand cmd49 = new SqlCommand(tabla49, cnn);
            SqlCommand cmd50 = new SqlCommand(tabla50, cnn);
            SqlCommand cmd51 = new SqlCommand(tabla51, cnn);
            SqlCommand cmd52 = new SqlCommand(tabla52, cnn);
            SqlCommand cmd53 = new SqlCommand(Usuario1, cnn);
            SqlCommand cmd54 = new SqlCommand(Usuario2, cnn);
            SqlCommand cmd55 = new SqlCommand(Usuario3, cnn);
            SqlCommand cmd56 = new SqlCommand(Usuario4, cnn);
            SqlCommand cmd57 = new SqlCommand(tabla53, cnn);
            SqlCommand cmd58 = new SqlCommand(tabla54, cnn);
            SqlCommand cmd59 = new SqlCommand(tabla55, cnn);
            SqlCommand cmd60 = new SqlCommand(tabla56, cnn);
            SqlCommand cmd61 = new SqlCommand(tabla57, cnn);
            SqlCommand cmd62 = new SqlCommand(tabla58, cnn);
            SqlCommand cmd63 = new SqlCommand(permisosMaster_ACOPEDH, cnn);
            SqlCommand cmd64 = new SqlCommand(permisosAdministrador, cnn);
            SqlCommand cmd65 = new SqlCommand(permisosUsuario, cnn);
            SqlCommand cmd66 = new SqlCommand(permisosInicioSesión, cnn);
            SqlCommand cmd67 = new SqlCommand(crearusuarios, cnn);
            SqlCommand cmd68 = new SqlCommand(crearahorros, cnn);
            SqlCommand cmd69 = new SqlCommand(crearpagos, cnn);
            SqlCommand cmd70 = new SqlCommand(crearsocios, cnn);
            SqlCommand cmd71 = new SqlCommand(creartrabajos, cnn);
            SqlCommand cmd72 = new SqlCommand(crearpréstamos, cnn);
            SqlCommand cmd73 = new SqlCommand(insertartiposdetransacciones, cnn);
            SqlCommand cmd74 = new SqlCommand(insertartiposdeteléfonos, cnn);

            //try
            //{
                //Abrimos la conexión y ejecutamos el comando
                cnn.Open();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                cmd5.ExecuteNonQuery();
                cmd6.ExecuteNonQuery();
                cmd7.ExecuteNonQuery();
                cmd8.ExecuteNonQuery();
                cmd9.ExecuteNonQuery();
                cmd10.ExecuteNonQuery();
                cmd11.ExecuteNonQuery();
                cmd12.ExecuteNonQuery();
                cmd13.ExecuteNonQuery();
                cmd14.ExecuteNonQuery();
                cmd15.ExecuteNonQuery();
                cmd16.ExecuteNonQuery();
                cmd17.ExecuteNonQuery();
                cmd18.ExecuteNonQuery();
                cmd19.ExecuteNonQuery();
                cmd20.ExecuteNonQuery();
                cmd21.ExecuteNonQuery();
                cmd22.ExecuteNonQuery();
                cmd23.ExecuteNonQuery();
                cmd24.ExecuteNonQuery();
                cmd25.ExecuteNonQuery();
                cmd26.ExecuteNonQuery();
                cmd27.ExecuteNonQuery();
                cmd28.ExecuteNonQuery();
                cmd29.ExecuteNonQuery();
                cmd30.ExecuteNonQuery();
                cmd31.ExecuteNonQuery();
                cmd32.ExecuteNonQuery();
                cmd33.ExecuteNonQuery();
                cmd34.ExecuteNonQuery();
                cmd35.ExecuteNonQuery();
                cmd36.ExecuteNonQuery();
                cmd37.ExecuteNonQuery();
                cmd38.ExecuteNonQuery();
                cmd39.ExecuteNonQuery();
                cmd41.ExecuteNonQuery();
                cmd42.ExecuteNonQuery();
                cmd43.ExecuteNonQuery();
                cmd44.ExecuteNonQuery();
                cmd45.ExecuteNonQuery();
                cmd46.ExecuteNonQuery();
                cmd47.ExecuteNonQuery();
                cmd48.ExecuteNonQuery();
                cmd49.ExecuteNonQuery();
                cmd50.ExecuteNonQuery();
                cmd51.ExecuteNonQuery();
                cmd52.ExecuteNonQuery();
                cmd53.ExecuteNonQuery();
                cmd54.ExecuteNonQuery();
                cmd55.ExecuteNonQuery();
                cmd56.ExecuteNonQuery();
                cmd57.ExecuteNonQuery();
                cmd58.ExecuteNonQuery();
                cmd59.ExecuteNonQuery();
                cmd60.ExecuteNonQuery();
                cmd61.ExecuteNonQuery();
                cmd62.ExecuteNonQuery();
                cmd63.ExecuteNonQuery();
                cmd64.ExecuteNonQuery();
                cmd65.ExecuteNonQuery();
                cmd66.ExecuteNonQuery();
                cmd67.ExecuteNonQuery();
                cmd68.ExecuteNonQuery();
                cmd69.ExecuteNonQuery();
                cmd70.ExecuteNonQuery();
                cmd71.ExecuteNonQuery();
                cmd72.ExecuteNonQuery();
                cmd73.ExecuteNonQuery();
                cmd74.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Base Creada");
                this.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message,
            //            "Error al crear la base",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
        }
    }
}