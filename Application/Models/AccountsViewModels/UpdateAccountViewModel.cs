using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.AccountsViewModels
{
    public class UpdateAccountViewModel
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; } = string.Empty;
    }
}
