using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppGestionEMS.Models
{
    public class Matriculas
    {
        public int Id { get; set; }
        public int cod_ultima_matricula { get; set; }
        public int curso { get; set; }
        public String dni_alumno { get; set; }
        public GrupoClases grupo_clase { get; set; }
    }
}