using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.AccountsViewModels
{
    public class CreateAccountViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
    }
}
