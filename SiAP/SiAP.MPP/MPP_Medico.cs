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
    public class MPP_Medico : IMapper<Medico>
    {
        private readonly IAccesoDatos _datos;
        private static MPP_Medico _instancia;

        private MPP_Medico()
        {
            _datos = AccesoXML.ObtenerInstancia();
        }

        public static MPP_Medico ObtenerInstancia()
        {
            return _instancia ??= new MPP_Medico();
        }

        public void Agregar(Medico entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            if (Existe(entidad)) return;

            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Medico"];
            var dr = dt.NewRow();

            AsignarDatos(dr, entidad);
            dr["Id"] = DataRowHelper.ObtenerSiguienteId(dt, "Id");
            dt.Rows.Add(dr);

            _datos.Actualizar_BD(ds);
        }

        public void Modificar(Medico entidad)
        {
            var ds = _datos.Obtener_Datos();
            var dr = ds.Tables["Medico"].AsEnumerable()
                      .FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id)
                      ?? throw new Exception("Médico no encontrado.");

            AsignarDatos(dr, entidad);
            _datos.Actualizar_BD(ds);
        }

        public void Eliminar(Medico entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            var ds = _datos.Obtener_Datos();
            var dr = ds.Tables["Medico"].AsEnumerable()
                       .FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id);
            dr?.Delete();

            _datos.Actualizar_BD(ds);
        }

        public bool Existe(Medico entidad)
        {
            if (entidad == null) return false;

            var ds = _datos.Obtener_Datos();
            return ds.Tables["Medico"].AsEnumerable().Any(r => Convert.ToInt64(r["Id"]) == entidad.Id);
        }

        public bool TieneDependencias(Medico entidad)
        {
            return false; // Sujeto a reglas de negocio futuras
        }

        public IList<Medico> ObtenerTodos()
        {
            var ds = _datos.Obtener_Datos();
            return ds.Tables["Medico"].AsEnumerable().Select(HidratarObjeto).ToList();
        }

        public IList<Medico> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var medicos = ObtenerTodos();

            if (string.IsNullOrWhiteSpace(campo) || string.IsNullOrWhiteSpace(valor))
                return medicos;

            return campo.ToLower() switch
            {
                "nombre" => medicos.Where(m => m.Nombre.Contains(valor)).ToList(),
                "apellido" => medicos.Where(m => m.Apellido.Contains(valor)).ToList(),
                "dni" => medicos.Where(m => m.Dni == valor).ToList(),
                _ => throw new ArgumentException($"Campo '{campo}' inválido.")
            };
        }

        public Medico LeerPorId(object id)
        {
            return ObtenerTodos().FirstOrDefault(m => m.Id == Convert.ToInt64(id));
        }

        private void AsignarDatos(DataRow dr, Medico entidad)
        {
            dr["Nombre"] = entidad.Nombre;
            dr["Apellido"] = entidad.Apellido;
            dr["Dni"] = entidad.Dni;
            dr["FechaNacimiento"] = entidad.FechaNacimiento;
            dr["Email"] = entidad.Email;
            dr["Telefono"] = entidad.Telefono;
            dr["ArancelConsulta"] = entidad.ArancelConsulta;
            dr["Titulo"] = entidad.Titulo;

            dr["EspecialidadId"] = entidad.Especialidad?.Id ?? 0;
            dr["EspecialidadNombre"] = entidad.Especialidad?.Nombre ?? string.Empty;
        }


        private Medico HidratarObjeto(DataRow r)
        {
            var especialidadId = Convert.ToInt32(r["EspecialidadId"]);
            var especialidad = Especialidad.ObtenerTodas().FirstOrDefault(e => e.Id == especialidadId);

            return new Medico
            {
                Id = Convert.ToInt64(r["Id"]),
                Nombre = r["Nombre"].ToString(),
                Apellido = r["Apellido"].ToString(),
                Dni = r["Dni"].ToString(),
                FechaNacimiento = Convert.ToDateTime(r["FechaNacimiento"]),
                Email = r["Email"].ToString(),
                Telefono = r["Telefono"].ToString(),
                ArancelConsulta = Convert.ToDecimal(r["ArancelConsulta"]),
                Titulo = r["Titulo"].ToString(),
                Especialidad = especialidad
            };
        }
    }
}
