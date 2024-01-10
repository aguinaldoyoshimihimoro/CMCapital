using System;
using System.ComponentModel.DataAnnotations;

namespace CMCapital.Domain
{
    public class ClientesProdutos
    {
        [Key]
        public int Id_Cod_ClienteProduto { get; set; }
        public int Id_Cod_Cliente { get; set; }

        public int Id_Cod_Produto { get; set; }
        public DateTime Dt_Compra { get; set; }
        public double Vr_Compra { get; set; }

    }
}
