using System;
using System.ComponentModel.DataAnnotations;

namespace CMCapital.Domain
{
    public class Produtos
    {
        [Key]
        public int Id_Cod_Produto { get; set; }
        public string Descricao { get; set; }
        public DateTime Dt_Vencimento { get; set; }

        public DateTime Dt_Cadastro { get; set; }

        public double Vr_Unitario { get; set; }
    }
}