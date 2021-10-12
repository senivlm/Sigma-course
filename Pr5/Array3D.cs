using System;
using System.Collections.Generic;
using System.Text;

namespace Practice3
{
    class Array3D
    {
        private int[,,] MyArray;
        private int[,] xy;
        private int[,] yz;
        private int[,] zx;
        private int n;

        public Array3D()
        {
            MyArray = new int[2, 2, 2];
            n = MyArray.GetLength(0);
            xy = new int[2, 2];
            yz = new int[2, 2];
            zx = new int[2, 2];
        }

        public Array3D(int[,,] myArray)
        {
            n = myArray.GetLength(0);

            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    for (int z = 0; z < n; z++)
                        MyArray[x, y, z] = myArray[x, y, z];
                }
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Array3D d &&
                   EqualityComparer<int[,,]>.Default.Equals(MyArray, d.MyArray) &&
                   EqualityComparer<int[,]>.Default.Equals(xy, d.xy) &&
                   EqualityComparer<int[,]>.Default.Equals(yz, d.yz) &&
                   EqualityComparer<int[,]>.Default.Equals(zx, d.zx);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(MyArray, xy, yz, zx);
        }

        public override string ToString()
        {
            return base.ToString();
        }
        
        public void FindProection1()
        {
            xy = new int[n, n];

            bool shadow = false;

            for (int x = 0; x < n; x++)
            {
                for (int y = 0; y < n; y++)
                {
                    for (int z = 0; z < n; z++)
                    {
                        if (MyArray[x, y, z] == 1)
                        {
                            shadow = true;
                            break;
                        }
                    }
                    if (shadow == true)
                    {
                        xy[x, y] = 1;
                        shadow = false;
                    }
                }
            }
        }

        public void FindProection2()
        {
            yz = new int[n, n];

            bool shadow = false;

            for (int z = 0; z < n; z++)
            {
                for (int y = 0; y < n; y++)
                {
                    for (int x = 0; x < n; x++)
                    {
                        if (MyArray[x, y, z] == 1)
                        {
                            shadow = true;
                            break;
                        }
                    }
                    if (shadow == true)
                    {
                        yz[y, z] = 1;
                        shadow = false;
                    }
                }
            }
        }

        public void FindProection3()
        {
            zx = new int[n, n];

            bool shadow = false;

            for (int x = 0; x < n; x++)
            {
                for (int z = 0; z < n; z++)
                {
                    for (int y = 0; y < n; y++)
                    {
                        if (MyArray[x, y, z] == 1)
                        {
                            shadow = true;
                            break;
                        }
                    }
                    if (shadow == true)
                    {
                        zx[z, x] = 1;
                        shadow = false;
                    }
                }
            }
        }
    }
}
