namespace Ngclopedia.Application.DataTransferObjects.Auth.Token;

public record RefreshTokenRequestDto(string Token, string RefreshToken);