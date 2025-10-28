using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using Policonsultorio.BE;
using SiAP.MPP;
using SiAP.BE;

namespace SiAP.BLL
{
    public class BLL_Medicamento
    {
        private static BLL_Medicamento _instancia;
        private readonly MPP_Medicamento _mapper;

        private BLL_Medicamento()
        {
            _mapper = MPP_Medicamento.ObtenerInstancia();
        }

        public static BLL_Medicamento ObtenerInstancia()
        {
            return _instancia ??= new BLL_Medicamento();
        }

        public void Agregar(Medicamento Medicamento)
        {
            try
            {
                ValidarDroga(Medicamento);
                _mapper.Agregar(Medicamento);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar Medicamento: {ex.Message}", ex);
            }
        }

        public void Modificar(Medicamento Medicamento)
        {
            try
            {
                ValidarDroga(Medicamento);
                _mapper.Modificar(Medicamento);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al modificar Medicamento: {ex.Message}", ex);
            }
        }

        public void Eliminar(Medicamento Medicamento)
        {
            try
            {
                if (Medicamento == null)
                    throw new ArgumentNullException(nameof(Medicamento));

                _mapper.Eliminar(Medicamento);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar Medicamento: {ex.Message}", ex);
            }
        }

        public Medicamento LeerPorId(long id)
        {
            try
            {
                return _mapper.LeerPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al leer Medicamento por ID: {ex.Message}", ex);
            }
        }

        public IList<Medicamento> ObtenerTodos()
        {
            try
            {
                return _mapper.ObtenerTodos();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener todas las drogas: {ex.Message}", ex);
            }
        }

        public IList<Medicamento> BuscarPorRecetaId(long recetaId)
        {
            try
            {
                return _mapper.BuscarPorRecetaId(recetaId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar drogas por receta: {ex.Message}", ex);
            }
        }

        public IList<Medicamento> BuscarPorNombreComercial(string nombre)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre))
                    return new List<Medicamento>();

                return _mapper.Buscar("nombrecomercial", nombre);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar drogas por nombre comercial: {ex.Message}", ex);
            }
        }

        public IList<Medicamento> BuscarPorNombreMonodroga(string nombre)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombre))
                    return new List<Medicamento>();

                return _mapper.Buscar("nombremonodroga", nombre);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar drogas por nombre monodroga: {ex.Message}", ex);
            }
        }

        public void EliminarPorRecetaId(long recetaId)
        {
            try
            {
                _mapper.EliminarPorRecetaId(recetaId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar drogas de la receta: {ex.Message}", ex);
            }
        }

        public void AgregarMedicamentosAReceta(long recetaId, List<Medicamento> medicamentos)
        {
            try
            {
                if (medicamentos == null || !medicamentos.Any())
                    return;

                foreach (var Medicamento in medicamentos)
                {
                    Medicamento.RecetaId = recetaId;
                    ValidarDroga(Medicamento);
                    _mapper.Agregar(Medicamento);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar medicamentos a la receta: {ex.Message}", ex);
            }
        }

        public void ActualizarMedicamentosDeReceta(long recetaId, List<Medicamento> medicamentos)
        {
            try
            {
                EliminarPorRecetaId(recetaId);

                if (medicamentos != null && medicamentos.Any())
                {
                    AgregarMedicamentosAReceta(recetaId, medicamentos);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar medicamentos de la receta: {ex.Message}", ex);
            }
        }

        public int ContarMedicamentosPorReceta(long recetaId)
        {
            try
            {
                return BuscarPorRecetaId(recetaId).Count;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al contar medicamentos de la receta: {ex.Message}", ex);
            }
        }

        public bool TieneMedicamentos(long recetaId)
        {
            try
            {
                return BuscarPorRecetaId(recetaId).Any();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al verificar si tiene medicamentos: {ex.Message}", ex);
            }
        }

        private void ValidarDroga(Medicamento Medicamento)
        {
            if (Medicamento == null)
                throw new ArgumentNullException(nameof(Medicamento), "La Medicamento no puede ser nula");

            if (string.IsNullOrWhiteSpace(Medicamento.NombreComercial) &&
                string.IsNullOrWhiteSpace(Medicamento.NombreMonodroga))
                throw new ArgumentException("La Medicamento debe tener al menos un nombre (comercial o monodroga)");

            if (Medicamento.Cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a cero");

            if (Medicamento.RecetaId <= 0)
                throw new ArgumentException("La Medicamento debe estar asociada a una receta válida");
        }
    }
}
