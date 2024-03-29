using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models;

public class Capital
{
    [Key]
    public int CapitalId { get; set; }

    public decimal Efectivo { get; set; }
}
