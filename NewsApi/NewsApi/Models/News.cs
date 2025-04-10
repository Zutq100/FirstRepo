namespace NewsApi.Models
{
    public class News
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public int CountVowels(string section)
        {
            string text = section switch
            {
                "title" => Title,
                "description" => Description,
                "content" => Content,
                _ => string.Empty
            };

            return text.Count(c => "aeiouаеёиоуыэюяAEIOUАЕЁИОУЫЭЮЯ".Contains(c));
        }
    }
}
