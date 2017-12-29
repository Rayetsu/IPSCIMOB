using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IPSCIMOB.Models
{
    public class ForeignStudents 
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Nacionalidade { get; set; }

        [Required]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataDeNascimento { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Escola IPS e curso")]
        public string EscolaIPSECurso { get; set; }

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
        public string Cidade { get; set; }

        [Required]
        [StringLength(50)]
        public string Distrito { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Código Postal")]
        public string CodigoPostal { get; set; }

        [Required]
        [StringLength(50)]
        public string Universidade { get; set; }


        public int Telefone { get; set; }

        [Display(Name = "Bolseiro")]
        public bool IsBolseiro { get; set; }

        [Display(Name = "Partilha Mobilidade")]
        public bool PartilhaMobilidade { get; set; }

        [Display(Name = "Funcionário")]
        public bool IsFuncionario { get; set; }

        [Display(Name = "Dados Verificados")]
        public bool IsDadosVerificados { get; set; }
    }
}

