using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Ngclopedia.Domain.Common;
using Ngclopedia.Domain.Forums;

namespace Ngclopedia.Domain.Users;

public class ApplicationUser : IdentityUser
{
    private int _TotComments;
    private int _TotArticles;
    private int _TotReactions;
    private string _CurrentLocation;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public List<string> MediaUrls { get; set; }
    public string Bio { get; set; }
    public string? ImageUrl { get; set; }
    public string? CoverUrl { get; set; }
    public bool IsActive { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public Guid ContactId { get; set; }
    public Contact Contact { get; set; }
    public Guid AddressId { get; set; }
    public Address Address { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public ICollection<Contact> Contacts { get; set; }
    public ICollection<Article>? Articles { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public ICollection<Reaction>? Reactions { get; set; }

    [NotMapped]
    public int TotArticles
    {
        get => Articles?.Count ?? _TotArticles;
        set => _TotArticles = value;
    }
    
    [NotMapped]
    public int TotComments
    {
        get => Comments?.Count ?? _TotComments;
        set => _TotComments = value;
    }

    [NotMapped]
    public int TotReactions
    {
        get => Reactions?.Count ?? _TotReactions;
        set => _TotReactions = value;
    }

    [NotMapped]
    public string CurrentLocation
    {
        get => Address.Location.Name ?? _CurrentLocation;
        set => _CurrentLocation = value;
    }
}