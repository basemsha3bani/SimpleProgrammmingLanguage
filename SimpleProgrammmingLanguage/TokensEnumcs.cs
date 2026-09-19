using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleProgrammmingLanguage
{
    public enum TokensEnum
    {
        Integer,    // keyword: int
        Identifier, // x, _temp1, name2
        Assignment, // =
        Number,     // 5, 123
        Plus,
        Minus,
        Multiply,
        Divide,
        LParen,
        RParen,
        Semicolon,  // ;
        Print,
        Unknown
    }
}
