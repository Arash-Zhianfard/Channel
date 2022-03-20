using System.Text;

namespace Service.Model
{
    public class TopSoldProduct
    {
        public string Gtin { get; }
        public string Description { get; }
        public int TotalQuantity { get; }

        public TopSoldProduct(string gtin, string description, int totalQuantity)
        {
            Gtin = gtin;
            Description = description;
            TotalQuantity = totalQuantity;
        }
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
