using CommandLine;
using System;

namespace Search.Client.Options
{
    [Verb("index", HelpText = "Index a document from a remote source.")]
    public class IndexOptions : ConnectionOptions
    {
        [Option('u', "url", Required = true, HelpText = "Url to recipe.")]
        public Uri Url { get; set; }
    }
}
