using ChannelEngine.Merchant.ApiClient.Model;
using System.Text;

namespace Service.Model
{
    public class MerchantOrderResponse
    {
        public object? ChannelOrderSupport { get; set; }
        public OrderStatusView? Status { get; set; }
        public int Id { get; set; }
        public string ChannelName { get; set; }
        public int? ChannelId { get; set; }
        public string GlobalChannelName { get; set; }
        public int? GlobalChannelId { get; set; }
        public string ChannelOrderNo { get; set; }
        public string MerchantOrderNo { get; set; }
        public bool IsBusinessOrder { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string MerchantComment { get; set; }
        public object BillingAddress { get; set; }
        public object ShippingAddress { get; set; }
        public decimal? SubTotalInclVat { get; set; }
        public decimal? SubTotalVat { get; set; }
        public decimal? ShippingCostsVat { get; set; }
        public decimal TotalInclVat { get; set; }
        public decimal? TotalVat { get; set; }
        public decimal? OriginalSubTotalInclVat { get; set; }
        public decimal? OriginalSubTotalVat { get; set; }
        public decimal? OriginalShippingCostsInclVat { get; set; }
        public decimal? OriginalShippingCostsVat { get; set; }
        public decimal? OriginalTotalInclVat { get; set; }
        public decimal? OriginalTotalVat { get; set; }
        public List<MerchantOrderLineResponse> Lines { get; set; }
        public decimal ShippingCostsInclVat { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CompanyRegistrationNo { get; set; }
        public string VatNo { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentReferenceNo { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime OrderDate { get; set; }
        public string ChannelCustomerNo { get; set; }
        public Dictionary<string, string> ExtraData { get; set; }
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("  Id: ").Append(Id).Append("\n");
            stringBuilder.Append("  ChannelName: ").Append(ChannelName).Append("\n");
            stringBuilder.Append("  ChannelId: ").Append(ChannelId).Append("\n");
            stringBuilder.Append("  GlobalChannelName: ").Append(GlobalChannelName).Append("\n");
            stringBuilder.Append("  GlobalChannelId: ").Append(GlobalChannelId).Append("\n");
            stringBuilder.Append("  ChannelOrderSupport: ").Append(ChannelOrderSupport).Append("\n");
            stringBuilder.Append("  ChannelOrderNo: ").Append(ChannelOrderNo).Append("\n");
            stringBuilder.Append("  MerchantOrderNo: ").Append(MerchantOrderNo).Append("\n");
            stringBuilder.Append("  Status: ").Append(Status).Append("\n");
            stringBuilder.Append("  IsBusinessOrder: ").Append(IsBusinessOrder).Append("\n");
            stringBuilder.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            stringBuilder.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            stringBuilder.Append("  MerchantComment: ").Append(MerchantComment).Append("\n");
            stringBuilder.Append("  BillingAddress: ").Append(BillingAddress).Append("\n");
            stringBuilder.Append("  ShippingAddress: ").Append(ShippingAddress).Append("\n");
            stringBuilder.Append("  SubTotalInclVat: ").Append(SubTotalInclVat).Append("\n");
            stringBuilder.Append("  SubTotalVat: ").Append(SubTotalVat).Append("\n");
            stringBuilder.Append("  ShippingCostsVat: ").Append(ShippingCostsVat).Append("\n");
            stringBuilder.Append("  TotalInclVat: ").Append(TotalInclVat).Append("\n");
            stringBuilder.Append("  TotalVat: ").Append(TotalVat).Append("\n");
            stringBuilder.Append("  OriginalSubTotalInclVat: ").Append(OriginalSubTotalInclVat).Append("\n");
            stringBuilder.Append("  OriginalSubTotalVat: ").Append(OriginalSubTotalVat).Append("\n");
            stringBuilder.Append("  OriginalShippingCostsInclVat: ").Append(OriginalShippingCostsInclVat).Append("\n");
            stringBuilder.Append("  OriginalShippingCostsVat: ").Append(OriginalShippingCostsVat).Append("\n");
            stringBuilder.Append("  OriginalTotalInclVat: ").Append(OriginalTotalInclVat).Append("\n");
            stringBuilder.Append("  OriginalTotalVat: ").Append(OriginalTotalVat).Append("\n");
            stringBuilder.Append("  Lines: ").Append(Lines).Append("\n");
            stringBuilder.Append("  ShippingCostsInclVat: ").Append(ShippingCostsInclVat).Append("\n");
            stringBuilder.Append("  Phone: ").Append(Phone).Append("\n");
            stringBuilder.Append("  Email: ").Append(Email).Append("\n");
            stringBuilder.Append("  CompanyRegistrationNo: ").Append(CompanyRegistrationNo).Append("\n");
            stringBuilder.Append("  VatNo: ").Append(VatNo).Append("\n");
            stringBuilder.Append("  PaymentMethod: ").Append(PaymentMethod).Append("\n");
            stringBuilder.Append("  PaymentReferenceNo: ").Append(PaymentReferenceNo).Append("\n");
            stringBuilder.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            stringBuilder.Append("  OrderDate: ").Append(OrderDate).Append("\n");
            stringBuilder.Append("  ChannelCustomerNo: ").Append(ChannelCustomerNo).Append("\n");
            stringBuilder.Append("  ExtraData: ").Append(ExtraData).Append("\n");
            return stringBuilder.ToString();
        }
    }

}
