using System.ComponentModel.DataAnnotations.Schema;
using Ngclopedia.Domain.Common;
using Ngclopedia.Domain.Contracts;
using Ngclopedia.Domain.Users;

namespace Ngclopedia.Domain.Forums;

public class Article : AuditableEntity
{
    private int _totAgreeReactions;
    private int _totComments;

    private int _totDisagreeReactions;

    private int _totNeutralReactions;

    private int _totReactions;

    public Article(
        string title, 
        string content, 
        Category category, 
        Guid locationId,
        PublishedStatus publishedStatus,
        string applicationUserId,
        ArticleCommunity articleCommunity)
    {
        Title = title;
        Content = content;
        Category = category;
        LocationId = locationId;
        PublishedStatus = publishedStatus;
        ApplicationUserId = applicationUserId;
        ArticleCommunity = articleCommunity;
    }

    public string Title { get; } = default!;
    public string Content { get; set; }
    public bool AllowComments { get; set; } = true;
    public Category Category { get; set; }
    public Guid LocationId { get; set; }
    public Location Location { get; set; }
    public PublishedStatus PublishedStatus { get; set; }
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
    public ArticleCommunity ArticleCommunity { get; set; }
    public bool Edited { get; set; }
    public List<string>? Edits { get; set; }
    public List<string>? Images { get; set; }
    public List<string> Tags { get; set; }
    public ICollection<Reaction>? Reactions { get; set; }
    public ICollection<Comment>? Comments { get; set; }

    [NotMapped]
    public int TotDisagreeReactions
    {
        get
        {
            var count = 0;
            if (Reactions != null)
                for (var fact = 0; fact < Reactions.Count; fact++)
                    if (Reactions.ElementAt(fact).ReactionType.Equals(UserReaction.Disagree))
                        count++;

            return Reactions != null ? count : _totAgreeReactions;
        }
        set => _totDisagreeReactions = value;
    }

    [NotMapped]
    public int TotAgreeReactions
    {
        get
        {
            var count = 0;
            if (Reactions != null)
                for (var reactionCount = 0; reactionCount < Reactions.Count; reactionCount++)
                    if (Reactions.ElementAt(reactionCount).ReactionType.Equals(UserReaction.Agree))
                        count++;

            return Reactions != null ? count : _totDisagreeReactions;
        }
        set => _totAgreeReactions = value;
    }

    [NotMapped]
    public int TotNeutralReactions
    {
        get
        {
            var count = 0;
            if (Reactions != null)
                for (var fact = 0; fact < Reactions.Count; fact++)
                    if (Reactions.ElementAt(fact).ReactionType.Equals(UserReaction.Neutral))
                        count++;

            return Reactions != null ? count : _totNeutralReactions;
        }
        set => _totNeutralReactions = value;
    }

    [NotMapped]
    public int TotComments
    {
        get => Comments?.Count ?? _totComments;
        set => _totComments = value;
    }

    [NotMapped]
    public int TotReactions
    {
        get => Reactions?.Count ?? _totReactions;
        set => _totReactions = value;
    }
}