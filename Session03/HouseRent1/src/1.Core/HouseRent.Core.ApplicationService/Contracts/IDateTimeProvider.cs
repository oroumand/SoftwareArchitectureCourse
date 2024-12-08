using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HourseRent.Core.Applicaiton.Contracts;
public interface IDateTimeProvider
{
    DateTime GetUtcNow();

}
