using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IPSCIMOB.Models
{
    public enum EstadoEntrevista
    {
        [Display(Name = "Em espera")]
        EmEspera,
        Aceite,
        Recusado,
        Entrevistado,

    }

    public class Entrevista
    {
        [Key]
        public int EntrevistaId { get; set; }

        [Display(Name = "Número Interno")]
        public int? NumeroAluno{ get; set; }


       
        [Display(Name = "Email")]
        public String Email { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy HH:mm:ss}")]
        [Display(Name = "Data de Entrevista")]
        public DateTime DataDeEntrevista { get; set; }

        [EnumDataType(typeof(EstadoEntrevista))]
        [Display(Name = "Estado da Candidatura")]
        public EstadoEntrevista Estado { get; set; }

    }
}
