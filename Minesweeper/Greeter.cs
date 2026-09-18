using System;
using System.Collections.Generic;
using System.Text;

namespace Minesweeper;

public class Greeter
{
    public string Name { get; }

    public Greeter(string name)
    {
        Name = name;
    }

    public string Introduce()
    {
        return $"Hi! My name is {Name}";
    }
}

