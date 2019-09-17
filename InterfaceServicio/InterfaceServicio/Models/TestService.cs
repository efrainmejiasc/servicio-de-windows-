using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterfaceServicio.Models
{
    public class TestService
    {

        public int Id { get; set; }

        public string Descripcion { get; set; }

        public double Cantidad { get; set; }

        public DateTime Fecha { get; set; }

        public Guid Identidad { get; set; }

        public bool Estatus { get; set; }
    }
}