using System;
using System.Collections.Generic;
using System.Text;

namespace Pr8
{
    class _1Sort
    {
        public delegate int Comparison(object a, object b);

        public int ComparisonImpl(object a, object b)
        {
            var aC = (IComparable) a;
            return aC.CompareTo(b);
        }

        public static object[] Sort(object[] objs, Comparison d)
        {
            foreach (var a in objs)
            {
                var fl = 0;
                for (var j = objs.Length - 2; j >= 0; j--)
                {
                    var res = d(objs[j], objs[j + 1]);
                    if (res <= 0) continue;

                    (objs[j], objs[j + 1]) = (objs[j + 1], objs[j]);
                    fl = 1;
                }

                if (fl == 0)
                    break;
            }

            return objs;
        }
    }
}