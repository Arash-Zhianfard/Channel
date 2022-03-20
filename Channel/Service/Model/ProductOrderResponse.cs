using Service.Interfaces;

namespace Service.Model
{
    public class ProductOrderResponse : BaseReponse<List<MerchantOrderResponse>>
    {
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int ItemsPerPage { get; set; }
        public List<MerchantOrderResponse> Content { get; set; }
        public int StatusCode { get; set; }
        public int? LogId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public Dictionary<string, List<string>> ValidationErrors { get; set; }

        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }
    }

}
