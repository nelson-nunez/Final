using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAP.MPP.Base
{
    public static class DataRowHelper
    {
        /// <summary>
        /// Devuelve el siguiente ID disponible (máximo + 1) de una columna tipo long.
        /// </summary>
        public static long ObtenerSiguienteId(DataTable tabla, string nombreColumna)
        {
            if (tabla == null)
                throw new ArgumentNullException(nameof(tabla));
            if (!tabla.Columns.Contains(nombreColumna))
                throw new ArgumentException($"La columna '{nombreColumna}' no existe en la tabla.");

            if (tabla.Rows.Count == 0)
                return 1;

            return tabla.AsEnumerable()
                        .Where(row => row[nombreColumna] != DBNull.Value)
                        .Select(row => Convert.ToInt64(row[nombreColumna]))
                        .DefaultIfEmpty(0)
                        .Max() + 1;
        }
    }
}
