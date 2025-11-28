using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using SiAP.Abstracciones;
using SiAP.MPP.Base;
using Policonsultorio.BE;
using SiAP.BE;

namespace SiAP.MPP
{
    public class MPP_Medicamento : MapperBase<Medicamento>, IMapper<Medicamento>
    {
        private static MPP_Medicamento _instancia;
        protected override string NombreTabla => "Medicamento";

        private MPP_Medicamento() : base() { }

        public static MPP_Medicamento ObtenerInstancia()
        {
            return _instancia ??= new MPP_Medicamento();
        }

        public void Agregar(Medicamento entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);

            if (Existe(entidad))
                return;

            AgregarEntidad(entidad, AsignarDatos);
        }

        public void Modificar(Medicamento entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            ModificarEntidad(entidad, AsignarDatos);
        }

        public void Eliminar(Medicamento entidad)
        {
            ArgumentNullException.ThrowIfNull(entidad);
            EliminarEntidad(entidad);
        }

        public bool Existe(Medicamento entidad)
        {
            return ExisteEntidad(entidad);
        }

        public bool TieneDependencias(Medicamento entidad)
        {
            return false;
        }

        public IList<Medicamento> ObtenerTodos()
        {
            return ObtenerTodasEntidades(HidratarObjeto);
        }

        public Medicamento LeerPorId(object id)
        {
            return LeerEntidadPorId(id, HidratarObjeto);
        }

        public void AsignarDatos(DataRow dr, Medicamento entidad)
        {
            dr["RecetaId"] = entidad.RecetaId;
            dr["NombreComercial"] = entidad.NombreComercial ?? string.Empty;
            dr["NombreMonodroga"] = entidad.NombreMonodroga ?? string.Empty;
            dr["Cantidad"] = entidad.Cantidad;
        }

        public Medicamento HidratarObjeto(DataRow r)
        {
            return new Medicamento
            {
                Id = Convert.ToInt64(r["Id"]),
                RecetaId = r["RecetaId"] != DBNull.Value ? Convert.ToInt64(r["RecetaId"]) : 0,
                NombreComercial = r["NombreComercial"]?.ToString() ?? string.Empty,
                NombreMonodroga = r["NombreMonodroga"]?.ToString() ?? string.Empty,
                Cantidad = r["Cantidad"] != DBNull.Value ? Convert.ToInt32(r["Cantidad"]) : 0
            };
        }

        //Otros
        public IList<Medicamento> BuscarPorRecetaId(long recetaId)
        {
            return ObtenerTodos().Where(d => d.RecetaId == recetaId).ToList();
        }

        public void EliminarPorRecetaId(long recetaId)
        {
            var Medicamentos = BuscarPorRecetaId(recetaId);
            foreach (var Medicamento in Medicamentos)
            {
                Eliminar(Medicamento);
            }
        }

    }
}