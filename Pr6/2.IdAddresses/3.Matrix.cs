using System;
using System.Collections;
using System.Globalization;

namespace Pr6
{
    class _3 : IEnumerable
    {
        private double[,] _arr2D;

        public double[,] Arr2D
        {
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                _arr2D = (double[,])value.Clone();
            }
            get => (double[,])_arr2D.Clone();
        }

        public _3() => _arr2D = null;

        public _3(double[,] matrix) => _arr2D = matrix;

        public override string ToString()
        {
            var test = "";
            for (var i = 0; i < _arr2D.GetLength(0); i++)
            {
                for (var j = 0; j < _arr2D.GetLength(1); j++)
                {
                    test += $"{_arr2D[i, j].ToString(CultureInfo.InvariantCulture):F00} ";
                }
                test += "\n";
            }

            return test;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }


        public class Enumerator : IEnumerator
        {
            private readonly double[,] _mArr2D;

            private int _i;
            private int _j;

            public Enumerator(_3 m)
            {
                _mArr2D = m.Arr2D;
                _i = _mArr2D.GetLength(0) - 1;
                _j = _mArr2D.GetLength(1);
            }

            object IEnumerator.Current => _mArr2D[_i, _j];

            public bool MoveNext()
            {
                _j--;
                if (_j >= 0) return _i >= 0;
                _j = _mArr2D.GetLength(1) - 1;
                _i--;
                return _i >= 0;
            }

            public void Reset()
            {
                _i = _mArr2D.GetLength(0) - 1;
                _j = _mArr2D.GetLength(1);
            }
        }
    }
}
