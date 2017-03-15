using System;
using System.Collections.Generic;

namespace WindowsFormsApplication1.Bll
{
    public class BasePrimeConvertor
    {
        private int[] _primes = new int[] { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73 };


        public BasePrimeConvertorResult GetDividers(int inputValue)
        {
            // param check
            if (inputValue <= 0)
                return new BasePrimeConvertorResult("-inf");

            // calculation
            var result = new List<int>();

            var remainingTotal = inputValue;
            var highestPossiblePrime = GetHighestPrimeUnderOrEqualToValue(inputValue);
            var divider = 2; //start with the lowest prime

            while (divider <= highestPossiblePrime && remainingTotal > 1)
            {
                var remainder = (remainingTotal % divider);

                if (remainder == 0)
                {
                    // Valid divider found. Add divider to output and restart the loop
                    remainingTotal = remainingTotal / divider;
                    result.Add(divider);
                }
                else
                {
                    //input not dividable by this divider, chose the next divider
                    divider = GetNextPrime(divider);
                }
            }

            // result
            result.Reverse();
            return new BasePrimeConvertorResult(result.ToArray());
        }

        /// <summary>
        /// Get the next prime based on the current value
        /// </summary>
        /// <param name="matchValue"></param>
        /// <returns></returns>
        internal int GetNextPrime(int currentPrime)
        {
            var currentIndex = Array.IndexOf(_primes, currentPrime);
            if (currentIndex + 1 == _primes.Length)
                return -1;
            return _primes[currentIndex + 1];
        }

        /// <summary>
        /// Determine the highest prime under or equal to the given value
        /// </summary>
        /// <param name="matchValue"></param>
        /// <returns></returns>
        internal int GetHighestPrimeUnderOrEqualToValue(int matchValue)
        {
            var maxVal = 0;

            for (int i = 0; i < _primes.Length; i++)
            {
                var thisValue = _primes[i];
                if ((thisValue > maxVal)
                    && thisValue <= matchValue)
                {
                    maxVal = thisValue;
                }
            }

            return maxVal;
        }

    }

    public class BasePrimeConvertorResult
    {
        public BasePrimeConvertorResult(int[] result)
        {
            Success = true;
            ErrorText = string.Empty;
            Dividers = (int[])result.Clone();
        }

        public BasePrimeConvertorResult(string error)
        {
            Success = false;
            ErrorText = error;
            Dividers = null;
        }

        public bool Success { get; set; }
        public string ErrorText { get; set; }
        public int[] Dividers { get; set; }
    }
}
