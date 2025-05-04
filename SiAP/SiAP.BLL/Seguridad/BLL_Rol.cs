using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;
using SiAP.BE.Seguridad;
using SiAP.MPP.Seguridad;

namespace SiAP.BLL.Seguridad
{
    public class BLL_Rol : IBLL<Rol>
    {
        private readonly MPP_Rol _mppRol;
        private static BLL_Rol _bllRol;
        private ILogger _logger;

        private string _mensajeError;

        public string MensajeError => _mensajeError;

        private BLL_Rol()
        {
            _mppRol = MPP_Rol.ObtenerInstancia();
            _logger = BLLLog.ObtenerInstancia();
        }

        public static BLL_Rol ObtenerInstancia()
        {
            return _bllRol ??= new BLL_Rol();
        }

        public void Agregar(Rol objeto)
        {
            if (!EsValido(objeto))
                throw new ArgumentException(MensajeError);

            if (_mppRol.Existe(objeto))
                throw new InvalidOperationException("El rol ya existe.");

            _mppRol.Agregar(objeto);
            _logger.GenerarLog($"Rol agregado: {objeto.Codigo}");
        }

        public void Modificar(Rol objeto, string valorUnicoAnterior = null)
        {
            if (!EsValido(objeto))
                throw new ArgumentException(MensajeError);

            _mppRol.Modificar(objeto, valorUnicoAnterior);
            _logger.GenerarLog($"Rol modificado: {objeto.Codigo}");
        }

        public void Eliminar(Rol objeto)
        {
            if (_mppRol.TieneDependencias(objeto))
                throw new InvalidOperationException("El rol tiene dependencias y no puede eliminarse.");

            _mppRol.Eliminar(objeto);
            _logger.GenerarLog($"Rol eliminado: {objeto.Codigo}");
        }

        public IList<Rol> ObtenerTodos()
        {
            return _mppRol.ObtenerTodos();
        }

        public Rol Leer(Rol objeto)
        {
            return _mppRol.LeerPorId(objeto.Codigo);
        }

        public bool EsValido(Rol objeto)
        {
            _mensajeError = "";

            if (string.IsNullOrWhiteSpace(objeto.Codigo))
                _mensajeError += "El código es obligatorio. ";

            if (string.IsNullOrWhiteSpace(objeto.Descripcion))
                _mensajeError += "La descripción es obligatoria. ";

            return string.IsNullOrEmpty(_mensajeError);
        }
    }
}



