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
        [Display(Name = "Aceite")]
        Aceite,
        [Display(Name = "Recusado")]
        Recusado,
        [Display(Name = "Entrevistado")]
        Entrevistado
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
        [Display(Name = "Estado da Entrevista")]
        public EstadoEntrevista Estado { get; set; }

        [Display(Name = "Nome do Programa")]
        public String NomePrograma { get; set; }

    }
}
