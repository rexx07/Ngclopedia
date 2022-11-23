using System.ComponentModel;

namespace Ngclopedia.Domain.Forums;

public enum ArticleCommunity
{
    [Description("Article is available to the public")]
    General = 10,

    [Description("Article is available based on location but can be open to the public")]
    Location = 20,

    [Description("Article is available based on category but can be open to the public")]
    Category = 30
}