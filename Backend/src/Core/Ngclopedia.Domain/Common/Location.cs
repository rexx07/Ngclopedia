using Ngclopedia.Domain.Administrations;
using Ngclopedia.Domain.Contracts;

namespace Ngclopedia.Domain.Common;

public class Location : AuditableEntity
{
    public Location(
        string introduction,
        string pcode,
        string name,
        AdminType adminType,
        AdminLevel adminLevel,
        Continent continent)
    {
        Introduction = introduction;
        Pcode = pcode;
        Name = name;
        AdminType = adminType;
        AdminLevel = adminLevel;
        Continent = continent;
    }
    public string Introduction { get; set; }
    public string Pcode { get; set; }
    public string Name { get; set; }
    public AdminType AdminType { get; set; }
    public AdminLevel AdminLevel { get; set; }
    public Continent Continent { get; set; }
}