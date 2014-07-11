using System;
using System.Linq;

namespace Hangman {

	public class Word {

		private string word;
	
		public Word(string w) {
			word = w;
		}

		public string CorrectLetters(string guess) {
			string returnStr = "";
			foreach (char c in word) {
				if (guess.ToLower().Contains(c)) {
					returnStr += c;
				} else {
					returnStr += "_";
				}
			}
			return returnStr;
		}

		public bool Contains(string letter) {
			return word.Contains(letter);
		}

		public bool CorrectGuess(string guess) {
			return word.Count(x => guess.ToLower().Contains(x)) == word.Length;
		}

		public override string ToString() {
			return this.word;
		}

	}
}

