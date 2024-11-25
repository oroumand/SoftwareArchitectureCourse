using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.AggregateSamples;
public class Complexity
{
    public int Prop1 { get; set; }
    public int Prop2 { get; set; }
    public int Prop3 { get; set; }
    public int Prop4 { get; set; }
    public int Prop5 { get; set; }
}

public class Complexity2
{
    public int Prop1 { get; set; }
    public int Prop2 { get; set; }
    public int Prop3 => Prop1 + Prop2;
    public int Prop4 => Prop3 * 10;
    public int Prop5 => Prop1 + Prop2 + Prop3;
    public int Prop6 => Prop1 + Prop2 * Prop3;
    public int Prop7 => Prop1 - Prop2 + Prop3;
    public int Prop8 => Prop7 / 10;
}