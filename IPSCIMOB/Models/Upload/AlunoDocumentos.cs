using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPSCIMOB.Models.Upload
{
    public class AlunoDocumentos
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Número Interno")]
        public int? NumeroAluno { get; set; }



        [Display(Name = "Email")]
        public String Email { get; set; }

        [Required]
        [Display(Name = "Nome documento")]
        public String Documento { get; set; }

        
        }
}
