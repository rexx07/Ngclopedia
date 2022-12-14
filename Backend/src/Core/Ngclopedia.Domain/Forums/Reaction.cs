using System.ComponentModel.DataAnnotations.Schema;
using Ngclopedia.Domain.Contracts;
using Ngclopedia.Domain.Users;

namespace Ngclopedia.Domain.Forums;

public class Reaction : AuditableEntity
{
    private string _Parent;

    public Reaction(
        UserReaction reactionType, 
        Guid? articleId, 
        Guid? commentId, 
        string applicationUserId)
    {
        ReactionType = reactionType;
        ArticleId = articleId;
        CommentId = commentId;
        ApplicationUserId = applicationUserId;
    }

    public UserReaction ReactionType { get; set; }
    public Guid? ArticleId { get; set; }
    public Guid? CommentId { get; set; }
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    [NotMapped]
    public string Parent
    {
        get
        {
            if(string.IsNullOrEmpty(_Parent))
               return (ArticleId ?? CommentId).ToString()!;
            return _Parent;
        } 
        set => _Parent = value;
    }
}