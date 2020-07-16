using System;

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
