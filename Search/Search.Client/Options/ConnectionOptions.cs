using CommandLine;

namespace Search.Client.Options
{
    public class ConnectionOptions
    {
        [Option('i', "index", Required = false, HelpText = "The name of the index you want to connect/create.")]
        public string Index { get; set; }

        [Option('h', "host", Required = false, HelpText = "Uri of host.")]
        public string Host { get; set; }
    }
}
