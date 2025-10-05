﻿using System.Data;
using SiAP.Abstracciones;
using SiAP.BE;
using SiAP.MPP.Base;

namespace SiAP.MPP
{
    public class MPP_Persona : MapperBase<Persona>, IMapper<Persona>
    {
        private static MPP_Persona _instancia;
        protected override string NombreTabla => "Persona";

        private MPP_Persona() : base() { }

        public static MPP_Persona ObtenerInstancia()
        {
            return _instancia ??= new MPP_Persona();
        }

        public void Agregar(Persona entidad)
        {
            if (Existe(entidad)) return;
            AgregarEntidad(entidad, AsignarDatos);
        }

        public void Modificar(Persona entidad)
        {
            ModificarEntidad(entidad, AsignarDatos);
        }

        public void Eliminar(Persona entidad)
        {
            EliminarEntidad(entidad);
        }

        public bool Existe(Persona entidad)
        {
            return ExisteEntidad(entidad);
        }

        public bool TieneDependencias(Persona entidad)
        {
            return TieneDependenciasEnTabla(entidad.Id, "Medico", "PersonaId") ||
                   TieneDependenciasEnTabla(entidad.Id, "Paciente", "PersonaId") ||
                   TieneDependenciasEnTabla(entidad.Id, "Secretario", "PersonaId") ||
                   TieneDependenciasEnTabla(entidad.Id, "Administrador", "PersonaId");
        }

        public IList<Persona> ObtenerTodos()
        {
            return ObtenerTodasEntidades(HidratarObjeto);
        }

        public IList<Persona> Buscar(string campo = "", string valor = "", bool incluirInactivos = true)
        {
            var personas = ObtenerTodos();

            if (string.IsNullOrWhiteSpace(campo) || string.IsNullOrWhiteSpace(valor))
                return personas;

            return campo.ToLower() switch
            {
                "nombre" => BuscarPorCampo(personas, campo, valor, p => p.Nombre),
                "apellido" => BuscarPorCampo(personas, campo, valor, p => p.Apellido),
                "dni" => BuscarPorCampo(personas, campo, valor, p => p.Dni),
                "email" => BuscarPorCampo(personas, campo, valor, p => p.Email),
                _ => throw new ArgumentException($"Campo '{campo}' inválido.")
            };
        }

        public Persona LeerPorId(object id)
        {
            return LeerEntidadPorId(id, HidratarObjeto);
        }

        public Persona LeerPorIdSinUsuario(object id)
        {
            var ds = _datos.Obtener_Datos();
            var row = ds.Tables[NombreTabla].AsEnumerable().FirstOrDefault(r => Convert.ToInt64(r["Id"]) == Convert.ToInt64(id));

            if (row == null) 
                return null;

            return new Persona
            {
                Id = Convert.ToInt64(row["Id"]),
                Nombre = row["Nombre"].ToString(),
                Apellido = row["Apellido"].ToString(),
                Dni = row["Dni"].ToString(),
                FechaNacimiento = Convert.ToDateTime(row["FechaNacimiento"]),
                Email = row["Email"].ToString(),
                Telefono = row["Telefono"].ToString()
            };
        }

        private void AsignarDatos(DataRow dr, Persona entidad)
        {
            dr["Nombre"] = entidad.Nombre;
            dr["Apellido"] = entidad.Apellido;
            dr["Dni"] = entidad.Dni;
            dr["FechaNacimiento"] = entidad.FechaNacimiento;
            dr["Email"] = entidad.Email;
            dr["Telefono"] = entidad.Telefono;
        }

        private Persona HidratarObjeto(DataRow r)
        {
            return new Persona
            {
                Id = Convert.ToInt64(r["Id"]),
                Nombre = r["Nombre"].ToString(),
                Apellido = r["Apellido"].ToString(),
                Dni = r["Dni"].ToString(),
                FechaNacimiento = Convert.ToDateTime(r["FechaNacimiento"]),
                Email = r["Email"].ToString(),
                Telefono = r["Telefono"].ToString()
            };
        }
    }
}
