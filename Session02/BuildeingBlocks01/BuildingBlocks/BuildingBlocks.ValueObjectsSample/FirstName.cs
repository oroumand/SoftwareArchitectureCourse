using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.ValueObjectsSample;
public class FirstName
{
    private string? v;

    public FirstName(string? v)
    {
        this.v = v;
    }
}

public class LastName
{
    public string Value { get; set; }
}

public record Temp
{
    public Temp()
    {
        
    }
}