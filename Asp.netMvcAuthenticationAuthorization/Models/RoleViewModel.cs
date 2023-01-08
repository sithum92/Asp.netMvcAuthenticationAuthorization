using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp.netMvcAuthenticationAuthorization.Models
{
    //1.4 forth step
    //Custom Code By Sithum 
    //for Create a role with asp.net identity
    public class RoleViewModel
    {
        public RoleViewModel() { }

        public RoleViewModel(ApplicationRole role)
        {
            Id = role.Id;
            Name = role.Name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}