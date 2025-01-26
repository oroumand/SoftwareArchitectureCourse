using IdGen;

namespace CourseStore.Framework.Services.IdGeneratorServices;

public class SnowflakeIdGenerator(IdGenerator generator) : IIdGenerator<long>
{
    private readonly IdGenerator _generator = generator;

    public long GetId()
    {
        return _generator.CreateId();
    }
}
