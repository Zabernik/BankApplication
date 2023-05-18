using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Enums
{
    /// <summary>This enums make a few marks strenght of password.</summary>
    public enum PasswordStrenght
    {
        Blank = 0,
        Weak = 1,
        Medium = 2,
        Strong = 3,
        Error = 4
    }
}
