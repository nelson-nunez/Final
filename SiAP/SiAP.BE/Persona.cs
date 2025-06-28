﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.BE.Base;

namespace SiAP.BE
{
    public abstract class Persona: ClaseBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}
