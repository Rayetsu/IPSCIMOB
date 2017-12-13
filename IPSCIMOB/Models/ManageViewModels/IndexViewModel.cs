using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPSCIMOB.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Nome Completo")]
        [StringLength(200)]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Número Interno")]
        //[RegularExpression(@"[0-9]{9}", ErrorMessage = "Tem de ser um número com 9 digitos")]
        public int NumeroInterno { get; set; }

        [Required]
        [Display(Name = "Numero do BI")]
        //[RegularExpression(@"[0-9]{9}", ErrorMessage = "Tem de ser um número com 9 digitos")]
        public int NumeroDoBI { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        [Display(Name = "Data de Nascimento", Prompt = "Ex: 10/10/2017")]
        public DateTime DataDeNascimento { get; set; }

        [Required]
        [StringLength(50)]
        public string Morada { get; set; }

        [Display(Name = "Partilha de Mobilidade")]
        public bool PartilhaMobilidade { get; set; }

        [Required]
        //[RegularExpression(@"[0-9]{9}", ErrorMessage = "Tem de ser um número com 9 digitos")]
        public int Telefone { get; set; }

        public string StatusMessage { get; set; }
    }
}
