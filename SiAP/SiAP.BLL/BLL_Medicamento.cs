using SiAP.MPP;
using SiAP.BE;
using Policonsultorio.BE;
using SiAP.Abstracciones;

namespace SiAP.BLL
{
    public class BLL_Medicamento : IBLL<Medicamento>
    {
        private static BLL_Medicamento _instancia;
        private readonly MPP_Medicamento _mapper;
        private string _mensajeError;
        public string MensajeError => _mensajeError;

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
                if (!EsValido(Medicamento))
                    throw new ArgumentException(MensajeError);
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
                if (!EsValido(Medicamento))
                    throw new ArgumentException(MensajeError);

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

        public Medicamento Leer(long id)
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

        public bool EsValido(Medicamento Medicamento)
        {
            _mensajeError = "";

            if (Medicamento == null)
                _mensajeError = "La Medicamento no puede ser nula";

            if (string.IsNullOrWhiteSpace(Medicamento.NombreComercial) && string.IsNullOrWhiteSpace(Medicamento.NombreMonodroga))
                _mensajeError =  "La Medicamento debe tener al menos un nombre (comercial o monodroga)";

            if (Medicamento.Cantidad <= 0)
                _mensajeError = "La cantidad debe ser mayor a cero";

            if (Medicamento.RecetaId <= 0)
                _mensajeError = "La Medicamento debe estar asociada a una receta válida";

            return true;
        }

    }
}
