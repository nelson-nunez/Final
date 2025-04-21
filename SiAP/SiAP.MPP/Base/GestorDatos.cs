using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;
using SiAP.DAL;

namespace SiAP.MPP.Base
{
    public class GestorDatos : IGestorDatos
    {
        // Constructor privado para patrón Singleton
        private GestorDatos()
        {
            _datos = AccesoXML.ObtenerInstancia();
        }

        // Instancia Singleton
        private static IGestorDatos _instancia = null;
        private IAccesoDatos _datos;

        public static IGestorDatos ObtenerInstancia()
        {
            if (_instancia == null)
                _instancia = new GestorDatos();
            return _instancia;
        }

        private DataSet _dataSet = null;

        #region modo

        private bool _cachearDataSet = true;

        #endregion

        #region Accesos a datos

        public DataSet Obtener_Datos()
        {
            try
            {
                if (_dataSet == null || !_cachearDataSet)
                {
                    _dataSet = new DataSet();
                    _dataSet = _datos.Obtener_Datos(); 
                }
                return _dataSet;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public DataSet Obtener_Logs()
        {
            try
            {
                if (_dataSet == null || !_cachearDataSet)
                {
                    _dataSet = new DataSet();
                    _dataSet = _datos.Obtener_Logs(); 
                }
                return _dataSet;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public void Guardar_Datos(DataSet ds)
        {
            try
            {
                _datos.Actualizar_BD(ds); 
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Guardar_Logs(DataSet ds)
        {
            try
            {
                _datos.Actualizar_BDLogs(ds); 
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion
    }
}
