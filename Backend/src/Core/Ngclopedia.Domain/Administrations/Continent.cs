using System.ComponentModel;

namespace Ngclopedia.Domain.Administrations;

public enum Continent
{
    [Description("The African Continent.")]
    Africa = 10,

    [Description("The Antartica Continent.")]
    Antarctica = 10,

    [Description("The Asian Continent.")] Asia = 20,

    [Description("The European Continent.")]
    Europe = 30,

    [Description("The Australian/Oceanian Continent.")]
    AustraliaOceania = 40,

    [Description("The North American Continent.")]
    NorthAmerica = 50,

    [Description("The South American Continent.")]
    SouthAmerica = 60
}