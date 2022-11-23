using Ngclopedia.Application.Interfaces.Persistence.Repository;
using Ngclopedia.Infrastructure.Persistence.Context;

namespace Ngclopedia.Infrastructure.Persistence.Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<IAddressRepository> _addressRepository;
    private readonly Lazy<IArticleRepository> _articleRepository;
    private readonly Lazy<ICategoryBasedCommunityRepository> _categoryBasedCommunityRepository;
    private readonly Lazy<ICommentRepository> _commentRepository;
    private readonly Lazy<IContactRepository> _contactRepository;
    private readonly Lazy<ILocationBasedCommunityRepository> _locationBasedCommunityRepository;
    private readonly Lazy<ILocationRepository> _locationRepository;
    private readonly Lazy<IPoliticalOfficeHolderRepository> _politicalOfficeHolderRepository;
    private readonly Lazy<IPoliticalOfficeRepository> _politicalOfficeRepository;
    private readonly Lazy<IPoliticalPartyRepository> _politicalPartyRepository;
    private readonly Lazy<IReactionRepository> _reactionRepository;
    private readonly ApplicationDbContext _repositoryContext;

    public RepositoryManager(ApplicationDbContext repositoryContext)
    {
        _repositoryContext = repositoryContext;

        _addressRepository = new Lazy<IAddressRepository>(() =>
            new AddressRepository(repositoryContext));

        _articleRepository = new Lazy<IArticleRepository>(() =>
            new ArticleRepository(repositoryContext));

        _categoryBasedCommunityRepository = new Lazy<ICategoryBasedCommunityRepository>(() =>
            new CategoryBasedCommunityRepository(repositoryContext));

        _commentRepository = new Lazy<ICommentRepository>(() =>
            new CommentRepository(repositoryContext));

        _contactRepository = new Lazy<IContactRepository>(() =>
            new ContactRepository(repositoryContext));

        _locationBasedCommunityRepository = new Lazy<ILocationBasedCommunityRepository>(() =>
            new LocationBasedCommunityRepository(repositoryContext));

        _locationRepository = new Lazy<ILocationRepository>(() =>
            new LocationRepository(repositoryContext));

        _politicalOfficeHolderRepository = new Lazy<IPoliticalOfficeHolderRepository>(() =>
            new PoliticalOfficeHolderRepository(repositoryContext));

        _politicalOfficeRepository = new Lazy<IPoliticalOfficeRepository>(() =>
            new PoliticalOfficeRepository(repositoryContext));

        _politicalPartyRepository = new Lazy<IPoliticalPartyRepository>(() =>
            new PoliticalPartyRepository(repositoryContext));

        _reactionRepository = new Lazy<IReactionRepository>(() =>
            new ReactionRepository(repositoryContext));
    }

    public IAddressRepository Address => _addressRepository.Value;
    public IArticleRepository Article => _articleRepository.Value;
    public ICategoryBasedCommunityRepository CategoryBasedCommunity => _categoryBasedCommunityRepository.Value;
    public ICommentRepository Comment => _commentRepository.Value;
    public IContactRepository Contact => _contactRepository.Value;
    public ILocationBasedCommunityRepository LocationBasedCommunity => _locationBasedCommunityRepository.Value;
    public ILocationRepository Location => _locationRepository.Value;
    public IPoliticalOfficeRepository PoliticalOffice => _politicalOfficeRepository.Value;
    public IPoliticalPartyRepository PoliticalParty => _politicalPartyRepository.Value;
    public IPoliticalOfficeHolderRepository PoliticalOfficeHolder => _politicalOfficeHolderRepository.Value;
    public IReactionRepository Reaction => _reactionRepository.Value;

    public async Task SaveAsync()
    {
        await _repositoryContext.SaveChangesAsync();
    }
}