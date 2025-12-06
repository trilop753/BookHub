namespace WebMVC.Models.Search
{
    public class SearchSuggestionsResponse
    {
        public IEnumerable<TitleSuggestion> Titles { get; set; } = Array.Empty<TitleSuggestion>();
        public IEnumerable<TextSuggestion> Genres { get; set; } = Array.Empty<TextSuggestion>();
        public IEnumerable<TextSuggestion> AuthorPublishers { get; set; } = Array.Empty<TextSuggestion>();
    }

    public class TitleSuggestion
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty; 
        public string Meta { get; set; } = string.Empty; 
    }

    public class TextSuggestion
    {
        public string Text { get; set; } = string.Empty;
        public string? Kind { get; set; } 
    }
}