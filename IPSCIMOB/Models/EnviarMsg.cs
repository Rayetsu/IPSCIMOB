using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPSCIMOB.Models
{
    public class EnviarMsg
    {

        [Key]
        public int EnviarId { get; set; }

        [DataType(DataType.EmailAddress), Display(Name = "Para")]
        [Required]
        public string ToEmail { get; set; }

        [Display(Name = "Assunto")]
        [DataType(DataType.MultilineText)]
        public string EMailBody { get; set; }

        [Display(Name = "Conteúdo")]
        public string EmailSubject { get; set; }
    }
}
