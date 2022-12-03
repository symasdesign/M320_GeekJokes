using GeekJokes.Models;
using GeekJokes.Services;

namespace M320_GeekJokes {
    internal class Program {
        static async Task Main(string[] args) {
            JokeService jokeService = new JokeService();
            bool printMoreJokes;

            System.Console.Clear();

            do {
                Joke joke = await jokeService.RetrieveAndAnalyzeJoke();
                Console.WriteLine(joke);

                Console.Write("\n=> Would you like to enjoy one more joke? [y/n] ");
                var key = Console.ReadKey();
                Console.WriteLine("\n");
                printMoreJokes = key.KeyChar.ToString().ToLower() != "n";
                if (printMoreJokes) {
                    Console.Clear();
                }
            } while (printMoreJokes);
        }
    }
}