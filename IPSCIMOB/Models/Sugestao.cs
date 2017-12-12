﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPSCIMOB.Models
{
    public class Sugestao
    {
        [Key]
        public int SugestaoID { get; set; }
        public String EmailUtilizador { get; set; }
        public String TextoSugestao { get; set; }
    }
}