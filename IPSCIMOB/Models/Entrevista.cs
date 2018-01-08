using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IPSCIMOB.Models
{
    public class Entrevista
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public int NumeroAluno{ get; set; }


        [Required]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm:ss}")]
        [Display(Name = "Data de Entrevista")]
        public DateTime DataDeEntrevista { get; set; }
        

       
    }
}
