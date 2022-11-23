using System.Collections.ObjectModel;

namespace Ngclopedia.Application.Authorization;

public static class NgclopediaAction
{
    public const string View = nameof(View);
    public const string Search = nameof(Search);
    public const string Create = nameof(Create);
    public const string Update = nameof(Update);
    public const string Delete = nameof(Delete);
    public const string Export = nameof(Export);
    public const string ExtendAccess = nameof(ExtendAccess);
}

public static class NgclopediaResource
{
    /*public const string Dashboard = nameof(Dashboard);
    public const string Hangfire = nameof(Hangfire);*/

    public const string Roots = nameof(Roots);
    public const string Users = nameof(Users);
    public const string UserRoles = nameof(UserRoles);
    public const string Roles = nameof(Roles);
    public const string RoleClaims = nameof(RoleClaims);
    public const string PoliticalOffices = nameof(PoliticalOffices);
    public const string PoliticalOfficeHolders = nameof(PoliticalOfficeHolders);
    public const string PoliticalParties = nameof(PoliticalParties);
    public const string CategoryBasedCommunities = nameof(CategoryBasedCommunities);
    public const string LocationBasedCommunities = nameof(LocationBasedCommunities);
    public const string Articles = nameof(Articles);
    public const string Comments = nameof(Comments);
    public const string Reactions = nameof(Reactions);
    public const string Locations = nameof(Locations);
    public const string Addresses = nameof(Addresses);
    public const string Contacts = nameof(Contacts);
}

public static class NgclopediaPermissions
{
    private static readonly NgclopediaPermission[] _all =
    {
        /*new("View Dashboard", NgclopediaAction.View, NgclopediaResource.Dashboard),
        new("View Hangfire", NgclopediaAction.View, NgclopediaResource.Hangfire),*/

        new("View Users", NgclopediaAction.View, NgclopediaResource.Users),
        new("Search Users", NgclopediaAction.Search, NgclopediaResource.Users),
        new("Create Users", NgclopediaAction.Create, NgclopediaResource.Users),
        new("Update Users", NgclopediaAction.Update, NgclopediaResource.Users),
        new("Delete Users", NgclopediaAction.Delete, NgclopediaResource.Users),
        new("Export Users", NgclopediaAction.Export, NgclopediaResource.Users),

        new("View User Roles", NgclopediaAction.View, NgclopediaResource.UserRoles),
        new("Search User Roles", NgclopediaAction.Search, NgclopediaResource.UserRoles),
        new("Create User Roles", NgclopediaAction.Create, NgclopediaResource.UserRoles),
        new("Update User Roles", NgclopediaAction.Update, NgclopediaResource.UserRoles),
        new("Delete User Roles", NgclopediaAction.Delete, NgclopediaResource.UserRoles),

        new("View Roles", NgclopediaAction.View, NgclopediaResource.Roles),
        new("Search Roles", NgclopediaAction.Search, NgclopediaResource.Roles),
        new("Create Roles", NgclopediaAction.Create, NgclopediaResource.Roles),
        new("Update Roles", NgclopediaAction.Update, NgclopediaResource.Roles),
        new("Delete Roles", NgclopediaAction.Delete, NgclopediaResource.Roles),
        new("View Role Claims", NgclopediaAction.View, NgclopediaResource.RoleClaims),
        new("Update Role Claims", NgclopediaAction.Update, NgclopediaResource.RoleClaims),

        new("View Political Offices", NgclopediaAction.View, NgclopediaResource.PoliticalOffices, true),
        new("Search Political Offices", NgclopediaAction.Search, NgclopediaResource.PoliticalOffices, true),
        new("Create Political Offices", NgclopediaAction.Create, NgclopediaResource.PoliticalOffices),
        new("Update Political Offices", NgclopediaAction.Update, NgclopediaResource.PoliticalOffices),
        new("Delete Political Offices", NgclopediaAction.Delete, NgclopediaResource.PoliticalOffices),
        new("Export Political Offices", NgclopediaAction.Export, NgclopediaResource.PoliticalOffices),

        new("View Political Office Holders", NgclopediaAction.View, NgclopediaResource.PoliticalOfficeHolders,
            true),
        new("Search Political Office Holders", NgclopediaAction.Search, NgclopediaResource.PoliticalOfficeHolders,
            true),
        new("Create Political Office Holders", NgclopediaAction.Create, NgclopediaResource.PoliticalOfficeHolders),
        new("Update Political Office Holders", NgclopediaAction.Update, NgclopediaResource.PoliticalOfficeHolders),
        new("Delete Political Office Holders", NgclopediaAction.Delete, NgclopediaResource.PoliticalOfficeHolders),
        new("Export Political Office Holders", NgclopediaAction.Export, NgclopediaResource.PoliticalOfficeHolders),

        new("View Political Parties", NgclopediaAction.View, NgclopediaResource.PoliticalParties,
            true),
        new("Search Political Parties", NgclopediaAction.Search, NgclopediaResource.PoliticalParties,
            true),
        new("Create Political Parties", NgclopediaAction.Create, NgclopediaResource.PoliticalParties),
        new("Update Political Parties", NgclopediaAction.Update, NgclopediaResource.PoliticalParties),
        new("Delete Political Parties", NgclopediaAction.Delete, NgclopediaResource.PoliticalParties),
        new("Export Political Parties", NgclopediaAction.Export, NgclopediaResource.PoliticalParties),

        new("View Category Based Communities", NgclopediaAction.View, NgclopediaResource.CategoryBasedCommunities,
            true),
        new("Search Category Based Communities", NgclopediaAction.Search, NgclopediaResource.CategoryBasedCommunities,
            true),
        new("Create Category Based Communities", NgclopediaAction.Create, NgclopediaResource.CategoryBasedCommunities),
        new("Update Category Based Communities", NgclopediaAction.Update, NgclopediaResource.CategoryBasedCommunities),
        new("Delete Category Based Communities", NgclopediaAction.Delete, NgclopediaResource.CategoryBasedCommunities),
        new("Export Category Based Communities", NgclopediaAction.Export, NgclopediaResource.CategoryBasedCommunities),

        new("View Location Based Communities", NgclopediaAction.View, NgclopediaResource.LocationBasedCommunities,
            true),
        new("Search Location Based Communities", NgclopediaAction.Search, NgclopediaResource.LocationBasedCommunities,
            true),
        new("Create Location Based Communities", NgclopediaAction.Create, NgclopediaResource.LocationBasedCommunities),
        new("Update Location Based Communities", NgclopediaAction.Update, NgclopediaResource.LocationBasedCommunities),
        new("Delete Location Based Communities", NgclopediaAction.Delete, NgclopediaResource.LocationBasedCommunities),
        new("Export Location Based Communities", NgclopediaAction.Export, NgclopediaResource.LocationBasedCommunities),

        new("View Articles", NgclopediaAction.View, NgclopediaResource.Articles, true),
        new("Search Articles", NgclopediaAction.Search, NgclopediaResource.Articles, true),
        new("Create Articles", NgclopediaAction.Create, NgclopediaResource.Articles),
        new("Update Articles", NgclopediaAction.Update, NgclopediaResource.Articles),
        new("Delete Articles", NgclopediaAction.Delete, NgclopediaResource.Articles),
        new("Export Articles", NgclopediaAction.Export, NgclopediaResource.Articles),

        new("View Comments", NgclopediaAction.View, NgclopediaResource.Comments, true),
        new("Search Comments", NgclopediaAction.Search, NgclopediaResource.Comments, true),
        new("Create Comments", NgclopediaAction.Create, NgclopediaResource.Comments),
        new("Update Comments", NgclopediaAction.Update, NgclopediaResource.Comments),
        new("Delete Comments", NgclopediaAction.Delete, NgclopediaResource.Comments),
        new("Export Comments", NgclopediaAction.Export, NgclopediaResource.Comments),

        new("View Reactions", NgclopediaAction.View, NgclopediaResource.Reactions, true),
        new("Search Reactions", NgclopediaAction.Search, NgclopediaResource.Reactions, true),
        new("Create Reactions", NgclopediaAction.Create, NgclopediaResource.Reactions),
        new("Update Reactions", NgclopediaAction.Update, NgclopediaResource.Reactions),
        new("Delete Reactions", NgclopediaAction.Delete, NgclopediaResource.Reactions),

        new("View Addresses", NgclopediaAction.View, NgclopediaResource.Addresses, true),
        new("Search Addresses", NgclopediaAction.Search, NgclopediaResource.Addresses, true),
        new("Create Addresses", NgclopediaAction.Create, NgclopediaResource.Addresses),
        new("Update Addresses", NgclopediaAction.Update, NgclopediaResource.Addresses),
        new("Delete Addresses", NgclopediaAction.Delete, NgclopediaResource.Addresses),
        new("Export Addresses", NgclopediaAction.Export, NgclopediaResource.Addresses),

        new("View Contacts", NgclopediaAction.View, NgclopediaResource.Contacts, true),
        new("Search Contacts", NgclopediaAction.Search, NgclopediaResource.Contacts, true),
        new("Create Contacts", NgclopediaAction.Create, NgclopediaResource.Contacts),
        new("Update Contacts", NgclopediaAction.Update, NgclopediaResource.Contacts),
        new("Delete Contacts", NgclopediaAction.Delete, NgclopediaResource.Contacts),
        new("Export Contacts", NgclopediaAction.Export, NgclopediaResource.Contacts),

        new("View Locations", NgclopediaAction.View, NgclopediaResource.Locations, true),
        new("Search Locations", NgclopediaAction.Search, NgclopediaResource.Locations, true),
        new("Create Locations", NgclopediaAction.Create, NgclopediaResource.Locations),
        new("Update Locations", NgclopediaAction.Update, NgclopediaResource.Locations),
        new("Delete Locations", NgclopediaAction.Delete, NgclopediaResource.Locations),
        new("Export Locations", NgclopediaAction.Export, NgclopediaResource.Locations),

        new("View Roots", NgclopediaAction.View, NgclopediaResource.Roots, IsRoot: true),
        new("Create Roots", NgclopediaAction.Create, NgclopediaResource.Roots, IsRoot: true),
        new("Update Roots", NgclopediaAction.Update, NgclopediaResource.Roots, IsRoot: true),
        new("Upgrade Roots Subscription", NgclopediaAction.ExtendAccess, NgclopediaResource.Roots, IsRoot: true)
    };

    public static IReadOnlyList<NgclopediaPermission> All { get; } = new ReadOnlyCollection<NgclopediaPermission>
        (_all);

    public static IReadOnlyList<NgclopediaPermission> Root { get; } = new ReadOnlyCollection<NgclopediaPermission>
        (_all.Where(p => p.IsRoot).ToArray());

    public static IReadOnlyList<NgclopediaPermission> Superuser { get; } = new ReadOnlyCollection<NgclopediaPermission>
        (_all.Where(p => p.IsRoot).ToArray());

    public static IReadOnlyList<NgclopediaPermission> Admin { get; } = new ReadOnlyCollection<NgclopediaPermission>
        (_all.Where(p => !p.IsRoot).ToArray());

    public static IReadOnlyList<NgclopediaPermission> Basic { get; } = new ReadOnlyCollection<NgclopediaPermission>
        (_all.Where(p => p.IsBasic).ToArray());
}

public record NgclopediaPermission(string Description, string Action, string Resource, bool IsBasic = false,
    bool IsRoot = false)
{
    public string Name => NameFor(Action, Resource);

    public static string NameFor(string action, string resource)
    {
        return $"Permissions.{resource}.{action}";
    }
}