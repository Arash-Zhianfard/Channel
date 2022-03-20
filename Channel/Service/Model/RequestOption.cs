namespace Service.Model
{
    public class RequestOption
    {
        public RequestOption()
        {
            QueryStringItems = new Dictionary<string, string>();
            HeaderParameters = new Dictionary<string, string>();
        }
        public string Url { get; set; }
        public object Body { get; set; }
        public string ContentType { get; set; } = "application/json";
        public string Token { get; set; }
        public TimeSpan? Timeout { get; set; } = null;
        public Dictionary<string, string> QueryStringItems { get; set; } = null;
        public Dictionary<string, string> HeaderParameters = new Dictionary<string, string> { { "Accept", "application/json" } };
    }
}
