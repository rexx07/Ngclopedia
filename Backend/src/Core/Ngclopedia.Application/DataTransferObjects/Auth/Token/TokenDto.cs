namespace Ngclopedia.Application.DataTransferObjects.Auth.Token;

public record TokenDto(string Token, string RefreshToken, DateTime RefreshTokenExpiryTime);