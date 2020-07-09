using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

public sealed class LoginUser
{
    public string LoginOrEmail { get; set; }
    public string Password { get; set; }
}