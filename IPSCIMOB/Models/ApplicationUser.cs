using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IPSCIMOB.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Número Interno")]
        public int NumeroInterno { get; set; }

        [Display(Name = "Candidatura Atual")]
        public int CandidaturaAtual { get; set; }

        [Required]
        [Display(Name = "Número do BI")]
        public int NumeroDoBI { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataDeNascimento { get; set; }

        [Required]
        [StringLength(50)]
        public string Morada { get; set; }

        [Required]
        [Display(Name = "Número Da Porta")]
        public int NumeroDaPorta { get; set; }

        [StringLength(50)]
        public string Andar { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Código Postal")]
        public string CodigoPostal { get; set; }

        [Required]
        [StringLength(50)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(50)]
        public string Distrito { get; set; }

        [Required]
        [StringLength(50)]
        public string Nacionalidade { get; set; }

        public int Telefone { get; set; }

        [Display(Name = "Partilha Mobilidade")]
        public bool PartilhaMobilidade { get; set; }

        [Display(Name = "Funcionário")]
        public bool IsFuncionario { get; set; }

        [Display(Name = "Dados Verificados")]
        public bool IsDadosVerificados { get; set; }







        // modificar este
        [Display(Name = "Em Mobilidade")]
        public bool IsEmMobilidade { get; set; }
    }
}