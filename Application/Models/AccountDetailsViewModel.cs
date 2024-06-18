using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class AccountDetailsViewModel
    {
        public string Name { get; init; } = string.Empty;
        public string Nickname { get; init; } = string.Empty;
        public decimal AmountOfMoney { get; set; }
    }
}
