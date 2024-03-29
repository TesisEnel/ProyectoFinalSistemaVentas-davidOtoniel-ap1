using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class Banco
{
    [Key]
    public int BancoId { get; set; }

    public string Usuario { get; set; }

    public string NumeroTarjeta { get; set; }

    public DateTime FechaVencimiento { get; set; }

    public int CodigoSeguridad { get; set; }

    public decimal Monto { get; set; }

}
