using System;
using System.ComponentModel.DataAnnotations;

namespace CMCapital.Domain
{
    public class Clientes
    {
        [Key]
        public int Id_Cod_Cliente { get; set; }
        public string Nome { get; set; }
        public DateTime Dt_Ultima_Compra { get; set; }
        public double Saldo { get; set; }

    }
}