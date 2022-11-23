using System.ComponentModel;

namespace Ngclopedia.Domain.Forums;

public enum UserReaction
{
    [Description("An Approving Reaction to An Article By A User")]
    Agree = 10,

    [Description("An Indifferent Reaction to An Article By A User.")]
    Neutral = 20,

    [Description("A Disapproving Reaction to An Article By A User")]
    Disagree = 30
}