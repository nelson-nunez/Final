using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.MPP.Base;
using Policonsultorio.BE;

namespace SiAP.MPP
{
    public class MPP_Consulta : MapperBase<Consulta>, IMapper<Consulta>
    {
        private readonly MPP_Medico _mppMedico;
        private readonly MPP_Receta _mppReceta;
        private readonly MPP_Certificado _mppCertificado;
        private static MPP_Consulta _instancia;
        protected override string NombreTabla => "Consulta";

        private MPP_Consulta() : base()
        {
            _mppMedico = MPP_Medico.ObtenerInstancia();
            _mppReceta = MPP_Receta.ObtenerInstancia();
            _mppCertificado = MPP_Certificado.ObtenerInstancia();
        }

        public static MPP_Consulta ObtenerInstancia()
        {
            return _instancia ??= new MPP_Consulta();
        }

        public void Agregar(Consulta entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            ArgumentNullException.ThrowIfNull(entidad.Medico, "La consulta debe tener un médico asociado");

            if (Existe(entidad))
                return;

            AgregarEntidad(entidad, AsignarDatos);
        }

        public void Modificar(Consulta entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            ArgumentNullException.ThrowIfNull(entidad.Medico, "La consulta debe tener un médico asociado");

            ModificarEntidad(entidad, AsignarDatos);
        }

        public void Eliminar(Consulta entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            EliminarEntidad(entidad);
        }

        public bool Existe(Consulta entidad)
        {
            return ExisteEntidad(entidad);
        }

        public bool TieneDependencias(Consulta entidad)
        {
            return TieneDependenciasEnTabla(entidad.Id, "Receta", "ConsultaId") ||
                   TieneDependenciasEnTabla(entidad.Id, "Certificado", "ConsultaId");
        }

        public IList<Consulta> ObtenerTodos()
        {
            return ObtenerTodasEntidades(HidratarObjeto);
        }

        public Consulta LeerPorId(object id)
        {
            return LeerEntidadPorId(id, HidratarObjeto);
        }

        public IList<Consulta> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var consultas = ObtenerTodos();

            if (string.IsNullOrWhiteSpace(campo) || string.IsNullOrWhiteSpace(valor))
                return consultas;

            return campo.ToLower() switch
            {
                "medicoid" => consultas.Where(c => c.Medico?.Id == Convert.ToInt64(valor)).ToList(),
                "historiaclinicaid" => consultas.Where(c => c.HistoriaClinica?.Id == Convert.ToInt64(valor)).ToList(),
                "diagnostico" => consultas.Where(c => c.Diagnostico?.Contains(valor, StringComparison.OrdinalIgnoreCase) ?? false).ToList(),
                _ => throw new ArgumentException($"Campo '{campo}' inválido.")
            };
        }

        /// Busca todas las consultas de una historia clínica específica
        public IList<Consulta> BuscarPorHistoriaClinicaId(long historiaClinicaId)
        {
            var ds = _datos.ObtenerDatos_BDSiAP();
            var consultas = ds.Tables[NombreTabla].AsEnumerable()
                .Where(r => Convert.ToInt64(r["HistoriaClinicaId"]) == historiaClinicaId)
                .Select(HidratarObjeto)
                .OrderByDescending(c => c.Fecha)
                .ToList();

            return consultas;
        }

        /// Busca consultas por médico
        public IList<Consulta> BuscarPorMedicoId(long medicoId)
        {
            return ObtenerTodos()
                .Where(c => c.Medico?.Id == medicoId)
                .OrderByDescending(c => c.Fecha)
                .ToList();
        }

        /// Busca consultas en un rango de fechas
        public IList<Consulta> BuscarPorRangoFechas(DateTime desde, DateTime hasta)
        {
            return ObtenerTodos()
                .Where(c => c.Fecha >= desde && c.Fecha <= hasta)
                .OrderByDescending(c => c.Fecha)
                .ToList();
        }

        private void AsignarDatos(DataRow dr, Consulta entidad)
        {
            dr["HistoriaClinicaId"] = entidad.HistoriaClinica?.Id ?? 0;
            dr["MedicoId"] = entidad.Medico?.Id ?? 0;
            dr["Fecha"] = entidad.Fecha;
            dr["Motivo"] = entidad.Motivo ?? string.Empty;
            dr["Diagnostico"] = entidad.Diagnostico ?? string.Empty;
            dr["Tratamiento"] = entidad.Tratamiento ?? string.Empty;
            dr["Observaciones"] = entidad.Observaciones ?? string.Empty;
        }

        private Consulta HidratarObjeto(DataRow rConsulta)
        {
            var medicoId = Convert.ToInt64(rConsulta["MedicoId"]);
            var medico = _mppMedico.LeerPorId(medicoId);

            var consultaId = Convert.ToInt64(rConsulta["Id"]);

            var consulta = new Consulta
            {
                Id = consultaId,
                Medico = medico,
                Fecha = Convert.ToDateTime(rConsulta["Fecha"]),
                Motivo = rConsulta["Motivo"]?.ToString() ?? string.Empty,
                Diagnostico = rConsulta["Diagnostico"]?.ToString() ?? string.Empty,
                Tratamiento = rConsulta["Tratamiento"]?.ToString() ?? string.Empty,
                Observaciones = rConsulta["Observaciones"]?.ToString() ?? string.Empty
            };
            CargarRecetasYCertificados(consulta);
            return consulta;
        }

        private void CargarRecetasYCertificados(Consulta consulta)
        {
            // Cargar recetas
            var recetas = _mppReceta.BuscarPorConsultaId(consulta.Id);
            if (recetas != null && recetas.Any())
            {
                consulta.Recetas = recetas.ToList();
            }

            // Cargar certificados
            var certificados = _mppCertificado.BuscarPorConsultaId(consulta.Id);
            if (certificados != null && certificados.Any())
            {
                consulta.Certificados = certificados.ToList();
            }
        }
    }
}