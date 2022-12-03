using GeekJokes.Models;
using System;
using System.Linq;

namespace GeekJokes.Services {

    /// <summary>
    /// The joke analyzer is responsible for the retrievement of statistical information for a given joke.
    /// The class contains many methods which are easy to cover with unit tests.
    /// Be aware although, there is at least one method which cannot be tested as it is.
    /// </summary>
    public class JokeAnalyzer {
        /// <summary>
        /// Returns the word count for the given joke instance.
        /// A word is considered any piece of text divided by a space character.
        /// </summary>
        /// <param name="joke">The joke to count the words of.</param>
        /// <returns>The number of words within the joke.</returns>
        public int GetWordCount(Joke joke) {
            var words = joke.JokeText.Split(' ');
            return words.Length;
        }

        /// <summary>
        /// Returns the character count for the given joke instance.
        /// The type of characters with shoud be considered may be controlled with the two optional parameters.
        /// </summary>
        /// <param name="joke">The joke to count the characters of.</param>
        /// <param name="includeSpecialChars">Whether non-alphanumeric characters should be included in the final count.</param>
        /// <param name="includeWhitespaces">Whether whitespace characters should be inclueded in the final count.</param>
        /// <returns></returns>
        public int GetCharCount(Joke joke, bool includeSpecialChars = true, bool includeWhitespaces = true) {
            if (includeSpecialChars && includeWhitespaces) {
                return joke.JokeText.Length;
            }

            if (includeSpecialChars && !includeWhitespaces) {
                return joke.JokeText.Where(c => !char.IsWhiteSpace(c)).ToArray().Length;
            }

            int alphanumericCharCount = joke.JokeText
                .Where(c => (c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                .ToArray()
                .Length;

            if (!includeSpecialChars && includeWhitespaces) {
                return alphanumericCharCount + joke.JokeText.Where(c => char.IsWhiteSpace(c)).ToArray().Length;
            }

            return alphanumericCharCount;
        }

        /// <summary>
        /// Mimicks a functionality which analyzes a given jokes funniness.
        /// Since there is no common sense of humor, a random number from 1 to 5 will be returned.
        /// The jokes text is used as seed for the random number generator.
        /// </summary>
        /// <param name="joke">The joke to determine the funiness of.</param>
        /// <returns>A value indicating the funniness of the joke. Higher means more funny.</returns>
        public int GetFunniness(Joke joke) {
            Random _funninessAnalyzer = new Random(joke.JokeText.GetHashCode());
            return _funninessAnalyzer.Next(1, 6);
        }
    }
}
