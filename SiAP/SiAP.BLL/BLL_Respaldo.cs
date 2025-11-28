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
    public class BLL_Respaldo : IBLL<Respaldo>
    {
        private readonly MPP_Respaldo _mppRespaldo;
        private static BLL_Respaldo _instancia;
        private readonly ILogger _logger;
        private string _mensajeError;

        public string MensajeError => _mensajeError;

        private BLL_Respaldo()
        {
            _mppRespaldo = MPP_Respaldo.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        public static BLL_Respaldo ObtenerInstancia()
        {
            return _instancia ??= new BLL_Respaldo();
        }

        public void Agregar(Respaldo respaldo)
        {
            try
            {
                respaldo.CreadoPor = GestionUsuario.UsuarioLogueado.Username;
                respaldo.FechaCreacion = DateTime.Now;

                if (!EsValido(respaldo))
                    throw new ArgumentException(MensajeError);

                if (_mppRespaldo.Existe(respaldo))
                    throw new InvalidOperationException("Ya existe un respaldo con ese nombre.");

                _mppRespaldo.Agregar(respaldo);
                _logger.GenerarLog($"Respaldo creado: {respaldo.NombreArchivo} - {respaldo.Descripcion}");
            }
            catch (Exception ex)
            {
                _logger.GenerarLog($"Error al crear respaldo {respaldo.NombreArchivo}: {ex.Message}");
                throw new InvalidOperationException($"No se pudo crear el respaldo: {ex.Message}", ex);
            }
        }

        public void Modificar(Respaldo respaldo)
        {
            if (!EsValido(respaldo))
                throw new ArgumentException(MensajeError);

            try
            {
                _mppRespaldo.Modificar(respaldo);
                _logger.GenerarLog($"Respaldo modificado: {respaldo.NombreArchivo}");
            }
            catch (Exception ex)
            {
                _logger.GenerarLog($"Error al modificar respaldo {respaldo.NombreArchivo}: {ex.Message}");
                throw new InvalidOperationException($"No se pudo modificar el respaldo: {ex.Message}", ex);
            }
        }

        public void Eliminar(Respaldo respaldo)
        {
            if (_mppRespaldo.TieneDependencias(respaldo))
                throw new InvalidOperationException("El respaldo tiene dependencias y no puede eliminarse.");

            try
            {
                _mppRespaldo.Eliminar(respaldo);
                _logger.GenerarLog($"Respaldo eliminado: {respaldo.NombreArchivo}");
            }
            catch (Exception ex)
            {
                _logger.GenerarLog($"Error al eliminar respaldo {respaldo.NombreArchivo}: {ex.Message}");
                throw new InvalidOperationException($"No se pudo eliminar el respaldo: {ex.Message}", ex);
            }
        }

        public IList<Respaldo> ObtenerTodos()
        {
            return _mppRespaldo.ObtenerTodos();
        }

        public Respaldo Leer(long respaldoId)
        {
            return _mppRespaldo.LeerPorId(respaldoId);
        }

        //Otros
        public void RestaurarRespaldo(Respaldo respaldo)
        {
            if (respaldo == null)
                throw new ArgumentNullException(nameof(respaldo));

            if (!_mppRespaldo.Existe(respaldo))
                throw new InvalidOperationException("El respaldo especificado no existe.");

            try
            {
                _mppRespaldo.RestaurarRespaldo(respaldo);
                _logger.GenerarLog($"Respaldo restaurado: {respaldo.NombreArchivo}");
            }
            catch (Exception ex)
            {
                _logger.GenerarLog($"Error al restaurar respaldo {respaldo.NombreArchivo}: {ex.Message}");
                throw new InvalidOperationException($"No se pudo restaurar el respaldo: {ex.Message}", ex);
            }
        }

        public IList<Respaldo> FiltrarPorFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            if (fechaDesde > fechaHasta)
                throw new ArgumentException("La fecha desde no puede ser mayor a la fecha hasta.");

            return _mppRespaldo.FiltrarPorFecha(fechaDesde, fechaHasta);
        }

        public bool EsValido(Respaldo respaldo)
        {
            _mensajeError = "";

            if (respaldo == null)
            {
                _mensajeError = "El respaldo no puede ser nulo. ";
                return false;
            }

            if (string.IsNullOrWhiteSpace(respaldo.NombreArchivo))
                _mensajeError += "El nombre del archivo es obligatorio. ";

            if (respaldo.NombreArchivo?.Length > 100)
                _mensajeError += "El nombre del archivo no puede exceder 100 caracteres. ";

            if (respaldo.FechaCreacion == default)
                _mensajeError += "La fecha de creación es obligatoria. ";

            if (respaldo.FechaCreacion > DateTime.Now)
                _mensajeError += "La fecha de creación no puede ser futura. ";

            if (string.IsNullOrWhiteSpace(respaldo.CreadoPor))
                _mensajeError += "El usuario creador es obligatorio. ";

            if (respaldo.TamanioKB < 0)
                _mensajeError += "El tamaño no puede ser negativo. ";

            // Validar caracteres inválidos en el nombre del archivo
            if (!string.IsNullOrWhiteSpace(respaldo.NombreArchivo))
            {
                var caracteresInvalidos = Path.GetInvalidFileNameChars();
                if (respaldo.NombreArchivo.Any(c => caracteresInvalidos.Contains(c)))
                    _mensajeError += "El nombre del archivo contiene caracteres inválidos. ";
            }

            return string.IsNullOrEmpty(_mensajeError);
        }
    }
}
