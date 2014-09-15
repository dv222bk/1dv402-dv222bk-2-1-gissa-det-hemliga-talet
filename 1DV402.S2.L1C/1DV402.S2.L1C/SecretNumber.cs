using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1C
{
    class SecretNumber
    {
        private GuessedNumber[] _guessedNumbers;
        private int? _number;
        public const int MaxNumberOfGuesses = 7;

        public bool CanMakeGuess
        {
            public get
            {

            }
            private set
            {

            }
        }

        public int Count
        {
            public get
            {

            }
            private set
            {

            }
        }

        public int? Guess
        {
            public get
            {

            }
            private set
            {

            }
        }

        public GuessedNumber[] GuessedNumbers 
        {
            public get
            {

            }
        }

        public int? Number
        {
            public get
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                else
                {
                    return _number;
                }
            }
            private set
            {
                _number = value;
            }
        }

        public Outcome Outcome
        {
            public get
            {

            }
            private set
            {

            }
        }

        public static SecretNumber()
        {
            Initialize();
        }

        public static void Initialize()
        {
            _guessedNumbers = new GuessedNumber[MaxNumberOfGuesses];
            //Number = RandomInt
            Count = 0;
            Guess = null;
            Outcome = Outcome.Indefinite;
        }

        public static Outcome MakeGuess(int guess)
        {

        }
    }
}
