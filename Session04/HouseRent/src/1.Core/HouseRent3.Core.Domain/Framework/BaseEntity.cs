using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Core.Domain.Framework;

public abstract class BaseEntity<TId>(TId id)
{
    public TId Id { get; init; } = id;

    
}
