using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPSCIMOB.Models
{
    public class InstituicaoParceiraModel

    {
        [Key]
        public int InstituicaoParceiraID { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "País")]
        public string Pais { get; set; }

        [Display(Name = "Cidade")]
        public String Cidade { get; set; }
        
        [Display(Name = "Programa Pertencente")]
        public String ProgramaNome { get; set; }
    }
}
