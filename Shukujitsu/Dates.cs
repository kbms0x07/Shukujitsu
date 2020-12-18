using System;
using System.Collections.Generic;
using System.Linq;

namespace Shukujitsu
{
    internal class Dates
    {
        internal static Dictionary<DateTime, string> dict = new[]
        {
            ("2020/1/1", "元日"),
        }.ToDictionary(x => DateTime.Parse(x.Item1), x => x.Item2);
    }
}
