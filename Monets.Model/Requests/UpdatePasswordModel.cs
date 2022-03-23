using System;
using System.Collections.Generic;
using System.Text;

namespace Monets.Model.Requests
{
    public class UpdatePasswordModel
    {
        public string Email { get; set; }
        public string? Password { get; set; }
        public string? PasswordRepeat { get; set; }
        public string Code { get; set; }
    }
}
