namespace Service.Interfaces
{
    public interface BaseReponse<T>
    {
        public T Content { get; set; }
        public int StatusCode { get; set; }
        public int? LogId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<string, List<string>> ValidationErrors { get; set; }
    }
}
