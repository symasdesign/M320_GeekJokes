using GeekJokes.Models;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GeekJokes.Services {
    /// <summary>
    /// This class is responsible for loading random geek jokes from a publicly available api.
    /// Since this class makes http requests, it is a typical example of a piece of code
    /// which can/should not be covered with unit tests.
    /// </summary>
    public class JokeProvider {
        /// <summary>
        /// Http client, makes http requests.
        /// </summary>
        /// <returns></returns>
        private readonly HttpClient client = new HttpClient();

        private const string ApiUrl = "https://geek-jokes.sameerkumar.website/api?format=json";

        /// <summary>
        /// In the constructor, default http request headers are defined.
        /// </summary>
        public JokeProvider() {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// In this method, the actual joke is loaded from the api.
        /// The response from the api is deserialized into an instance of the Joke class.
        /// </summary>
        /// <param name="excludeChuckNorris">Whether Chuck Norris jokes should be exclueded.</param>
        /// <returns>A Joke instance retrieved from the api.</returns>
        public async Task<Joke> GetJoke(bool excludeChuckNorris = true) {
            Joke joke;
            do {
                Stream jokeJson = await client.GetStreamAsync(ApiUrl);
                joke = await JsonSerializer.DeserializeAsync<Joke>(jokeJson);
            } while (joke.JokeText.ToLower().Contains("chuck") == excludeChuckNorris);
            return joke;
        }
    }
}
