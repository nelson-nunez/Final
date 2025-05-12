using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiAP.Abstracciones;

namespace SiAP.BE.Base
{
    public abstract class ClaseBase : IEntidad
    {
        public long Id { get; set; }
    }
}
