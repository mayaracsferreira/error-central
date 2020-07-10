using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.AppDomain.Models
{
    public class MyLoggedUser : IUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Credentials { get; set; }
        public Boolean IsAdmin { get; set; }
    }
}
