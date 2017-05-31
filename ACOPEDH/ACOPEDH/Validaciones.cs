using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ACOPEDH
{
    public partial class Validaciones
    {
        public bool validar_DUI(ref TextBox DUI, ref ErrorProvider Mostrar)
        {
            Mostrar.Clear();
            String expresion;
            expresion = "[0-9]{8}\\-[0-9]{1}?$";
            if (Regex.IsMatch(DUI.Text, expresion))
            {
                if (Regex.Replace(DUI.Text, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    Mostrar.SetError(DUI, "El DUI ingresado en inválido.");
                    return false;
                }
            }
            else
            {
                Mostrar.SetError(DUI, "El DUI ingresado en inválido.");
                return false;
            }
        }
        public bool validar_NIT(ref TextBox NIT, ref ErrorProvider Mostrar)
        {
            Mostrar.Clear();
            String expresion;
            expresion = "[0-9]{4}\\-[0-9]{6}\\-[0-9]{3}\\-[0-9]{1}?$";
            if (Regex.IsMatch(NIT.Text, expresion))
            {
                if (Regex.Replace(NIT.Text, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    Mostrar.SetError(NIT, "El NIT ingresado en inválido.");
                    return false;
                }
            }
            else
            {
                Mostrar.SetError(NIT, "El NIT ingresado en inválido.");
                return false;
            }
        }
        public bool validar_correo(ref TextBox correo, ref ErrorProvider Mostrar)
        {
            Mostrar.Clear();
            String expresion;
            expresion = "^[_a-z0-9-]+(\\.[_a-z0-9-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$";
            while (correo.Text.Contains(" "))
            {
                correo.Text = correo.Text.Replace(" ", "");
                correo.SelectionStart = correo.Text.Length;
            }
            if (Regex.IsMatch(correo.Text, expresion))
            {
                if (Regex.Replace(correo.Text, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    Mostrar.SetError(correo, "El correo ingresado en inválido.");
                    return false;
                }
            }
            else
            {
                Mostrar.SetError(correo, "El correo ingresado en inválido.");
                return false;
            }
        }
        public bool validar_nombre(ref TextBox Nombre, ref ErrorProvider Mostrar)
        {
            Mostrar.Clear();
            String expresion;
            expresion = "[a-zA-ZñÑáéíóúÁÉÍÓÚäëïöüÄËÏÖÜ\\s]{2,50}";
            if (Regex.IsMatch(Nombre.Text, expresion))
            {
                if (Regex.Replace(Nombre.Text, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    Mostrar.SetError(Nombre, "El nombre ingresado en inválido.");
                    return false;
                }
            }
            else
            {
                Mostrar.SetError(Nombre, "El Nombre ingresado en inválido.");
                return false;
            }
        }
        public bool validar_Teléfonos(ref TextBox Telefono, ref ErrorProvider Mostrar)
        {
            Mostrar.Clear();
            String expresion;
            expresion = "[0-9]{4}\\-[0-9]{4}?$";
            if ((Regex.IsMatch(Telefono.Text, expresion) && !(Telefono.Text.ToString().Length < 8)))
            {
                if (Regex.Replace(Telefono.Text, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    Mostrar.SetError(Telefono, "El Número ingresado es inválido. Formato 7000-0000");
                    return false;
                }
            }
            else
            {
                Mostrar.SetError(Telefono, "El Número ingresado es inválido. Formato 7000-0000");
                return false;
            }
        }
        public bool validar_contraseñas(TextBox Contraseña1, ref ErrorProvider Mostrar)
        {
            Mostrar.Clear();
            String expresion;
            expresion = "(?=^.{8,}$)((?=.*\\d)|(?=.*\\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$";
            if (Regex.IsMatch(Contraseña1.Text, expresion))
            {
                if (Regex.Replace(Contraseña1.Text, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {

                    Mostrar.SetError(Contraseña1, "La clave debe contener al menos 8 caracteres, una letra mayúscula, una le tra minúscula, un número y un carcter.");
                    return false;
                }
            }
            else
            {
                Mostrar.SetError(Contraseña1, "La clave debe contener al menos 8 caracteres, una letra mayúscula, una le tra minúscula, un número y un carcter.");

                return false;
            }
        }
        public bool claves_iguales(TextBox Contraseña1, TextBox Contraseña2, ref ErrorProvider Mostrar)
        {
            Mostrar.Clear();
            if (Contraseña1.Text != Contraseña2.Text)
            {
                Mostrar.SetError(Contraseña2, "Las contraseñas no son iguales");
                return false;
            }
            else
                return true;
        }
        public bool ValidarNomApe(ref TextBox txt, ref ErrorProvider Mostrar)
        {
            txt.Text = retornarMayúscula(ref txt);
            txt.SelectionStart = txt.Text.Length;
            validar_nombre(ref txt, ref Mostrar);
            return !string.IsNullOrEmpty(txt.Text);
        }

        private string retornarMayúscula(ref TextBox Cadena)
        {
            while (Cadena.Text.Contains("  "))
            {
                Cadena.Text = Cadena.Text.Replace("  ", " ");
            }
            if (Cadena.Text == " ")
            {
                Cadena.Text = Cadena.Text.Trim();
            }
            if ((Cadena.Text.Length >= 1))
            {
                if (!(string.IsNullOrEmpty(Cadena.Text)))
                {
                    try
                    {
                        string[] modificado = Cadena.Text.Split(' ');
                        string retornar = modificado[0].Substring(0, 1).ToUpper() + modificado[0].Substring(1, modificado[0].Length - 1);
                        for (int i = 1; i < modificado.Length; i++)
                        {
                            retornar = retornar + ' ' + modificado[i].Substring(0, 1).ToUpper() + modificado[i].Substring(1, modificado[i].Length - 1);
                        }
                        return retornar;
                    }
                    catch
                    {
                        return Cadena.Text;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }
        public bool validar_Cheque(ref TextBox Cheque, ref ErrorProvider Mostrar)
        {
            Mostrar.Clear();
            String expresion;
            expresion = "[0-9]{6}\\-[0-9]{1}?$";
            if (Regex.IsMatch(Cheque.Text, expresion))
            {
                if (Regex.Replace(Cheque.Text, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    Mostrar.SetError(Cheque, "El cheque ingresado es inválido. Formato: 123456-1");
                    return false;
                }
            }
            else
            {
                Mostrar.SetError(Cheque, "El cheque ingresado es inválido. Formato: 123456-1");
                return false;
            }
        }
        public bool IsNullOrEmty(ref TextBox Cadena, ref ErrorProvider Mostrar)
        {
            if (String.IsNullOrEmpty(Cadena.Text))
            {
                Mostrar.SetError(Cadena, "Campo obligatorio.");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
