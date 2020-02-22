using LeadNew.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeadNew.Models
{
    public class UserViewModel
    {
        public LeadNew.Models.tbEmpresa empresa;

        public string PartialViewName;

        public PartialViewModelBase Tab;
    }
}
