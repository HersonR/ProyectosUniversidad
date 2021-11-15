using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinal01.Models
{
    public class Catedratico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodigoCatedratico { get; set; }

        public string NombresCatedratico { get; set; }
        public string ApellidosCatedratico { get; set; }
        public string EstadoCatedratico{ get; set; }

    }
}
