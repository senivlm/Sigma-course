using System;
using System.Collections.Generic;
using System.Text;

namespace Pr4
{
    class Polynom
    {
        private Monomial[] monomials;
        private Monomial[] Monomials
        {
            get
            {
                return monomials;
            }

            set
            {
                for (int i = 1; i < value.Length; ++i)
                {
                    for (int j = i + 1; j < value.Length; j++)
                    {
                        if (value[i].Equals(value[j]))
                        {
                            throw new Exception("Polunom has equal value!");
                        }
                    }
                }

                monomials = new Monomial[value.Length];
                for (int i = 0; i < value.Length; i++)
                {
                    monomials[i] = new Monomial(value[i]);
                }

                for (int i = 0; i < monomials.Length; ++i)
                {
                    for (int j = 1; j < monomials.Length - i; ++j)
                    {
                        if (monomials[j - 1] > monomials[j])
                        {
                            Swap(monomials[j - 1], monomials[j]);
                        }
                    }
                }
            }
        }

        private void Swap(Monomial m1, Monomial m2)
        {
            Monomial temp = new Monomial(m1);
            m1 = m2;
            m2 = temp;
        }

        private void DeleteMon(int index)
        {
            Monomial[] temp = new Monomial[monomials.Length - 1];
            int counter = 0;
            for (int i = 0; i < monomials.Length; i++)
            {
                if (i == index)
                {
                    i++;
                    if (i == monomials.Length)
                        break;
                }
                temp[counter] = monomials[i];
                counter++;
            }
            Monomials = temp;
        }

        private void AddMon(Monomial m)
        {
            Monomial[] temp = new Monomial[monomials.Length + 1];
            for (int i = 0; i < monomials.Length; i++)
            {
                temp[i] = monomials[i];
            }
            temp[monomials.Length] = new Monomial(m);
            Monomials = temp;
        }

        public Polynom()
        {
            monomials = null;
        }

        public Polynom(Polynom p)
        {
            Monomials = p.monomials;
        }

        public Polynom(Monomial[] monomial)
        {
            Monomials = monomial;
        }

        public double this[int index]
        {
            set
            {
                bool existing = false;
                int num = 0;
                for (int i = 0; i < monomials.Length; i++)
                {
                    if (monomials[i].Power == index)
                    {
                        existing = true;
                        num = i;
                        break;
                    }
                }
                if (existing)
                {
                    if (value == 0)
                    {
                        DeleteMon(num);
                    }
                    else
                    {
                        monomials[num].Coefficient = value;
                    }
                }
                else
                {
                    if (value != 0)
                    {
                        AddMon(new Monomial(index, value));
                    }
                }
            }
        }

        public override string ToString()
        {
            string str = string.Empty;

            str += monomials[0].ToString();

            for (int i = 1; i < Monomials.Length; ++i)
            {
                if (monomials[i].Coefficient > 0)
                    str += "+" + monomials[i];
                else
                    str += monomials[i].ToString();
            }
            return str;
        }

        public Polynom Add(Polynom polynom)
        {
            Polynom res = new Polynom(this);

            bool exist;

            int[] deletingIndexes = new int[res.monomials.Length];
            int delc = 0;
            for (int i = 0; i < deletingIndexes.Length; i++)
            {
                deletingIndexes[i] = -1;
            }

            for (int i = 0; i < polynom.monomials.Length; i++)
            {
                exist = false;
                for (int j = 0; j < res.monomials.Length; j++)
                {
                    if (polynom.monomials[i].Equals(res.monomials[j]))
                    {
                        if (res.monomials[i].Coefficient + polynom.monomials[j].Coefficient != 0)
                            res.monomials[i].Coefficient += polynom.monomials[j].Coefficient;
                        else
                        {
                            deletingIndexes[delc] = i;
                            delc++;
                        }
                        exist = true;
                        break;
                    }
                }
                if (!exist)
                {
                    res.AddMon(polynom.monomials[i]);
                }

            }

            for (int i = 0; i < delc; i++)
            {
                res.DeleteMon(deletingIndexes[i]);
            }

            return res;
        }

        public Polynom Subtract(Polynom polynom)
        {
            Polynom res = new Polynom(this);

            int[] deletingnodesindexes = new int[res.monomials.Length];
            int delc = 0;
            for (int i = 0; i < deletingnodesindexes.Length; i++)
            {
                deletingnodesindexes[i] = -1;
            }

            bool exist;
            for (int i = 0; i < polynom.monomials.Length; i++)
            {
                exist = false;
                for (int j = 0; j < res.monomials.Length; j++)
                {
                    if (polynom.monomials[i].Equals(res.monomials[j]))
                    {
                        if (res.monomials[i].Coefficient - polynom.monomials[j].Coefficient != 0)
                            res.monomials[i].Coefficient -= polynom.monomials[j].Coefficient;
                        else
                        {
                            deletingnodesindexes[delc] = i;
                            delc++;
                        }
                        exist = true;
                        break;
                    }
                }
                if (!exist)
                {
                    res.AddMon(new Monomial(polynom.monomials[i].Power, -polynom.monomials[i].Coefficient));
                }
            }

            for (int i = 0; i < delc; i++)
            {
                res.DeleteMon(deletingnodesindexes[i]);
            }

            return res;
        }

        public void Parse(string s)
        {
            string[] sstr = s.Split('+', StringSplitOptions.RemoveEmptyEntries);

            Monomial[] marray = new Monomial[sstr.Length];

            string[][] smonomials = new string[sstr.Length][];

            for (int i = 0; i < sstr.Length; i++)
            {
                smonomials[i] = sstr[i].Split("*x^");
            }

            int initindex = 0;

            double tempcoef;
            int temppower;

            if (smonomials[0].Length == 1)
            {
                initindex = 1;
                if (!double.TryParse(smonomials[0][0], out tempcoef))
                {
                    throw new Exception("Wrong Parse input");
                }
                marray[0] = new Monomial(0, tempcoef);
            }

            for (int i = initindex; i < smonomials.Length; i++)
            {
                if (!double.TryParse(smonomials[i][0], out tempcoef) || !int.TryParse(smonomials[i][1], out temppower)
                    || smonomials[i].Length != 2)
                    throw new Exception("Wrong Parse input");
                marray[i] = new Monomial(temppower, tempcoef);
            }

            Monomials = marray;
        }
    }
}
