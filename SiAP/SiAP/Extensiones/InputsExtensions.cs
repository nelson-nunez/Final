using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using SiAP.BE.Base;

namespace SiAP.UI.Extensiones
{
    public static class InputsExtensions
    {
        public static bool IsNOTNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable != null && enumerable.Any();
        }

        public static bool IsNOTNullOrEmpty<T>(this ICollection<T> enumerable)
        {
            return enumerable != null && enumerable.Any();
        }


        public static void PedirConfirmacion()
        {
            DialogResult result = MessageBox.Show("Desea continuar con la operación?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                throw new Exception("Se canceló la operación");
        }

        public static void PedirConfirmacion(string msg)
        {
            DialogResult result = MessageBox.Show(msg, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                throw new Exception("Se canceló la operación");
        }

        public static void PedirConfirmacionGuardado(ClaseBase item)
        {
            string msg = (item.Id == 0) ? "Desea GUARDAR el registro?" : "Desea EDITAR el registro?";
            DialogResult result = MessageBox.Show(msg, "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                throw new Exception("Se canceló la operación");
        }

        // Verifica que este seleccionado
        public static void OnlySelected(this ClaseBase item, string msg)
        {
            if (item == null || item.Id == 0)
                throw new Exception($"Debe seleccionar {msg} para continuar");
        }

        #region Validar Campos
        public static void Validar(this string valor, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException($"El campo '{nombreCampo}' no puede estar vacío.");
        }

        public static void ValidarSoloTexto(this string valor, string nombreCampo)
        {
            valor.Validar(nombreCampo); // Verifica que no esté vacío

            if (!Regex.IsMatch(valor, @"^[a-zA-ZÁÉÍÓÚáéíóúñÑ\s]+$"))
                throw new ArgumentException($"El campo '{nombreCampo}' solo puede contener letras.");
        }

        public static void ValidarEmail(this string valor, string nombreCampo)
        {
            valor.Validar(nombreCampo);

            var patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(valor, patronEmail))
                throw new ArgumentException($"El campo '{nombreCampo}' no tiene un formato de email válido.");
        }

        public static void Validar(this bool valor, string nombreCampo)
        {
            if (!valor)
                throw new ArgumentException($"Debe aceptar '{nombreCampo}'.");
        }

        public static void ValidarSoloNumeros(this decimal valor, string nombreCampo)
        {
            if (valor <= 0)
                throw new ArgumentException($"El campo '{nombreCampo}' debe ser mayor a cero.");
        }

        public static void ValidarPassword(this string valor, string nombreCampo)
        {
            valor.Validar(nombreCampo); // Verifica que no esté vacío

            if (valor.Length < 5)
                throw new ArgumentException($"El campo '{nombreCampo}' debe tener al menos 5 caracteres.");

            if (!Regex.IsMatch(valor, @"^[a-zA-Z0-9]+$"))
                throw new ArgumentException($"El campo '{nombreCampo}' solo puede contener letras y números sin espacios ni símbolos.");
        }

        #endregion
    }

}
