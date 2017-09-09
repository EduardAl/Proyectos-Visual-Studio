﻿using System;
using System.Windows.Forms;
using System.Data.SqlClient;

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
                "[Seguridad] [varchar](32) NOT NULL," +
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
                "@Dirección varchar(100), " +
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
                "Insert into Asociado values(@ID_Tipo_Socio, @Nombres, @Apellidos, @DUI, @NIT, @Dirección, @Fecha_Nacimiento, @Fecha_Asociación, null,@ID_Ocupación) " +
                "Commit tran Asociado " +
                "End try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback tran Asociado " +
                "End Catch ";
            String tabla22 = "Create Procedure[Cargar Asociados] " +
                "@Código_Asociado varchar(5) " +
                 "As " +
                 "Begin Tran Cargar_Asociados " +
                 "Begin Try " +
                 "Select[Código Asociado],[FK Tipo Socio], (Nombres + ' ' + Apellidos), DUI, NIT, Dirección,[Fecha de Nacimiento],[Fecha de Asociación] " +
                 "From Asociado where[Fecha de Desasociación] is null " +
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
                "Select Teléfono.Teléfono From Teléfono inner join Contacto on Teléfono.[id Teléfono]=Contacto.[FK Teléfono] " +
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
                "If(Select[Tipos de Teléfonos].[Tipo de Teléfono]From[Tipos de Teléfonos] inner join Teléfono " +
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
                "Delete From Teléfono where @ID_Teléfono = [id Teléfono] " +
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
            String tabla28 = "Create Procedure[Cargar Ahorros] " +
                "As " +
                "Begin Tran Cargar_Ahorros " +
                "Begin Try " +
                "Select Ahorro.[id Ahorro] as 'Código de Ahorro',(Asociado.Nombres+' ' +Asociado.Apellidos) as 'Persona Asociada',[Tipo de Ahorro].Nombre as 'Tipo de Ahorro' From Asociado inner join Ahorro " +
                "on Ahorro.[FK Código de Asociado] = Asociado.[Código Asociado] inner join [Tipo de Ahorro] on Ahorro.[FK Tipo Ahorro]=[Tipo de Ahorro].[id Tipo Ahorro] " +
                "where Ahorro.Estado = 'ACTIVO' " +
                "Commit Tran Cargar_Ahorros " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Cargar_Ahorros " +
                "End Catch";
            String tabla29 = "Create Procedure[dbo].[Realizar Aportación] " +
                "@Aportación smallmoney, " +
                "@Fecha_Aportación datetime,  " +
                "@ID_Asociado varchar(5) " +
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
                "Insert into Transacciones values('TT001',@Fecha_Aportación) " +
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
                "Select Aportaciones.Aportación as 'Aportación',Transacciones.[Fecha de Transacción] as 'Fecha de Aportación' From Aportaciones inner join Transacciones on Aportaciones.[FK Transacción] =" +
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
                "Select SUM(Aportación) From Aportaciones where @Código_Asociado = [FK Asociado] " +
                "Commit Tran S_Aportaciones " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran S_Aportaciones  " +
                "End Catch ";
            String tabla32 = "Create Procedure[Cargar Pagos] " +
                "@ID_Préstamo varchar(9) " +
                "As " +
                "Begin Tran Cargar_Pagos " +
                "Begin Try " +
                "Select Pago.Pago as 'Monto Cancelado', Transacciones.[Fecha de Transacción] as 'Fecha de Pago' From Pago inner join Información on Pago.[id Pago] = Información.[id Pago] " +
                "Inner join Préstamos on Información.[id Préstamo] = Préstamos.[id Préstamos] inner join Transacciones on Préstamos.[FK Transacción] = Transacciones.[id Transacción] " +
                "where Préstamos.[id Préstamos]=@ID_Préstamo " +
                "Commit Tran Cargar_Pagos " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Cargar_Pagos " +
                "End Catch ";
            String tabla33 = "Create Procedure[Abonar] " +
                "@Abono smallmoney, " +
                "@Fecha_Abono datetime, " +
                "@FK_Ahorro varchar(40) " +
                "As " +
                "Begin Tran Abono " +
                "Begin Try " +
                "Declare @id_Transación varchar(5) " +
                "Insert into Transacciones values('TT002',@Fecha_Abono) " +
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
                "Select Abono.Abono as 'Abono',Transacciones.[Fecha de Transacción] as 'Fecha de Abono' From Abono inner join Transacciones on Abono.[FK Transacción] = Transacciones.[id Transacción] " +
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
                "Select SUM(Abono) From Abono where[FK Ahorro] = @ID_Ahorro " +
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
                "@FK_Ahorro varchar(30) " +
                "As " +
                "Begin Try " +
                "Begin Tran Retiro " +
                "Declare @id_Transación varchar(5) " +
                "Insert into Transacciones values('TT005',@Fecha_Retiro) " +
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
                "Select Retiros.Retiro as 'Retiro',Transacciones.[Fecha de Transacción] as 'Fecha de Retiro' From Retiros inner join Transacciones on Retiros.[FK Transacción] = Transacciones.[id Transacción] " +
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
                "Select SUM(Retiro) From Retiros where[FK Ahorro] = @ID_Ahorro " +
                "Commit Tran Disponibles_Retiro " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Disponibles_Retiro " +
                "End Catch ";
            String tabla39 = "Create Procedure[Realizar Pago] " +
                "@ID_Préstamo varchar(9), " +
                "@Pago smallmoney, " +
                "@No_Cuota int, " +
                "@Intereses smallmoney, " +
                "@Capital smallmoney, " +
                "@Saldo smallmoney, " +
                "@Mora smallmoney, " +
                "@Fecha_Límite datetime, " +
                "@Fecha_Pago datetime " +
                "As " +
                "Begin Tran Pago " +
                "Begin Try " +
                "Declare @ID_Pago as varchar(5) " +
                "Declare @id_Transación varchar(5) " +
                "Insert into Transacciones values('TT004',@Fecha_Pago) " +
                "set @id_Transación = (Select MAX([id Transacción]) From Transacciones) " +
                "If(@Fecha_Pago <= @Fecha_Límite) " +
                "Begin " +
                "Insert into Pago values(@Pago, @No_Cuota, @Intereses, @Capital, @Saldo, @id_Transación) " +
                "Set @ID_Pago = (Select Max([id Pago])From Pago) " +
                "Insert into Información values(@ID_Pago, @ID_Préstamo,null,@Fecha_Límite) " +
                "Commit Tran Pago " +
                "End " +
                "Else " +
                "Insert into Pago values(@Pago, @No_Cuota, @Intereses, @Capital, @Saldo, @id_Transación) " +
                "Set @ID_Pago = (Select Max([id Pago])From Pago) " +
                "Insert into Información values(@ID_Pago, @ID_Préstamo, @Mora, @Fecha_Límite) " +
                "Commit Tran Pago " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Pago " +
                "End Catch ";
            String tabla41 = "Create Procedure[Cargar Saldo] " +
                "@ID_Préstamo varchar(9) " +
                "As " +
                "Begin Tran Cargar_Saldo " +
                "Begin Try " +
                "Select Min(Pago.Saldo) From Pago inner join Información on Pago.[id Pago] = Información.[id Pago] inner join Préstamos " +
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
            String tabla43 = "Create Procedure[Cargar Préstamo] " +
                "@ID_Préstamo varchar(9) " +
                 "As " +
                 "Begin Tran Cargar_P " +
                "Begin Try " +
                "Select Asociado.[Código Asociado],(Asociado.Nombres + ' ' + Asociado.Apellidos)AS 'Nombre', [Tipo de Préstamo].[Tipo de Préstamo]As 'TipoP', " +
                "[Tipo de Préstamo].[Tasa de Interés] As Iterés,Préstamos.[Monto del Préstamo] AS Monto,Transacciones.[Fecha de Transacción] AS FechaT, Préstamos.Cuotas AS NCuotas, " +
                "Préstamos.[Cuota Mensual] AS PCuotas,Préstamos.Estado AS Estado From Asociado inner join Préstamos on " +
                "Asociado.[Código Asociado]= Préstamos.[Código Asociado] inner join [Tipo de Préstamo] on Préstamos.[id Tipo de Préstamo] " +
                "= [Tipo de Préstamo].[id Tipo de Préstamo] inner join Transacciones on Préstamos.[FK Transacción] = Transacciones.[id Transacción] where Préstamos.[id Préstamos]= @ID_Préstamo  " +
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
                "Select Préstamos.[id Préstamos] as 'Código de Préstamo', Asociado.[Código Asociado], [Tipo de Préstamo].[Tipo de Préstamo] " +
                "From Asociado inner join Préstamos on Asociado.[Código Asociado] = Préstamos.[Código Asociado] inner join [Tipo de Préstamo] " +
                "on Préstamos.[id Tipo de Préstamo] = [Tipo de Préstamo].[id Tipo de Préstamo] " +
                "Commit Tran Pres " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Pres " +
                "End Catch";
            String tabla45 = "Create Procedure[Asociado DVG]" +
                "As " +
                "Begin Tran Aso " +
                "Begin Try " +
                "Select Asociado.[Código Asociado] as 'Código', (Asociado.Nombres + ' ' + Asociado.Apellidos) as 'Persona Asociada' " +
                "From Asociado where Asociado.[Fecha de Desasociación] = NULL " +
                "Commit Tran Aso " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Aso " +
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
                "to Administrador with grant option ";
            String permisosUsuario =
                 "Use " + txtNombre.Text + ";" +
                 "Exec sp_addrolemember N'db_datareader',N'Usuario' ";
            String permisosInicioSesión =
                 "Use " + txtNombre.Text + ";" +
                 "grant select, insert on object :: Usuarios " +
                 "to InicioSesion with grant option " +
                 "grant select on object :: [Tipo de Usuarios] " +
                 "to InicioSesion with grant option ";
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
            SqlCommand cmd44 = new SqlCommand(Usuario1, cnn);
            SqlCommand cmd45 = new SqlCommand(Usuario2, cnn);
            SqlCommand cmd46 = new SqlCommand(Usuario3, cnn);
            SqlCommand cmd47 = new SqlCommand(Usuario4, cnn);
            SqlCommand cmd48 = new SqlCommand(tabla44, cnn);
            SqlCommand cmd49 = new SqlCommand(tabla45, cnn);
            SqlCommand cmd51 = new SqlCommand(permisosMaster_ACOPEDH, cnn);
            SqlCommand cmd52 = new SqlCommand(permisosAdministrador, cnn);
            SqlCommand cmd53 = new SqlCommand(permisosUsuario, cnn);
            SqlCommand cmd54 = new SqlCommand(permisosInicioSesión, cnn);
            SqlCommand cmd55 = new SqlCommand(crearusuarios, cnn);
            SqlCommand cmd56 = new SqlCommand(crearahorros, cnn);
            SqlCommand cmd57 = new SqlCommand(crearpagos, cnn);
            SqlCommand cmd58 = new SqlCommand(crearsocios, cnn);
            SqlCommand cmd59 = new SqlCommand(creartrabajos, cnn);
            SqlCommand cmd60 = new SqlCommand(crearpréstamos, cnn);
            SqlCommand cmd61 = new SqlCommand(insertartiposdetransacciones, cnn);
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
                cnn.Close();
                MessageBox.Show("Base Creada");
                this.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message,
            //        "Error al crear la base",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
