using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1C
{
    public class SecretNumber
    {
        private GuessedNumber[] _guessedNumbers;
        private int? _number;
        public const int MaxNumberOfGuesses = 7;

        public bool CanMakeGuess
        {
            get
            {
                if (Count >= MaxNumberOfGuesses || Outcome == Outcome.Right)
                {
                    return false;
                }
                return true;
            }
        }

        public int Count
        {
            get;
            private set;
        }

        public int? Guess
        {
            get;
            private set;
        }

        public GuessedNumber[] GuessedNumbers 
        {
            get
            {
                return (GuessedNumber[])_guessedNumbers.Clone();
            }
        }

        public int? Number
        {
            get
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
            private set { _number = value; }
        }

        public Outcome Outcome
        {
            get;
            private set;
        }

        public void Initialize()
        {
            for (int i = 0; i < _guessedNumbers.Length; i++)
            {
                _guessedNumbers[i].Number = null;
                _guessedNumbers[i].Outcome = Outcome.Indefinite;
            }
            Random random = new Random();
            Number = random.Next(1, 100);
            Count = 0;
            Guess = null;
            Outcome = Outcome.Indefinite;
        }

        public Outcome MakeGuess(int guess)
        {
            if (CanMakeGuess)
            {
                if (guess < 1 || guess > 100)
                {
                    throw new ArgumentOutOfRangeException();
                }
                for (int i = 0; i < GuessedNumbers.Length; i++)
                {
                    if (GuessedNumbers[i].Number == guess)
                    {
                        Outcome = Outcome.OldGuess;
                        return Outcome;
                    }
                }
                Guess = guess;
                Count++;
                if (Guess > _number)
                {
                    Outcome = Outcome.High;
                }
                else if (Guess < _number)
                {
                    Outcome = Outcome.Low;
                }
                else if (Guess == _number)
                {
                    Outcome = Outcome.Right;
                }
                else
                {
                    throw new ArgumentException("Ditt värde är jätte konstigt."); // This should never happen
                }
                _guessedNumbers[Count - 1].Number = Guess;
                _guessedNumbers[Count - 1].Outcome = Outcome;
            }
            else
            {
                Outcome = Outcome.NoMoreGuesses;
            }
            return Outcome;
        }
        public SecretNumber()
        {
            _guessedNumbers = new GuessedNumber[MaxNumberOfGuesses];
            Initialize();
        }
    }
}
