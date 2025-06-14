using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiAP.UI.Extensiones
{
    public static class ControlExtensions
    {
        /// <summary>
        /// Busca recursivamente un control por nombre y tipo dentro del árbol de controles.
        /// </summary>
        public static T FindUserControl<T>(this Control parent, string controlName) where T : Control
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is T typed && ctrl.Name == controlName)
                    return typed;

                var result = ctrl.FindUserControl<T>(controlName);
                if (result != null)
                    return result;
            }

            return null;
        }
    }
}
