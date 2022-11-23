using System.ComponentModel;

namespace Ngclopedia.Domain.Administrations;

public enum OfficeType
{
    [Description("The Office Of The President.")]
    President = 10,

    [Description("The Office Of The Governor.")]
    Governor = 20,

    [Description("The Office Of The Senator.")]
    Senator = 30,

    [Description("The Office Of The Federal House Of Representative.")]
    FederalRepresentative = 40,

    [Description("The Office Of The State House Of Representative.")]
    StateRepresentative = 50,

    [Description("The Office Of The Local Government Chairman.")]
    LgaChairman = 60,

    [Description("The Office Of The Councillor.")]
    Councillor = 70
}