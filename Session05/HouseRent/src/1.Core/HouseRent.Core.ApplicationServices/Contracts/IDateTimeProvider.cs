using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Core.ApplicationServices.Contracts;
public interface IDateTimeProvider
{
    DateTime GetUtcNow();

}
