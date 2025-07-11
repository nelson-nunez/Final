﻿using SiAP.BE.Seguridad;
using SiAP.Abstracciones;
using SiAP.MPP.Seguridad;
using SiAP.BLL.Logs;

namespace SiAP.BLL.Seguridad
{
    public class BLL_Permiso : IBLL<Permiso>
    {
        private readonly MPP_Permiso _mppPermiso;
        private static BLL_Permiso _instancia;
        private readonly ILogger _logger;

        private string _mensajeError;
        public string MensajeError => _mensajeError;

        private BLL_Permiso()
        {
            _mppPermiso = MPP_Permiso.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        public static BLL_Permiso ObtenerInstancia()
        {
            return _instancia ??= new BLL_Permiso();
        }

        public void Agregar(Permiso permiso)
        {
            if (!EsValido(permiso))
                throw new ArgumentException(MensajeError);

            if (_mppPermiso.Existe(permiso))
                throw new InvalidOperationException("El permiso ya existe.");

            _mppPermiso.Agregar(permiso);
            _logger.GenerarLog($"Permiso agregado: {permiso.Codigo}");
        }

        public void Modificar(Permiso permiso)
        {
            if (!EsValido(permiso))
                throw new ArgumentException(MensajeError);

            _mppPermiso.Modificar(permiso);
            _logger.GenerarLog($"Permiso modificado: {permiso.Codigo}");
        }

        public void Eliminar(Permiso permiso)
        {
            if (_mppPermiso.TieneDependencias(permiso))
                throw new InvalidOperationException("El permiso tiene dependencias y no puede eliminarse.");

            _mppPermiso.Eliminar(permiso);
            _logger.GenerarLog($"Permiso eliminado: {permiso.Codigo}");
        }

        public void Asignar(Permiso permisopadre, Permiso permisohijo)
        {
            if (!EsValido(permisohijo))
                throw new ArgumentException(MensajeError);

            _mppPermiso.Asignar(permisopadre, permisohijo);
            _logger.GenerarLog($"Permiso asignado: {permisohijo} a {permisopadre}");
        }
        
        public void Desasignar(Permiso permisopadre, Permiso permisohijo)
        {
            if (!EsValido(permisohijo))
                throw new ArgumentException(MensajeError);

            _mppPermiso.Desasignar(permisopadre, permisohijo);
            _logger.GenerarLog($"Permiso desasignado: {permisohijo} a {permisopadre}");
        }


        public IList<Permiso> ObtenerTodos()
        {
            return _mppPermiso.ObtenerTodos();
        }

        public Permiso Leer(long permisoId)
        {
            return _mppPermiso.LeerPorId(permisoId);
        }

        public bool EsValido(Permiso permiso)
        {
            _mensajeError = "";

            if (string.IsNullOrWhiteSpace(permiso.Codigo))
                _mensajeError += "El código es obligatorio. ";

            if (string.IsNullOrWhiteSpace(permiso.Descripcion))
                _mensajeError += "La descripción es obligatoria. ";

            return string.IsNullOrEmpty(_mensajeError);
        }
    }
}
