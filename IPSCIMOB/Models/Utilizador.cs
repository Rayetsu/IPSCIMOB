using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPSCIMOB.Models
{
    public class Utilizador
    {
        [Key]
        public int UtilizadorID { get; set; }
        [Required]
        public string NomeCompleto { get; set; }
        [Required]
        [RegularExpression(@"[0-9]{9,9}", ErrorMessage = "Tem de ser um número com 9 digitos")]
        public int NumeroInterno { get; set; }
        [Required]
        [RegularExpression(@"[0-9]{9,9}", ErrorMessage = "Tem de ser um número com 9 digitos")]
        public int NumeroDoBI { get; set; }
        public string Curso { get; set; }
        public string Ano { get; set; }
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        [Display(Name = "Data de Nascimento", Prompt = "Ex: 10/10/2017")]
        public DateTime DataDeNascimento { get; set; }
        [Required]
        public string Morada { get; set; }
        [Required]
        [RegularExpression(@"[0-9]{9,9}", ErrorMessage = "Tem de ser um número com 9 digitos")]
        public int Telefone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string PalavraPasse { get; set; }
        public bool PartilhaMobilidade { get; set; }
        public bool IsAdministrador { get; set; }
    }
}
