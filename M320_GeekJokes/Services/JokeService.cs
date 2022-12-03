using GeekJokes.Models;
using System.Threading.Tasks;

namespace GeekJokes.Services {
    /// <summary>
    /// The joke service is the central piece of the application.
    /// It might be used to retrieve a joke containing full analytics.
    /// </summary>
    public class JokeService {
        /// <summary>
        /// This method retrieves a joke using an instance of JokeProvider and
        /// analyzes that joke using an instance of JokeAnalyzer.
        /// </summary>
        /// <param name="includeSpecialChars">Whether non-alphanumeric characters should be counted in the joke analytics.</param>
        /// <param name="includeWhitespaces">Whether whitespace characters should be counted in the joke analytics.</param>
        /// <returns></returns>
        public async Task<Joke> RetrieveAndAnalyzeJoke(bool includeSpecialChars = true, bool includeWhitespaces = true) {
            // Retrieve joke
            JokeProvider jokeProvider = new JokeProvider();
            Joke joke = await jokeProvider.GetJoke();

            // Analyze Joke
            JokeAnalyzer jokeAnalyzer = new JokeAnalyzer();
            int wordCount = jokeAnalyzer.GetWordCount(joke);
            int charCount = jokeAnalyzer.GetCharCount(joke, includeSpecialChars, includeWhitespaces);
            int funnyness = jokeAnalyzer.GetFunniness(joke);
            JokeAnalytics analytics = new JokeAnalytics(wordCount, charCount, funnyness);
            joke.Analytics = analytics;

            return joke;
        }
    }
}