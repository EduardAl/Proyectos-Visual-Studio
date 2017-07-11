using System;
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
            String tabla4 = "CREATE TABLE [dbo].[Tipo de Ahorro](" +
                "[Número][int] IDENTITY(1, 1) NOT NULL," +
                "[id Tipo Ahorro]  AS('TA' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Nombre] [varchar](20) NOT NULL," +
                "[Tasa de Interés] [decimal](10, 2) NOT NULL," +
                "CONSTRAINT[PK_Tipo de Ahorro] PRIMARY KEY ([id Tipo Ahorro]))";
            String tabla5 = "CREATE TABLE [dbo].[Ocupación](" +
                "[Número][int] IDENTITY(1, 1) NOT NULL," +
                "[Id Ocupación]  AS('OC' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Nombre de la Empresa] [varchar](60) NOT NULL," +
                "CONSTRAINT[PK_Ocupación] PRIMARY KEY ([Id Ocupación]))";
            String tabla6 = "CREATE TABLE [dbo].[Asociado](" +
                "[Número][int] IDENTITY(1, 1) NOT NULL," +
                "[Código Asociado]  AS('AS' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[FK Tipo Socio] [varchar](5) NOT NULL," +
                "[Nombres] [varchar](50) NOT NULL," +
                "[Apellidos] [varchar](50) NOT NULL," +
                "[DUI] [varchar](10) NOT NULL," +
                "[NIT] [varchar](17) NOT NULL," +
                "[Dirección] [varchar](100) NULL," +
                "[Fecha de Nacimiento] [date] NOT NULL," +
                "[Fecha de Asociación] [date] NOT NULL," +
                "[Fecha de Desasociación] [date] NULL," +
                "[FK Ocupación] [varchar](5) NOT NULL," +
                "CONSTRAINT [PK_Asociado] PRIMARY KEY ([Código Asociado])," +
                "CONSTRAINT [FK Tipo Socio] FOREIGN KEY ([FK Tipo Socio])" +
                "REFERENCES [Tipo de Socio]([id Tipo de Socio])," +
                "CONSTRAINT [FK Ocupación] FOREIGN KEY ([FK Ocupación])" +
                "REFERENCES Ocupación([Id Ocupación]))";
            String tabla7 = "CREATE TABLE [dbo].[Aportaciones](" +
                "[Número] [int] IDENTITY(1,1) NOT NULL," +
                "[id Aportación]  AS('AP' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Aportación] [smallmoney] NOT NULL," +
                "[Fecha de Aportación] [date] NOT NULL," +
                "[FK Asociado] [varchar](5) NOT NULL," +
                "CONSTRAINT[PK_Aportaciones] PRIMARY KEY([id Aportación])," +
                "CONSTRAINT [FK Asociado] FOREIGN KEY ([FK Asociado])" +
                "REFERENCES Asociado([Código Asociado]))";
            String tabla8 = "CREATE TABLE[dbo].[Ahorro](" +
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
            String tabla9 = "CREATE TABLE [dbo].[Retiros](" +
                "[Número][int] IDENTITY(1, 1) NOT NULL," +
                "[id Retiro]  AS('RE' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Retiro] [smallmoney] NOT NULL," +
                "[Fecha de Retiro] [date] NOT NULL," +
                "[Número de Cheque] [varchar](8) NOT NULL," +
                "[FK Ahorro] [varchar](5) NOT NULL," +
                "CONSTRAINT[PK_Retiros] PRIMARY KEY ([id Retiro])," +
                "CONSTRAINT [FK Ahorro] FOREIGN KEY ([FK Ahorro])" +
                "REFERENCES Ahorro([id Ahorro]))";
            String tabla10 = "CREATE TABLE [dbo].[Abono](" +
                "[Número][int] IDENTITY(1,1) NOT NULL," +
                "[id Abono]  AS('AB' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Abono] [smallmoney] NOT NULL," +
                "[Fecha de Abono] [date] NOT NULL," +
                "[FK Ahorro] [varchar](5) NOT NULL," +
                "CONSTRAINT [PK Abono] PRIMARY KEY ([id Abono])," +
                "CONSTRAINT [FK Abono] FOREIGN KEY ([FK Ahorro])" +
                "references Ahorro([id Ahorro]))";
            String tabla11 = "CREATE TABLE [dbo].[Tipos de Teléfonos](" +
                "[Número][int] IDENTITY(1, 1) NOT NULL," +
                "[id Tipo de Teléfono]  AS('TF' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Tipo de Teléfono] [varchar](50) NOT NULL," +
                "CONSTRAINT [PK Tipo de Teléfono] PRIMARY KEY ([id Tipo de Teléfono]))";
            String tabla12 = "CREATE TABLE [dbo].[Teléfono](" +
                "[Número][int] identity(1,1) NOT NULL," +
                "[id Teléfono] AS('TE' + right('000' + CONVERT([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Teléfono][varchar](10) NOT NULL,"+
                "[FK Tipo de Teléfono][varchar](5) NOT NULL references [Tipos de Teléfonos]([id Tipo de Teléfono]),"+
                "CONSTRAINT [PK Teléfono] PRIMARY KEY ([id Teléfono]))";
            String tabla13 = "CREATE TABLE [dbo].[Contacto](" +
                "[FK Teléfono] [varchar](5) NOT NULL references[Teléfono]([id Teléfono])," +
                "[FK Código Asociado] [varchar](5) NOT NULL references Asociado([Código Asociado]))";
            String tabla14 = "Create table [dbo].[Pago](" +
                "[Número][int] identity(1, 1) NOT NULL," +
                "[id Pago] AS('PA' + right('000' + Convert([varchar](3),[Número]), (3))) PERSISTED NOT NULL," +
                "[Pago] [smallmoney] NOT NULL," +
                "[Número de Cuota] [int] NOT NULL," +
                "[Intereses] [smallmoney] NOT NULL," +
                "[Capital] [smallmoney] NOT NULL," +
                "[Saldo] [smallmoney] NOT NULL," +
                "[Fecha de Pago] [date] NOT NULL,"+
                 "CONSTRAINT [PK Pago] PRIMARY KEY ([id Pago]))";
            String tabla15 = "Create table [dbo].[Forma de Pago](" +
                "[Número] [int] identity(1, 1) NOT NULL," +
                "[id Forma de Pago] AS('FP' + right('000' + Convert([varchar](3), [Número]), (3))) PERSISTED NOT NULL," +
                "[Nombre] [varchar](50) NOT NULL unique," +
                "CONSTRAINT [PK_Forma de Pago] PRIMARY KEY ([id Forma de Pago]))";
            String tabla16 = "Create table [dbo].[Tipo de Préstamo](" +
                "[Número] [int] identity(1,1) NOT NULL," +
                "[id Tipo de Préstamo] AS('TP' + right('000'+Convert([varchar](3), [Número]), (3))) PERSISTED NOT NULL," +
                "[Tipo de Préstamo] [varchar](50) NOT NULL Unique," +
                "[Tasa de Interés] [decimal](10, 2) NOT NULL," +
                "CONSTRAINT [PK_Tipo de Préstamo] PRIMARY KEY ([id Tipo de Préstamo]))";
            String tabla17 = "Create table [Préstamos](" +
                "[Número] [int] identity(1,1)," +
                "[id Préstamos] AS('PP-' + right('000000'+Convert([varchar](6), [Número]), (6))) PERSISTED NOT NULL PRIMARY KEY," +
                "[Código Asociado] [varchar](5) NOT NULL references [Asociado]([Código Asociado])," +
                "[id Forma de Pago] [varchar](5) references[Forma de Pago]([id Forma de Pago]) NOT NULL," +
                "[id Tipo de Préstamo] [varchar](5) references [Tipo de Préstamo]([id Tipo de Préstamo]) NOT NULL,"+
                "[Fecha de Otorgamiento] [date] NOT NULL," +
                "[Plazo en Meses] [int] NOT NULL," +
                "[Cuotas] [int] NOT NULL," +
                "[Monto del Préstamo] [smallmoney] NOT NULL," +
                "[Cuota Mensual] [smallmoney] NOT NULL,"+
                "[Estado] [varchar](10) NOT NULL)";
            String tabla18 = "Create Table [Información](" +
                "[id Pago] [varchar](5) references [Pago]([id Pago])NOT NULL," +
                "[id Préstamo] [varchar](9) references [Préstamos]([id Préstamos])NOT NULL," +
                "[Mora] [smallmoney]," +
                "[Fecha Límite][date] NOT NULL)";
            String Usuario1 =
                "CREATE LOGIN Master_ACOPEDH " +
                "WITH PASSWORD = 'AUREO112358' " +
                "USE "+txtNombre.Text+";" +
                "CREATE USER Master FOR LOGIN Master_ACOPEDH ";
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
            String permisosAdministrador =
                "Use " + txtNombre.Text + ";" +
                "grant select, update, references, insert on object :: Ahorro " +
                "to Administrador with grant option " +
                "grant select, update, references, insert on object :: [Tipo de Ahorro]" +
                "to Administrador with grant option " +
                "grant select, update, references, insert on object :: Retiros " +
                "to Administrador with grant option " +
                "grant select, update, references, insert on object :: Abono " +
                "to Administrador with grant option " +
                "grant select, update, references, insert on object :: Ocupación " +
                "to Administrador with grant option " +
                "grant select, update, references, insert on object :: Asociado " +
                "to Administrador with grant option " +
                "grant select, update, references, insert on object :: Aportaciones " +
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
                "to Administrador with grant option ";
            String permisosUsuario =
                 "Use " + txtNombre.Text + ";" +
                 "grant select on database :: [" + txtNombre.Text + "] " +
                 "to Usuario with grant option " +
                 "grant insert, update on object :: Usuarios " +
                 "to Usuario with grant option ";
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
            SqlCommand cmd19 = new SqlCommand(Usuario1, cnn);
            SqlCommand cmd20 = new SqlCommand(Usuario2, cnn);
            SqlCommand cmd21 = new SqlCommand(Usuario3, cnn);
            SqlCommand cmd22 = new SqlCommand(Usuario4, cnn);
            SqlCommand cmd23 = new SqlCommand(permisosAdministrador, cnn);
            SqlCommand cmd24 = new SqlCommand(permisosUsuario, cnn);
            SqlCommand cmd25 = new SqlCommand(permisosInicioSesión, cnn);
            SqlCommand cmd26 = new SqlCommand(crearusuarios, cnn);
            SqlCommand cmd27 = new SqlCommand(crearahorros, cnn);
            SqlCommand cmd28 = new SqlCommand(crearpagos, cnn);
            SqlCommand cmd29 = new SqlCommand(crearsocios, cnn);
            SqlCommand cmd30 = new SqlCommand(creartrabajos, cnn);
            SqlCommand cmd31 = new SqlCommand(crearpréstamos, cnn);
            try
            {
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
                cmd30.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Base Creada");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error al crear la base",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
