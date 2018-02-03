using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BruteForce
{
    public class XBased
    {

        #region Properties
        private char[] _CharSet;
        public char[] CharSet { get { return _CharSet; } set { _CharSet = value; } }

        private short _length;
        public short Length
        {
            get { return _length; }
            set
            {
                _length = value;

            }
        }
        #endregion

        #region Constructor
        public XBased(short Length, char[] CharSet)
        {
            this._CharSet = CharSet;
            this.Length = Length;

        }
        #endregion

        #region ConverterMethods
        public string ToXBased(BigInteger value)
        {
            //draft for N length X Based Value for example AAAAA
            char[] array = Enumerable.Repeat(_CharSet[0], _length).ToArray();

            int divider = _CharSet.Length;
            short count = _length; //used to speedup making string 
            do
            {
                count--;
                array[count] = _CharSet[(Int64)(value % divider)];
                value /= divider;

            } while (value > 0);

            return new string(array);
        }
        public BigInteger FromXBased(string str)
        {
            BigInteger big = 0;
            for (int i = 0; i < str.Length; i++)
            {
                big += Array.FindIndex(_CharSet, w => w.Equals(str[i])) * BigInteger.Pow(_CharSet.Length, (str.Length - i - 1));
            }
            return big;
        }

        #endregion
    }
}
