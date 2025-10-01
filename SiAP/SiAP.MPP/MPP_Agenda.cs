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
    public class MPP_Agenda : IMapper<Agenda>
    {
        private readonly IAccesoDatos _datos;
        private static MPP_Agenda _instancia;

        private MPP_Agenda()
        {
            _datos = AccesoXML.ObtenerInstancia();
        }

        public static MPP_Agenda ObtenerInstancia()
        {
            return _instancia ??= new MPP_Agenda();
        }

        public void Agregar(Agenda entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            if (Existe(entidad)) return;

            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Agenda"];
            var dr = dt.NewRow();

            dr["Id"] = DataRowHelper.ObtenerSiguienteId(dt, "Id");
            dr["Fecha"] = entidad.Fecha;
            dr["HoraInicio"] = entidad.HoraInicio.ToString(@"hh\:mm");
            dr["HoraFin"] = entidad.HoraFin.ToString(@"hh\:mm");
            dr["MedicoId"] = entidad.MedicoId;

            dt.Rows.Add(dr);
            _datos.Actualizar_BD(ds);
        }

        public void AgregarAgendas(List<Agenda> entidades)
        {
            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Agenda"];

            foreach (var entidad in entidades) 
            {
                ArgumentNullException.ThrowIfNull(entidad);
                if (Existe(entidad)) return;
                var dr = dt.NewRow();
                dr["Id"] = DataRowHelper.ObtenerSiguienteId(dt, "Id");
                dr["Fecha"] = entidad.Fecha;
                dr["HoraInicio"] = entidad.HoraInicio.ToString(@"hh\:mm");
                dr["HoraFin"] = entidad.HoraFin.ToString(@"hh\:mm");
                dr["MedicoId"] = entidad.MedicoId;
                dt.Rows.Add(dr);
            }
            _datos.Actualizar_BD(ds);
        }

        public void Modificar(Agenda entidad)
        {
            var ds = _datos.Obtener_Datos();
            var dr = ds.Tables["Agenda"].AsEnumerable()
                .FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id)
                ?? throw new Exception("Agenda no encontrada.");

            dr["Fecha"] = entidad.Fecha;
            dr["HoraInicio"] = entidad.HoraInicio.ToString(@"hh\:mm");
            dr["HoraFin"] = entidad.HoraFin.ToString(@"hh\:mm");
            dr["MedicoId"] = entidad.MedicoId;

            _datos.Actualizar_BD(ds);
        }

        public void Eliminar(Agenda entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            var ds = _datos.Obtener_Datos();
            var dr = ds.Tables["Agenda"].AsEnumerable().FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id);

            dr?.Delete();
            _datos.Actualizar_BD(ds);
        }

        public void EliminarAgendas(List<Agenda> entidades)
        {
            var ds = _datos.Obtener_Datos();
            foreach (var entidad in entidades)
            {
                ArgumentNullException.ThrowIfNull(entidad);
                var dr = ds.Tables["Agenda"].AsEnumerable().FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id);
                dr?.Delete();
            }
            _datos.Actualizar_BD(ds);
        }

        public bool Existe(Agenda entidad)
        {
            var ds = _datos.Obtener_Datos();
            return ds.Tables["Agenda"].AsEnumerable()
                .Any(r =>
                    Convert.ToDateTime(r["Fecha"]) == entidad.Fecha &&
                    TimeSpan.Parse(r["HoraInicio"].ToString()) == entidad.HoraInicio &&
                    Convert.ToInt64(r["MedicoId"]) == entidad.MedicoId);
        }

        public bool TieneDependencias(Agenda entidad)
        {
            return false; // Cambiar si hay relaciones con Turno
        }

        public IList<Agenda> ObtenerTodos()
        {
            var ds = _datos.Obtener_Datos();
            return ds.Tables["Agenda"].AsEnumerable().Select(HidratarObjeto).ToList();
        }

        public Agenda LeerPorId(object id)
        {
            return ObtenerTodos().FirstOrDefault(a => a.Id == Convert.ToInt64(id));
        }

        public IList<Agenda> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var lista = ObtenerTodos();

            if (string.IsNullOrWhiteSpace(campo) || string.IsNullOrWhiteSpace(valor))
                return lista;

            return campo.ToLower() switch
            {
                "medicoid" => lista.Where(a => a.MedicoId == Convert.ToInt64(valor)).ToList(),
                "fecha" => lista.Where(a => a.Fecha.ToShortDateString().Contains(valor)).ToList(),
                _ => throw new ArgumentException($"Campo '{campo}' inválido.")
            };
        }

        public IList<Agenda> BuscarPorMedicoyRango(long medicoId, DateTime fechadesde, DateTime fechahasta)
        {
            var lista = ObtenerTodos().Where(t => t.MedicoId == medicoId && (t.Fecha >= fechadesde && t.Fecha <= fechahasta)).ToList();
            return (IList<Agenda>)lista;
        }

        private Agenda HidratarObjeto(DataRow r)
        {
            return new Agenda
            {
                Id = Convert.ToInt64(r["Id"]),
                Fecha = Convert.ToDateTime(r["Fecha"]),
                HoraInicio = TimeSpan.Parse(r["HoraInicio"].ToString()),
                HoraFin = TimeSpan.Parse(r["HoraFin"].ToString()),
                MedicoId = Convert.ToInt64(r["MedicoId"])
            };
        }
    }
}
