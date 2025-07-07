using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.BLL.Logs;
using SiAP.BLL.Seguridad;
using SiAP.MPP;

namespace SiAP.BLL
{
    public class BLL_Paciente : IBLL<Paciente>
    {
        private readonly MPP_Paciente _mppPaciente;
        private static BLL_Paciente _instancia;
        private readonly ILogger _logger;
        private string _mensajeError;
        public string MensajeError => _mensajeError;

        private BLL_Paciente()
        {
            _mppPaciente = MPP_Paciente.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        public static BLL_Paciente ObtenerInstancia()
        {
            return _instancia ??= new BLL_Paciente();
        }

        public void Agregar(Paciente paciente)
        {
            if (!EsValido(paciente))
                throw new ArgumentException(MensajeError);

            if (_mppPaciente.Existe(paciente))
                throw new InvalidOperationException("El paciente ya existe.");

            _mppPaciente.Agregar(paciente);
            _logger.GenerarLog($"Paciente agregado: {paciente.Nombre} {paciente.Apellido}");
        }

        public void Modificar(Paciente paciente)
        {
            if (!EsValido(paciente))
                throw new ArgumentException(MensajeError);

            _mppPaciente.Modificar(paciente);
            _logger.GenerarLog($"Paciente modificado: {paciente.Nombre} {paciente.Apellido}");
        }

        public void Eliminar(Paciente paciente)
        {
            if (_mppPaciente.TieneDependencias(paciente))
                throw new InvalidOperationException("El paciente tiene dependencias y no puede eliminarse.");

            _mppPaciente.Eliminar(paciente);
            _logger.GenerarLog($"Paciente eliminado: {paciente.Nombre} {paciente.Apellido}");
        }

        public IList<Paciente> ObtenerTodos()
        {
            return _mppPaciente.ObtenerTodos();
        }

        public IList<Paciente> Buscar(string parametro)
        {
            var usuarios = _mppPaciente.ObtenerTodos()
                .Where(x => string.IsNullOrWhiteSpace(parametro)
                         || x.Nombre.Contains(parametro, StringComparison.OrdinalIgnoreCase)
                         || x.Apellido.Contains(parametro, StringComparison.OrdinalIgnoreCase)
                         || x.Dni.Contains(parametro, StringComparison.OrdinalIgnoreCase)
                      )
                .ToList();

            return _mppPaciente.ObtenerTodos();
        }


        public Paciente Leer(long pacienteId)
        {
            return _mppPaciente.LeerPorId(pacienteId);
        }

        public bool EsValido(Paciente paciente)
        {
            _mensajeError = "";

            if (string.IsNullOrWhiteSpace(paciente.Nombre))
                _mensajeError += "El nombre es obligatorio. ";

            if (string.IsNullOrWhiteSpace(paciente.Apellido))
                _mensajeError += "El apellido es obligatorio. ";

            if (string.IsNullOrWhiteSpace(paciente.Dni))
                _mensajeError += "El DNI es obligatorio. ";

            if (string.IsNullOrWhiteSpace(paciente.Email))
                _mensajeError += "El email es obligatorio. ";

            if (string.IsNullOrWhiteSpace(paciente.ObraSocial))
                _mensajeError += "La obra social es obligatoria. ";

            return string.IsNullOrEmpty(_mensajeError);
        }
    }

}
