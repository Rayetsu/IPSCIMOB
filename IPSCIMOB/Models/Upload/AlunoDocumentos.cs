using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IPSCIMOB.Models.Upload
{
    public class AlunoDocumentos
    {

        [Key]
        public int InsertId { get; set; }

        [Display(Name = "Número Interno")]
        public int? NumeroAluno { get; set; }


        [Required]
        [Display(Name = "Nome documento")]
        public String Documento { get; set; }

        [Required]
        [Display(Name = "Caminho")]
        public string Caminho { get; set; }

        [Required]
        [Display(Name = "Programa")]
        public string Programa { get; set; }


    }
}
