using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Initiation.Shared.Dto
{
    public class DtoUserForLogin
    {
        public string Token { get; set; }

       public string UserName { get; set; }

    }
}
