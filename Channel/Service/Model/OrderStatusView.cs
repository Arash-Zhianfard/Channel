using System.Runtime.Serialization;

namespace ChannelEngine.Merchant.ApiClient.Model
{
    public enum OrderStatusView
    {
        [EnumMember(Value = "IN_PROGRESS")]
        IN_PROGRESS = 1,

        [EnumMember(Value = "SHIPPED")]
        SHIPPED,
    }
}
