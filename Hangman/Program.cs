using System;
using System.Linq;

namespace Hangman {

	class MainClass {

		private const string FILE_PATH = @"/Users/ero/Dropbox/utvikling/csharp/Hangman/words.txt";
		private const int MAX_GUESSES = 8;

		public static string availableLetters(string guess) {
			string availableLetters = "";
	
			foreach (char c in "abcdefghijklmnopqrstuvwxyzæøå") {
				if (!guess.ToLower().Contains(c)) {
					availableLetters += c;
				}
			}
				
			return availableLetters;
		}

		public static int Main(string[] args) {
			Dictionary dict = new Dictionary(FILE_PATH);
			Word secretWord = dict.RandomWord();
			bool found = false;
			string guess = "";
			string letter;
			string guessedWord = "";
			int guessesLeft = MAX_GUESSES;
			Console.WriteLine("--------------------");

			while (guessesLeft > 0 && !found) {
				Console.WriteLine("Du har " + guessesLeft + " ganger å gjette igjen.");
				Console.WriteLine("Tilgjengelige bokstaver: " + availableLetters(guess));
				Console.Write("Gjett en bokstav: ");
				letter = Console.ReadLine();

				if (guess.Contains(letter)) {
					Console.WriteLine("Du har allerede brukt bokstaven " + letter + ". Prøv igjen.");
				} else {
					guess += letter;
					guessedWord = secretWord.CorrectLetters(guess);

					if (secretWord.Contains(letter)) {
						Console.WriteLine("Bra! " + guessedWord);
					} else {
						Console.WriteLine("Voops. Den bokstaven er ikke i ordet. " + guessedWord);
						guessesLeft--;
					}
			
				}

				Console.WriteLine();

				if (secretWord.CorrectGuess(guess)) {
					Console.WriteLine ("Gratulerer! Du gjetta riktig.");
					return 1;
				}

			}

			Console.WriteLine ("Beklager, du kan ikke gjette flere ganger. Ordet var: " + secretWord.ToString());
			return -1;
	
		}
	}

}
	
