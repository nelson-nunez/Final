﻿using System.Data;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.MPP.Base;

namespace SiAP.MPP
{
    public class MPP_Agenda : MapperBase<Agenda>, IMapper<Agenda>
    {
        private static MPP_Agenda _instancia;
        protected override string NombreTabla => "Agenda";

        private MPP_Agenda() : base() { }

        public static MPP_Agenda ObtenerInstancia()
        {
            return _instancia ??= new MPP_Agenda();
        }

        public void Agregar(Agenda entidad)
        {
            if (Existe(entidad)) return;
            AgregarEntidad(entidad, AsignarDatos);
        }

        public void AgregarAgendas(List<Agenda> entidades)
        {
            var ds = _datos.Obtener_Datos();
            var dt = ds.Tables[NombreTabla];

            foreach (var entidad in entidades)
            {
                ArgumentNullException.ThrowIfNull(entidad);
                if (Existe(entidad)) continue;

                var dr = dt.NewRow();
                long nuevoId = DataRowHelper.ObtenerSiguienteId(dt, "Id");
                dr["Id"] = nuevoId;
                AsignarDatos(dr, entidad);
                dt.Rows.Add(dr);
                entidad.Id = nuevoId;
            }
            _datos.Actualizar_BD(ds);
        }

        public void Modificar(Agenda entidad)
        {
            ModificarEntidad(entidad, AsignarDatos);
        }

        public void Eliminar(Agenda entidad)
        {
            EliminarEntidad(entidad);
        }

        public void EliminarAgendas(List<Agenda> entidades)
        {
            var ds = _datos.Obtener_Datos();

            foreach (var entidad in entidades)
            {
                ArgumentNullException.ThrowIfNull(entidad);
                var dr = ds.Tables[NombreTabla].AsEnumerable().FirstOrDefault(r => Convert.ToInt64(r["Id"]) == entidad.Id);
                dr?.Delete();
            }

            _datos.Actualizar_BD(ds);
        }

        public bool Existe(Agenda entidad)
        {
            var ds = _datos.Obtener_Datos();
            return ds.Tables[NombreTabla].AsEnumerable()
                .Any(r =>
                    Convert.ToDateTime(r["Fecha"]) == entidad.Fecha &&
                    TimeSpan.Parse(r["HoraInicio"].ToString()) == entidad.HoraInicio &&
                    Convert.ToInt64(r["MedicoId"]) == entidad.MedicoId);
        }

        public bool TieneDependencias(Agenda entidad)
        {
            return TieneDependenciasEnTabla(entidad.Id, "Turno", "AgendaId");
        }

        public IList<Agenda> ObtenerTodos()
        {
            return ObtenerTodasEntidades(HidratarObjeto);
        }

        public Agenda LeerPorId(object id)
        {
            return LeerEntidadPorId(id, HidratarObjeto);
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
            return ObtenerTodos()
                .Where(a => a.MedicoId == medicoId &&
                            a.Fecha >= fechadesde &&
                            a.Fecha <= fechahasta)
                .ToList();
        }

        private void AsignarDatos(DataRow dr, Agenda entidad)
        {
            dr["Fecha"] = entidad.Fecha;
            dr["HoraInicio"] = entidad.HoraInicio.ToString(@"hh\:mm");
            dr["HoraFin"] = entidad.HoraFin.ToString(@"hh\:mm");
            dr["MedicoId"] = entidad.MedicoId;
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