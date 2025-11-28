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

        public bool EsValido(Receta receta)
        {
            _mensajeError = "";

            if (receta == null)
            {
                _mensajeError = "La receta no puede ser nula. ";
                return false;
            }

            if (receta.Medicamentos == null || !receta.Medicamentos.Any())
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