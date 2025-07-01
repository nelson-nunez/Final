using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.DAL;
using SiAP.MPP.Base;

namespace SiAP.MPP
{
    public class MPP_Paciente : IMapper<Paciente>
    {
        private readonly IAccesoDatos _datos;
        private static MPP_Paciente _instancia;

        private MPP_Paciente()
        {
            _datos = AccesoXML.ObtenerInstancia();
        }

        public static MPP_Paciente ObtenerInstancia()
        {
            return _instancia ??= new MPP_Paciente();
        }

        public void Agregar(Paciente entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            if (Existe(entidad)) return;

            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Paciente"];
            var dr = dt.NewRow();

            AsignarDatos(dr, entidad);
            dr["Id"] = DataRowHelper.ObtenerSiguienteId(dt, "Id");
            dt.Rows.Add(dr);

            _datos.Actualizar_BD(ds);
        }

        public void Modificar(Paciente entidad)
        {
            var ds = _datos.Obtener_Datos();
            var dr = ds.Tables["Paciente"].AsEnumerable()
                      .FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id)
                      ?? throw new Exception("Paciente no encontrado.");

            AsignarDatos(dr, entidad);
            _datos.Actualizar_BD(ds);
        }

        public void Eliminar(Paciente entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            var ds = _datos.Obtener_Datos();
            var dr = ds.Tables["Paciente"].AsEnumerable()
                       .FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id);
            dr?.Delete();

            _datos.Actualizar_BD(ds);
        }

        public bool Existe(Paciente entidad)
        {
            if (entidad == null) return false;

            var ds = _datos.Obtener_Datos();
            return ds.Tables["Paciente"].AsEnumerable().Any(r => Convert.ToInt64(r["Id"]) == entidad.Id);
        }

        public bool TieneDependencias(Paciente entidad)
        {
            return false; 
        }

        public IList<Paciente> ObtenerTodos()
        {
            var ds = _datos.Obtener_Datos();
            return ds.Tables["Paciente"].AsEnumerable().Select(HidratarObjeto).ToList();
        }

        public IList<Paciente> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var pacientes = ObtenerTodos();

            if (string.IsNullOrWhiteSpace(campo) || string.IsNullOrWhiteSpace(valor))
                return pacientes;

            return campo.ToLower() switch
            {
                "nombre" => pacientes.Where(p => p.Nombre.Contains(valor)).ToList(),
                "apellido" => pacientes.Where(p => p.Apellido.Contains(valor)).ToList(),
                "dni" => pacientes.Where(p => p.Dni == valor).ToList(),
                _ => throw new ArgumentException($"Campo '{campo}' inválido.")
            };
        }

        public Paciente LeerPorId(object id)
        {
            return ObtenerTodos().FirstOrDefault(p => p.Id == Convert.ToInt64(id));
        }

        private void AsignarDatos(DataRow dr, Paciente entidad)
        {
            dr["Nombre"] = entidad.Nombre;
            dr["Apellido"] = entidad.Apellido;
            dr["Dni"] = entidad.Dni;
            dr["FechaNacimiento"] = entidad.FechaNacimiento;
            dr["Email"] = entidad.Email;
            dr["Telefono"] = entidad.Telefono;
            dr["ObraSocial"] = entidad.ObraSocial;
            dr["Plan"] = entidad.Plan;
            dr["NumeroSocio"] = entidad.NumeroSocio;
        }

        private Paciente HidratarObjeto(DataRow r)
        {
            return new Paciente
            {
                Id = Convert.ToInt64(r["Id"]),
                Nombre = r["Nombre"].ToString(),
                Apellido = r["Apellido"].ToString(),
                Dni = r["Dni"].ToString(),
                FechaNacimiento = Convert.ToDateTime(r["FechaNacimiento"]),
                Email = r["Email"].ToString(),
                Telefono = r["Telefono"].ToString(),
                ObraSocial = r["ObraSocial"].ToString(),
                Plan = r["Plan"].ToString(),
                NumeroSocio = Convert.ToInt32(r["NumeroSocio"])
            };
        }
    }
}
