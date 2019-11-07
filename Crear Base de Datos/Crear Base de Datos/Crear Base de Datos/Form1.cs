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
            Focus();
            Servidores ser = new Servidores();
            this.Hide();
            ser.ShowDialog();
        }
        private void BttCrear_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection("Server=" + Servidores.Servidor + "; \n" + "database=master; integrated security=yes");
            try
            {
                cnn.Open();
                cnn.Close();
            }
            catch
            {
                cnn.Close();
                cnn = new SqlConnection("Server=" + Servidores.Servidor2 + "; \n" + "database=master; integrated security=yes");
            }
            SqlConnection cnn2 = cnn;

            ////  Para crear la base en Azure
            //SqlConnection cnn = new SqlConnection("Server=yiyel501.database.windows.net;database=master; User Id=Yiyel501;Password=acopedh_1234");
            //SqlConnection cnn2 = new SqlConnection("Server=yiyel501.database.windows.net;database=ACOPEDH; User Id=Yiyel501;Password=acopedh_1234");

            String cadena1 = "CREATE DATABASE \n" + txtNombre.Text;
            //Comentar para Azure
            String USE = "Use \n" + txtNombre.Text + ";";
            //Tablas
#warning Añadir más variables después
            String tablaVariables = "CREATE TABLE [dbo].[Variables]( \n" +
                "[Aportación] smallmoney not null, \n" +
                "[Mora] Numeric(3,2) \n" +
                //" \n" +
                //" \n" +
                //" \n" +
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
#warning Aquí se cambio la llave primaria
                /*"[Número][int] IDENTITY(1, 1) NOT NULL," +
                "[id Transacción]  AS('TR' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL primary key," +*/
                "[id Transacción] [int] IDENTITY(1, 1) NOT NULL primary key," +
                "[ID Usuario Transacción] varchar(5) references [Usuarios]([Id Usuario]), \n" +
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
            String tabla08 = "CREATE TABLE [dbo].[Persona](" +
                "[Número][int] IDENTITY(1, 1) NOT NULL," +
                "[Código Persona]  AS('PC' + right('000000' + CONVERT([varchar](6),[Número]), (6))) PERSISTED NOT NULL," +
                "[Nombres] [varchar](50) NOT NULL," +
                "[Apellidos] [varchar](50) NOT NULL," +
                "[DUI] [varchar](10) NULL unique," +
                "[NIT] [varchar](17) NULL unique," +
                "[Dirección] [varchar](100) NULL," +
                "[Fecha de Nacimiento] [datetime] NOT NULL," +
                "CONSTRAINT [PK_Persona] PRIMARY KEY ([Código Persona]))";
            String tabla8 = "CREATE TABLE [dbo].[Asociado](" +
#warning verificar aqui sobre llaves primarias
                  "[Número][int] IDENTITY(1, 1) NOT NULL," +
                  "[Código Asociado]  AS(right('000000' + CONVERT([varchar](6),[Número]), (6))) PERSISTED NOT NULL," +
                //"[Código Asociado][int] IDENTITY(1, 1) Not Null, \n" +
                "[FK Persona] [varchar](8) NOT NULL," +
                "[FK Tipo Socio] [varchar](5) NOT NULL," +
                "[Fecha de Asociación] [datetime] NOT NULL," +
                "[Fecha de Desasociación] [datetime] NULL," +
                "[Estado] [varchar](10) NOT NULL, \n" +
                "[FK Ocupación] [varchar](5) NOT NULL," +
                "CONSTRAINT [PK_Asociado] PRIMARY KEY ([Código Asociado])," +
                "CONSTRAINT [FK Persona] FOREIGN KEY ([FK Persona])" +
                "REFERENCES [Persona]([Código Persona])," +
                "CONSTRAINT [FK Tipo Socio] FOREIGN KEY ([FK Tipo Socio])" +
                "REFERENCES [Tipo de Socio]([id Tipo de Socio])," +
                "CONSTRAINT [FK Ocupación] FOREIGN KEY ([FK Ocupación])" +
                "REFERENCES Ocupación([Id Ocupación]))";
            String tabla010 = "CREATE TABLE [dbo].[Beneficiario](" +
                "[FK Persona] [varchar](8) NOT NULL," +
                "[FK Asociado] [varchar](6) NOT NULL," +
                "CONSTRAINT [FK Persona A] FOREIGN KEY ([FK Persona])" +
                "REFERENCES [Persona]([Código Persona])," +
                "CONSTRAINT [FK Asociado P] FOREIGN KEY ([FK Asociado])" +
                "REFERENCES [Asociado]([Código Asociado]))";
            String tabla9 = "CREATE TABLE [dbo].[Aportaciones](" +
                "[Número] [int] IDENTITY(1,1) NOT NULL," +
                "[id Aportación]  AS('AP' + right('000000' + CONVERT([varchar](6),[Número]), (6))) PERSISTED NOT NULL," +
                "[Aportación] [money] NOT NULL," +
                "[FK Asociado] [varchar](6) NOT NULL," +
                "[FK Transacción] [int] references [Transacciones]([id Transacción])," +
                "CONSTRAINT[PK_Aportaciones] PRIMARY KEY([id Aportación])," +
                "CONSTRAINT [FK Asociado] FOREIGN KEY ([FK Asociado])" +
                "REFERENCES Asociado([Código Asociado]))";
            String tabla10 = "CREATE TABLE[dbo].[Ahorro](" +
                "[Número] [int] IDENTITY(1,1) NOT NULL," +
                "[id Ahorro]  AS('AH' + right('000000' + CONVERT([varchar](6),[Número]), (6))) PERSISTED NOT NULL," +
                "[Estado] [varchar](10) NOT NULL," +
                "[FK Tipo Ahorro] [varchar](5) NOT NULL," +
                "[FK Código de Asociado] [varchar](6) NOT NULL," +
                "[FK Transacción] [int] references [Transacciones]([id Transacción])," +
                "CONSTRAINT [PK_Ahorro] PRIMARY KEY ([id Ahorro])," +
                "CONSTRAINT [FK Tipo Ahorro] FOREIGN KEY ([FK Tipo Ahorro])" +
                "REFERENCES [Tipo de Ahorro]([id Tipo Ahorro])," +
                "CONSTRAINT [FK Código de Asociado] FOREIGN KEY ([FK Código de Asociado])" +
                "REFERENCES Asociado([Código Asociado]))";
            String tabla11 = "CREATE TABLE [dbo].[Retiros](" +
                "[Número][int] IDENTITY(1, 1) NOT NULL," +
                "[id Retiro]  AS('RE' + right('000000' + CONVERT([varchar](6),[Número]), (6))) PERSISTED NOT NULL," +
                "[Retiro] [money] NOT NULL," +
                "[Número de Cheque] [varchar](8) NOT NULL," +
                "[FK Ahorro] [varchar](8) NOT NULL," +
                "[FK Transacción] [int] references [Transacciones]([id Transacción])," +
                "CONSTRAINT[PK_Retiros] PRIMARY KEY ([id Retiro])," +
                "CONSTRAINT [FK Ahorro] FOREIGN KEY ([FK Ahorro])" +
                "REFERENCES Ahorro([id Ahorro]))";
            String tabla12 = "CREATE TABLE [dbo].[Abono](" +
                "[Número][int] IDENTITY(1,1) NOT NULL," +
                "[id Abono]  AS('AB' + right('000000' + CONVERT([varchar](6),[Número]), (6))) PERSISTED NOT NULL," +
                "[Abono] [money] NOT NULL," +
                "[Abono y Comisión] [money] NOT NULL," +
                "[FK Ahorro] [varchar](8) NOT NULL," +
                "[FK Transacción] [int] references [Transacciones]([id Transacción])," +
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
                "[id Teléfono] AS('TE' + right('000000' + CONVERT([varchar](6),[Número]), (6))) PERSISTED NOT NULL," +
                "[Teléfono][varchar](10) NOT NULL," +
                "CONSTRAINT [PK Teléfono] PRIMARY KEY ([id Teléfono]))";
            String tabla15 = "CREATE TABLE [dbo].[Contacto](" +
                "[FK Teléfono] [varchar](8) NOT NULL references[Teléfono]([id Teléfono])," +
                "[FK Persona] [varchar](8) NOT NULL references Persona([Código Persona]), \n" +
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
                "[Código Asociado] [varchar](6) NOT NULL references [Asociado]([Código Asociado])," +
                "[id Forma de Pago] [varchar](5) references[Forma de Pago]([id Forma de Pago]) NOT NULL," +
                "[id Tipo de Préstamo] [varchar](5) references [Tipo de Préstamo]([id Tipo de Préstamo]) NOT NULL," +
                "[Tasa de Interés] [decimal](10, 2) NOT NULL," +
                "[Fecha de Otorgamiento] [datetime] NOT NULL," +
                "[Cuotas] [int] NOT NULL," +
                "[Monto del Préstamo] [money] NOT NULL," +
                "[Cuota Mensual] [money] NOT NULL," +
                "[FK Transacción] [int] references [Transacciones]([id Transacción])," +
                "[Estado] [varchar](10) NOT NULL)";
            String tabla19 = "Create table [dbo].[Pago](" +
                "[Número][int] identity(1, 1) NOT NULL," +
                "[id Pago] AS('PA' + right('000000' + Convert([varchar](6),[Número]), (6))) PERSISTED NOT NULL," +
                "[Pago] [money] NOT NULL," +
                "[Número de Cuota] [int] NOT NULL," +
                "[Intereses] [money] NOT NULL," +
                "[Capital] [money] NOT NULL," +
                "[Saldo] [money] NOT NULL," +
                "[id Préstamo] [varchar](9) references [Préstamos]([id Préstamos])NOT NULL," +
                "[Mora] [money]," +
                "[Fecha Límite][datetime] NOT NULL," +
                "[FK Transacción] [int] references [Transacciones]([id Transacción])," +
                 "CONSTRAINT [PK Pago] PRIMARY KEY ([id Pago]))";
            String tabla20 = "Create table Imagenes(" +
                "Cod_Imagen int identity(1, 1) primary key, \n" +
                "Imagen Image, \n" +
                "[Tipo imagen] int, \n" +
                "Estado varchar(8), \n" +
                "Descripcion varchar(MAX)); ";
            String tabla21 = "Create table[Retiros Aportaciones](" +
                "[Número][int] IDENTITY(1, 1) NOT NULL, \n" +
                "[Id Retiro Aportación]  AS('RA' + right('000000' + CONVERT([varchar](6),[Número]), (6))) PERSISTED NOT NULL, \n" +
                "[Retiro] money NOT NULL, \n" +
                "[Número de Cheque] varchar(8) NOT NULL, \n" +
                "[FK Asociado] [varchar](6) NOT NULL references Asociado([Código Asociado]), \n" +
                "[FK Transacción] [int] NOT NULL references Transacciones([id Transacción])) ";
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
                "[Persona Asociada] [varchar](8) references [Persona]([Código Persona])," +
                "[Tipo Imagen] [varchar](5) references [Tipos de Imágenes]([id Tipo Imagen])," +
                "[Comentarios] [varchar](120) null," +
                "CONSTRAINT [PK Imagen] PRIMARY KEY ([id Imagen]))";
            //Añadido para conseguir el límite anterior
            String procedimiento1 = "Create Procedure [Conseguir Límite] \n" +
                "@Id_Préstamo varchar(9) \n" +
                "As Begin Tran Pagar \n" +
                "Begin Try \n" +
                "Declare @NPagos int \n" +
                "Set @NPagos = (Select Count(Pago.[Número de Cuota]) From Pago inner join Préstamos on Préstamos.[id Préstamos] = Pago.[id Préstamo] \n" +
                "where Préstamos.[id Préstamos] = @Id_Préstamo) \n" +
                "IF @NPagos > 0 \n" +
                "begin \n" +
                "Select Pago.[Fecha Límite] as 'Límite' from Pago where Pago.[Número de Cuota] = @NPagos \n" +
                "END \n" +
                "ELSE \n" +
                "begin \n" +
                "    Select Préstamos.[Fecha de Otorgamiento] as 'Límite' from Préstamos where Préstamos.[id Préstamos]= @Id_Préstamo \n" +
                "END \n" +
                "Commit tran Pagar \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Pagar \n" +
                "return 0 \n" +
                "End Catch";
            String procedimiento2 = "Create Procedure[Insertar Asociado]" +
                "@FK_Persona varchar(8), \n" +
                "@FK_Tipo_Socio varchar(5), \n" +
                "@Nombres varchar(80), \n" +
                "@Apellidos varchar(80), \n" +
                "@DUI varchar(10), \n" +
                "@NIT varchar(17), \n" +
                "@Residencia varchar(100), \n" +
                "@Fecha_Nacimiento datetime, \n" +
                "@Fecha_Asociación datetime, \n" +
                "@FK_Ocupacion varchar(5) \n" +
                "As \n" +
                "Begin Tran Asociado Begin try \n" +
                "Declare @Persona int Declare @FK_Per varchar(8) \n" +
                "if(@FK_Persona='') begin \n" +
                "Set @FK_Per=(Select [Código Persona] from Persona where [DUI]=@DUI) \n" +
                "if(@FK_Per is null) begin \n" +
                "Insert into Persona values(@Nombres,@Apellidos,@DUI,@NIT,@Residencia,@Fecha_Nacimiento) \n" +
                "Set @FK_Per=(Select [Código Persona] from Persona where [DUI]=@DUI) \n" +
                "end end \n" +
                "else begin Set @FK_Per=@FK_Persona end \n" +
                "set @Persona=(Select count([Código Asociado]) from Asociado where [FK Persona]=@FK_Per) \n" +
                "if @Persona=0 \n" +
                "begin \n" +
                "Insert into Asociado values(@FK_Per,@FK_Tipo_Socio, @Fecha_Asociación, null, 'ACTIVO', @FK_Ocupacion) \n" +
                "end \n" +
                "else \n" +
                "begin Print 'Ya existe una persona registrada con ese DUI' \n" +
                "end \n" +
                "Commit tran Asociado \n" +
                "End try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback tran Asociado \n" +
                "End Catch ";
            //Cambiado los nombres para cargar las variables y añadiendo campos
            String procedimiento3 = "Create Procedure[Cargar Asociados] \n" +
                "@Código_Asociado varchar(6) \n" +
                "As \n" +
                "Begin Tran Cargar_Asociados \n" +
                "Begin Try \n" +
                "Select p.[Código Persona] as 'id', [Tipo de Socio].[Nombre Tipo Socio] AS 'Tipo de Asociación', p.Nombres AS 'Name', p.Apellidos AS 'LName',p.DUI AS 'DDui', p.NIT AS 'DNit', \n" +
                "p.Dirección AS 'Residencia', p.[Fecha de Nacimiento] AS 'FNacimiento', [Fecha de Asociación] AS 'FAsociación', [Fecha de Desasociación] AS 'FDesasociación', Estado AS 'Est', \n" +
                "Ocupación.[Nombre de la Empresa] AS 'Trabajo' From Asociado inner join [Tipo de Socio] on [Tipo de Socio].[id Tipo de Socio]=Asociado.[FK Tipo Socio] \n" +
                "inner join Ocupación on Ocupación.[Id Ocupación] = Asociado.[FK Ocupación] \n" +
                "inner join Persona p on p.[Código Persona]=Asociado.[FK Persona] where [Código Asociado] = @Código_Asociado \n" +
                "Commit Tran Cargar_Asociados \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Cargar_Asociados \n" +
                "End Catch";
            String procedimiento4 = "Create Procedure[Insertar Teléfono] \n" +
                "@Tipo_Teléfono varchar(5),  \n" +
                "@Teléfono varchar(9), \n" +
                "@DUI varchar(10) \n" +
                "As \n" +
                "Begin Tran Teléfono \n" +
                "Begin Try \n" +
                "Declare @ID_Persona varchar(8) \n" +
                "Declare @ID_Teléfono varchar(8) \n" +
                "Begin \n" +
                "Set @ID_Persona = (Select[Código Persona] From Persona where @DUI = DUI)  \n" +
                "Insert into Teléfono values(@Teléfono) \n" +
                "set @ID_Teléfono = (Select Max([id Teléfono]) From Teléfono) \n" +
                "Insert into Contacto values(@ID_Teléfono, @ID_Persona, @Tipo_Teléfono) \n" +
                "Commit Tran Teléfono \n" +
                "End \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Teléfono \n" +
                "End Catch";
            String procedimiento5 = "Create Procedure[Cargar Teléfonos] \n" +
                "@Código_Persona varchar(8) \n" +
                "As \n" +
                "Begin Tran Cargar_Teléfonos \n" +
                "Begin Try \n" +
                "Select Teléfono.Teléfono AS 'Número de Teléfono',[Tipos de Teléfonos].[Tipo de Teléfono] From Teléfono \n" +
                "inner join Contacto on Teléfono.[id Teléfono] = Contacto.[FK Teléfono] inner join [Tipos de Teléfonos] on [Tipos de Teléfonos].[id Tipo de Teléfono] = Contacto.[FK Tipo de Teléfono] \n" +
                "where Contacto.[FK Persona] = @Código_Persona \n" +
                "Commit Tran Cargar_Teléfonos \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Cargar_Teléfonos \n" +
                "End Catch ";
            String procedimiento6 = "Create Procedure[Modificar Teléfono] \n" +
                "@Tipo_Telefono varchar(50), \n" +
                "@ID_Teléfono varchar(8), \n" +
                "@Teléfono varchar(10), \n" +
                "@Código_Persona varchar(8) \n" +
                "As \n" +
                "Begin Tran Mod_Tel \n" +
                "Begin Try \n" +
                "If((Select [Tipos de Teléfonos].[Tipo de Teléfono] From[Tipos de Teléfonos] inner join Contacto \n" +
                "on[Tipos de Teléfonos].[id Tipo de Teléfono] = Contacto.[FK Tipo de Teléfono] where Contacto.[FK Teléfono] = @ID_Teléfono AND Contacto.[FK Persona] = @Código_Persona) \n" +
                "= @Tipo_Telefono) \n" +
                "Update Teléfono set Teléfono = @Teléfono where @ID_Teléfono =[id Teléfono] \n" +
                "Commit Tran Mod_Tel \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Mod_Tel \n" +
                "End Catch";
            String procedimiento7 = "Create Procedure[Eliminar Teléfono] \n" +
                "@ID_Teléfono varchar(8), \n" +
                "@Id_Persona varchar(8) \n" +
                "As   \n" +
                "Begin Tran Del_Teléfono \n" +
                "Begin Try \n" +
                "Begin \n" +
                "Delete From Contacto where @ID_Teléfono = [FK Teléfono] AND @Id_Persona = [FK Persona] \n" +
                "Commit Tran Del_Teléfono \n" +
                "End \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Del_Teléfono \n" +
                "End Catch ";
            String procedimiento8 = "Create Procedure[Abonar] \n" +
               "@Abono money, \n" +
               "@Comision money, \n" +
               "@FK_Ahorro varchar(40), \n" +
               "@Id_Usuario varchar(5) \n" +
               "As \n" +
               "Begin Tran Abono \n" +
               "Begin Try \n" +
               "if ((Select Estado From Ahorro where Ahorro.[id Ahorro] = @FK_Ahorro) <> 'INACTIVO') \n"+
               "Begin \n"+
               "Declare @id_Transación int \n" +
               "Insert into Transacciones values(@Id_Usuario, 'TT002',GETDATE()) \n" +
               "set @id_Transación = (Select MAX([id Transacción]) From Transacciones) \n" +
               "Insert into Abono values(@Abono,@Comision,@FK_Ahorro, @id_Transación) \n" +
               "Commit Tran Abono \n" +
               "End \n"+
               "Else begin \n"+
               "Print 'Cuenta INACTIVA. No se puede abonar.' \n"+
               "Commit Tran Abono \n"+
               "end \n"+
               "End Try \n" +
               "Begin Catch \n" +
               "Print ERROR_MESSAGE(); \n" +
               "Rollback tran Abono \n" +
               "End Catch ";
            //Cambiado para que se muestren activos e inactivos
            String procedimiento9 = "Create Procedure[Ahorro DVG] \n" +
                "As \n" +
                "Begin Tran Ahorro_DVG \n" +
                "Begin Try \n" +
                "Select Ahorro.[id Ahorro] as 'Código de Ahorro',(p.Nombres+' ' + p.Apellidos) as 'Persona Asociada', p.DUI as 'DUI' ,[Tipo de Ahorro].Nombre as 'Tipo de Ahorro', Ahorro.Estado as 'Estado' From Asociado inner join Ahorro \n" +
                "on Ahorro.[FK Código de Asociado] = Asociado.[Código Asociado] inner join [Tipo de Ahorro] on Ahorro.[FK Tipo Ahorro]=[Tipo de Ahorro].[id Tipo Ahorro] \n" +
                "inner join Persona p on p.[Código Persona]= Asociado.[FK Persona]" +
                "Commit Tran Ahorro_DVG \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Cargar_Ahorros \n" +
                "End Catch";
            String procedimiento10 = "Create Procedure[dbo].[Realizar Aportación] \n" +
                "@Aportación money, \n" +
                "@ID_Asociado varchar(6), \n" +
                "@Id_Usuario varchar(5) \n" +
                "As \n" +
                "Begin Tran Asociado \n" +
                "Begin try \n" +
                "if ((Select Estado From Asociado where Asociado.[Código Asociado] = @ID_Asociado) = 'ACTIVO') \n" +
                "Begin \n" +
                "If Exists(Select Aportaciones.[id Aportación] from Aportaciones inner join Transacciones on Aportaciones.[FK Transacción]= Transacciones.[id Transacción] \n" +
                "where MONTH(Transacciones.[Fecha de Transacción])= MONTH(GETDATE())AND YEAR(Transacciones.[Fecha de Transacción]) = YEAR(GETDATE()) \n" +
                "AND Aportaciones.[FK Asociado]= @ID_Asociado) \n" +
                "Begin \n" +
                "Print 'Ya se realizó aportación mensual' \n" +
                "Rollback tran Asociado \n" +
                "End \n" +
                "Else \n" +
                "Begin \n" +
                "Declare @id_Transación int \n" +
                "Insert into Transacciones values(@Id_Usuario, 'TT001',GETDATE()) \n" +
                "set @id_Transación = (Select MAX([id Transacción]) From Transacciones) \n" +
                "Insert into Aportaciones values(@Aportación, @ID_Asociado, @id_Transación) \n" +
                "Print 'Aporte realizado con éxito' \n" +
                "Commit tran Asociado \n" +
                "End \n" +
                "End \n" +
                "Else begin \n" +
                "Print 'No se puede realizar aportación. La persona está desasociada.' \n" +
                "Commit Tran Asociado \n" +
                "End \n" +
                "End try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback tran Asociado \n" +
                "End Catch ";
            String procedimiento11 = "Create Procedure[Cargar Aportaciones] \n" +
                "@Código_Asociado varchar(6) \n" +
                "As \n" +
                "Begin Tran C_Aportaciones \n" +
                "Begin Try \n" +
                "Select Aportaciones.Aportación as 'Monto de la Aportación',Transacciones.[Fecha de Transacción] as 'Fecha de Aportación' From Aportaciones inner join Transacciones on Aportaciones.[FK Transacción] =" +
                "Transacciones.[id Transacción] where @Código_Asociado = Aportaciones.[FK Asociado] \n" +
                "Commit Tran C_Aportaciones \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran C_Aportaciones \n" +
                "End Catch";
            String procedimiento12 = "Create Procedure[Suma Aportaciones] \n" +
                "@Código_Asociado varchar(6) \n" +
                "As \n" +
                "Begin Tran S_Aportaciones \n" +
                "Begin Try \n" +
                "if (Select Count(Aportación) AS 'Suma de Aportaciones' From Aportaciones where @Código_Asociado = [FK Asociado] ) > 0 \n" +
                "Begin Select SUM(Aportación) AS 'Suma de Aportaciones' From Aportaciones where @Código_Asociado = [FK Asociado] \n" +
                "Commit Tran S_Aportaciones End \n" +
                "Else Begin Select 0 AS 'Suma de Aportaciones' Commit Tran S_Aportaciones end \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran S_Aportaciones \n" +
                "Select 0 AS 'Suma de Aportaciones' Commit Tran S_Aportaciones \n" +
                "End Catch ";
            //Cambio para visualizar más campos en la consulta
            String procedimiento13 = "Create Procedure[Cargar Pagos] \n" +
                "@ID_Préstamo varchar(9) \n" +
                "As \n" +
                "Begin Tran Cargar_Pagos \n" +
                "Begin Try \n" +
                "Select Pago.[Número de Cuota] as 'No Pago', Pago.Pago as 'Monto Cancelado', Pago.Intereses as 'Pago a Intereses', Pago.Capital as 'Pago a Capital', Pago.Mora as 'Mora por retraso', Pago.Saldo as 'Saldo restante', Transacciones.[Fecha de Transacción] as 'Fecha de Pago', Pago.[Fecha Límite] as 'Fecha Límite de Pago' From Pago \n" +
                "inner join Préstamos on Préstamos.[id Préstamos] = Pago.[id Préstamo] \n" +
                "inner join Transacciones on Préstamos.[FK Transacción] = Transacciones.[id Transacción] where Préstamos.[id Préstamos]=@ID_Préstamo \n" +
                "Commit Tran Cargar_Pagos \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Cargar_Pagos \n" +
                "End Catch ";
#warning Podría causar errores
            //Modificado para que ingrese además un abono
            String procedimiento14 = "Create Procedure [Nueva Cuenta de Ahorro] \n" +
                "@FK_Tipo_Ahorro varchar(20), \n" +
                "@FK_Asociado varchar(6), \n" +
                "@Abono_inicial money, \n" +
                "@Comision money, \n" +
                "@ID_Usuario varchar(5) \n" +
                "As Begin Tran Ahorro \n" +
                "Begin try \n" +
                "Declare @ID_Tipo_Ahorro as varchar(5) \n" +
                "Declare @Contar_Activos as int \n" +
                "Declare @id_Transacción as int \n" +
                "set @ID_Tipo_Ahorro = (Select [id Tipo Ahorro] From [Tipo de Ahorro] where Nombre = @FK_Tipo_Ahorro) \n" +
                "set @Contar_Activos = (Select COUNT([id Ahorro]) from Ahorro where [FK Código de Asociado] = @FK_Asociado AND Estado = 'ACTIVO') \n" +
                "if (Select Estado from Asociado where[Código Asociado] = @FK_Asociado) = 'ACTIVO' \n"+
                "Begin \n"+
                "if @Contar_Activos < 3 \n" +
                "Begin \n" +
                "Insert into Transacciones values(@Id_Usuario, 'TT006', GETDATE()) \n" +
                "set @id_Transacción = (Select MAX([id Transacción]) From Transacciones) \n" +
                "Insert into Ahorro values('ACTIVO', @ID_Tipo_Ahorro, @FK_Asociado, @id_Transacción) \n" +
                "Declare @FK_Ahorro_nuevo as varchar(8) \n" +
                "set @FK_Ahorro_nuevo = (Select MAX([id Ahorro]) from Ahorro where [FK Código de Asociado] = @FK_Asociado) \n" +
                "exec Abonar @Abono_inicial,@Comision,@FK_Ahorro_nuevo,@ID_Usuario \n" +
                "Commit tran Ahorro \n" +
                "End \n" +
                "else \n" +
                "Begin \n" +
                "Print 'El usuario ya tiene 3 cuentas de ahorro activas' \n" +
                "Commit tran Ahorro \n" +
                "End \n" +
                "End \n"+
                "Else begin \n"+
                "Print 'La persona se encuentra DESASOCIADA.' \n"+
                "Commit tran Ahorro \n"+
                "end \n"+
                "End try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback tran Ahorro \n" +
                "return 0 \n" +
                "End Catch ";
            String procedimiento15 = "Create Procedure[Cargar Abonos] \n" +
                "@ID_Ahorro varchar(8) \n" +
                "As \n" +
                "Begin Tran Cargar_Abono \n" +
                "Begin Try \n" +
                "Select Abono.Abono as 'Monto Abonado', Abono.[Abono y Comisión] as 'Abono más Comisión',Transacciones.[Fecha de Transacción] as 'Fecha de Abono' From Abono inner join Transacciones on Abono.[FK Transacción] = Transacciones.[id Transacción] \n" +
                "where[FK Ahorro] = @ID_Ahorro \n" +
                "Commit Tran Cargar_Abono \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Cargar_Abono \n" +
                "End Catch";
            String procedimiento16 = "Create Procedure[Suma Abonos] \n" +
                "@ID_Ahorro varchar(8) \n" +
                "As \n" +
                "Begin Tran Disponibles_Abono \n" +
                "Begin Try \n" +
                "if (Select Count([Abono y Comisión]) AS 'Suma de Abonos' From Abono where[FK Ahorro] = @ID_Ahorro) > 0 Begin \n" +
                "Select SUM([Abono y Comisión]) AS 'Suma de Abonos' From Abono where[FK Ahorro] = @ID_Ahorro \n" +
                "Commit Tran Disponibles_Abono End \n" +
                "else begin Select 0 as 'Suma de Abonos' Commit Tran Disponibles_Abono End \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Disponibles_Abono \n" +
                "Select 0 as 'Suma de Abonos' \n" +
                "End Catch";
            String procedimiento17 = "Create Procedure[Realizar Retiros] \n" +
                "@Retiro money, \n" +
                "@Número_Cheque varchar(8), \n" +
                "@FK_Ahorro varchar(30), \n" +
                "@Id_Usuario varchar(5) \n" +
                "As \n" +
                "Begin Try \n" +
                "Begin Tran Retiro \n" +
                "Declare @id_Transación int \n" +
                "Insert into Transacciones values(@Id_Usuario, 'TT005',GETDATE()) \n" +
                "set @id_Transación = (Select MAX([id Transacción]) From Transacciones) \n" +
                "Insert into Retiros values(@Retiro,@Número_Cheque, @FK_Ahorro, @id_Transación) \n" +
                "Commit Tran Retiro \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback tran Retiro \n" +
                "End Catch ";
            String procedimiento18 = "Create Procedure[Cargar Retiros] \n" +
                "@ID_Ahorro varchar(8) \n" +
                "As \n" +
                "Begin Tran Cargar_Retiro \n" +
                "Begin Try \n" +
                "Select Retiros.Retiro as 'Monto Retirado',Transacciones.[Fecha de Transacción] as 'Fecha de Retiro' From Retiros inner join Transacciones on Retiros.[FK Transacción] = Transacciones.[id Transacción] \n" +
                "where[FK Ahorro] = @ID_Ahorro \n" +
                "Commit Tran Cargar_Retiro \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Cargar_Retiro \n" +
                "End Catch ";
            //Si no hay retiros
            String procedimiento19 = "Create Procedure[Suma Retiros] \n" +
                "@ID_Ahorro varchar(8) \n" +
                "As \n" +
                "Begin Tran Disponibles_Retiro \n" +
                "Begin Try \n" +
                "if (Select Count(Retiro) From Retiros where[FK Ahorro] = @ID_Ahorro ) > 0 \n" +
                "begin \n" +
                "Select SUM(Retiro) AS 'Suma de Retiros' From Retiros where[FK Ahorro] = @ID_Ahorro \n" +
                "Commit Tran Disponibles_Retiro end else \n" +
                "begin \n" +
                "Select 0 AS 'Suma de Retiros' \n" +
                "commit tran Disponibles_Retiro end \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Disponibles_Retiro Select 0 AS 'Suma de Retiros' \n" +
                "End Catch ";
            //Cambiado por el n de cuota
            String procedimiento20 = "Create Procedure[Realizar Pago] \n" +
                "@ID_Préstamo varchar(9), \n" +
                "@Pago money, \n" +
                "@Id_Usuario varchar(5), \n" +
                "@Intereses money, \n" +
                "@Capital money, \n" +
                "@Saldo money, \n" +
                "@Mora money, \n" +
                "@Fecha_Límite datetime \n" +
                "As Begin Tran Pagar \n" +
                "Begin Try \n" +
                "Declare @id_Transación int \n" +
                "Declare @No_Cuota int \n" +
                "if (Select Estado from Préstamos where [id Préstamos] = @ID_Préstamo) = 'ACTIVO' Begin \n" +
                "Insert into Transacciones values(@Id_Usuario, 'TT004', GETDATE()) \n" +
                "set @id_Transación = (Select MAX([id Transacción]) From Transacciones) \n" +
                "Set @No_Cuota = ((Select Count(Pago.[Número de Cuota]) From Pago inner join Préstamos on Préstamos.[id Préstamos] = Pago.[id Préstamo]" +
                "Where Préstamos.[id Préstamos] = @ID_Préstamo) + 1) \n" +
                "Insert into Pago values(@Pago, @No_Cuota, @Intereses, @Capital, @Saldo, @ID_Préstamo, @Mora, @Fecha_Límite, @id_Transación) \n" +
                "Commit Tran Pagar End \n" +
                "Else Begin Print 'El préstamo ya fue cancelado' Commit Tran Pagar return 0 End \n" +
                "End Try Begin Catch Print ERROR_MESSAGE(); Rollback Tran Pagar End Catch ";
            String procedimiento21 = "Create Procedure[Cargar Saldo] \n" +
                  "@ID_Préstamo varchar(9) \n" +
                  "As \n" +
                  "Begin Tran Cargar_Saldo \n" +
                  "Begin Try \n" +
                  "Select Min(Pago.Saldo) AS 'Pago Mínimo' From Pago inner join Préstamos \n" +
                  "on Pago.[id Préstamo] = Préstamos.[id Préstamos] where Préstamos.[id Préstamos]=@ID_Préstamo \n" +
                  "Commit Tran Cargar_Saldo \n" +
                  "End Try \n" +
                  "Begin Catch \n" +
                  "Print ERROR_MESSAGE(); \n" +
                  "Rollback Tran Cargar_Saldo \n" +
                  "End Catch ";
            //Trigger Feo
            String Trigger1 = "Create Trigger [Préstamo Cancelado] \n" +
            "On Pago For Insert \n" +
            "As \n" +
            "Declare @Pago_Ultimo money \n" +
            "Select @Pago_Ultimo = Pago.Saldo From inserted \n" +
            "inner join Pago on Pago.[id Pago] = inserted.[id Pago] \n" +
            "inner join Préstamos on Préstamos.[id Préstamos] = inserted.[id Préstamo] \n" +
            "If (@Pago_Ultimo) = 0 \n" +
            "Begin \n" +
            "Update Préstamos set Estado = 'CANCELADO' \n" +
            "From Préstamos inner join Pago on Préstamos.[id Préstamos] = Pago.[id Préstamo] \n" +
            "inner join inserted on Pago.[id Pago] = inserted.[id Pago] \n" +
            "where Pago.[id Pago] = inserted.[id Pago] \n" +
            "End;";
            //Modificación
            String procedimiento22 = "Create Procedure[Cargar Préstamo] \n" +
                "@ID_Préstamo varchar(9) \n" +
                 "As \n" +
                 "Begin Tran Cargar_P \n" +
                "Begin Try \n" +
                "Select Asociado.[Código Asociado] AS 'Código_A', (p.Nombres + ' ' + p.Apellidos) AS 'Nombre',[Forma de Pago].Nombre AS 'FormaP'," +
                " [Tipo de Préstamo].[Tipo de Préstamo]As 'TipoP', [Préstamos].[Tasa de Interés] As Interés, Préstamos.[Monto del Préstamo] AS Monto, \n" +
                "Transacciones.[Fecha de Transacción] AS FechaT, Préstamos.Cuotas AS NCuotas, Préstamos.[Cuota Mensual] AS PCuotas, Préstamos.Estado AS Estado \n" +
                "From Asociado inner join [Forma de Pago] on [Forma de Pago].[id Forma de Pago] = [id Forma de Pago] inner join Préstamos on \n" +
                "Asociado.[Código Asociado] = Préstamos.[Código Asociado] inner join [Tipo de Préstamo] on Préstamos.[id Tipo de Préstamo] \n" +
                "= [Tipo de Préstamo].[id Tipo de Préstamo] inner join Transacciones on Préstamos.[FK Transacción] = Transacciones.[id Transacción] \n" +
                "inner join Persona p on p.[Código Persona]=Asociado.[FK Persona]" +
                "where Préstamos.[id Préstamos]= @ID_Préstamo \n" +
                "Commit Tran Cargar_P \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Cargar_P \n" +
                "End Catch ";
            //Modificado para que se vean también los no activos
            String procedimiento23 = "Create Procedure[Préstamo DVG] \n" +
                "As \n" +
                "Begin Tran Pres \n" +
                "Begin Try \n" +
                "Select Préstamos.[id Préstamos] as 'Código de Préstamo', (p.Nombres + ' ' + p.Apellidos) as 'Persona Asociada', p.DUI as 'Dui', [Tipo de Préstamo].[Tipo de Préstamo], Préstamos.Estado as 'Estado' \n" +
                "From Asociado inner join Préstamos on Asociado.[Código Asociado] = Préstamos.[Código Asociado] inner join [Tipo de Préstamo] \n" +
                "on Préstamos.[id Tipo de Préstamo] = [Tipo de Préstamo].[id Tipo de Préstamo] \n" +
                "inner join Persona p on p.[Código Persona]=Asociado.[FK Persona] \n" +
                "Commit Tran Pres \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Pres \n" +
                "End Catch";
            //Cambiado para que muestre los activos y no activos
            String procedimiento24 = "Create Procedure[Asociado DVG]" +
                "As \n" +
                "Begin Tran Aso \n" +
                "Begin Try \n" +
                "Select Asociado.[Código Asociado] as 'Código', (p.Nombres + ' ' + p.Apellidos) as 'Persona Asociada',p.DUI as 'Dui',[Tipo de Socio].[Nombre Tipo Socio] as 'Tipo Asociación', Asociado.Estado as 'Estado' \n" +
                "From Asociado inner join [Tipo de Socio] on [Tipo de Socio].[id Tipo de Socio]=Asociado.[FK Tipo Socio] \n" +
                "inner join Persona p on p.[Código Persona]=Asociado.[FK Persona] \n" +
                "Commit Tran Aso \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Aso \n" +
                "End Catch";
            String procedimiento25 = "Create Procedure [Cargar Tipo Préstamo] As Begin Tran Pre Begin Try \n" +
                "Select[Tipo de Préstamo].[Tipo de Préstamo] AS 'TipoP',[Tipo de Préstamo].[Tasa de Interés] AS 'Interés' from[Tipo de Préstamo] \n" +
                "Commit Tran Pre End Try Begin Catch Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Pre End Catch";
            String procedimiento26 = "Create Procedure [Cargar Tipo Socio] As Begin Tran Aso Begin Try \n" +
                "Select [Tipo de Socio].[Nombre Tipo Socio] AS 'TipoS',[Tipo de Socio].[id Tipo de Socio]as'ID' from [Tipo de Socio] \n" +
                "Commit Tran Aso End Try Begin Catch Print ERROR_MESSAGE(); Rollback Tran Aso End Catch";
            String procedimiento27 = "Create Procedure [Cargar Tipo Ahorro] As Begin Tran Aho Begin Try \n" +
                "Select [Tipo de Ahorro].Nombre AS 'TipoA',[Tipo de Ahorro].[Tasa de Interés] AS 'Interés' from [Tipo de Ahorro] \n" +
                "Commit Tran Aho End Try Begin Catch Print ERROR_MESSAGE(); Rollback Tran Aho End Catch";
            String procedimiento28 = "create Procedure[dbo].[Recuperar Contraseña] \n" +
                "@Correo varchar(50), \n" +
                "@Contraseña varchar(MAX) \n" +
                "As \n" +
                "Begin Tran Mod_Tel \n" +
                "Begin Try \n" +
                "Begin Update Usuarios set Contraseña = @Contraseña where @Correo =[Correo] \n" +
                "Commit \n" +
                "Tran Mod_Tel End;" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Mod_Tel \n" +
                "End Catch ";
            String procedimiento29 =
                "create Procedure[ModificarDatos] \n" +
                "@Id varchar(5), \n" +
                "@Correo varchar(50), \n" +
                "@Nombre varchar(50), \n" +
                "@Apellido varchar(50), \n" +
                "@Contraseña varchar(MAX) \n" +
                "As \n" +
                "Begin Try \n" +
                "if exists(select Contraseña from Usuarios where Usuarios.[Id Usuario] = @Id) \n" +
                "Begin \n" +
                "update Usuarios set Correo = @Correo, Nombres = @Nombre, Apellidos = @Apellido, Contraseña = @Contraseña where[Id Usuario] = @Id; \n" +
                "select * from Usuarios where [Id Usuario] = @Id \n" +
                "End \n" +
                "Else \n" +
                "Begin \n" +
                "Print 'Ocurrió un problema al actualizar los datos.' \n" +
                "End \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Catch: \n" +
                "Begin \n" +
                "print ERROR_MESSAGE(); \n" +
                "End \n" +
                "End Catch";
            String procedimiento30 =
                "create Procedure[dbo].[InicioDeSesión] \n" +
                "@Correo varchar(50) \n" +
                "As \n" +
                "Begin Try \n" +
                "if exists(select * from Usuarios where Usuarios.Correo = @Correo) \n" +
                "Begin \n" +
                "select * from Usuarios where Correo = @Correo; \n" +
                "End \n" +
                "Else \n" +
                "Begin \n" +
                "Print 'No se encontró ningún usuario con esta dirección de e-mail.'; \n" +
                "End \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "End Catch";
            String procedimiento31 =
                "create Procedure[dbo].[Nuevo Usuario] \n" +
                "@Correo varchar(50), \n" +
                "@Nombre varchar(50), \n" +
                "@Apellido varchar(50), \n" +
                "@Contraseña varchar(MAX), \n" +
                "@Tipo_Usuario varchar(5) \n" +
                "As \n" +
                "Begin Try \n" +
                "if not exists(select * from Usuarios where Usuarios.Correo = @Correo) \n" +
                "Begin \n" +
                "insert into Usuarios values(@Nombre, @Apellido, @Contraseña, @Correo, @Tipo_Usuario); \n" +
                "End \n" +
                "Else \n" +
                "Begin \n" +
                "print 'Ya hay una cuenta creada con esta dirección de e-mail.'; \n" +
                "End \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Catch:  \n" +
                "Begin \n" +
                "print ERROR_MESSAGE(); \n" +
                "End \n" +
                "End Catch";
            String procedimiento32 =
                "Create procedure [Cargar Ocupaciones] \n" +
                "As \n" +
                "Begin \n" +
                "Select [Nombre de la Empresa] As 'Trabajo',[Id Ocupación] as 'ID' from Ocupación \n" +
                "End";
            //Aqui se cambió para tener la referencia "TipoT"
            String procedimiento33 =
                "Create procedure [Cargar Tipo Teléfono] \n" +
                "As \n" +
                "Begin \n" +
                "Select [Tipos de Teléfonos].[Tipo de Teléfono] as 'TipoT',[Tipos de Teléfonos].[id Tipo de Teléfono] 'Cod' From [Tipos de Teléfonos] \n" +
                "End";
            //Faltaba este procedimiento
            String procedimiento34 = "Create Procedure[Cargar Ahorros] \n" +
                "@Código_Ahorro varchar(8) \n" +
               "As \n" +
               "Begin Tran Cargar_Ahorros \n" +
               "Begin Try \n" +
               "Select Asociado.[Código Asociado] as 'Código_A', (p.Nombres+' ' + p.Apellidos) as 'Nombre', Ahorro.Estado as 'Est',  [Tipo de Ahorro].Nombre as 'TipoA', [Tipo de Ahorro].[Tasa de Interés] as 'Interés' from Ahorro inner join Asociado \n" +
               "on Ahorro.[FK Código de Asociado] = Asociado.[Código Asociado] inner join [Tipo de Ahorro] on Ahorro.[FK Tipo Ahorro]=[Tipo de Ahorro].[id Tipo Ahorro] \n" +
               "inner join Persona p on p.[Código Persona]=Asociado.[FK Persona] where Ahorro.[id Ahorro] = @Código_Ahorro \n" +
               "Commit Tran Cargar_Ahorros \n" +
               "End Try \n" +
               "Begin Catch \n" +
               "Print ERROR_MESSAGE(); \n" +
               "Rollback Tran Cargar_Ahorros \n" +
               "End Catch";
#warning Verificar cantidad de préstamos que se pueden otorgar
            //Faltaba este procedimiento
            String procedimiento35 = "Create Procedure[Nuevo Préstamo] \n" +
                "@FK_Tipo_Préstamo varchar(20), \n" +
                "@FK_Asociado varchar(6), \n" +
                "@Forma_Pago varchar(5), \n" +
                "@NCuotas int, \n" +
                "@Monto money, \n" +
                "@Cuota money, \n" +
                "@Usuario varchar(5) \n" +
                "As Begin Tran Préstamo Begin try \n" +
                "Declare @ID_Tipo_Préstamo as varchar(5) \n" +
                "Declare @Contar_Emergencia as int \n" +
                "Declare @Contar_Normal as int \n" +
                "Declare @Id_Transacción as int \n" +
                "Declare @Tasa_Interés as int \n" +
                "set @ID_Tipo_Préstamo = (Select [id Tipo de Préstamo] From [Tipo de Préstamo] where [Tipo de Préstamo] = @FK_Tipo_Préstamo) \n" +
                "set @Contar_Emergencia = (Select COUNT(Préstamos.[id Préstamos]) from Préstamos inner join [Tipo de Préstamo] on [Tipo de Préstamo].[id Tipo de Préstamo] = Préstamos.[id Tipo de Préstamo] where Préstamos.[Código Asociado] = @FK_Asociado AND Estado = 'ACTIVO' AND [Tipo de Préstamo].[Tipo de Préstamo] = 'Emergencia') \n" +
                "set @Contar_Normal = (Select COUNT(Préstamos.[id Préstamos]) from Préstamos inner join [Tipo de Préstamo] on [Tipo de Préstamo].[id Tipo de Préstamo] = Préstamos.[id Tipo de Préstamo] where Préstamos.[Código Asociado] = @FK_Asociado AND Estado = 'ACTIVO' AND [Tipo de Préstamo].[Tipo de Préstamo] <> 'Emergencia') \n" +
                "if (Select Estado from Asociado where[Código Asociado] = @FK_Asociado) = 'ACTIVO' \n" +
                "Begin " +
                "IF (@FK_Tipo_Préstamo <> 'Emergencia' AND @Contar_Normal < 2 ) OR (@FK_Tipo_Préstamo = 'Emergencia' AND @Contar_Emergencia < 1) \n" +
                "	BEGIN \n" +
                "	Insert into Transacciones values(@Usuario, 'TT003', GETDATE()) \n" +
                "	Set @Id_Transacción = (Select MAX([id Transacción]) from Transacciones) \n" +
                "   Set @Tasa_Interés = (Select[Tipo de Préstamo].[Tasa de Interés] from[Tipo de Préstamo]  \n" +
                "                           where [Tipo de Préstamo].[id Tipo de Préstamo] = @ID_Tipo_Préstamo) \n" +
                "	Insert into Préstamos values(@FK_Asociado, @Forma_Pago,@ID_Tipo_Préstamo,@Tasa_Interés,GETDATE(),@NCuotas,@Monto,@Cuota,@Id_Transacción,'ACTIVO') \n" +
                "	Commit tran Préstamo \n" +
                "END \n" +
                "ELSE \n" +
                "BEGIN \n" +
                "	Print 'El usuario ya ha superado máximo de préstamos permitidos para este tipo de préstamo' \n" +
                "   Commit tran Préstamo return 0 \n" +
                "END \n" +
                "end \n" +
                "else begin \n" +
                "   Print 'La persona ya no está asociada.' \n" +
                "   Commit tran Préstamo return 0 \n" +
                "end \n" +
                "End try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback tran Préstamo \n" +
                "return 0 \n" +
                "End Catch";
            //Añadido para el combobox
            String procedimiento36 = "Create Procedure [dbo].[Cargar Tipo Pagos] \n" +
                "As Begin Tran Tipo_Pagos \n" +
                "Begin Try \n" +
                "Select[Forma de Pago].Nombre AS 'FormaP', [Forma de Pago].[id Forma de Pago] as 'Id' from[Forma de Pago] \n" +
                "Commit Tran Tipo_pagos End Try Begin Catch Print ERROR_MESSAGE(); Rollback Tran Pre End Catch";
            //Añadido para cerrar ahorro
            String procedimiento37 = "Create Procedure[dbo].[Cerrar Ahorro] \n" +
                "@Id_Ahorro varchar(8) \n" +
                "As Begin Tran Cuenta_Cerrada \n" +
                "Begin Try \n" +
                "If(Select Estado from Ahorro where [id Ahorro] = @Id_Ahorro) = 'ACTIVO' \n" +
                "Begin \n" +
                "    Update Ahorro Set Estado = 'INACTIVO' where[id Ahorro] = @Id_Ahorro \n" +
                "    Print 'La cuenta ha sido cerrada' \n" +
                "    Commit Tran Cuenta_Cerrada \n" +
                "End \n" +
                "Else \n" +
                "Begin \n" +
                "    Print 'La cuenta ya se encuentra cerrada' \n" +
                "    Commit Tran Cuenta_Cerrada \n" +
                "End \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Cuenta_Cerrada \n" +
                "End Catch ";
            //Añadido para desasociar
            String procedimiento38 = "Create Procedure[dbo].[Desasociar] \n" +
                "@Código_Asociado varchar(6) \n" +
                "As Begin Tran Desasociado \n" +
                "Begin Try \n" +
                "If(Select Estado from Asociado where[Código Asociado] = @Código_Asociado) = 'ACTIVO' \n" +
                "Begin \n" +
                "Declare @Ahorro int, @Préstamo_E int , @Préstamo_N int \n" +
                "Set @Ahorro = (Select COUNT([id Ahorro]) from Ahorro where [FK Código de Asociado] = @Código_Asociado AND Estado = 'ACTIVO')  \n" +
                "If(@Ahorro = 0) \n" +
                "Begin \n" +
                "Set @Préstamo_E = (Select COUNT(Préstamos.[id Préstamos]) from Préstamos inner join [Tipo de Préstamo] on [Tipo de Préstamo].[id Tipo de Préstamo] = Préstamos.[id Tipo de Préstamo] where Préstamos.[Código Asociado] = @Código_Asociado AND Estado = 'ACTIVO' AND[Tipo de Préstamo].[Tipo de Préstamo] = 'Emergencia') \n" +
                "Set @Préstamo_N = (Select COUNT(Préstamos.[id Préstamos]) from Préstamos inner join [Tipo de Préstamo] on [Tipo de Préstamo].[id Tipo de Préstamo] = Préstamos.[id Tipo de Préstamo] where Préstamos.[Código Asociado] = @Código_Asociado AND Estado = 'ACTIVO' AND[Tipo de Préstamo].[Tipo de Préstamo] <> 'Emergencia') \n" +
                "if (@Préstamo_E = 0) AND(@Préstamo_N = 0) \n" +
                "Begin \n" +
                "Update Asociado Set Estado = 'INACTIVO', [Fecha de Desasociación] = GetDate() \n" +
                "where[Código Asociado] = @Código_Asociado \n" +
                "Commit Tran Desasociado \n" +
                "End \n" +
                "else \n" +
                "Begin \n" +
                "Print 'La persona asociada tiene préstamos sin cancelar' \n" +
                "Commit Tran Desasociado \n" +
                "End \n" +
                "End \n" +
                "Else \n" +
                "Begin \n" +
                "Print 'La persona asociada tiene cuentas de ahorro activas' \n" +
                "Commit Tran Desasociado \n" +
                "End \n" +
                "End \n" +
                "Else \n" +
                "Begin \n" +
                "Print 'La persona ya se encuentra desasociada' \n" +
                "Commit Tran Desasociado \n" +
                "End \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Desasociado \n" +
                "return 0 \n" +
                "End Catch ";
            //Añadido Actualizar Asociado
            String procedimiento039 = "Create procedure[dbo].[Actualizar Persona] \n" +
                "@Codigo_Persona varchar(8), \n" +
                "@Nombres varchar(50), \n" +
                "@Apellidos varchar(50), \n" +
                "@DUI varchar(10), \n" +
                "@NIT varchar(17), \n" +
                "@Residencia varchar(100), \n" +
                "@Fecha_Nacimiento datetime \n" +
                "As \n" +
                "Begin transaction \n" +
                "Update Persona set \n" +
                        "Nombres = @Nombres, \n" +
                        "Apellidos = @Apellidos, \n" +
                        "DUI = @DUI, \n" +
                        "NIT = @NIT, \n" +
                        "Dirección = @Residencia, \n" +
                        "[Fecha de Nacimiento] = @Fecha_Nacimiento \n" +
                        "where[Código Persona] = @Codigo_Persona \n" +
              "If @@error = 0 \n" +
              "Begin \n" +
                "COMMIT TRANSACTION \n" +
              "End \n" +
              "Else \n" +
              "Begin \n" +
                "ROLLBACK TRANSACTION \n" +
                "Print 'Error en modificar datos de la persona ' + ERROR_MESSAGE(); \n" +
              "End ";
            String procedimiento39 = "Create procedure[dbo].[Actualizar Asociado] \n" +
                "@Codigo_Asociado varchar(6), \n" +
                "@FK_Tipo_Socio varchar(5), \n" +
                "@FK_Ocupación varchar(5) \n" +
                "As \n" +
                "Begin transaction \n" +
                "Update Asociado set[FK Tipo Socio] = @FK_Tipo_Socio, \n" +
                        "[FK Ocupación] = @FK_Ocupación where[Código Asociado] = @Codigo_Asociado \n" +
              "If @@error = 0 \n" +
              "Begin \n" +
                "COMMIT TRANSACTION \n" +
              "End \n" +
              "Else \n" +
              "Begin \n" +
                "ROLLBACK TRANSACTION \n" +
                "Print 'Error en modificar datos de la persona asociada ' + ERROR_MESSAGE(); \n" +
              "End ";
            String procedimiento40 = "create procedure[Cargar Imagenes] \n" +
                "As Begin \n" +
                "select Imagen, [Tipo imagen], Descripcion from Imagenes where Estado = 'Activa' \n" +
                "End; ";
            String procedimiento41 = "create procedure[Nueva Imagen] \n" +
                "@Imagen image, \n" +
                "@Tipo_imagen int, \n" +
                "@Descripcion varchar(MAX)" +
                "As Begin \n" +
                "If exists(select Cod_Imagen from Imagenes where [Tipo imagen] = @Tipo_imagen) \n" +
                "Begin \n" +
                "Update Imagenes set Estado = 'Inactiva' where Cod_Imagen = (select Cod_Imagen from Imagenes where [Tipo imagen] = @Tipo_imagen); \n" +
                "Insert into Imagenes values(@Imagen, @Tipo_imagen, 'Activa', @Descripcion); \n" +
                "End \n" +
                "Else \n" +
                "Begin \n" +
                "Insert into Imagenes values(@Imagen, @Tipo_imagen, 'Activa', @Descripcion); \n" +
                "End \n" +
                "End ";
            String procedimiento42 = "create procedure[Elimina Imagen] \n" +
                "@Cod_Imagen int \n" +
                "As \n" +
                "Begin \n" +
                "delete from Imagenes where Cod_Imagen = @Cod_Imagen \n" +
                "End; ";
            //Procedimiento para retirar las aportaciones al desasociar.
            String procedimiento43 = "create procedure [dbo].[Retirar Aportaciones] \n" +
                "@Código_Asociado varchar(6), \n"+
                "@No_Cheque varchar(8), \n"+
                "@Id_Usuario varchar(5) \n"+
                "As Begin Tran Retiro \n"+
                "Begin Try \n"+
                "declare @total_Retiro money \n"+
                "if (Select SUM(Aportación) from Aportaciones where [FK Asociado] = @Código_Asociado) > 0 \n"+
                "Begin \n"+
                "set @total_Retiro = (Select SUM(Aportación) from Aportaciones where [FK Asociado] = @Código_Asociado) \n"+
			    "Declare @Id_Transacción int \n"+
                "Insert into Transacciones values(@Id_Usuario,'TT007',GETDATE()) "+
			    "set @Id_Transacción = (Select MAX([id Transacción]) From Transacciones) "+
			    "Insert into[Retiros Aportaciones] values(@total_Retiro, @No_Cheque, @Código_Asociado, @Id_Transacción) \n"+
                "Commit Tran Retiro \n"+
                "End \n"+
                "Else Begin \n"+
                "Print 'La persona se encuentra desasociada.' \n"+
                "Commit Tran Retiro \n"+
                "End \n"+
                "End Try \n"+
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Retiro \n" +
                "End Catch ";
            //Procedimiento para cerrar un préstamo
            String procedimiento44 = "Create procedure [dbo].[Cerrar Préstamo] \n" +
                "@Id_Préstamo varchar(9), \n" +
                "@Id_Usuario varchar(5) \n" +
                "As Begin Tran Cancelar \n" +
                "Begin Try \n" +
                "Declare @Id_Transacción int \n" +
                "Update Préstamos set Estado = 'CANCELADO' From Préstamos where[id Préstamos] = @Id_Préstamo \n" +
                "Insert into Transacciones values(@Id_Usuario, 'TT008', GETDATE()) \n" +
                "Commit Tran Cancelar \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Cancelar  \n" +
                "End catch ";
            //Procedimiento para Constancia de Pago
            String procedimiento45 = "Create procedure[dbo].[Constancia Pago] \n" +
                "@Id_Préstamo varchar(9) \n" +
                "As begin tran Constancia \n" +
                "Begin try \n" +
                "declare @id_Pago varchar(9) \n" +
                "Set @id_Pago = (Select Max([id Pago]) From Pago where Pago.[id Préstamo] = @Id_Préstamo) \n" +
                "Select Pago.[id Pago] as 'Pid_Pago', Préstamos.[id Préstamos] as 'PPréstamo', (p.Nombres +' '+ p.Apellidos) as 'PNombre', \n" +
                "Préstamos.[Cuota Mensual] as 'Monto mínimo',Pago.Saldo as 'Psaldo',  Pago.Pago as 'PPago', Pago.Mora as 'Pmora', \n" +
                "Transacciones.[Fecha de Transacción] as 'PFecha' From Asociado inner join Préstamos on Asociado.[Código Asociado] = Préstamos.[Código Asociado] \n" +
                "inner join Pago on Préstamos.[id Préstamos] = Pago.[id Préstamo] inner join Transacciones on Pago.[FK Transacción] = Transacciones.[id Transacción] \n" +
                "inner join Persona p on p.[Código Persona]=Asociado.[FK Persona] \n" +
                "where Pago.[id Pago] = @id_Pago and Préstamos.[id Préstamos]= @Id_Préstamo \n" +
                "Commit Tran Constancia \n" +
                "End try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback tran Constancia \n" +
                "End Catch ";
            //Procedimiento para Informe de Préstamo
            String procedimiento46 = "Create Procedure[dbo].[Informe Préstamo] \n" +
                "@Codigo varchar(6) \n" +
                "As Begin \n" +
                "Tran Informe \n" +
                "Begin Try \n" +
                "Declare @Id_Préstamo varchar(9) \n" +
                "Set @Id_Préstamo = (Select Max(Préstamos.[id Préstamos]) From Préstamos inner join Asociado on Préstamos.[Código Asociado] = Asociado.[Código Asociado] \n" +
                "where Asociado.[Código Asociado] = @Codigo) \n" +
                "Select Asociado.[Código Asociado] AS 'Código_A', p.Nombres AS 'Nombre', \n" +
                "p.Apellidos as 'Apellido', Préstamos.[id Préstamos] as 'Préstamo', \n" +
                "p.Dirección as 'Dir', Ocupación.[Nombre de la Empresa] as 'Trabajo',[Forma de Pago].Nombre AS 'FormaP', [Tipo de Préstamo].[Tipo de Préstamo] As 'TipoP',  \n" +
                "p.DUI as 'PDUI',[Préstamos].[Tasa de Interés] As 'Interés',  \n" +
                "Préstamos.[Monto del Préstamo] AS 'Monto', Transacciones.[Fecha de Transacción] AS 'FechaT', Préstamos.Cuotas AS 'NCuotas', \n" +
                "Préstamos.[Cuota Mensual] AS 'PCuotas', Préstamos.Estado AS 'Estado' From Ocupación inner join Asociado on \n" +
                "Ocupación.[Id Ocupación] = Asociado.[FK Ocupación] inner join Préstamos on Asociado.[Código Asociado] = Préstamos.[Código Asociado] \n" +
                "inner join [Tipo de Préstamo] on Préstamos.[id Tipo de Préstamo] = [Tipo de Préstamo].[id Tipo de Préstamo] \n" +
                "inner join [Forma de Pago] on Préstamos.[id Forma de Pago] = [Forma de Pago].[id Forma de Pago] \n" +
                "inner join Transacciones on Préstamos.[FK Transacción] = Transacciones.[id Transacción] \n" +
                "inner join Persona p on p.[Código Persona]=Asociado.[FK Persona] where Préstamos.[id Préstamos]= @Id_Préstamo \n" +
                "Commit Tran Informe End Try Begin Catch Print ERROR_MESSAGE(); Rollback Tran Informe End Catch ";
            //Añadido para cargar datos cooperativa
            String procedimiento47 = "Create Procedure [dbo].[Conseguir Transacciones]  \n" +
                "@Fecha_Inicial datetime, \n" +
                "@Fecha_Final datetime, \n" +
                "@Tipo_Transaccion varchar(30) \n" +
                "As \n" +
                "Begin Tran Coop \n" +
                "Begin Try \n" +
                "If(@Tipo_Transaccion = 'Todas las transacciones') \n" +
                "Begin \n" +
                "Set @Tipo_Transaccion = '' \n" +
                "End \n" +
                "Select t.[Fecha de Transacción] AS 'Fecha', tt.[Tipo de Transacción] AS 'Transacción', \n" +
                "	(tu.Nombres + ' ' + tu.Apellidos) AS 'Usuario' from Transacciones t \n" +
                "   inner join [Tipo de Transacción] as tt on tt.[id Tipo de Transacción] = t.[FK Tipo de Transacción] \n" +
                "   inner join [Usuarios] as tu on tu.[Id Usuario] = t.[ID Usuario Transacción] \n" +
                "   where tt.[Tipo de Transacción] Like('%' + @Tipo_Transaccion + '%') AND \n" +
                "   t.[Fecha de Transacción] <= @Fecha_Final AND \n" +
                "   t.[Fecha de Transacción] >= @Fecha_Inicial order by t.[Fecha de Transacción] \n" +
                "Commit tran Coop \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Coop \n" +
                "End Catch";
#warning Editar, para añadir las aportaciones retiradas
            String procedimiento48 = "Create Procedure [dbo].[Conseguir Datos Cooperativa] \n" +
                "@Fecha_Inicial datetime, \n" +
                "@Fecha_Final datetime \n" +
                "As \n" +
                "Begin Tran Coop \n" +
                "Begin Try \n" +
                "Declare @Abonos smallmoney = 0, @Retiros smallmoney = 0, @Aportaciones smallmoney = 0, \n" +
                "    @RetiroAportación smallmoney = 0, @Préstamos_Otorgados smallmoney = 0, \n" +
                "    @Pago_Capital smallmoney = 0, @Intereses_Pagados smallmoney = 0, @Mora_Pagada smallmoney = 0 , @SumaP smallmoney, @SumaN smallmoney \n" +
                "Set @Abonos = (Select SUM(X.Abono) From Abono X \n" +
                "    inner join Transacciones t on t.[id Transacción] = X.[FK Transacción] \n" +
                "    where t.[Fecha de Transacción]<=@Fecha_Final AND \n" +
                "    t.[Fecha de Transacción]>=@Fecha_Inicial) \n" +
                "Set @Retiros = (Select SUM(X.Retiro) From Retiros X \n" +
                "    inner join Transacciones t on t.[id Transacción]= X.[FK Transacción] \n" +
                "    where t.[Fecha de Transacción]<=@Fecha_Final AND \n" +
                "    t.[Fecha de Transacción]>=@Fecha_Inicial) \n" +
                "Set @Aportaciones = (Select SUM(X.Aportación) From Aportaciones X \n" +
                "    inner join Transacciones t on t.[id Transacción]= X.[FK Transacción] \n" +
                "    where t.[Fecha de Transacción]<=@Fecha_Final AND \n" +
                "    t.[Fecha de Transacción]>=@Fecha_Inicial) \n" +
                "Set @Préstamos_Otorgados = (Select SUM(X.[Monto del Préstamo]) From Préstamos X \n" +
                "    inner join Transacciones t on t.[id Transacción]= X.[FK Transacción] \n" +
                "    where t.[Fecha de Transacción]<=@Fecha_Final AND \n" +
                "    t.[Fecha de Transacción]>=@Fecha_Inicial) \n" +
                "Set @Pago_Capital = (Select SUM(X.Capital) From Pago X \n" +
                "    inner join Transacciones t on t.[id Transacción]= X.[FK Transacción] \n" +
                "    where t.[Fecha de Transacción]<=@Fecha_Final AND \n" +
                "    t.[Fecha de Transacción]>=@Fecha_Inicial) \n" +
                "Set @Intereses_Pagados = (Select SUM(X.Intereses) From Pago X \n" +
                "    inner join Transacciones t on t.[id Transacción]= X.[FK Transacción] \n" +
                "    where t.[Fecha de Transacción]<=@Fecha_Final AND \n" +
                "    t.[Fecha de Transacción]>=@Fecha_Inicial) \n" +
                "Set @Mora_Pagada = (Select SUM(X.Mora) From Pago X \n" +
                "    inner join Transacciones t on t.[id Transacción]= X.[FK Transacción] \n" +
                "    where t.[Fecha de Transacción]<=@Fecha_Final AND \n" +
                "    t.[Fecha de Transacción]>=@Fecha_Inicial) \n" +
                "Set @SumaP = @Abonos + @Aportaciones + @Pago_Capital + @Intereses_Pagados + @Mora_Pagada \n" +
                "Set @SumaN = @Retiros + @RetiroAportación + @Préstamos_Otorgados \n" +
                "Select @Abonos as 'Abonos', @Retiros as 'Retiros', @Aportaciones as 'Aportaciones', \n" +
                "    @RetiroAportación as 'RetiroAportación', @Préstamos_Otorgados as 'Préstamos_Otorgados', @Pago_Capital as 'Pago_Capital', \n" +
                "    @Intereses_Pagados as 'Intereses_Pagados', @Mora_Pagada as 'Mora_Pagada' , @SumaP as 'TotalP', @SumaN as 'TotalN' \n" +
                "Commit tran Coop \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "    Print ERROR_MESSAGE(); \n" +
                "    Rollback Tran Coop \n" +
                "End Catch";
            String procedimiento49 = "CREATE Procedure [dbo].[Conseguir Imágenes]  \n" +
                "@Persona_Asociada varchar(8) As \n" +
                "Begin Tran Img \n" +
                "Begin Try \n" +
                "Select i.Imagen as 'img', ti.Nombre as 'tipo', i.[Fecha de Subida] as 'fecha', i.Comentarios as 'comment', i.[id Imagen] as 'id' from Imagen i  \n" +
                "inner join [Tipos de Imágenes] ti on ti.[id Tipo Imagen]=i.[Tipo Imagen] \n" +
                "where [Persona Asociada] = @Persona_Asociada \n" +
                "Commit tran Img \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Img \n" +
                "End Catch";
            String procedimiento50 = "CREATE Procedure [dbo].[Insertar Imagen]  \n" +
                "@Persona_Asociada varchar(8), \n" +
                "@Imagen Image, \n" +
                "@TipoImagen varchar(5), \n" +
                "@Comentarios varchar(120) \n" +
                "As \n" +
                "Begin Tran Img \n" +
                "Begin Try Declare @Contar_Tipo int \n" +
                "Set @Contar_Tipo = (Select Count([id Imagen]) from Imagen where [Tipo Imagen]=@TipoImagen and [Persona Asociada]=@Persona_Asociada ) \n" +
                "IF (@Contar_Tipo < 2) Begin \n" +
                "if (@Comentarios <> '') \n" +
                "Begin \n" +
                "Insert Imagen values(@Imagen, GetDate(), @Persona_Asociada, @TipoImagen, @Comentarios) \n" +
                "End \n" +
                "Else \n" +
                "Begin \n" +
                "Insert Imagen(Imagen,[Fecha de Subida],[Persona Asociada],[Tipo Imagen]) \n" +
                "values(@Imagen, GetDate(), @Persona_Asociada, @TipoImagen) \n" +
                "End END \n" +
                "ELSE BEGIN \n" +
                "Print 'Ya se encuentran almacenadas dos imágenes de este tipo. Elimine otra imagen, modifíquela o cambie de tipo de imagen para poder continuar' \n" +
                "END Commit tran Img \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran Img \n" +
                "End Catch";
            String procedimiento51 = "Create Procedure [dbo].[Actualizar Imagen]  \n" +
                "@Persona_Asociada varchar(8), \n" +
                "@Id_Imagen varchar(7), \n" +
                "@Imagen Image, \n" +
                "@TipoImagen varchar(5), \n" +
                "@Comentarios varchar(120) \n" +
                "As \n" +
                "Begin Tran Img \n" +
                "Begin Try \n" +
                "Declare @Contar_Tipo int, @Tipo_Original varchar(5) \n" +
                "Set @Contar_Tipo = (Select Count([id Imagen]) from Imagen where [Tipo Imagen] = @TipoImagen and[Persona Asociada] = @Persona_Asociada )  \n" +
                "Set @Tipo_Original = (Select[Tipo Imagen] from Imagen where [id Imagen] = @Id_Imagen) \n" +
                "IF(@Contar_Tipo < 2 or @Tipo_Original = @TipoImagen) \n" +
                "Begin \n" +
                "    if (@Comentarios <> '') \n" +
                "    Begin \n" +
                "    Update Imagen set Imagen=@Imagen, [Fecha de Subida]=GETDATE(),[Tipo Imagen]=@TipoImagen, Comentarios=@Comentarios  where [id Imagen]=@Id_Imagen \n" +
                "    End \n" +
                "    Else \n" +
                "    Begin \n" +
                "    Update Imagen set Imagen=@Imagen, [Fecha de Subida]=GETDATE(), [Persona Asociada]=@Persona_Asociada, [Tipo Imagen]=@TipoImagen, Comentarios=null where [id Imagen]=@Id_Imagen \n" +
                "    End \n" +
                "END \n" +
                "ELSE \n" +
                "BEGIN \n" +
                "Print 'Ya se encuentran almacenadas dos imágenes de este tipo. Elimine otra imagen o cambie de tipo de imagen para poder continuar' \n" +
                "END \n" +
                "Commit tran Img \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "    Print ERROR_MESSAGE(); \n" +
                "    Rollback Tran Img \n" +
                "End Catch ";
            String procedimiento52 = "Create Procedure [dbo].[Eliminar Imagen] \n" +
                "@Id_Imagen varchar(7) \n" +
                "As \n" +
                "Begin Tran Img \n" +
                "Begin Try \n" +
                "    Delete Imagen where [id Imagen] = @Id_Imagen \n" +
                "    Commit tran Img \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "    Print ERROR_MESSAGE(); \n" +
                "    Rollback Tran Img \n" +
                "End Catch ";
            String procedimiento53 = "Create Procedure [dbo].[Cargar Tipo Imagen] \n" +
                "As \n" +
                "Begin Tran img \n" +
                "Begin Try \n" +
                "Select Nombre AS 'TipoI', [id Tipo Imagen] as 'idI' from[Tipos de Imágenes] \n" +
                "Commit Tran img \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran img \n" +
                "End Catch ";
            String procedimiento54 = "Create Procedure[dbo].[Constancia Retiro] \n" +
                "@ID_Ahorro varchar(8) \n" +
                "As Begin Tran C_Abono \n" +
                "Begin Try \n" +
                "declare @id_Retiro varchar(9) \n" +
                "Set @id_Retiro = (Select Max([id Retiro]) From Retiros where Retiros.[FK Ahorro] = @ID_Ahorro) \n" +
                "Select Retiros.Retiro as 'CantidadRetiro', Retiros.[id Retiro] as 'idRetiro', (p.Nombres + ' ' + p.Apellidos) as 'Nombre', \n" +
                "[Tipo de Ahorro].Nombre as 'Tipo',[Tipo de Ahorro].[Tasa de Interés] as 'Interés',Asociado.[Código Asociado] as 'Código', \n" +
                "Retiros.[Número de Cheque] as 'Cheque', Ahorro.Estado as 'Estado' \n" +
                "from Asociado inner join Ahorro on Asociado.[Código Asociado]= Ahorro.[FK Código de Asociado] inner join Retiros on Retiros.[FK Ahorro] = Ahorro.[id Ahorro] \n" +
                "inner join [Tipo de Ahorro] on[Tipo de Ahorro].[id Tipo Ahorro] = Ahorro.[FK Tipo Ahorro] \n" +
                "inner join Persona p on p.[Código Persona]=Asociado.[FK Persona] \n" +
                "where @ID_Ahorro = Ahorro.[id Ahorro] and Retiros.[id Retiro] = @id_Retiro \n" +
                "Commit Tran C_Abono \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran C_Abono \n" +
                "End Catch ";
            String procedimiento55 = "Create Procedure[dbo].[Constancia Abono] \n" +
                "@ID_Ahorro varchar(8) \n" +
                "As Begin Tran C_Abono \n" +
                "Begin Try \n" +
                "if ((Select Estado From Ahorro where Ahorro.[id Ahorro] = @ID_Ahorro) <> 'INACTIVO') \n" +
                "Begin \n" +
                "declare @id_Abono varchar(9) \n" +
                "Set @id_Abono = (Select Max([id Abono]) From Abono where Abono.[FK Ahorro] = @ID_Ahorro) \n" +
                "Select Abono.[id Abono] as 'Pid_Abono', Abono.Abono as 'Abono', (p.Nombres + ' ' + p.Apellidos) as 'PNombre', \n" +
                "[Tipo de Ahorro].Nombre as 'PTipo',[Tipo de Ahorro].[Tasa de Interés] as 'PInterés'from Asociado inner join Ahorro \n" +
                "on Asociado.[Código Asociado]= Ahorro.[FK Código de Asociado] inner join Abono on Abono.[FK Ahorro] = Ahorro.[id Ahorro] \n" +
                "inner join [Tipo de Ahorro] on[Tipo de Ahorro].[id Tipo Ahorro] = Ahorro.[FK Tipo Ahorro] \n" +
                "inner join Persona p on p.[Código Persona]=Asociado.[FK Persona] \n" +
                "where @ID_Ahorro = Ahorro.[id Ahorro] \n" +
                "and Abono.[id Abono] = @id_Abono \n" +
                "Commit Tran C_Abono \n" +
                "end \n" +
                "Else begin \n" +
                "Commit Tran C_Abono \n" +
                "End \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran C_Abono \n" +
                "End Catch ";
            String procedimiento56 = "Create Procedure[Constancia Nuevo Ahorro] \n" +
                "@ID_Asociado varchar(6) \n" +
                "As \n" +
                "Begin Tran N_Ahorro \n" +
                "Begin Try \n" +
                "declare @id_Ahorro varchar(8) \n" +
                "Set @id_Ahorro = (Select Max([FK Ahorro]) from Abono inner join Ahorro on Abono.[FK Ahorro] = Ahorro.[id Ahorro] where Ahorro.[FK Código de Asociado] = @ID_Asociado) \n" +
                "Select(p.Nombres + ' ' + p.Apellidos) as 'Nombre', \n" +
                "Ahorro.[id Ahorro] as 'id_Ahorro',[Tipo de Ahorro].Nombre as 'Tipo', \n" +
                "[Tipo de Ahorro].[Tasa de Interés] as 'Interés', \n" +
                "Abono.Abono as 'Abono', Abono.[id Abono] as 'Pid_Abono' From Asociado \n" +
                "inner join Ahorro on Asociado.[Código Asociado]=Ahorro.[FK Código de Asociado] \n" +
                "inner join Abono on Abono.[FK Ahorro]= Ahorro.[id Ahorro] \n" +
                "inner join [Tipo de Ahorro] on[Tipo de Ahorro].[id Tipo Ahorro] = Ahorro.[FK Tipo Ahorro] \n" +
                "inner join Persona p on p.[Código Persona]=Asociado.[FK Persona] \n" +
                "where Ahorro.[FK Código de Asociado] = @ID_Asociado and Ahorro.[id Ahorro] = @id_Ahorro \n" +
                "Commit Tran N_Ahorro \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print ERROR_MESSAGE(); \n" +
                "Rollback Tran N_Ahorro \n" +
                "End Catch ";
            //Procedimiento Insertar Beneficiario
            String procedimiento57 = "Create procedure [dbo].[Insertar Beneficiario] \n" +
                "@Codigo_Asociado varchar(6), \n" +
                "@Nombres varchar(80), \n" +
                "@Apellidos varchar(80), \n" +
                "@DUI varchar(10),  \n" +
                "@NIT varchar(17), \n" +
                "@Residencia varchar(100), \n" +
                "@Fecha_Nacimiento datetime \n" +
                "As Begin Tran Beneficiario \n" +
                "Begin try \n" +
                "   Declare @Codigo_Persona varchar(8) \n" +
                "   Declare @No_Persona int \n" +
                "   Set @No_Persona = (Select COUNT(NIT) From Persona where NIT = @NIT) \n" +
                "   if @No_Persona = 0 \n" +
                "   Begin \n" +
                "       Insert into Persona values(@Nombres, @Apellidos, @DUI, @NIT, @Residencia, @Fecha_Nacimiento) \n" +
                "       Set @Codigo_Persona = (Select Max([Código Persona]) from Persona where [DUI] = @DUI) \n" +
                "       Insert into Beneficiario values(@Codigo_Persona, @Codigo_Asociado) \n" +
                "   End \n" +
                "   Else begin \n" +
                "       Set @Codigo_Persona = (Select[Código Persona] from Persona where [NIT] = @NIT) \n" +
                "       Insert into Beneficiario values(@Codigo_Persona, @Codigo_Asociado) \n" +
                "   End \n" +
                "   Commit Tran Beneficiario \n" +
                "End try \n" +
                "Begin Catch \n" +
                "   print 'Ha ocurrido un error. ' + ERROR_MESSAGE() + '. Inténtelo más tarde'; \n" +
                "   Rollback Tran Beneficiario \n" +
                "End Catch ";
            String procedimiento58 = "Create procedure [dbo].[Personas DVG] \n" +
                "As \n" +
                "Begin Tran Personas_DVG \n" +
                "Begin Try \n" +
                "Select Persona.[Código Persona] as 'Código Persona', (Persona.Nombres +' ' + Persona.Apellidos) as 'Nombre', \n" +
                "Persona.DUI as 'DUI', Persona.NIT as 'NIT', Persona.Dirección as 'Dirección', Persona.[Fecha de Nacimiento] as 'Fecha' \n" +
                "from Persona full outer join Asociado on Persona.[Código Persona] = Asociado.[FK Persona] \n" +
                "full outer join Beneficiario on Persona.[Código Persona] = Beneficiario.[FK Persona] where Asociado.Estado<> 'ACTIVO' or Asociado.[Código Asociado] is null \n" +
                "Commit Tran Personas_DVG \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "Print 'Ha ocurrido un error: ' + ERROR_MESSAGE() + ' . Inténtelo más tarde.' \n" +
                "Rollback Tran Personas_DVG \n" +
                "End Catch ";
            String procedimiento59 = "Create procedure[dbo].[Constancia Retiro Aportaciones] \n" +
                "@Codigo varchar(6) \n" +
                "As begin tran Constancia_A \n" +
                "Begin try \n" +
                "   Select(Persona.Nombres + ' ' + Persona.Apellidos) as 'NombreP', Asociado.Estado as 'EstadoP'  from Persona inner join Asociado \n" +
                "           on Persona.[Código Persona] = Asociado.[FK Persona] where Asociado.[Código Asociado] = @Codigo \n" +
                "   Commit Tran Constancia_A \n" +
                "End try \n" +
                "Begin Catch \n" +
                "   Print ERROR_MESSAGE(); \n" +
                "   Rollback tran Constancia_A \n" +
                "End Catch \n";
            String procedimiento60 = "Create procedure [dbo].[Administrar Asociados] \n" +
                "As \n" +
                "Begin Tran AdministrarA \n" +
                "Begin Try \n" +
                "   Select Asociado.[Código Asociado] as 'Código',(Persona.Nombres + ' ' + Persona.Apellidos) as 'Nombre', [Tipo de Socio].[Nombre Tipo Socio] as 'Tipo', \n" +
                "   Asociado.Estado as 'Estado' from Persona inner join Asociado on Persona.[Código Persona] = Asociado.[FK Persona] \n " +
                "   inner join[Tipo de Socio] on[Tipo de Socio].[id Tipo de Socio] = Asociado.[FK Tipo Socio] \n" +
                "   Commit Tran AdministrarA \n" +
                "End Try \n" +
                "Begin Catch \n " +
                "   Print 'Ha ocurrido un error: ' + ERROR_MESSAGE() + ' . Inténtelo más tarde.' \n" +
                "   Rollback Tran AdministrarA \n" +
                "End Catch";
            String procedimiento61 = "Create procedure [dbo].[Administrar Usuarios] \n" +
                "As begin Tran AdminU \n" +
                "Begin Try \n" +
                "Select Usuarios.[Id Usuario] as 'ID Usuario', (Usuarios.Nombres + ' ' + Usuarios.Apellidos) as 'Nombre del Usuario', \n" +
                "Usuarios.Correo as 'Correo Electrónico', [Tipo de Usuarios].Nombre as 'Tipo de Usuario' from Usuarios inner join[Tipo de Usuarios] \n" +
                "on Usuarios.[FK Tipo Usuario] = [Tipo de Usuarios].[Id Tipo Usuario] \n" +
                "Commit Tran AdminU \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "    Print 'Ha ocurrido el siguiente un error. Inténtelo más tarde.' \n" +
                "    Rollback Tran AdminU \n" +
                "End Catch";
            String procedimiento62 = "Create procedure [dbo].[Contar Ahorros] \n" +
                "@Código as varchar(6) \n" +
                "as \n" +
                "begin tran contar \n" +
                "begin try \n" +
                "   Select ta.Nombre as 'Ahorro', count(a.[id Ahorro]) as 'No' from [Tipo de Ahorro] ta \n" +
                "   inner join Ahorro a on ta.[id Tipo Ahorro] = a.[FK Tipo Ahorro] \n" +
                "   inner join Asociado pa on pa.[Código Asociado] = a.[FK Código de Asociado] \n" +
                "   where pa.[Código Asociado] = @Código group by ta.Nombre \n" +
                "Commit tran contar \n" +
                "End try \n" +
                "begin catch \n" +
                "Print 'Ha ocurrido un error. ' + ERROR_MESSAGE() + ' . Inténtelo más tarde.' \n" +
                "Rollback Tran contar \n" +
                "end catch";
            String procedimiento63 = "Create procedure [dbo].[Transacciones por Asociado] \n" +
                "@Código as varchar(6) \n" +
                "As \n" +
                "Begin Tran Trans_A \n" +
                "Begin Try \n" +
                "    Select Ahorro.[id Ahorro] as 'Código', [Tipo de Transacción].[Tipo de Transacción] as 'Categoría', [Tipo de Ahorro].Nombre as 'Tipo', \n" +
                "    Ahorro.Estado  as 'Estado' from Ahorro inner join Transacciones on Ahorro.[FK Transacción] = Transacciones.[id Transacción] \n" +
                "    inner join [Tipo de Ahorro] on Ahorro.[FK Tipo Ahorro] = [Tipo de Ahorro].[id Tipo Ahorro] \n" +
                "    inner join [Tipo de Transacción] on Transacciones.[FK Tipo de Transacción] = [Tipo de Transacción].[id Tipo de Transacción] \n" +
                "    where Ahorro.[FK Código de Asociado] = @Código \n" +
                "    union all \n" +
                "    Select Préstamos.[id Préstamos] as 'Código', [Tipo de Transacción].[Tipo de Transacción] as 'Categoría', [Tipo de Préstamo].[Tipo de Préstamo] as 'Tipo', \n" +
                "    Préstamos.Estado as 'Estado' from Préstamos inner join Transacciones on Préstamos.[FK Transacción] = Transacciones.[id Transacción] \n" +
                "    inner join [Tipo de Préstamo] on [Tipo de Préstamo].[id Tipo de Préstamo] = Préstamos.[id Tipo de Préstamo] \n" +
                "    inner join [Tipo de Transacción] on [Tipo de Transacción].[id Tipo de Transacción] = Transacciones.[FK Tipo de Transacción] \n" +
                "    where Préstamos.[Código Asociado] = @Código \n" +
                "    order by Estado \n" +
                "    Commit Tran Trans_A \n" +
                "End Try \n" +
                "Begin Catch \n" +
                "    Print 'Ha ocurrido un error: ' + ERROR_MESSAGE() + '. Inténtelo más tarde' \n" +
                "    Rollback Tran Trans_A \n" +
                "End Catch";
            String procedimiento64 = "Create procedure [dbo].[Contar Préstamos] \n" +
                "@Código as varchar(6) \n" +
                "as begin tran contar \n" +
                "begin try \n" +
                "Select tp.[Tipo de Préstamo] 'Préstamos', count(p.[id Préstamos]) as 'No' from [Tipo de Préstamo] tp \n" +
                "inner join Préstamos p on tp.[id Tipo de Préstamo] = p.[id Tipo de Préstamo] \n" +
                "inner join Asociado pa on pa.[Código Asociado] = p.[Código Asociado] \n"+
                "where pa.[Código Asociado] = @Código group by tp.[Tipo de Préstamo] \n"+
                "Commit tran contar \n" +
                "End try \n" +
                "begin catch \n" +
                "Print 'Ha ocurrido un error. ' + ERROR_MESSAGE() + ' . Inténtelo más tarde.' \n" +
                "Rollback Tran contar \n" +
                "end catch";
            String Login1 =
                "CREATE LOGIN Master_ACOPEDH \n" +
                "WITH PASSWORD = 'Aureo112358' ";

            String Login2 =
                "CREATE LOGIN Administrador \n" +
                "WITH PASSWORD = 'Acopedh365' ";
            String Login3 =
                "CREATE LOGIN Usuario \n" +
                "WITH PASSWORD = 'User12345' ";
            String Login4 =
                "CREATE LOGIN InicioSesion \n" +
                "WITH PASSWORD = 'In112358' " ;
            String Usuario1 =
               "USE \n" + txtNombre.Text + ";" +
               "CREATE USER Master_ACOPEDH FOR LOGIN Master_ACOPEDH ";
            String Usuario2 =
                "USE \n" + txtNombre.Text + ";" +
                "CREATE USER Administrador FOR LOGIN Administrador";
            String Usuario3 =
                "USE \n" + txtNombre.Text + ";" +
                "CREATE USER Usuario FOR LOGIN Usuario ";
            String Usuario4 =
                "USE \n" + txtNombre.Text + ";" +
                "CREATE USER InicioSesion FOR LOGIN InicioSesion ";
            String permisosMaster_ACOPEDH =
                "Use \n" + txtNombre.Text + ";" +
                "Exec sp_addrolemember N'db_owner',N'Master_ACOPEDH' ";
            String permisosAdministrador =
                "Use \n" + txtNombre.Text + ";" +
                "grant select, update, references, insert on object :: Ahorro \n" +
                "to Administrador with grant option \n" +
                "grant select, update, references, insert on object :: Imagenes \n" +
                "to Administrador with grant option \n" +
                "grant select, update, references, insert on object :: [Tipo de Ahorro]" +
                "to Administrador with grant option \n" +
                "grant select, references, insert on object :: Retiros \n" +
                "to Administrador with grant option \n" +
                "grant select, references, insert on object :: Abono \n" +
                "to Administrador with grant option \n" +
                "grant select, update, references, insert on object :: Ocupación \n" +
                "to Administrador with grant option \n" +
                "grant select, update, insert,references, insert on object :: Asociado \n" +
                "to Administrador with grant option \n" +
                "grant select, references, insert on object :: Aportaciones \n" +
                "to Administrador with grant option \n" +
                "grant select, update, references, insert on object :: [Tipos de Teléfonos] \n" +
                "to Administrador with grant option \n" +
                "grant select, update, references, insert on object :: [Contacto] \n" +
                "to Administrador with grant option \n" +
                "grant select, update, references, insert on object :: [Teléfono] \n" +
                "to Administrador with grant option \n" +
                "grant select, update, references, insert on object :: Usuarios \n" +
                "to Administrador with grant option \n" +
                "grant select, update, references, insert on object :: [Tipo de Socio] \n" +
                "to Administrador with grant option \n" +
                "grant select on object :: [Tipo de Usuarios] \n" +
                "to Administrador with grant option \n" +
                "grant select, references, insert on object :: [Pago] \n" +
                "to Administrador with grant option \n" +
                "grant select, update, references, insert on object :: [Préstamos] \n" +
                "to Administrador with grant option \n" +
                "grant select, update, references, insert on object :: [Retiros] \n" +
                "to Administrador with grant option \n" +
                "grant select, update, references, insert on object :: [Tipo de Préstamo] \n" +
                "to Administrador with grant option \n" +
                "grant select, update, references, insert on object :: [Tipo de Transacción] \n" +
                "to Administrador with grant option \n" +
                "grant select, update, references, insert on object :: [Forma de Pago] \n" +
                "to Administrador with grant option \n" +
                "grant select, references, insert on object :: [Transacciones] \n" +
                "to Administrador with grant option \n" +
                "grant select, references, insert on object :: [Retiros Aportaciones] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Insertar Asociado] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Cargar Asociados] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Ahorro DVG] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Asociado DVG] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Préstamo DVG] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Cargar Ahorros] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Cargar Abonos] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Cargar Aportaciones] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Cargar Pagos] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Cargar Préstamo] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Cargar Retiros] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Cargar Saldo] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Cargar Teléfonos] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Eliminar Teléfono] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Insertar Asociado] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Insertar Teléfono] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Modificar Teléfono] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Nueva Cuenta de Ahorro] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Realizar Aportación] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Realizar Pago] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Realizar Retiros] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Suma Abonos] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Suma Aportaciones] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Suma Retiros] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Cargar Tipo Préstamo] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Cargar Tipo Socio] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Cargar Tipo Ahorro] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Nuevo Usuario] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Nuevo Préstamo] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Cargar Tipo Pagos] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Conseguir Límite] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Desasociar] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Cerrar Ahorro] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Cargar Imagenes] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Nueva Imagen] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Elimina Imagen] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Retirar Aportaciones] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Cerrar Préstamo] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Constancia Pago] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Informe Préstamo] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Conseguir Transacciones] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Conseguir Datos Cooperativa] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Conseguir Imágenes] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Insertar Imagen] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Actualizar Imagen] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Eliminar Imagen] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Cargar Tipo Imagen] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Constancia Retiro] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Constancia Abono] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Constancia Nuevo Ahorro] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Actualizar Persona] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Insertar Beneficiario] \n" +
                "to Administrador with grant option \n" + 
                "grant execute on object :: [Personas DVG] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Constancia Retiro Aportaciones] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [ModificarDatos] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Transacciones por Asociado] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Administrar Asociados] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Administrar Usuarios] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Contar Ahorros] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Contar Préstamos] \n" +
                "to Administrador with grant option \n" +
                "grant execute on object :: [Actualizar Asociado] \n" +
                 "to Administrador with grant option ";
            String permisosUsuario =
                 "Use \n" + txtNombre.Text + ";" +
                 "Exec sp_addrolemember N'db_datareader',N'Usuario' \n" +
                "grant execute on object :: [ModificarDatos] \n" +
                "to Usuario with grant option \n" +
                "grant execute on object :: [Nuevo Usuario] \n" +
                "to Usuario with grant option ";
            String permisosInicioSesión =
                 "Use \n" + txtNombre.Text + ";" +
                 "grant select, insert on object :: Usuarios \n" +
                 "to InicioSesion \n" +
                 "grant select on object :: [Tipo de Usuarios] \n" +
                 "to InicioSesion \n" +
                 "grant execute on object :: [Recuperar Contraseña] \n" +
                 "to InicioSesion \n" +
                "grant execute on object :: [InicioDeSesión] \n" +
                "to InicioSesion \n" +
                "grant execute on object :: [Nuevo Usuario] \n" +
                "to InicioSesion";
            String crearusuarios =
                 "Use \n" + txtNombre.Text + ";" +
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
            String insertarTiposImagenes =
                 "Insert into [Tipos de Imágenes] values ('DUI'),('NIT'),('Documentos'),('Otro')";
            //Creación Base de Datos

            SqlCommand cmd = new SqlCommand(cadena1, cnn2);
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
            SqlCommand cmd08 = new SqlCommand(tabla08, cnn);
            SqlCommand cmd9 = new SqlCommand(tabla9, cnn);
            SqlCommand cmd10 = new SqlCommand(tabla10, cnn);
            SqlCommand cmd010 = new SqlCommand(tabla010, cnn);
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
            SqlCommand cmd_039 = new SqlCommand(procedimiento039, cnn);
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
            SqlCommand cmd_54 = new SqlCommand(procedimiento54, cnn);
            SqlCommand cmd_55 = new SqlCommand(procedimiento55, cnn);
            SqlCommand cmd_56 = new SqlCommand(procedimiento56, cnn);
            SqlCommand cmd_57 = new SqlCommand(procedimiento57, cnn);
            SqlCommand cmd_58 = new SqlCommand(procedimiento58, cnn);
            SqlCommand cmd_59 = new SqlCommand(procedimiento59, cnn);
            SqlCommand cmd_60 = new SqlCommand(procedimiento60, cnn);
            SqlCommand cmd_61 = new SqlCommand(procedimiento61, cnn);
            SqlCommand cmd_62 = new SqlCommand(procedimiento62, cnn);
            SqlCommand cmd_63 = new SqlCommand(procedimiento63, cnn);
            SqlCommand cmd_64 = new SqlCommand(procedimiento64, cnn);
            //Creación Triggers

            SqlCommand cmdTrigger1 = new SqlCommand(Trigger1, cnn);

            //Creación Login

            SqlCommand cmdLogin1 = new SqlCommand(Login1, cnn2);
            SqlCommand cmdLogin2 = new SqlCommand(Login2, cnn2);
            SqlCommand cmdLogin3 = new SqlCommand(Login3, cnn2);
            SqlCommand cmdLogin4 = new SqlCommand(Login4, cnn2);

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
            SqlCommand cmdCrearTipoImágenes = new SqlCommand(insertarTiposImagenes, cnn);

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
            cmd08.ExecuteNonQuery();
            cmd8.ExecuteNonQuery();
            cmd9.ExecuteNonQuery();
            cmd10.ExecuteNonQuery();
            cmd010.ExecuteNonQuery();
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
            cmd_039.ExecuteNonQuery();
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
            cmd_54.ExecuteNonQuery();
            cmd_55.ExecuteNonQuery();
            cmd_56.ExecuteNonQuery();
            cmd_57.ExecuteNonQuery();
            cmd_58.ExecuteNonQuery();
            cmd_59.ExecuteNonQuery();
            cmd_60.ExecuteNonQuery();
            cmd_61.ExecuteNonQuery();
            cmd_62.ExecuteNonQuery();
            cmd_63.ExecuteNonQuery();
            cmd_64.ExecuteNonQuery();

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
            cmdCrearTipoImágenes.ExecuteNonQuery();
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