using Microsoft.AspNetCore.Razor.TagHelpers;
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
        [Display(Name = "1ºPasso")]
        EmRealizacao1,
        [Display(Name = "2ºPasso")]
        EmRealizacao2,
        [Display(Name = "3ºPasso")]
        EmRealizacao3,
        [Display(Name = "4ºPasso")]
        EmRealizacao4,
        [Display(Name = "Em Espera")]
        EmEspera,
        [Display(Name = "Aceite")]
        Aceite,
        [Display(Name = "Recusado")]
        Recusado,
        [Display(Name = "Desistiu")]
        Desistiu,
        [Display(Name = "Em Mobilidade")]
        EmMobilidade,
        [Display(Name = "Finalizou")]
        Finalizou
    }

    

    public enum EstadoBolsa
    {
        [Display(Name = "Em Espera")]
        EmEspera,
        [Display(Name = "Aceite")]
        Aceite,
        [Display(Name = "Recusada")]
        Recusada     
    }

    public enum EstadoDocumentos
    {
        [Display(Name = "EmEspera")]
        EmEspera,
        [Display(Name = "Aceites")]
        Aceites,
        [Display(Name = "Recusados")]
        Recusados       
    }

    public enum Semestre
    {
        [Display(Name = "1ºSemestre")]
        PrimeiroSemestre,
        [Display(Name = "2ºSemestre")]
        SegundoSemestre
    }


    public class CandidaturaModel
    {

        [Key]
        public int CandidaturaID { get; set; }

        //[Required]
        [Display(Name = "Programa")]
        public string Programa { get; set; }

        [Display(Name = "Instituição")]  
        public string InstituicaoNome { get; set; }

        [Display(Name = "Instituição País")]
        public string InstituicaoPais { get; set; }

        [Display(Name = "Instituição Cidade")]
        public string InstituicaoCidade { get; set; }




        // modificar este
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data Inicio Candidatura")]
        public DateTime DataInicioCandidatura { get; set; }
        // modificar este
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data Fim Candidatura")]
        public DateTime DataFimCandidatura { get; set; }

        // modificar este
        [Display(Name = "Semestre")]
        public Semestre Semestre { get; set; }






        //[Display(Name = "InstituiçãoID")]
        //public InstituicaoParceiraModel InstituicaoID { get; set; }

        //[Required]
        [Display(Name = "Email")]
        public String Email { get; set; }

        //[Required]
        [Display(Name = "Entrevista ID")]
        public int EntrevistaID { get; set; }

        //[Required]
        [Display(Name = "Nome Candidato")]
        public string Nome { get; set; }

        //[Required]
        [Display(Name = "Número Interno")]
        public int NumeroInterno { get; set; }
             

        [Display(Name = "Candidato à Bolsa")]
        public bool IsBolsa { get; set; }

        [EnumDataType(typeof(EstadoBolsa))]
        [Display(Name = "Estado Bolsa")]
        public EstadoBolsa EstadoBolsa { get; set; }

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

        //[Required]
        [Display(Name = "Declaro que li o regulamento de mobilidade")]
        public bool IsConfirmado { get; set; }

        //[EnumDataType(typeof(Paises))]
        //[Display(Name = "País")]
        //public Paises Pais { get; set; }

        [EnumDataType(typeof(EstadoCandidatura))]
        [Display(Name = "Estado da Candidatura")]
        public EstadoCandidatura Estado { get; set; }

        [EnumDataType(typeof(EstadoDocumentos))]
        [Display(Name = "Estado dos Documentos")]
        public EstadoDocumentos EstadoDocumentos { get; set; }        

    }
}