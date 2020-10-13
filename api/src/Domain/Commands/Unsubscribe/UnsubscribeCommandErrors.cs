using System.ComponentModel;

namespace Domain.Commands.Unsubscribe
{
    public enum UnsubscribeCommandErrors
    {
        [Description("You are not subscribed")]
        NotSubscribed,
    }
}
