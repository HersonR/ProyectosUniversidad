using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal01.Models
{
    public class Curso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoCurso { get; set; }

        [ForeignKey("CatedraticoModel")]
        public int CodigoCatedratico { get; set; }

        public string NombresCurso { get; set; }
        public int NotaCurso { get; set; }
        public string EstadoNota { get; set; }
    }
}
