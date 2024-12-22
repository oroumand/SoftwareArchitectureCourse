using HouseRent.Core.Domain.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Core.Domain.Amenities;
public record AmenityCreated(long AmenityId) : IDomainEvent;
