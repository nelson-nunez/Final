using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.BLL.Logs;
using SiAP.MPP;

namespace SiAP.BLL
{
    public class BLL_Medico : IBLL<Medico>
    {
        private readonly MPP_Medico _mppMedico;
        private static BLL_Medico _instancia;
        private readonly ILogger _logger;
        private string _mensajeError;
        public string MensajeError => _mensajeError;

        private BLL_Medico()
        {
            _mppMedico = MPP_Medico.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        public static BLL_Medico ObtenerInstancia()
        {
            return _instancia ??= new BLL_Medico();
        }

        public void Agregar(Medico medico)
        {
            if (!EsValido(medico))
                throw new ArgumentException(MensajeError);

            if (_mppMedico.Existe(medico))
                throw new InvalidOperationException("El médico ya existe.");

            _mppMedico.Agregar(medico);
            _logger.GenerarLog($"Médico agregado: {medico.Nombre} {medico.Apellido}");
        }

        public void Modificar(Medico medico)
        {
            if (!EsValido(medico))
                throw new ArgumentException(MensajeError);

            _mppMedico.Modificar(medico);
            _logger.GenerarLog($"Médico modificado: {medico.Nombre} {medico.Apellido}");
        }

        public void Eliminar(Medico medico)
        {
            if (_mppMedico.TieneDependencias(medico))
                throw new InvalidOperationException("El médico tiene dependencias y no puede eliminarse.");

            _mppMedico.Eliminar(medico);
            _logger.GenerarLog($"Médico eliminado: {medico.Nombre} {medico.Apellido}");
        }

        public IList<Medico> ObtenerTodos()
        {
            return _mppMedico.ObtenerTodos();
        }

        public Medico Leer(long medicoId)
        {
            return _mppMedico.LeerPorId(medicoId);
        }

        public bool EsValido(Medico medico)
        {
            _mensajeError = "";

            if (string.IsNullOrWhiteSpace(medico.Nombre))
                _mensajeError += "El nombre es obligatorio. ";

            if (string.IsNullOrWhiteSpace(medico.Apellido))
                _mensajeError += "El apellido es obligatorio. ";

            if (string.IsNullOrWhiteSpace(medico.Dni))
                _mensajeError += "El DNI es obligatorio. ";

            if (string.IsNullOrWhiteSpace(medico.Titulo))
                _mensajeError += "El título es obligatorio. ";

            if (string.IsNullOrWhiteSpace(medico.Email))
                _mensajeError += "El email es obligatorio. ";

            return string.IsNullOrEmpty(_mensajeError);
        }
    }
}
