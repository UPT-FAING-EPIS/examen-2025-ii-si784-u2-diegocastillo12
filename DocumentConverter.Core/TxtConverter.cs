namespace DocumentConverter.Core
{
    public class TxtConverter : IDocumentConverter
    {
        public string Convert(string content)
        {
            string conversion = " [Converted to TXT]";
            return content + conversion;
        }

        public string TargetExtension => ".txt";
    }
}
