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
            //Comentar para Azure
            String USE = "Use " + txtNombre.Text + ";";
            //Tablas
#warning Añadir más variables después
            String tablaVariables = "CREATE TABLE [dbo].[Variables]( " +
                "[Aportación] smallmoney not null, " +
                "[Mora] Numeric(3,2) " +
                //" " +
                //" " +
                //" " +
                " )";
            String tabla1 = "CREATE TABLE [dbo].[Tipo de Usuarios](" +
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
                "[Correo] [varchar](50) NOT NULL unique," +
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
                "[Tipo de Transacción] varchar(30) unique NOT NULL)";
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
                "[DUI] [varchar](10) NOT NULL unique," +
                "[NIT] [varchar](17) NOT NULL unique," +
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
                "[Aportación] [money] NOT NULL," +
                "[FK Asociado] [varchar](5) NOT NULL," +
                "[FK Transacción] [varchar](5) references [Transacciones]([id Transacción])," +
                "CONSTRAINT[PK_Aportaciones] PRIMARY KEY([id Aportación])," +
                "CONSTRAINT [FK Asociado] FOREIGN KEY ([FK Asociado])" +
                "REFERENCES Asociado([Código Asociado]))";
            String tabla10 = "CREATE TABLE[dbo].[Ahorro](" +
                "[Número] [int] IDENTITY(1,1) NOT NULL," +
                "[id Ahorro]  AS('AH' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Estado] [varchar](10) NOT NULL," +
                "[FK Tipo Ahorro] [varchar](5) NOT NULL," +
                "[FK Código de Asociado] [varchar](5) NOT NULL," +
                "[FK Transacción] [varchar](5) references [Transacciones]([id Transacción])," +
                "CONSTRAINT [PK_Ahorro] PRIMARY KEY ([id Ahorro])," +
                "CONSTRAINT [FK Tipo Ahorro] FOREIGN KEY ([FK Tipo Ahorro])" +
                "REFERENCES [Tipo de Ahorro]([id Tipo Ahorro])," +
                "CONSTRAINT [FK Código de Asociado] FOREIGN KEY ([FK Código de Asociado])" +
                "REFERENCES Asociado([Código Asociado]))";
            String tabla11 = "CREATE TABLE [dbo].[Retiros](" +
                "[Número][int] IDENTITY(1, 1) NOT NULL," +
                "[id Retiro]  AS('RE' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Retiro] [money] NOT NULL," +
                "[Número de Cheque] [varchar](8) NOT NULL," +
                "[FK Ahorro] [varchar](5) NOT NULL," +
                "[FK Transacción] [varchar](5) references [Transacciones]([id Transacción])," +
                "CONSTRAINT[PK_Retiros] PRIMARY KEY ([id Retiro])," +
                "CONSTRAINT [FK Ahorro] FOREIGN KEY ([FK Ahorro])" +
                "REFERENCES Ahorro([id Ahorro]))";
            String tabla12 = "CREATE TABLE [dbo].[Abono](" +
                "[Número][int] IDENTITY(1,1) NOT NULL," +
                "[id Abono]  AS('AB' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Abono] [money] NOT NULL," +
                "[Abono y Comisión] [money] NOT NULL," +
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
                "CONSTRAINT [PK Teléfono] PRIMARY KEY ([id Teléfono]))";
            String tabla15 = "CREATE TABLE [dbo].[Contacto](" +
                "[FK Teléfono] [varchar](5) NOT NULL references[Teléfono]([id Teléfono])," +
                "[FK Código Asociado] [varchar](5) NOT NULL references Asociado([Código Asociado]), " +
                "[FK Tipo de Teléfono][varchar](5) NOT NULL references [Tipos de Teléfonos]([id Tipo de Teléfono]))";
            String tabla16 = "Create table [dbo].[Forma de Pago](" +
                "[Número] [int] identity(1, 1) NOT NULL," +
                "[id Forma de Pago] AS('FP' + right('000' + Convert([varchar](3), [Número]), (3))) PERSISTED NOT NULL," +
                "[Nombre] [varchar](50) NOT NULL unique," +
                "CONSTRAINT [PK_Forma de Pago] PRIMARY KEY ([id Forma de Pago]))";
            String tabla17 = "Create table [dbo].[Tipo de Préstamo](" +
                "[Número] [int] identity(1,1) NOT NULL," +
                "[id Tipo de Préstamo] AS('TP' + right('000'+Convert([varchar](3), [Número]), (3))) PERSISTED NOT NULL," +
                "[Tipo de Préstamo] [varchar](50) NOT NULL Unique," +
                "[Tasa de Interés] [decimal](10, 2) NOT NULL," +
                "CONSTRAINT [PK_Tipo de Préstamo] PRIMARY KEY ([id Tipo de Préstamo]))";
            String tabla18 = "Create table [Préstamos](" +
                "[Número] [int] identity(1,1)," +
                "[id Préstamos] AS('PP-' + right('000000'+Convert([varchar](6), [Número]), (6))) PERSISTED NOT NULL PRIMARY KEY," +
                "[Código Asociado] [varchar](5) NOT NULL references [Asociado]([Código Asociado])," +
                "[id Forma de Pago] [varchar](5) references[Forma de Pago]([id Forma de Pago]) NOT NULL," +
                "[id Tipo de Préstamo] [varchar](5) references [Tipo de Préstamo]([id Tipo de Préstamo]) NOT NULL," +
                "[Fecha de Otorgamiento] [datetime] NOT NULL," +
                "[Cuotas] [int] NOT NULL," +
                "[Monto del Préstamo] [money] NOT NULL," +
                "[Cuota Mensual] [money] NOT NULL," +
                "[FK Transacción] [varchar](5) references [Transacciones]([id Transacción])," +
                "[Estado] [varchar](10) NOT NULL)";
            String tabla19 = "Create table [dbo].[Pago](" +
                "[Número][int] identity(1, 1) NOT NULL," +
                "[id Pago] AS('PA' + right('000' + Convert([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Pago] [money] NOT NULL," +
                "[Número de Cuota] [int] NOT NULL," +
                "[Intereses] [money] NOT NULL," +
                "[Capital] [money] NOT NULL," +
                "[Saldo] [money] NOT NULL," +
                "[id Préstamo] [varchar](9) references [Préstamos]([id Préstamos])NOT NULL," +
                "[Mora] [money]," +
                "[Fecha Límite][datetime] NOT NULL," +
                "[FK Transacción] [varchar](5) references [Transacciones]([id Transacción])," +
                 "CONSTRAINT [PK Pago] PRIMARY KEY ([id Pago]))";
            String tabla20 = "Create table Imagenes(" +
                "Cod_Imagen int identity(1, 1) primary key, " +
                "Imagen Image, " +
                "[Tipo imagen] int, " +
                "Estado varchar(8), " +
                "Descripcion varchar(MAX)); ";
            String tabla21 = "Create table[Retiros Aportaciones](" +
                "[Número][int] IDENTITY(1, 1) NOT NULL, " +
                "[Id Retiro Aportación]  AS('RA' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL, " +
                "[Retiro] money NOT NULL, " +
                "[Número de Cheque] varchar(8), " +
                "[FK Asociado] varchar(5) NOT NULL references Asociado([Código Asociado]), " +
                "[FK Transacción] varchar(5) NOT NULL references Transacciones([id Transacción])) ";
            String tabla22 = "Create table [dbo].[Tipos de Imágenes](" +
               "[Número][int] identity(1, 1) NOT NULL," +
               "[id Tipo Imagen] AS('TI' + right('000' + Convert([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
               "[Nombre][varchar](20) NOT NULL UNIQUE," +
               "CONSTRAINT [PK Tipo Imagen] PRIMARY KEY ([id Tipo Imagen]))";
            String tabla23 = "Create table [dbo].[Imagen](" +
                "[Número][int] identity(1, 1) NOT NULL," +
                "[id Imagen] AS('IA' + right('00000' + Convert([varchar](5),[Número]), (5))) PERSISTED NOT NULL," +
                "[Imagen] Image not null," +
                "[Fecha de Subida] [datetime] NOT NULL," +
                "[Persona Asociada] [varchar](5) references [Asociado]([Código Asociado])," +
                "[Tipo Imagen] [varchar](5) references [Tipos de Imágenes]([id Tipo Imagen])," +
                "[Comentarios] [varchar](120) null," +
                "CONSTRAINT [PK Imagen] PRIMARY KEY ([id Imagen]))";
            //Añadido para conseguir el límite anterior
            String procedimiento1 = "Create Procedure [Conseguir Límite] " +
                "@Id_Préstamo varchar(9) " +
                "As Begin Tran Pagar " +
                "Begin Try " +
                "Declare @NPagos int " +
                "Set @NPagos = (Select Count(Pago.[Número de Cuota]) From Pago inner join Préstamos on Préstamos.[id Préstamos] = Pago.[id Préstamo] " +
                "where Préstamos.[id Préstamos] = @Id_Préstamo) " +
                "IF @NPagos > 0 " +
                "begin " +
                "Select Pago.[Fecha Límite] as 'Límite' from Pago where Pago.[Número de Cuota] = @NPagos " +
                "END " +
                "ELSE " +
                "begin " +
                "    Select Préstamos.[Fecha de Otorgamiento] as 'Límite' from Préstamos where Préstamos.[id Préstamos]= @Id_Préstamo " +
                "END " +
                "Commit tran Pagar " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Pagar " +
                "return 0 " +
                "End Catch";
            String procedimiento2 = "Create Procedure[Insertar Asociado]" +
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
            String procedimiento3 = "Create Procedure[Cargar Asociados] " +
                "@Código_Asociado varchar(5) " +
                "As " +
                "Begin Tran Cargar_Asociados " +
                "Begin Try " +
                "Select [Tipo de Socio].[Nombre Tipo Socio] AS 'Tipo de Asociación', Nombres AS 'Name', Apellidos AS 'LName',DUI AS 'DDui', NIT AS 'DNit', " +
                "Dirección AS 'Residencia', [Fecha de Nacimiento] AS 'FNacimiento', [Fecha de Asociación] AS 'FAsociación', [Fecha de Desasociación] AS 'FDesasociación', Estado AS 'Est', " +
                "Ocupación.[Nombre de la Empresa] AS 'Trabajo' From Asociado inner join [Tipo de Socio] on [Tipo de Socio].[id Tipo de Socio]=Asociado.[FK Tipo Socio] " +
                "inner join Ocupación on Ocupación.[Id Ocupación] = Asociado.[FK Ocupación] where [Código Asociado] = @Código_Asociado " +
                "Commit Tran Cargar_Asociados " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Cargar_Asociados " +
                "End Catch";
            String procedimiento4 = "Create Procedure[Insertar Teléfono] " +
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
                "Set @ID_Tipo_Teléfono = (Select [id Tipo de Teléfono] From[Tipos de Teléfonos] where @Tipo_Teléfono =[Tipo de Teléfono]) " +
                "Insert into Teléfono values(@Teléfono) " +
                "set @ID_Teléfono = (Select Max([id Teléfono]) From Teléfono) " +
                "Insert into Contacto values(@ID_Teléfono, @ID_Asociado, @ID_Tipo_Teléfono) " +
                "Commit Tran Teléfono " +
                "End " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Teléfono " +
                "End Catch";
            String procedimiento5 = "Create Procedure[Cargar Teléfonos] " +
                "@Código_Asociado varchar(5) " +
                "As " +
                "Begin Tran Cargar_Teléfonos " +
                "Begin Try " +
                "Select Teléfono.Teléfono AS 'Número de Teléfono',[Tipos de Teléfonos].[Tipo de Teléfono] From Teléfono " +
                "inner join Contacto on Teléfono.[id Teléfono] = Contacto.[FK Teléfono] inner join [Tipos de Teléfonos] on [Tipos de Teléfonos].[id Tipo de Teléfono] = Contacto.[FK Tipo de Teléfono] " +
                "where Contacto.[FK Código Asociado] = @Código_Asociado " +
                "Commit Tran Cargar_Teléfonos " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Cargar_Teléfonos " +
                "End Catch ";
            String procedimiento6 = "Create Procedure[Modificar Teléfono] " +
                "@Tipo_Telefono varchar(50), " +
                "@ID_Teléfono varchar(5), " +
                "@Teléfono varchar(10), " +
                "@Código_Asociado varchar(5) " +
                "As " +
                "Begin Tran Mod_Tel " +
                "Begin Try " +
                "If((Select [Tipos de Teléfonos].[Tipo de Teléfono] From[Tipos de Teléfonos] inner join Contacto " +
                "on[Tipos de Teléfonos].[id Tipo de Teléfono] = Contacto.[FK Tipo de Teléfono] where Contacto.[FK Teléfono] = @ID_Teléfono AND Contacto.[FK Código Asociado] = @Código_Asociado) " +
                "= @Tipo_Telefono) " +
                "Update Teléfono set Teléfono = @Teléfono where @ID_Teléfono =[id Teléfono] " +
                "Commit Tran Mod_Tel " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Mod_Tel " +
                "End Catch";
            String procedimiento7 = "Create Procedure[Eliminar Teléfono] " +
                "@ID_Teléfono varchar(5), " +
                "@Id_Asociado varchar(5) " +
                "As   " +
                "Begin Tran Del_Teléfono " +
                "Begin Try " +
                "Begin " +
                "Delete From Contacto where @ID_Teléfono = [FK Teléfono] AND @Id_Asociado = [FK Código Asociado] " +
                "Commit Tran Del_Teléfono " +
                "End " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Del_Teléfono " +
                "End Catch ";
            String procedimiento8 = "Create Procedure[Abonar] " +
               "@Abono money, " +
               "@Comision money, " +
               "@FK_Ahorro varchar(40), " +
               "@Id_Usuario varchar(5) " +
               "As " +
               "Begin Tran Abono " +
               "Begin Try " +
               "Declare @id_Transación varchar(5) " +
               "Insert into Transacciones values(@Id_Usuario, 'TT002',GETDATE()) " +
               "set @id_Transación = (Select MAX([id Transacción]) From Transacciones) " +
               "Insert into Abono values(@Abono,@Comision,@FK_Ahorro, @id_Transación) " +
               "Commit Tran Abono " +
               "End Try " +
               "Begin Catch " +
               "Print ERROR_MESSAGE(); " +
               "Rollback tran Abono " +
               "End Catch ";
            //Cambiado para que se muestren activos e inactivos
            String procedimiento9 = "Create Procedure[Ahorro DVG] " +
                "As " +
                "Begin Tran Ahorro_DVG " +
                "Begin Try " +
                "Select Ahorro.[id Ahorro] as 'Código de Ahorro',(Asociado.Nombres+' ' + Asociado.Apellidos) as 'Persona Asociada', Asociado.DUI as 'DUI' ,[Tipo de Ahorro].Nombre as 'Tipo de Ahorro', Ahorro.Estado as 'Estado' From Asociado inner join Ahorro " +
                "on Ahorro.[FK Código de Asociado] = Asociado.[Código Asociado] inner join [Tipo de Ahorro] on Ahorro.[FK Tipo Ahorro]=[Tipo de Ahorro].[id Tipo Ahorro] " +
                "Commit Tran Ahorro_DVG " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Cargar_Ahorros " +
                "End Catch";
            String procedimiento10 = "Create Procedure[dbo].[Realizar Aportación] " +
                "@Aportación money, " +
                "@ID_Asociado varchar(5), " +
                "@Id_Usuario varchar(5) " +
                "As " +
                "Begin Tran Asociado " +
                "Begin try " +
                "If Exists(Select Aportaciones.[id Aportación] from Aportaciones inner join Transacciones on Aportaciones.[FK Transacción]= Transacciones.[id Transacción] " +
                "where MONTH(Transacciones.[Fecha de Transacción])= MONTH(GETDATE())AND YEAR(Transacciones.[Fecha de Transacción]) = YEAR(GETDATE()) " +
                "AND Aportaciones.[FK Asociado]= @ID_Asociado) " +
                "Begin " +
                "Print 'Ya se realizó aportación mensual' " +
                "Rollback tran Asociado " +
                "End " +
                "Else " +
                "Begin " +
                "Declare @id_Transación varchar(5) " +
                "Insert into Transacciones values(@Id_Usuario, 'TT001',GETDATE()) " +
                "set @id_Transación = (Select MAX([id Transacción]) From Transacciones) " +
                "Insert into Aportaciones values(@Aportación, @ID_Asociado, @id_Transación) " +
                "Print 'Aporte realizado con éxito' " +
                "Commit tran Asociado " +
                "End " +
                "End try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback tran Asociado " +
                "End Catch ";
            String procedimiento11 = "Create Procedure[Cargar Aportaciones] " +
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
            String procedimiento12 = "Create Procedure[Suma Aportaciones] " +
                "@Código_Asociado varchar(5) " +
                "As " +
                "Begin Tran S_Aportaciones " +
                "Begin Try " +
                "if (Select Count(Aportación) AS 'Suma de Aportaciones' From Aportaciones where @Código_Asociado = [FK Asociado] ) > 0 " +
                "Begin Select SUM(Aportación) AS 'Suma de Aportaciones' From Aportaciones where @Código_Asociado = [FK Asociado] " +
                "Commit Tran S_Aportaciones End " +
                "Else Begin Select 0 AS 'Suma de Aportaciones' Commit Tran S_Aportaciones end " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran S_Aportaciones " +
                "Select 0 AS 'Suma de Aportaciones' Commit Tran S_Aportaciones " +
                "End Catch ";
            //Cambio para visualizar más campos en la consulta
            String procedimiento13 = "Create Procedure[Cargar Pagos] " +
                "@ID_Préstamo varchar(9) " +
                "As " +
                "Begin Tran Cargar_Pagos " +
                "Begin Try " +
                "Select Pago.[Número de Cuota] as 'No Pago', Pago.Pago as 'Monto Cancelado', Pago.Intereses as 'Pago a Intereses', Pago.Capital as 'Pago a Capital', Pago.Mora as 'Mora por retraso', Pago.Saldo as 'Saldo restante', Transacciones.[Fecha de Transacción] as 'Fecha de Pago', Pago.[Fecha Límite] as 'Fecha Límite de Pago' From Pago " +
                "inner join Préstamos on Préstamos.[id Préstamos] = Pago.[id Préstamo] " +
                "inner join Transacciones on Préstamos.[FK Transacción] = Transacciones.[id Transacción] where Préstamos.[id Préstamos]=@ID_Préstamo " +
                "Commit Tran Cargar_Pagos " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Cargar_Pagos " +
                "End Catch ";
#warning Podría causar errores
            //Modificado para que ingrese además un abono
            String procedimiento14 = "Create Procedure [Nueva Cuenta de Ahorro] " +
                "@FK_Tipo_Ahorro varchar(20), " +
                "@FK_Asociado varchar(5), " +
                "@Abono_inicial money, " +
                "@Comision money, " +
                "@ID_Usuario varchar(5) " +
                "As Begin Tran Ahorro " +
                "Begin try " +
                "Declare @ID_Tipo_Ahorro as varchar(5) " +
                "Declare @Contar_Activos as int " +
                "Declare @id_Transacción as varchar(5)" +
                "set @ID_Tipo_Ahorro = (Select [id Tipo Ahorro] From [Tipo de Ahorro] where Nombre = @FK_Tipo_Ahorro) " +
                "set @Contar_Activos = (Select COUNT([id Ahorro]) from Ahorro where [FK Código de Asociado] = @FK_Asociado AND Estado = 'ACTIVO') " +
                "if @Contar_Activos < 3 " +
                "Begin " +
                "Insert into Transacciones values(@Id_Usuario, 'TT006', GETDATE()) " +
                "set @id_Transacción = (Select MAX([id Transacción]) From Transacciones) " +
                "Insert into Ahorro values('ACTIVO', @ID_Tipo_Ahorro, @FK_Asociado, @id_Transacción) " +
                "Declare @FK_Ahorro_nuevo as varchar(5) " +
                "set @FK_Ahorro_nuevo = (Select MAX([id Ahorro]) from Ahorro where [FK Código de Asociado] = @FK_Asociado) " +
                "exec Abonar @Abono_inicial,@Comision,@FK_Ahorro_nuevo,@ID_Usuario " +
                "Commit tran Ahorro " +
                "End " +
                "else " +
                "Begin " +
                "Print 'El usuario ya tiene 3 cuentas de ahorro activas' " +
                "Commit tran Ahorro " +
                "End " +
                "End try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback tran Ahorro " +
                "return 0 " +
                "End Catch ";
            String procedimiento15 = "Create Procedure[Cargar Abonos] " +
                "@ID_Ahorro varchar(5) " +
                "As " +
                "Begin Tran Cargar_Abono " +
                "Begin Try " +
                "Select Abono.Abono as 'Monto Abonado', Abono.[Abono y Comisión] as 'Abono más Comisión',Transacciones.[Fecha de Transacción] as 'Fecha de Abono' From Abono inner join Transacciones on Abono.[FK Transacción] = Transacciones.[id Transacción] " +
                "where[FK Ahorro] = @ID_Ahorro " +
                "Commit Tran Cargar_Abono " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Cargar_Abono " +
                "End Catch";
            String procedimiento16 = "Create Procedure[Suma Abonos] " +
                "@ID_Ahorro varchar(5) " +
                "As " +
                "Begin Tran Disponibles_Abono " +
                "Begin Try " +
                "if (Select Count([Abono y Comisión]) AS 'Suma de Abonos' From Abono where[FK Ahorro] = @ID_Ahorro) > 0 Begin " +
                "Select SUM([Abono y Comisión]) AS 'Suma de Abonos' From Abono where[FK Ahorro] = @ID_Ahorro " +
                "Commit Tran Disponibles_Abono End " +
                "else begin Select 0 as 'Suma de Abonos' Commit Tran Disponibles_Abono End " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Disponibles_Abono " +
                "Select 0 as 'Suma de Abonos' " +
                "End Catch";
            String procedimiento17 = "Create Procedure[Realizar Retiros] " +
                "@Retiro money, " +
                "@Número_Cheque varchar(8), " +
                "@FK_Ahorro varchar(30), " +
                "@Id_Usuario varchar(5) " +
                "As " +
                "Begin Try " +
                "Begin Tran Retiro " +
                "Declare @id_Transación varchar(5) " +
                "Insert into Transacciones values(@Id_Usuario, 'TT005',GETDATE()) " +
                "set @id_Transación = (Select MAX([id Transacción]) From Transacciones) " +
                "Insert into Retiros values(@Retiro,@Número_Cheque, @FK_Ahorro, @id_Transación) " +
                "Commit Tran Retiro " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback tran Retiro " +
                "End Catch ";
            String procedimiento18 = "Create Procedure[Cargar Retiros] " +
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
            //Si no hay retiros
            String procedimiento19 = "Create Procedure[Suma Retiros] " +
                "@ID_Ahorro varchar(5) " +
                "As " +
                "Begin Tran Disponibles_Retiro " +
                "Begin Try " +
                "if (Select Count(Retiro) From Retiros where[FK Ahorro] = @ID_Ahorro ) > 0 " +
                "begin " +
                "Select SUM(Retiro) AS 'Suma de Retiros' From Retiros where[FK Ahorro] = @ID_Ahorro " +
                "Commit Tran Disponibles_Retiro end else " +
                "begin " +
                "Select 0 AS 'Suma de Retiros' " +
                "commit tran Disponibles_Retiro end " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Disponibles_Retiro Select 0 AS 'Suma de Retiros' " +
                "End Catch ";
            //Cambiado por el n de cuota
            String procedimiento20 = "Create Procedure[Realizar Pago] " +
                "@ID_Préstamo varchar(9), " +
                "@Pago money, " +
                "@Id_Usuario varchar(5), " +
                "@Intereses money, " +
                "@Capital money, " +
                "@Saldo money, " +
                "@Mora money, " +
                "@Fecha_Límite datetime " +
                "As Begin Tran Pagar " +
                "Begin Try " +
                "Declare @id_Transación varchar(5) " +
                "Declare @No_Cuota int " +
                "if (Select Estado from Préstamos where [id Préstamos] = @ID_Préstamo) = 'ACTIVO' Begin " +
                "Insert into Transacciones values(@Id_Usuario, 'TT004', GETDATE()) " +
                "set @id_Transación = (Select MAX([id Transacción]) From Transacciones) " +
                "Set @No_Cuota = ((Select Count(Pago.[Número de Cuota]) From Pago inner join Préstamos on Préstamos.[id Préstamos] = Pago.[id Préstamo]" +
                "Where Préstamos.[id Préstamos] = @ID_Préstamo) + 1) " +
                "Insert into Pago values(@Pago, @No_Cuota, @Intereses, @Capital, @Saldo, @ID_Préstamo, @Mora, @Fecha_Límite, @id_Transación) " +
                "Commit Tran Pagar End " +
                "Else Begin Print 'El préstamo ya fue cancelado' Commit Tran Pagar return 0 End " +
                "End Try Begin Catch Print ERROR_MESSAGE(); Rollback Tran Pagar End Catch ";
            String procedimiento21 = "Create Procedure[Cargar Saldo] " +
                  "@ID_Préstamo varchar(9) " +
                  "As " +
                  "Begin Tran Cargar_Saldo " +
                  "Begin Try " +
                  "Select Min(Pago.Saldo) AS 'Pago Mínimo' From Pago inner join Préstamos " +
                  "on Pago.[id Préstamo] = Préstamos.[id Préstamos] where Préstamos.[id Préstamos]=@ID_Préstamo " +
                  "Commit Tran Cargar_Saldo " +
                  "End Try " +
                  "Begin Catch " +
                  "Print ERROR_MESSAGE(); " +
                  "Rollback Tran Cargar_Saldo \n" +
                  "End Catch ";
            //Trigger Feo
            String Trigger1 = "Create Trigger [Préstamo Cancelado] " +
            "On Pago For Insert " +
            "As " +
            "Declare @Pago_Ultimo money " +
            "Select @Pago_Ultimo = Pago.Saldo From inserted " +
            "inner join Pago on Pago.[id Pago] = inserted.[id Pago] " +
            "inner join Préstamos on Préstamos.[id Préstamos] = inserted.[id Préstamo] " +
            "If (@Pago_Ultimo) = 0 " +
            "Begin " +
            "Update Préstamos set Estado = 'CANCELADO' " +
            "From Préstamos inner join Pago on Préstamos.[id Préstamos] = Pago.[id Préstamo] " +
            "inner join inserted on Pago.[id Pago] = inserted.[id Pago] " +
            "where Pago.[id Pago] = inserted.[id Pago] " +
            "End;";
            //Modificación
            String procedimiento22 = "Create Procedure[Cargar Préstamo] " +
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
            //Modificado para que se vean también los no activos
            String procedimiento23 = "Create Procedure[Préstamo DVG] " +
                "As " +
                "Begin Tran Pres " +
                "Begin Try " +
                "Select Préstamos.[id Préstamos] as 'Código de Préstamo', (Asociado.Nombres + ' ' + Asociado.Apellidos) as 'Persona Asociada', Asociado.DUI as 'Dui', [Tipo de Préstamo].[Tipo de Préstamo], Préstamos.Estado as 'Estado' " +
                "From Asociado inner join Préstamos on Asociado.[Código Asociado] = Préstamos.[Código Asociado] inner join [Tipo de Préstamo] " +
                "on Préstamos.[id Tipo de Préstamo] = [Tipo de Préstamo].[id Tipo de Préstamo] " +
                "Commit Tran Pres " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Pres " +
                "End Catch";
            //Cambiado para que muestre los activos y no activos
            String procedimiento24 = "Create Procedure[Asociado DVG]" +
                "As " +
                "Begin Tran Aso " +
                "Begin Try " +
                "Select Asociado.[Código Asociado] as 'Código', (Asociado.Nombres + ' ' + Asociado.Apellidos) as 'Persona Asociada',Asociado.DUI as 'Dui',[Tipo de Socio].[Nombre Tipo Socio] as 'Tipo Asociación', Asociado.Estado as 'Estado' From Asociado inner join [Tipo de Socio] on [Tipo de Socio].[id Tipo de Socio]=Asociado.[FK Tipo Socio] " +
                "Commit Tran Aso " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Aso " +
                "End Catch";
            String procedimiento25 = "Create Procedure [Cargar Tipo Préstamo] As Begin Tran Pre Begin Try " +
                "Select[Tipo de Préstamo].[Tipo de Préstamo] AS 'TipoP',[Tipo de Préstamo].[Tasa de Interés] AS 'Interés' from[Tipo de Préstamo] " +
                "Commit Tran Pre End Try Begin Catch Print ERROR_MESSAGE(); " +
                "Rollback Tran Pre End Catch";
            String procedimiento26 = "Create Procedure [Cargar Tipo Socio] As Begin Tran Aso Begin Try " +
                "Select [Tipo de Socio].[Nombre Tipo Socio] AS 'TipoS' from [Tipo de Socio] " +
                "Commit Tran Aso End Try Begin Catch Print ERROR_MESSAGE(); Rollback Tran Aso End Catch";
            String procedimiento27 = "Create Procedure [Cargar Tipo Ahorro] As Begin Tran Aho Begin Try " +
                "Select [Tipo de Ahorro].Nombre AS 'TipoA',[Tipo de Ahorro].[Tasa de Interés] AS 'Interés' from [Tipo de Ahorro] " +
                "Commit Tran Aho End Try Begin Catch Print ERROR_MESSAGE(); Rollback Tran Aho End Catch";
            String procedimiento28 = "create Procedure[dbo].[Recuperar Contraseña] " +
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
            String procedimiento29 =
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
                "select * from Usuarios where [Id Usuario] = @Id " +
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
            String procedimiento30 =
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
            String procedimiento31 =
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
            String procedimiento32 =
                "Create procedure [Cargar Ocupaciones] " +
                "As " +
                "Begin " +
                "Select [Nombre de la Empresa] As 'Trabajo' from Ocupación " +
                "End";
            //Aqui se cambió para tener la referencia "TipoT"
            String procedimiento33 =
                "Create procedure [Cargar Tipo Teléfono] " +
                "As " +
                "Begin " +
                "Select [Tipos de Teléfonos].[Tipo de Teléfono] as 'TipoT' From [Tipos de Teléfonos] " +
                "End";
            //Faltaba este procedimiento
            String procedimiento34 = "Create Procedure[Cargar Ahorros] " +
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
            String procedimiento35 = "Create Procedure[Nuevo Préstamo] " +
                "@FK_Tipo_Préstamo varchar(20), " +
                "@FK_Asociado varchar(5), " +
                "@Forma_Pago varchar(5), " +
                "@NCuotas int, " +
                "@Monto money, " +
                "@Cuota money, " +
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
                "   Commit tran Préstamo return 0 " +
                "END " +
                "End try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback tran Préstamo " +
                "return 0 " +
                "End Catch";
            //Añadido para el combobox
            String procedimiento36 = "Create Procedure [dbo].[Cargar Tipo Pagos] " +
                "As Begin Tran Tipo_Pagos " +
                "Begin Try " +
                "Select[Forma de Pago].Nombre AS 'FormaP', [Forma de Pago].[id Forma de Pago] as 'Id' from[Forma de Pago] " +
                "Commit Tran Tipo_pagos End Try Begin Catch Print ERROR_MESSAGE(); Rollback Tran Pre End Catch";
            //Añadido para cerrar ahorro
            String procedimiento37 = "Create Procedure[dbo].[Cerrar Ahorro] " +
                "@Id_Ahorro varchar(5) " +
                "As Begin Tran Cuenta_Cerrada " +
                "Begin Try " +
                "If(Select Estado from Ahorro where [id Ahorro] = @Id_Ahorro) = 'ACTIVO' " +
                "Begin " +
                "    Update Ahorro Set Estado = 'INACTIVO' where[id Ahorro] = @Id_Ahorro " +
                "    Print 'La cuenta ha sido cerrada' " +
                "    Commit Tran Cuenta_Cerrada " +
                "End " +
                "Else " +
                "Begin " +
                "    Print 'La cuenta ya se encuentra cerrada' " +
                "    Commit Tran Cuenta_Cerrada " +
                "End " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Cuenta_Cerrada " +
                "End Catch ";
            //Añadido para desasociar
            String procedimiento38 = "Create Procedure[dbo].[Desasociar] " +
                "@Código_Asociado varchar(5) " +
                "As Begin Tran Desasociado " +
                "Begin Try " +
                "If(Select Estado from Asociado where[Código Asociado] = @Código_Asociado) = 'ACTIVO' " +
                "Begin " +
                "Declare @Ahorro int, @Préstamo_E int , @Préstamo_N int " +
                "Set @Ahorro = (Select COUNT([id Ahorro]) from Ahorro where [FK Código de Asociado] = @Código_Asociado AND Estado = 'ACTIVO')  " +
                "If(@Ahorro = 0) " +
                "Begin " +
                "Set @Préstamo_E = (Select COUNT(Préstamos.[id Préstamos]) from Préstamos inner join [Tipo de Préstamo] on [Tipo de Préstamo].[id Tipo de Préstamo] = Préstamos.[id Tipo de Préstamo] where Préstamos.[Código Asociado] = @Código_Asociado AND Estado = 'ACTIVO' AND[Tipo de Préstamo].[Tipo de Préstamo] = 'Emergencia') " +
                "Set @Préstamo_N = (Select COUNT(Préstamos.[id Préstamos]) from Préstamos inner join [Tipo de Préstamo] on [Tipo de Préstamo].[id Tipo de Préstamo] = Préstamos.[id Tipo de Préstamo] where Préstamos.[Código Asociado] = @Código_Asociado AND Estado = 'ACTIVO' AND[Tipo de Préstamo].[Tipo de Préstamo] <> 'Emergencia') " +
                "if (@Préstamo_E = 0) AND(@Préstamo_N = 0) " +
                "Begin " +
                "Update Asociado Set Estado = 'INACTIVO', [Fecha de Desasociación] = GetDate() " +
                "where[Código Asociado] = @Código_Asociado " +
                "Commit Tran Desasociado " +
                "End " +
                "else " +
                "Begin " +
                "Print 'La persona asociada tiene préstamos sin cancelar' " +
                "Commit Tran Desasociado " +
                "End " +
                "End " +
                "Else " +
                "Begin " +
                "Print 'La persona asociada tiene cuentas de ahorro activas' " +
                "Commit Tran Desasociado " +
                "End " +
                "End " +
                "Else " +
                "Begin " +
                "Print 'La persona ya se encuentra desasociada' " +
                "Commit Tran Desasociado " +
                "End " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Desasociado " +
                "return 0 " +
                "End Catch ";
            //Añadido Actualizar Asociado
            String procedimiento39 = "Create procedure[dbo].[Actualizar Asociado] " +
                "@Codigo_Asociado varchar(5), " +
                "@FK_Tipo_Socio varchar(50), " +
                "@Nombres varchar(50), " +
                "@Apellidos varchar(50), " +
                "@DUI varchar(10), " +
                "@NIT varchar(17), " +
                "@Residencia varchar(100), " +
                "@Fecha_Nacimiento datetime, " +
                "@Fecha_Asociación datetime, " +
                "@FK_Ocupacion varchar(30) " +
                "As " +
                "Begin transaction " +
                "Declare @ID_Tipo_Socio as varchar(5) " +
                "Declare @ID_Ocupación as varchar(5) " +
                "set @ID_Tipo_Socio = (Select[id Tipo de Socio] From[Tipo de Socio] where[Nombre Tipo Socio] = @FK_Tipo_Socio)  " +
                "set @ID_Ocupación = (Select[Id Ocupación] From[Ocupación] where[Nombre de la Empresa] = @FK_Ocupacion) " +
                "Update Asociado set[FK Tipo Socio] = @ID_Tipo_Socio, " +
                        "Nombres = @Nombres, " +
                        "Apellidos = @Apellidos, " +
                        "DUI = @DUI, " +
                        "NIT = @NIT, " +
                        "Dirección = @Residencia, " +
                        "[Fecha de Nacimiento] = @Fecha_Nacimiento, " +
                        "[FK Ocupación] = @ID_Ocupación where[Código Asociado] = @Codigo_Asociado " +
              "If @@error = 0 " +
              "Begin " +
                "COMMIT TRANSACTION " +
              "End " +
              "Else " +
              "Begin " +
                "ROLLBACK TRANSACTION " +
                "Print 'Error en modificar datos de asociado ' + ERROR_MESSAGE(); " +
              "End ";
            String procedimiento40 = "create procedure[Cargar Imagenes] " +
                "As Begin " +
                "select Imagen, [Tipo imagen], Descripcion from Imagenes where Estado = 'Activa' " +
                "End; ";
            String procedimiento41 = "create procedure[Nueva Imagen] " +
                "@Imagen image, " +
                "@Tipo_imagen int, " +
                "@Descripcion varchar(MAX)" +
                "As Begin " +
                "If exists(select Cod_Imagen from Imagenes where [Tipo imagen] = @Tipo_imagen) " +
                "Begin " +
                "Update Imagenes set Estado = 'Inactiva' where Cod_Imagen = (select Cod_Imagen from Imagenes where [Tipo imagen] = @Tipo_imagen); " +
                "Insert into Imagenes values(@Imagen, @Tipo_imagen, 'Activa', @Descripcion); " +
                "End " +
                "Else " +
                "Begin " +
                "Insert into Imagenes values(@Imagen, @Tipo_imagen, 'Activa', @Descripcion); " +
                "End " +
                "End ";
            String procedimiento42 = "create procedure[Elimina Imagen] " +
                "@Cod_Imagen int " +
                "As " +
                "Begin " +
                "delete from Imagenes where Cod_Imagen = @Cod_Imagen " +
                "End; ";
            //Procedimiento para retirar las aportaciones al desasociar.
            String procedimiento43 = "create procedure [dbo].[Retirar Aportaciones] " +
                "@Código_Asociado varchar(5), " +
                "@Total_Retiro money, " +
                "@No_Cheque varchar(8), " +
                "@Id_Usuario varchar(5) " +
                "As Begin Tran Retiro " +
                "Begin Try " +
                "If(Select Estado from Asociado where[Código Asociado] = @Código_Asociado) = 'ACTIVO' " +
                "Begin "+
                "if (Select SUM(Aportación) from Aportaciones where [FK Asociado] = @Código_Asociado) <> 0 " +
                "Begin " +
                "Declare @Id_Transacción varchar(5) " +
                "Insert into Transacciones values(@Id_Usuario,'TT007',GETDATE()) " +
                "set @Id_Transacción = (Select MAX([id Transacción]) From Transacciones) " +
                "Insert into[Retiros Aportaciones] values(@Total_Retiro, @No_Cheque, @Código_Asociado, @Id_Transacción) " +
                "Commit Tran Retiro " +
                "End " +
                "Else "+
                "Begin " +
                "Print 'No hay aportaciones que retirar.' " +
                "Commit Tran Retiro " +
                "End " +
                "End "+
                "Else Begin "+
                "Print 'La persona se encuentra desasociada.' "+
                "Commit Tran Retiro " +
                "End " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Retiro " +
                "End Catch ";
            //Procedimiento para cerrar un préstamo
            String procedimiento44 = "Create procedure [dbo].[Cerrar Préstamo] " +
                "@Id_Préstamo varchar(9), " +
                "@Id_Usuario varchar(5) " +
                "As Begin Tran Cancelar " +
                "Begin Try " +
                "Declare @Id_Transacción varchar(5) " +
                "Update Préstamos set Estado = 'CANCELADO' From Préstamos where[id Préstamos] = @Id_Préstamo " +
                "Insert into Transacciones values(@Id_Usuario, 'TT008', GETDATE()) " +
                "Commit Tran Cancelar " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Cancelar  " +
                "End catch ";
            //Procedimiento para Constancia de Pago
            String procedimiento45 = "Create procedure[dbo].[Constancia Pago] " +
                "@Id_Préstamo varchar(9) " +
                "As begin tran Constancia " +
                "Begin try " +
                "declare @id_Pago varchar(9) " +
                "Set @id_Pago = (Select Max([id Pago]) From Pago where Pago.[id Préstamo] = @Id_Préstamo) " +
                "Select Pago.[id Pago] as 'Pid_Pago', Préstamos.[id Préstamos] as 'PPréstamo', (Asociado.Nombres +' '+ Asociado.Apellidos) as 'PNombre', " +
                "Préstamos.[Cuota Mensual] as 'Monto mínimo',Pago.Saldo as 'Psaldo',  Pago.Pago as 'PPago', Pago.Mora as 'Pmora', " +
                "Transacciones.[Fecha de Transacción] as 'PFecha' From Asociado inner join Préstamos on Asociado.[Código Asociado] = Préstamos.[Código Asociado] " +
                "inner join Pago on Préstamos.[id Préstamos] = Pago.[id Préstamo] inner join Transacciones on Pago.[FK Transacción] = Transacciones.[id Transacción] " +
                "where Pago.[id Pago] = @id_Pago and Préstamos.[id Préstamos]= @Id_Préstamo " +
                "Commit Tran Constancia " +
                "End try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback tran Constancia " +
                "End Catch ";
            //Procedimiento para Informe de Préstamo
            String procedimiento46 = "Create Procedure[dbo].[Informe Préstamo] " +
                "@Codigo varchar(5) " +
                "As Begin " +
                "Tran Informe " +
                "Begin Try " +
                "Declare @Id_Préstamo varchar(9) " +
                "Set @Id_Préstamo = (Select Max(Préstamos.[id Préstamos]) From Préstamos inner join Asociado on Préstamos.[Código Asociado] = Asociado.[Código Asociado] " +
                "where Asociado.[Código Asociado] = @Codigo) " +
                "Select Asociado.[Código Asociado] AS 'Código_A', (Asociado.Nombres + ' ' + Asociado.Apellidos) AS 'Nombre', " +
                "Asociado.Apellidos as 'Ape', Préstamos.[id Préstamos] as 'Préstamo', " +
                "Asociado.Dirección as 'Dir', Ocupación.[Nombre de la Empresa] as 'Trabajo',[Forma de Pago].Nombre AS 'FormaP', [Tipo de Préstamo].[Tipo de Préstamo] As 'TipoP',  " +
                "Asociado.DUI as 'PDUI',[Tipo de Préstamo].[Tasa de Interés] As 'Interés',  " +
                "Préstamos.[Monto del Préstamo] AS 'Monto', Transacciones.[Fecha de Transacción] AS 'FechaT', Préstamos.Cuotas AS 'NCuotas', " +
                "Préstamos.[Cuota Mensual] AS 'PCuotas', Préstamos.Estado AS 'Estado' From Ocupación inner join Asociado on " +
                "Ocupación.[Id Ocupación] = Asociado.[FK Ocupación] inner join Préstamos on Asociado.[Código Asociado] = Préstamos.[Código Asociado] " +
                "inner join [Tipo de Préstamo] on Préstamos.[id Tipo de Préstamo] = [Tipo de Préstamo].[id Tipo de Préstamo] " +
                "inner join [Forma de Pago] on Préstamos.[id Forma de Pago] = [Forma de Pago].[id Forma de Pago] " +
                "inner join Transacciones on Préstamos.[FK Transacción] = Transacciones.[id Transacción] where Préstamos.[id Préstamos]= @Id_Préstamo " +
                "Commit Tran Informe End Try Begin Catch Print ERROR_MESSAGE(); Rollback Tran Informe End Catch ";
            //Añadido para cargar datos cooperativa
            String procedimiento47 = "Create Procedure [dbo].[Conseguir Transacciones]  " +
                "@Fecha_Inicial datetime, " +
                "@Fecha_Final datetime, " +
                "@Tipo_Transaccion varchar(30) " +
                "As " +
                "Begin Tran Coop " +
                "Begin Try " +
                "If(@Tipo_Transaccion = 'Todas las transacciones') " +
                "Begin " +
                "Set @Tipo_Transaccion = '' " +
                "End " +
                "Select t.[Fecha de Transacción] AS 'Fecha', tt.[Tipo de Transacción] AS 'Transacción', " +
                "	(tu.Nombres + ' ' + tu.Apellidos) AS 'Usuario' from Transacciones t " +
                "   inner join [Tipo de Transacción] as tt on tt.[id Tipo de Transacción] = t.[FK Tipo de Transacción] " +
                "   inner join [Usuarios] as tu on tu.[Id Usuario] = t.[ID Usuario Transacción] " +
                "   where tt.[Tipo de Transacción] Like('%' + @Tipo_Transaccion + '%') AND " +
                "   t.[Fecha de Transacción] <= @Fecha_Final AND " +
                "   t.[Fecha de Transacción] >= @Fecha_Inicial order by t.[Fecha de Transacción] " +
                "Commit tran Coop " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Coop " +
                "End Catch";
#warning Editar, para añadir las aportaciones retiradas
            String procedimiento48 = "Create Procedure [dbo].[Conseguir Datos Cooperativa] " +
                "@Fecha_Inicial datetime, " +
                "@Fecha_Final datetime " +
                "As " +
                "Begin Tran Coop " +
                "Begin Try " +
                "Declare @Abonos smallmoney = 0, @Retiros smallmoney = 0, @Aportaciones smallmoney = 0, " +
                "    @RetiroAportación smallmoney = 0, @Préstamos_Otorgados smallmoney = 0, " +
                "    @Pago_Capital smallmoney = 0, @Intereses_Pagados smallmoney = 0, @Mora_Pagada smallmoney = 0 , @SumaP smallmoney, @SumaN smallmoney " +
                "Set @Abonos = (Select SUM(X.Abono) From Abono X " +
                "    inner join Transacciones t on t.[id Transacción] = X.[FK Transacción] " +
                "    where t.[Fecha de Transacción]<=@Fecha_Final AND " +
                "    t.[Fecha de Transacción]>=@Fecha_Inicial) " +
                "Set @Retiros = (Select SUM(X.Retiro) From Retiros X " +
                "    inner join Transacciones t on t.[id Transacción]= X.[FK Transacción] " +
                "    where t.[Fecha de Transacción]<=@Fecha_Final AND " +
                "    t.[Fecha de Transacción]>=@Fecha_Inicial) " +
                "Set @Aportaciones = (Select SUM(X.Aportación) From Aportaciones X " +
                "    inner join Transacciones t on t.[id Transacción]= X.[FK Transacción] " +
                "    where t.[Fecha de Transacción]<=@Fecha_Final AND " +
                "    t.[Fecha de Transacción]>=@Fecha_Inicial) " +
                "Set @Préstamos_Otorgados = (Select SUM(X.[Monto del Préstamo]) From Préstamos X " +
                "    inner join Transacciones t on t.[id Transacción]= X.[FK Transacción] " +
                "    where t.[Fecha de Transacción]<=@Fecha_Final AND " +
                "    t.[Fecha de Transacción]>=@Fecha_Inicial) " +
                "Set @Pago_Capital = (Select SUM(X.Capital) From Pago X " +
                "    inner join Transacciones t on t.[id Transacción]= X.[FK Transacción] " +
                "    where t.[Fecha de Transacción]<=@Fecha_Final AND " +
                "    t.[Fecha de Transacción]>=@Fecha_Inicial) " +
                "Set @Intereses_Pagados = (Select SUM(X.Intereses) From Pago X " +
                "    inner join Transacciones t on t.[id Transacción]= X.[FK Transacción] " +
                "    where t.[Fecha de Transacción]<=@Fecha_Final AND " +
                "    t.[Fecha de Transacción]>=@Fecha_Inicial) " +
                "Set @Mora_Pagada = (Select SUM(X.Mora) From Pago X " +
                "    inner join Transacciones t on t.[id Transacción]= X.[FK Transacción] " +
                "    where t.[Fecha de Transacción]<=@Fecha_Final AND " +
                "    t.[Fecha de Transacción]>=@Fecha_Inicial) " +
                "Set @SumaP = @Abonos + @Aportaciones + @Pago_Capital + @Intereses_Pagados + @Mora_Pagada " +
                "Set @SumaN = @Retiros + @RetiroAportación + @Préstamos_Otorgados " +
                "Select @Abonos as 'Abonos', @Retiros as 'Retiros', @Aportaciones as 'Aportaciones', " +
                "    @RetiroAportación as 'RetiroAportación', @Préstamos_Otorgados as 'Préstamos_Otorgados', @Pago_Capital as 'Pago_Capital', " +
                "    @Intereses_Pagados as 'Intereses_Pagados', @Mora_Pagada as 'Mora_Pagada' , @SumaP as 'TotalP', @SumaN as 'TotalN' " +
                "Commit tran Coop " +
                "End Try " +
                "Begin Catch " +
                "    Print ERROR_MESSAGE(); " +
                "    Rollback Tran Coop " +
                "End Catch";
            String procedimiento49 = "CREATE Procedure [dbo].[Conseguir Imágenes]  " +
                "@Persona_Asociada varchar(5) As " +
                "Begin Tran Img " +
                "Begin Try " +
                "Select i.Imagen as 'img', ti.Nombre as 'tipo', i.[Fecha de Subida] as 'fecha', i.Comentarios as 'comment', i.[id Imagen] as 'id' from Imagen i  " +
                "inner join [Tipos de Imágenes] ti on ti.[id Tipo Imagen]=i.[Tipo Imagen] " +
                "where [Persona Asociada] = @Persona_Asociada " +
                "Commit tran Img " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Img " +
                "End Catch";
            String procedimiento50 = "CREATE Procedure [dbo].[Insertar Imagen]  " +
                "@Persona_Asociada varchar(5), " +
                "@Imagen Image, " +
                "@TipoImagen varchar(5), " +
                "@Comentarios varchar(120) " +
                "As " +
                "Begin Tran Img " +
                "Begin Try Declare @Contar_Tipo int " +
                "Set @Contar_Tipo = (Select Count([id Imagen]) from Imagen where [Tipo Imagen]=@TipoImagen and [Persona Asociada]=@Persona_Asociada ) " +
                "IF (@Contar_Tipo < 2) Begin " +
                "if (@Comentarios <> '') " +
                "Begin " +
                "Insert Imagen values(@Imagen, GetDate(), @Persona_Asociada, @TipoImagen, @Comentarios) " +
                "End " +
                "Else " +
                "Begin " +
                "Insert Imagen(Imagen,[Fecha de Subida],[Persona Asociada],[Tipo Imagen]) " +
                "values(@Imagen, GetDate(), @Persona_Asociada, @TipoImagen) " +
                "End END " +
                "ELSE BEGIN " +
                "Print 'Ya se encuentran almacenadas dos imágenes de este tipo. Elimine otra imagen, modifíquela o cambie de tipo de imagen para poder continuar' " +
                "END Commit tran Img " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran Img " +
                "End Catch";
            String procedimiento51 = "Create Procedure [dbo].[Actualizar Imagen]  " +
                "@Persona_Asociada varchar(5), " +
                "@Id_Imagen varchar(7), " +
                "@Imagen Image, " +
                "@TipoImagen varchar(5), " +
                "@Comentarios varchar(120) " +
                "As " +
                "Begin Tran Img " +
                "Begin Try " +
                "Declare @Contar_Tipo int, @Tipo_Original varchar(5) " +
                "Set @Contar_Tipo = (Select Count([id Imagen]) from Imagen where [Tipo Imagen] = @TipoImagen and[Persona Asociada] = @Persona_Asociada )  " +
                "Set @Tipo_Original = (Select[Tipo Imagen] from Imagen where [id Imagen] = @Id_Imagen) " +
                "IF(@Contar_Tipo < 2 or @Tipo_Original = @TipoImagen) " +
                "Begin " +
                "    if (@Comentarios <> '') " +
                "    Begin " +
                "    Update Imagen set Imagen=@Imagen, [Fecha de Subida]=GETDATE(),[Tipo Imagen]=@TipoImagen, Comentarios=@Comentarios  where [id Imagen]=@Id_Imagen " +
                "    End " +
                "    Else " +
                "    Begin " +
                "    Update Imagen set Imagen=@Imagen, [Fecha de Subida]=GETDATE(), [Persona Asociada]=@Persona_Asociada, [Tipo Imagen]=@TipoImagen, Comentarios=null where [id Imagen]=@Id_Imagen " +
                "    End " +
                "END " +
                "ELSE " +
                "BEGIN " +
                "Print 'Ya se encuentran almacenadas dos imágenes de este tipo. Elimine otra imagen o cambie de tipo de imagen para poder continuar' " +
                "END " +
                "Commit tran Img " +
                "End Try " +
                "Begin Catch " +
                "    Print ERROR_MESSAGE(); " +
                "    Rollback Tran Img " +
                "End Catch ";
            String procedimiento52 = "Create Procedure [dbo].[Eliminar Imagen] " +
                "@Id_Imagen varchar(7) " +
                "As " +
                "Begin Tran Img " +
                "Begin Try " +
                "    Delete Imagen where [id Imagen] = @Id_Imagen " +
                "    Commit tran Img " +
                "End Try " +
                "Begin Catch " +
                "    Print ERROR_MESSAGE(); " +
                "    Rollback Tran Img " +
                "End Catch ";
            String procedimiento53 = "Create Procedure [dbo].[Cargar Tipo Imagen] " +
                "As " +
                "Begin Tran img " +
                "Begin Try " +
                "Select Nombre AS 'TipoI', [id Tipo Imagen] as 'idI' from[Tipos de Imágenes] " +
                "Commit Tran img " +
                "End Try " +
                "Begin Catch " +
                "Print ERROR_MESSAGE(); " +
                "Rollback Tran img " +
                "End Catch ";

            String Login1 =
                "CREATE LOGIN Master_ACOPEDH " +
                "WITH PASSWORD = 'Aureo112358' ";

            String Login2 =
                "CREATE LOGIN Administrador " +
                "WITH PASSWORD = 'Acopedh365' ";
            String Login3 =
                "CREATE LOGIN Usuario " +
                "WITH PASSWORD = 'User12345' ";
            String Login4 =
                "CREATE LOGIN InicioSesion " +
                "WITH PASSWORD = 'In112358' " ;
            String Usuario1 =
               "USE " + txtNombre.Text + ";" +
               "CREATE USER Master_ACOPEDH FOR LOGIN Master_ACOPEDH ";
            String Usuario2 =
                "USE " + txtNombre.Text + ";" +
                "CREATE USER Administrador FOR LOGIN Administrador";
            String Usuario3 =
                "USE " + txtNombre.Text + ";" +
                "CREATE USER Usuario FOR LOGIN Usuario ";
            String Usuario4 =
                "USE " + txtNombre.Text + ";" +
                "CREATE USER InicioSesion FOR LOGIN InicioSesion ";
            String permisosMaster_ACOPEDH =
                "Use " + txtNombre.Text + ";" +
                "Exec sp_addrolemember N'db_owner',N'Master_ACOPEDH' ";
            String permisosAdministrador =
                "Use " + txtNombre.Text + ";" +
                "grant select, update, references, insert on object :: Ahorro " +
                "to Administrador with grant option " +
                "grant select, update, references, insert on object :: Imagenes " +
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
                "grant select, references, insert on object :: [Retiros Aportaciones] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Insertar Asociado] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Cargar Asociados] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Ahorro DVG] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Asociado DVG] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Préstamo DVG] " +
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
                "grant execute on object :: [Modificar Teléfono] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Nueva Cuenta de Ahorro] " +
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
                "to Administrador with grant option " +
                "grant execute on object :: [Desasociar] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Cerrar Ahorro] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Cargar Imagenes] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Nueva Imagen] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Elimina Imagen] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Retirar Aportaciones] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Cerrar Préstamo] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Constancia Pago] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Informe Préstamo] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Conseguir Transacciones] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Conseguir Datos Cooperativa] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Conseguir Imágenes] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Insertar Imagen] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Actualizar Imagen] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Eliminar Imagen] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Cargar Tipo Imagen] " +
                "to Administrador with grant option " +
                "grant execute on object :: [Actualizar Asociado] " +
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
                 "('Master_ACOPEDH', 'Aureo112358')," +
                 "('Administrador', 'Acopedh365')," +
                 "('Usuario', 'User12345')," +
                 "('InicioSesion', 'In112358')";
            String crearsocios =
                "insert into [Tipo de Socio] values ('Asociado'), ('Fundador')";
            String creartrabajos =
                "insert into Ocupación values ('PDDH')";
            String crearpagos =
                "insert into [Forma de Pago] values ('Descuento a Planilla'), ('Pago Voluntario')";
            String crearahorros =
                "insert into [Tipo de Ahorro] values ('A la Vista',0),('Vacaciones',0),('Navideño',0),('Escolar',2)";
            String crearpréstamos =
                "insert into [Tipo de Préstamo] values ('Personal',17),('Emergencia',17)";
            String insertartiposdetransacciones =
                "insert into [Tipo de Transacción] values ('Aportación'),('Abono'), ('Préstamo'), ('Pago'), ('Retiro'), ('Ahorro'),('Retiro de Aportaciones'), ('Refinanciamiento de Préstamo')";
            //Añadido, la inserción de teléfonos
            String insertartiposdeteléfonos =
                 "insert into [Tipos de Teléfonos] values ('Celular'),('Casa'), ('Trabajo'), ('Fax')";

            //Creación Base de Datos

            SqlCommand cmd = new SqlCommand(cadena1, cnn);
            SqlCommand cmdUse = new SqlCommand(USE, cnn);

            //Creación Tablas

            SqlCommand cmd0 = new SqlCommand(tablaVariables, cnn);

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

            //Creación Procedimientos

            SqlCommand cmd_01 = new SqlCommand(procedimiento1, cnn);
            SqlCommand cmd_02 = new SqlCommand(procedimiento2, cnn);
            SqlCommand cmd_03 = new SqlCommand(procedimiento3, cnn);
            SqlCommand cmd_04 = new SqlCommand(procedimiento4, cnn);
            SqlCommand cmd_05 = new SqlCommand(procedimiento5, cnn);
            SqlCommand cmd_06 = new SqlCommand(procedimiento6, cnn);
            SqlCommand cmd_07 = new SqlCommand(procedimiento7, cnn);
            SqlCommand cmd_08 = new SqlCommand(procedimiento8, cnn);
            SqlCommand cmd_09 = new SqlCommand(procedimiento9, cnn);
            SqlCommand cmd_10 = new SqlCommand(procedimiento10, cnn);
            SqlCommand cmd_11 = new SqlCommand(procedimiento11, cnn);
            SqlCommand cmd_12 = new SqlCommand(procedimiento12, cnn);
            SqlCommand cmd_13 = new SqlCommand(procedimiento13, cnn);
            SqlCommand cmd_14 = new SqlCommand(procedimiento14, cnn);
            SqlCommand cmd_15 = new SqlCommand(procedimiento15, cnn);
            SqlCommand cmd_16 = new SqlCommand(procedimiento16, cnn);
            SqlCommand cmd_17 = new SqlCommand(procedimiento17, cnn);
            SqlCommand cmd_18 = new SqlCommand(procedimiento18, cnn);
            SqlCommand cmd_19 = new SqlCommand(procedimiento19, cnn);
            SqlCommand cmd_20 = new SqlCommand(procedimiento20, cnn);
            SqlCommand cmd_21 = new SqlCommand(procedimiento21, cnn);
            SqlCommand cmd_22 = new SqlCommand(procedimiento22, cnn);
            SqlCommand cmd_23 = new SqlCommand(procedimiento23, cnn);
            SqlCommand cmd_24 = new SqlCommand(procedimiento24, cnn);
            SqlCommand cmd_25 = new SqlCommand(procedimiento25, cnn);
            SqlCommand cmd_26 = new SqlCommand(procedimiento26, cnn);
            SqlCommand cmd_27 = new SqlCommand(procedimiento27, cnn);
            SqlCommand cmd_28 = new SqlCommand(procedimiento28, cnn);
            SqlCommand cmd_29 = new SqlCommand(procedimiento29, cnn);
            SqlCommand cmd_30 = new SqlCommand(procedimiento30, cnn);
            SqlCommand cmd_31 = new SqlCommand(procedimiento31, cnn);
            SqlCommand cmd_32 = new SqlCommand(procedimiento32, cnn);
            SqlCommand cmd_33 = new SqlCommand(procedimiento33, cnn);
            SqlCommand cmd_34 = new SqlCommand(procedimiento34, cnn);
            SqlCommand cmd_35 = new SqlCommand(procedimiento35, cnn);
            SqlCommand cmd_36 = new SqlCommand(procedimiento36, cnn);
            SqlCommand cmd_37 = new SqlCommand(procedimiento37, cnn);
            SqlCommand cmd_38 = new SqlCommand(procedimiento38, cnn);
            SqlCommand cmd_39 = new SqlCommand(procedimiento39, cnn);
            SqlCommand cmd_40 = new SqlCommand(procedimiento40, cnn);
            SqlCommand cmd_41 = new SqlCommand(procedimiento41, cnn);
            SqlCommand cmd_42 = new SqlCommand(procedimiento42, cnn);
            SqlCommand cmd_43 = new SqlCommand(procedimiento43, cnn);
            SqlCommand cmd_44 = new SqlCommand(procedimiento44, cnn);
            SqlCommand cmd_45 = new SqlCommand(procedimiento45, cnn);
            SqlCommand cmd_46 = new SqlCommand(procedimiento46, cnn);
            SqlCommand cmd_47 = new SqlCommand(procedimiento47, cnn);
            SqlCommand cmd_48 = new SqlCommand(procedimiento48, cnn);
            SqlCommand cmd_49 = new SqlCommand(procedimiento49, cnn);
            SqlCommand cmd_50 = new SqlCommand(procedimiento50, cnn);
            SqlCommand cmd_51 = new SqlCommand(procedimiento51, cnn);
            SqlCommand cmd_52 = new SqlCommand(procedimiento52, cnn);
            SqlCommand cmd_53 = new SqlCommand(procedimiento53, cnn);

            //Creación Triggers

            SqlCommand cmdTrigger1 = new SqlCommand(Trigger1, cnn);

            //Creación Login

            SqlCommand cmdLogin1 = new SqlCommand(Login1, cnn);
            SqlCommand cmdLogin2 = new SqlCommand(Login2, cnn);
            SqlCommand cmdLogin3 = new SqlCommand(Login3, cnn);
            SqlCommand cmdLogin4 = new SqlCommand(Login4, cnn);

            //Creación Usuarios

            SqlCommand cmdUsuario1 = new SqlCommand(Usuario1, cnn);
            SqlCommand cmdUsuario2 = new SqlCommand(Usuario2, cnn);
            SqlCommand cmdUsuario3 = new SqlCommand(Usuario3, cnn);
            SqlCommand cmdUsuario4 = new SqlCommand(Usuario4, cnn);

            //Otorgar Permisos

            SqlCommand cmdPermisosMaster = new SqlCommand(permisosMaster_ACOPEDH, cnn);
            SqlCommand cmdPermisosAdmin = new SqlCommand(permisosAdministrador, cnn);
            SqlCommand cmdPermisosUsuario = new SqlCommand(permisosUsuario, cnn);
            SqlCommand cmdPermisosInicio = new SqlCommand(permisosInicioSesión, cnn);

            //Insertar estáticos

            SqlCommand cmdCrearUsuarios = new SqlCommand(crearusuarios, cnn);
            SqlCommand cmdCrearAhorros = new SqlCommand(crearahorros, cnn);
            SqlCommand cmdCrearPagos = new SqlCommand(crearpagos, cnn);
            SqlCommand cmdCrearSocios = new SqlCommand(crearsocios, cnn);
            SqlCommand cmdCrearTrabajos = new SqlCommand(creartrabajos, cnn);
            SqlCommand cmdCrearPréstamos = new SqlCommand(crearpréstamos, cnn);
            SqlCommand cmdCrearTransacciones = new SqlCommand(insertartiposdetransacciones, cnn);
            SqlCommand cmdCrearTeléfonos = new SqlCommand(insertartiposdeteléfonos, cnn);

            //try
            //{
            ////Abrimos la conexión y ejecutamos el comando
            cnn.Open();
            cmd.ExecuteNonQuery();
            cmdUse.ExecuteNonQuery();
            cmd0.ExecuteNonQuery();
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

            cmd_01.ExecuteNonQuery();
            cmd_02.ExecuteNonQuery();
            cmd_03.ExecuteNonQuery();
            cmd_04.ExecuteNonQuery();
            cmd_05.ExecuteNonQuery();
            cmd_06.ExecuteNonQuery();
            cmd_07.ExecuteNonQuery();
            cmd_08.ExecuteNonQuery();
            cmd_09.ExecuteNonQuery();
            cmd_10.ExecuteNonQuery();
            cmd_11.ExecuteNonQuery();
            cmd_12.ExecuteNonQuery();
            cmd_13.ExecuteNonQuery();
            cmd_14.ExecuteNonQuery();
            cmd_15.ExecuteNonQuery();
            cmd_16.ExecuteNonQuery();
            cmd_17.ExecuteNonQuery();
            cmd_18.ExecuteNonQuery();
            cmd_19.ExecuteNonQuery();
            cmd_20.ExecuteNonQuery();
            cmd_21.ExecuteNonQuery();
            cmd_22.ExecuteNonQuery();
            cmd_23.ExecuteNonQuery();
            cmd_24.ExecuteNonQuery();
            cmd_25.ExecuteNonQuery();
            cmd_26.ExecuteNonQuery();
            cmd_27.ExecuteNonQuery();
            cmd_28.ExecuteNonQuery();
            cmd_29.ExecuteNonQuery();
            cmd_30.ExecuteNonQuery();
            cmd_31.ExecuteNonQuery();
            cmd_32.ExecuteNonQuery();
            cmd_33.ExecuteNonQuery();
            cmd_34.ExecuteNonQuery();
            cmd_35.ExecuteNonQuery();
            cmd_36.ExecuteNonQuery();
            cmd_37.ExecuteNonQuery();
            cmd_38.ExecuteNonQuery();
            cmd_39.ExecuteNonQuery();
            cmd_40.ExecuteNonQuery();
            cmd_41.ExecuteNonQuery();
            cmd_42.ExecuteNonQuery();
            cmd_43.ExecuteNonQuery();
            cmd_44.ExecuteNonQuery();
            cmd_45.ExecuteNonQuery();
            cmd_46.ExecuteNonQuery();
            cmd_47.ExecuteNonQuery();
            cmd_48.ExecuteNonQuery();
            cmd_49.ExecuteNonQuery();
            cmd_50.ExecuteNonQuery();
            cmd_51.ExecuteNonQuery();
            cmd_52.ExecuteNonQuery();
            cmd_53.ExecuteNonQuery();


            cmdTrigger1.ExecuteNonQuery();

            cmdLogin1.ExecuteNonQuery();
            cmdLogin2.ExecuteNonQuery();
            cmdLogin3.ExecuteNonQuery();
            cmdLogin4.ExecuteNonQuery();

            cmdUsuario1.ExecuteNonQuery();
            cmdUsuario2.ExecuteNonQuery();
            cmdUsuario3.ExecuteNonQuery();
            cmdUsuario4.ExecuteNonQuery();

            cmdPermisosMaster.ExecuteNonQuery();
            cmdPermisosAdmin.ExecuteNonQuery();
            cmdPermisosUsuario.ExecuteNonQuery();
            cmdPermisosInicio.ExecuteNonQuery();

            cmdCrearUsuarios.ExecuteNonQuery();
            cmdCrearAhorros.ExecuteNonQuery();
            cmdCrearPagos.ExecuteNonQuery();
            cmdCrearSocios.ExecuteNonQuery();
            cmdCrearTrabajos.ExecuteNonQuery();
            cmdCrearPréstamos.ExecuteNonQuery();
            cmdCrearTransacciones.ExecuteNonQuery();
            cmdCrearTeléfonos.ExecuteNonQuery();
            cnn.Close();
            MessageBox.Show("Base Creada");
            this.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message,"Error al crear la base", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
        }
    }
}