using HouseRent.Core.Domain.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRent.Core.Domain.Homes;
public record HomeCreated(long HomeId) : IDomainEvent;
public record HomeBooked(long HomeId) : IDomainEvent;


