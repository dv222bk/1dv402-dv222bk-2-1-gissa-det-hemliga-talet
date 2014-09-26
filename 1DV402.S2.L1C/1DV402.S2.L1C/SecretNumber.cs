using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1C
{
    /// <summary>
    /// The class SecretNumber, the core of the Secret Number game
    /// </summary>
    public class SecretNumber
    {
        private GuessedNumber[] _guessedNumbers;
        private int? _number;
        public const int MaxNumberOfGuesses = 7;

        /// <summary>
        /// Keeps track on if the user can still make guesses
        /// GET: True if the user can make a guess, false if not
        /// </summary>
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

        /// <summary>
        /// Keeps track on the number of guesses the user has made
        /// GET: Returns the number of guesses the user has made
        /// SET (private): Sets the number of guesses the user has made
        /// </summary>
        public int Count
        {
            get;
            private set;
        }

        /// <summary>
        /// Keeps track on the latest guess the user has made
        /// GET: Returns the latest guess
        /// SET (private): Stores the latest guess
        /// </summary>
        public int? Guess
        {
            get;
            private set;
        }

        /// <summary>
        /// Keeps track on all the guesses the user has made
        /// GET: Returns a GussedNumber[] with all the guesses
        /// </summary>
        public GuessedNumber[] GuessedNumbers 
        {
            get
            {
                return (GuessedNumber[])_guessedNumbers.Clone();
            }
        }

        /// <summary>
        /// Keeps track on the secret number the user must guess
        /// GET: If the user still can make a guess, returns null. If not, returns the secret number
        /// SET (private): Sets the secret number
        /// </summary>
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

        /// <summary>
        /// Keeps tracks on the latest outcome of the guess (see Outcome.cs)
        /// GET: Returns the latest outcome
        /// SET (private): Sets the latest outcome
        /// </summary>
        public Outcome Outcome
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes the secret number class by giving default values to everything
        /// </summary>
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

        /// <summary>
        /// Call to registrate the latest guess the user makes.
        /// </summary>
        /// <param name="guess">The users guess (int)</param>
        /// <returns>Returns the outcome of the users guess (see Outcome.cs)</returns>
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

        /// <summary>
        /// Creates a new instance of the SecretNumber class
        /// </summary>
        public SecretNumber()
        {
            _guessedNumbers = new GuessedNumber[MaxNumberOfGuesses];
            Initialize();
        }
    }
}
