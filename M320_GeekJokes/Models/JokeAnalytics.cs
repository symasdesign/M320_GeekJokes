namespace GeekJokes.Models {
    public class JokeAnalytics {
        public int WordCount { get; }

        public int CharCount { get; }

        public int Funniness { get; }

        public JokeAnalytics(int wordCount, int charCount, int funniness) {
            WordCount = wordCount;
            CharCount = charCount;
            Funniness = funniness;
        }
    }
}