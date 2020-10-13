using System.ComponentModel;

namespace Domain.Commands.Subscribe
{
    public enum SubscribeCommandErrors
    {
        [Description("You are already subscribed")]
        AlreadySubscribed,
    }
}
