using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.BE.Base;

namespace SiAP.BE
{
    public class FormaPago : ClaseBase
    {
        public string Nombre { get; init; }
        public string Codigo { get; init; }              // Código interno o abreviado (Ej: "EF", "MP")
        public TipoFormaPago Tipo { get; init; }         // Ej: Manual, Electrónica, etc.
        public bool EsElectronico => Tipo == TipoFormaPago.Electronico;

        public override string ToString()
        {
            return $"{Nombre} ({Codigo})";
        }

        private FormaPago(int id, string nombre, string codigo, TipoFormaPago tipo)
        {
            Id = id;
            Nombre = nombre;
            Codigo = codigo;
            Tipo = tipo;
        }

        // Lista predefinida
        private static readonly List<FormaPago> _todas = new()
        {
            new(1, "Efectivo",          "EF",   TipoFormaPago.Manual),
            new(2, "Débito",            "DEB",  TipoFormaPago.Manual),
            new(3, "Crédito",           "CRE",  TipoFormaPago.Electronico),
            new(4, "Transferencia",     "TRANS",TipoFormaPago.Electronico),
            new(5, "Mercado Pago",      "MP",   TipoFormaPago.Electronico),
            new(6, "Cheque",            "CHQ",  TipoFormaPago.Manual),
            new(7, "Cuenta Corriente",  "CC",   TipoFormaPago.Manual)
        };

        public static IReadOnlyList<FormaPago> ObtenerTodas() => _todas;
    }
    public enum TipoFormaPago
    {
        Manual,
        Electronico
    }
}
