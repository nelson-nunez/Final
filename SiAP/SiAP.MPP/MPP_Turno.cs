using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.BE.Base;
using SiAP.DAL;
using SiAP.MPP.Base;

namespace SiAP.MPP
{
    public class MPP_Turno : IMapper<Turno>
    {
        private readonly IAccesoDatos _datos;
        private static MPP_Turno _instancia;

        private MPP_Turno()
        {
            _datos = AccesoXML.ObtenerInstancia();
        }

        public static MPP_Turno ObtenerInstancia()
        {
            return _instancia ??= new MPP_Turno();
        }

        public void Agregar(Turno entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            if (Existe(entidad)) return;

            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables["Turno"];
            var dr = dt.NewRow();

            dr["Id"] = DataRowHelper.ObtenerSiguienteId(dt, "Id");
            dr["Fecha"] = entidad.Fecha;
            dr["HoraInicio"] = entidad.HoraInicio;
            dr["HoraFin"] = entidad.HoraFin;
            dr["TipoAtencion"] = entidad.TipoAtencion;
            dr["Estado"] = entidad.Estado.ToString();
            dr["MedicoId"] = entidad.MedicoId;
            dr["PacienteId"] = entidad.PacienteId;
            dr["AgendaId"] = entidad.AgendaId;

            dt.Rows.Add(dr);
            _datos.Actualizar_BD(ds);
        }

        public void Modificar(Turno entidad)
        {
            var ds = _datos.Obtener_Datos();
            var dr = ds.Tables["Turno"].AsEnumerable()
                .FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id)
                ?? throw new Exception("Turno no encontrado.");

            dr["Fecha"] = entidad.Fecha;
            dr["HoraInicio"] = entidad.HoraInicio;
            dr["HoraFin"] = entidad.HoraFin;
            dr["TipoAtencion"] = entidad.TipoAtencion;
            dr["Estado"] = entidad.Estado.ToString();
            dr["MedicoId"] = entidad.MedicoId;
            dr["PacienteId"] = entidad.PacienteId;
            dr["AgendaId"] = entidad.AgendaId;

            _datos.Actualizar_BD(ds);
        }

        public void Eliminar(Turno entidad)
        {
            var ds = _datos.Obtener_Datos();
            var dr = ds.Tables["Turno"].AsEnumerable()
                .FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id);
            dr?.Delete();
            _datos.Actualizar_BD(ds);
        }

        public bool Existe(Turno entidad)
        {
            var ds = _datos.Obtener_Datos();
            return ds.Tables["Turno"].AsEnumerable()
                .Any(r => Convert.ToInt64(r["Id"]) == entidad.Id);
        }

        public bool TieneDependencias(Turno entidad) => false;

        public IList<Turno> ObtenerTodos()
        {
            var ds = _datos.Obtener_Datos();
            return ds.Tables["Turno"].AsEnumerable().Select(Hidratar).ToList();
        }

        public Turno LeerPorId(object id)
        {
            return ObtenerTodos().FirstOrDefault(t => t.Id == Convert.ToInt64(id));
        }

        public IList<Turno> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
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

        // Si necesitas buscar por rango de tiempo en lugar de hora exacta
        public Turno BuscarTurnoPorMedIdyRangoHorario(long medicoId, DateTime fecha, TimeSpan horaDesde, TimeSpan horaHasta)
        {
            var lista = ObtenerTodos();
            return lista.FirstOrDefault(
                t => t.MedicoId == medicoId && 
                t.Fecha.Date == fecha.Date &&
                (t.HoraInicio >= horaDesde && t.HoraInicio < horaHasta || t.HoraFin > horaDesde && t.HoraFin <= horaHasta)
                );
        }

        public IList<Turno> BuscarPorMedicoyRango(long medicoId, DateTime fechadesde, DateTime fechahasta)
        {
            var lista = ObtenerTodos().Where(t => t.MedicoId == medicoId && (t.Fecha >= fechadesde && t.Fecha <= fechahasta)).ToList();
            return (IList<Turno>)lista;
        }

        private Turno Hidratar(DataRow r)
        {
            return new Turno
            {
                Id = Convert.ToInt64(r["Id"]),
                Fecha = Convert.ToDateTime(r["Fecha"]),
                HoraInicio = TimeSpan.Parse(r["HoraInicio"].ToString()),
                HoraFin = TimeSpan.Parse(r["HoraFin"].ToString()),
                TipoAtencion = r["TipoAtencion"].ToString(),
                Estado = Enum.Parse<EstadoTurno>(r["Estado"].ToString()),
                MedicoId = Convert.ToInt64(r["MedicoId"]),
                PacienteId = Convert.ToInt64(r["PacienteId"]),
                AgendaId = Convert.ToInt64(r["AgendaId"])
            };
        }
    }
}
