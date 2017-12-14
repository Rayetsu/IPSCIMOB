using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPSCIMOB.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Nascimento", Prompt = "Ex: 10/10/2017")]
        public DateTime DataDeNascimento { get; set; }

        [Required]
        [StringLength(50)]
        public string Morada { get; set; }

        [Required]
        //[RegularExpression(@"[0-9]{9}", ErrorMessage = "Tem de ser um número com 9 digitos")]
        public int Telefone { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
