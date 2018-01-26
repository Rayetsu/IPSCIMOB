using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPSCIMOB.Models
{
    public enum UtilizadorProfissao
    {
        [Display(Name = "Funcionário")]
        Funcionario,
        [Display(Name = "Aluno")]
        Aluno,
        [Display(Name = "Funcionário E Aluno")]
        FuncionarioAluno
    }

    public class ProgramaModel
    {

        [Key]
        public int ProgramaID { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Programa Atual")]
        public Boolean ProgramaAtual { get; set; }

        [Display(Name = "Profissão Indicada")]
        public UtilizadorProfissao UtilizadorProfissao { get; set; }
    }
}
