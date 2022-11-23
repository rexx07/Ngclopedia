using System.ComponentModel;

namespace Ngclopedia.Domain.Common;

public enum AddressType
{
    [Description("The Office Address of the Party Headquarter.")]
    PoliticalPartyAddressHq = 10,

    [Description("The Branch Office Address of a Politiacl Party.")]
    PoliticalPartyAddressBranch = 20,

    [Description("The Address Office of The Administration Headquarter.")]
    AdministrativeOfficeHq = 30,

    [Description("The Address Office of The Adminstration Branch Office.")]
    AdministrativeOfficeBranch = 40,

    [Description("The Address of An Event.")]
    EventLocation = 50
}