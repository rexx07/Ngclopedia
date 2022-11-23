namespace Ngclopedia.Application.Interfaces.Persistence.Repository;

public interface IRepositoryManager
{
    IAddressRepository Address { get; }
    IArticleRepository Article { get; }
    ICategoryBasedCommunityRepository CategoryBasedCommunity { get; }
    ICommentRepository Comment { get; }
    IContactRepository Contact { get; }
    ILocationBasedCommunityRepository LocationBasedCommunity { get; }
    ILocationRepository Location { get; }
    IPoliticalOfficeRepository PoliticalOffice { get; }
    IPoliticalPartyRepository PoliticalParty { get; }
    IPoliticalOfficeHolderRepository PoliticalOfficeHolder { get; }
    IReactionRepository Reaction { get; }
    Task SaveAsync();
}