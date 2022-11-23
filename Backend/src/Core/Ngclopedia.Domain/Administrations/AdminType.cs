using System.ComponentModel;

namespace Ngclopedia.Domain.Administrations;

public enum AdminType
{
    [Description("Federal Administration.")]
    Federal = 10,

    [Description("State Administration.")] State = 20,

    [Description("Senate House Of Assembly.")]
    Senate = 30,

    [Description("Federal House Of Representative.")]
    FederalConstituencies = 40,

    [Description("State House Of Representative.")]
    StateConstituencies = 50,

    [Description("Local Governtment Administration.")]
    LocalConstituencies = 60,

    [Description("Ward Administration.")] Wards = 70,

    [Description("Based in The Diaspora.")]
    Diaspora = 80
}