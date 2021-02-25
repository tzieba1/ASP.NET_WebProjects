using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment3.Models
{
  interface IRegisterRepository
  {
    void CreateRegister(Register register);
  }
}
