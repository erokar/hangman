using System;
using System.Collections.Generic;
using System.IO;

namespace Hangman {

	public class Dictionary {
	
		private List<string> words;
		private static Random random;

		public Dictionary(string filePath) {
			words = new List<string>(File.ReadAllLines(filePath));
			random = new Random();
		}

		public Word RandomWord() {
			int index = random.Next(words.Count);
			string word = words[index];
			words.RemoveAt(index);
			return new Word(word);
		}

	}
}

