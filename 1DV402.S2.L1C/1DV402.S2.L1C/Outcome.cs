using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1C
{
    /// <summary>
    /// Outcome can have the following values:
    /// Indefinite: Default value
    /// Low: Guess was too low
    /// High: Guess was too high
    /// Right: Guess was correct
    /// NoMoreGuesses: User has no more guesses left
    /// OldGuess: User made a duplicate guess
    /// </summary>
    public enum Outcome { Indefinite, Low, High, Right, NoMoreGuesses, OldGuess };
}
