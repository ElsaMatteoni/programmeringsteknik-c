using CommandLine;

namespace Search.Client.Options
{
    [Verb("search", HelpText = "Search for documents.")]
    public class SearchOptions : ConnectionOptions
    {
        [Option('q', "query", Required = true, HelpText = "Query to search for.")]
        public string Query { get; set; }
    }
}