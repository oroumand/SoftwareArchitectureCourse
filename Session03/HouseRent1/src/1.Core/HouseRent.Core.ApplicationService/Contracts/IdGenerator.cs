using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Core.ApplicationService.Contracts;
public interface IdGenerator
{
    int GetId();
}
