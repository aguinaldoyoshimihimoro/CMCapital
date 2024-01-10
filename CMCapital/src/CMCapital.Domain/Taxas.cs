using System;
using System.ComponentModel.DataAnnotations;

namespace CMCapital.Domain
{
    public class Taxas
    {
        [Key]
        public int Id_Cod_Taxa { get; set; }
        public double Vr_Inicial { get; set; }
        public double Vr_Final { get; set; }
        public double Percentual { get; set; }
    }
}

