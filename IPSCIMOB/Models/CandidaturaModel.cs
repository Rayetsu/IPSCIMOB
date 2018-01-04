using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace IPSCIMOB.Models
{
    public enum EstadoCandidatura
    {
        EmEspera,
        Aceite,
        Recusado,
        EmRealizacao1,
        EmRealizacao2,
        EmRealizacao3,
        EmRealizacao4,
        Desistiu
    }

    public class CandidaturaModel
    {

        [Key]
        public int CandidaturaID { get; set; }

        //[Required]
        [Display(Name = "Programa")]
        public string Programa { get; set; }

        //[Required]
        [Display(Name = "Utilizador")]
        public ApplicationUser Utilizador { get; set; }

        //[Required]
        //[Display(Name = "EntrevistaID")]
        //public EntrevistaModel Entrevista { get; set; }
        
        //public File Documentos { get; set; }
        
        //[Required]
        [Display(Name = "Nome Candidato")]
        public string Nome { get; set; }

        //[Required]
        [Display(Name = "Número Interno")]
        public string NumeroInterno { get; set; }
             

        [Display(Name = "Candidatar-me à Bolsa")]
        public bool IsBolsa { get; set; }

        [Display(Name = "Estudo")]
        public bool IsEstudo { get; set; }

        [Display(Name = "Estágio")]
        public bool IsEstagio { get; set; }

        [Display(Name = "Investigação")]
        public bool IsInvestigacao { get; set; }

        [Display(Name = "Lecionar")]
        public bool IsLecionar { get; set; }

        [Display(Name = "Formação")]
        public bool IsFormacao { get; set; }

        [Display(Name = "Declaro que li o regulamento de mobilidade")]
        public bool IsConfirmado { get; set; }

        [Display(Name = "País")]
        public string Pais { get; set; }

        [Display(Name = "Estado da Candidatura")]
        public EstadoCandidatura Estado { get; set; }



    }
}