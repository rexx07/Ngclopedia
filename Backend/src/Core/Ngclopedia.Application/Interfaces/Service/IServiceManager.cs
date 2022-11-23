using Ngclopedia.Application.Interfaces.Service.Administration;
using Ngclopedia.Application.Interfaces.Service.Auth;
using Ngclopedia.Application.Interfaces.Service.Common;
using Ngclopedia.Application.Interfaces.Service.Community;
using Ngclopedia.Application.Interfaces.Service.Forum;
using Ngclopedia.Application.Interfaces.Service.User;

namespace Ngclopedia.Application.Interfaces.Service;

public interface IServiceManager
{
    IRoleService RoleService { get; }

    ITokenService TokenService { get; }
    IUserService UserService { get; }
    IPoliticalOfficeService PoliticalOfficeService { get; }
    IPoliticalOfficeHolderService PoliticalOfficeHolderService { get; }
    IPoliticalPartyService PoliticalPartyService { get; }
    IAddressService AddressService { get; }
    IContactService ContactService { get; }
    ILocationService LocationService { get; }
    ICategoryBasedCommunityService CategoryBasedCommunityService { get; }
    ILocationBasedCommunityService LocationBasedCommunityService { get; }
    IArticleService ArticleService { get; }
    ICommentService CommentService { get; }
    IReactionService ReactionService { get; }
}