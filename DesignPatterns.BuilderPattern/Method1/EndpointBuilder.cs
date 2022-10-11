using System.Text;

namespace DesignPatterns.BuilderPattern.Method1
{
    public class EndpointBuilder
    {
        private readonly StringBuilder sbUrl = new();
        private readonly StringBuilder sbParams = new();
        private const char defaultDelimiter = '/';
        
        public string BaseUrl { get; set; }
        
        public EndpointBuilder(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public EndpointBuilder Append(string value)
        {
            // localhost/api/v1/user
            sbUrl.Append(value);
            sbUrl.Append(defaultDelimiter);
            return this;
        }

        public EndpointBuilder AppendParam(string name, string value)
        {
            // localhost/api/v1/user?[id=5]
            sbParams.AppendFormat("{0}={1}&", name, value);
            return this;
        }

        public string Build()
        {
            if (BaseUrl.EndsWith(defaultDelimiter))
                sbUrl.Insert(0, BaseUrl);
            else
              sbUrl.Insert(0, BaseUrl + defaultDelimiter);

            // localhost/api/v1/user
            var url = sbUrl.ToString().TrimEnd('&');

            if (sbParams.Length > 0)
            {
                string qParams = sbParams.ToString().TrimEnd('&');
                url = sbUrl.ToString().TrimEnd(defaultDelimiter).TrimEnd('?');

                // localhost/api/v1/user?[id=5]
                url = $"{url}?{qParams}";
            }

            return url.TrimEnd(defaultDelimiter);
        }
    }
}