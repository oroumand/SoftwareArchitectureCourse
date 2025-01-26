using HouseRent.Core.ApplicationServices.Framework.Commands;
using HouseRent.Core.Domain.Framework;
using HouseRent.Endpoints.RestAPI.Extensions;
using HouseRent.Infra.Data.Sql.Command.Shared;
using System.Reflection;

namespace HouseRent.ArchitectureTest.Shared;

public class BaseTest
{
    protected static readonly Assembly ApplicationAssembly = typeof(IBaseCommand).Assembly;

    protected static readonly Assembly DomainAssembly = typeof(IAggregateRoot).Assembly;

    protected static readonly Assembly InfrastructureAssembly = typeof(HouseRentDbContext).Assembly;

    protected static readonly Assembly PresentationAssembly = typeof(HostingExtensions).Assembly;
}