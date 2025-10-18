using System;
using System.Collections.Generic;
using SiAP.Abstracciones;
using SiAP.BLL.Logs;
using SiAP.MPP;
using Policonsultorio.BE;

namespace SiAP.BLL
{
    public class BLL_Receta : IBLL<Receta>
    {
        private readonly MPP_Receta _mppReceta;
        private static BLL_Receta _instancia;
        private readonly ILogger _logger;
        private string _mensajeError;
        public string MensajeError => _mensajeError;

        private BLL_Receta()
        {
            _mppReceta = MPP_Receta.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        public static BLL_Receta ObtenerInstancia()
        {
            return _instancia ??= new BLL_Receta();
        }

        public void Agregar(Receta receta)
        {
            if (!EsValido(receta))
                throw new ArgumentException(MensajeError);

            if (_mppReceta.Existe(receta))
                throw new InvalidOperationException("La receta ya existe.");

            _mppReceta.Agregar(receta);
            _logger.GenerarLog($"Receta agregada - Profesional: {receta.Profesional}, Fecha: {receta.Fecha.ToShortDateString()}");
        }

        public void Modificar(Receta receta)
        {
            if (!EsValido(receta))
                throw new ArgumentException(MensajeError);

            _mppReceta.Modificar(receta);
            _logger.GenerarLog($"Receta modificada - ID: {receta.Id}");
        }

        public void Eliminar(Receta receta)
        {
            if (_mppReceta.TieneDependencias(receta))
                throw new InvalidOperationException("La receta tiene dependencias y no puede eliminarse.");

            _mppReceta.Eliminar(receta);
            _logger.GenerarLog($"Receta eliminada - ID: {receta.Id}");
        }

        public IList<Receta> ObtenerTodos()
        {
            return _mppReceta.ObtenerTodos();
        }

        public Receta Leer(long recetaId)
        {
            return _mppReceta.LeerPorId(recetaId);
        }




        public IList<Receta> BuscarPorConsulta(long consultaId)
        {
            if (consultaId <= 0)
                throw new ArgumentException("El ID de la consulta debe ser válido.");

            return _mppReceta.BuscarPorConsultaId(consultaId);
        }


        public IList<Receta> ObtenerCronicasVigentes()
        {
            return _mppReceta.BuscarCronicasVigentes();
        }


        public IList<Receta> BuscarPorNumeroSocio(int numeroSocio)
        {
            if (numeroSocio <= 0)
                throw new ArgumentException("El número de socio debe ser válido.");

            return _mppReceta.BuscarPorNumeroSocio(numeroSocio);
        }


        public IList<Receta> BuscarPorRangoFechas(DateTime desde, DateTime hasta)
        {
            if (hasta < desde)
                throw new ArgumentException("La fecha 'hasta' debe ser posterior a la fecha 'desde'.");

            return _mppReceta.BuscarPorRangoFechas(desde, hasta);
        }


        public Receta RenovarReceta(long recetaId)
        {
            var recetaOriginal = _mppReceta.LeerPorId(recetaId);

            if (recetaOriginal == null)
                throw new InvalidOperationException("Receta no encontrada.");

            var recetaRenovada = recetaOriginal.RenovarReceta();
            Agregar(recetaRenovada);

            _logger.GenerarLog($"Receta renovada - Original ID: {recetaId}, Nueva ID: {recetaRenovada.Id}");

            return recetaRenovada;
        }

        public bool EsValido(Receta receta)
        {
            _mensajeError = "";

            if (receta == null)
            {
                _mensajeError = "La receta no puede ser nula. ";
                return false;
            }

            if (string.IsNullOrWhiteSpace(receta.Medicamentos))
                _mensajeError += "Los medicamentos son obligatorios. ";

            if (string.IsNullOrWhiteSpace(receta.Profesional))
                _mensajeError += "El profesional es obligatorio. ";

            if (receta.Fecha == default(DateTime))
                _mensajeError += "La fecha es obligatoria. ";

            if (receta.Fecha > DateTime.Now)
                _mensajeError += "La fecha no puede ser futura. ";

            if (receta.EsCronica && receta.Nro_Socio <= 0)
                _mensajeError += "Las recetas crónicas requieren número de socio. ";

            return string.IsNullOrEmpty(_mensajeError);
        }
    }
}