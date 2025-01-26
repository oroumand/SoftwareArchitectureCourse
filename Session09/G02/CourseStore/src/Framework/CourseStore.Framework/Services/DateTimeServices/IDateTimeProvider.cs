using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStore.Framework.Services.DateTimeServices;
public interface IDateTimeProvider
{
    DateTime GetUtcNow();

}
