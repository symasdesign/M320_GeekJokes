using System.Text;
using System.Text.Json.Serialization;

namespace GeekJokes.Models {
    public class Joke {
        [JsonPropertyName("joke")]
        public string JokeText { get; set; }

        [JsonIgnore]
        public JokeAnalytics Analytics { get; set; }

        public override string ToString() {
            StringBuilder builder = new StringBuilder(JokeText);

            if (!ReferenceEquals(null, Analytics)) {
                builder.AppendLine("\n");
                builder.AppendLine($"  Word count:    {Analytics.WordCount}");
                builder.AppendLine($"  Char count:    {Analytics.CharCount}");
                builder.AppendLine($"  Funniness:     {Analytics.Funniness}");
            }

            return builder.ToString();
        }
    }
}