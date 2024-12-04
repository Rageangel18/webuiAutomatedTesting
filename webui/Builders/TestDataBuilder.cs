namespace WebUi_automated_testing.Utilities
{
    public class TestDataBuilder
    {
        private string _url = "https://en.ehu.lt/";
        private string _linkText = string.Empty;
        private string _languageLinkText = string.Empty;
        private string _expectedUrlContains = string.Empty;
        private string _expectedHeader = string.Empty;
        private string _expectedTitle = string.Empty;

        public TestDataBuilder WithUrl(string url)
        {
            _url = url;
            return this;
        }

        public TestDataBuilder WithLanguageLinkText(string languageLinkText)
        {
            _languageLinkText = languageLinkText;
            return this;
        }
        public TestDataBuilder WithLinkText(string linkText)
        {
            _linkText = linkText;
            return this;
        }

        public TestDataBuilder WithExpectedUrlContains(string expectedUrlContains)
        {
            _expectedUrlContains = expectedUrlContains;
            return this;
        }
        public TestDataBuilder WithExpectedTitle(string expectedTitle)
        {
            _expectedTitle = expectedTitle;
            return this;
        }

        public TestDataBuilder WithExpectedHeader(string expectedHeader)
        {
            _expectedHeader = expectedHeader;
            return this;
        }

        public (string Url, string LanguageLinkText, string ExpectedUrlContains, string ExpectedHeader, string ExpectedTitle, string LinkText) Build()
        {
            return (_url, _languageLinkText, _expectedUrlContains, _expectedHeader, _expectedTitle, _linkText);
        }
    }
}