using Ngclopedia.Application.DataTransferObjects.Auth.Token;
using Ngclopedia.Application.Interfaces.Common;

namespace Ngclopedia.Application.Interfaces.Service.Auth;

public interface ITokenService : ITransientService
{
    Task<TokenDto> GetTokenAsync(TokenRequestDto request, string ipAddress, CancellationToken cancellationToken);

    Task<TokenDto> RefreshTokenAsync(RefreshTokenRequestDto request, string ipAddress);
}