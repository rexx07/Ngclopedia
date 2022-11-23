using System.ComponentModel;

namespace Ngclopedia.Domain.Forums;

public enum PublishedStatus
{
    [Description("All Articles")] All = 10,

    [Description("Articles Under Review Due to Violation.")]
    UnderReview = 20,

    [Description("Articles That Have Been Approved or Published To Public.")]
    Published = 30,

    [Description("Articles That Are Featured.")]
    Featured = 40
}