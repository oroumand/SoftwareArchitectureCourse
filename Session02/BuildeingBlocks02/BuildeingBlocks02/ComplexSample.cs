using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildeingBlocks02;
public class ComplexSample1
{
    public int Prop1 { get; set; }
    public int Prop2 { get; set; }
    public int Prop3 { get; set; }
    public int Prop4 { get; set; }
    public int Prop5 { get; set; }
}


public class ComplexSample2
{
    public int Prop1 { get; set; }
    public int Prop2 { get; set; }
    public int Prop3 => Prop1 + Prop2;
    public int Prop4 => Prop1 - Prop2;
    public int Prop5 =>Math.Abs(Prop1 - Prop2);
    public double Prop6 => Math.Asinh((double)(Prop1 / Prop2));
    public double Prop7 => Math.Cos((double)(Prop1 / Prop2));
    public double Prop8 => Math.Sin(Prop7 + Prop6);
}