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
        [StringLength(50)]
        public string Nome { get; set; }

        public int NumeroInterno { get; set; }

        public int NumeroDoBI { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataDeNascimento { get; set; }

        [StringLength(50)]
        public string Morada { get; set; }

        public int Telefone { get; set; }

        public bool PartilhaMobilidade { get; set; }

        public bool IsFuncionario { get; set; }

        public bool IsDadosVerificados { get; set; }
    }
}
