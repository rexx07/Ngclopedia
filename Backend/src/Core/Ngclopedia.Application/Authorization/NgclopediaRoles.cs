using System.Collections.ObjectModel;

namespace Ngclopedia.Application.Authorization;

public static class NgclopediaRoles
{
    public const string Root = nameof(Root);
    public const string Superuser = nameof(Superuser);
    public const string Admin = nameof(Admin);
    public const string Basic = nameof(Basic);

    public static IReadOnlyList<string> DefaultRoles { get; } = new ReadOnlyCollection<string>(new[]
    {
        Root,
        Superuser,
        Admin,
        Basic
    });

    public static bool IsDefault(string roleName)
    {
        return DefaultRoles.Any(r => r == roleName);
    }
}