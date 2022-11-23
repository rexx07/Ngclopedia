using Ngclopedia.Application.Interfaces.Common;

namespace Ngclopedia.Application.Mailing;

public interface IMailService : ITransientService
{
    Task SendAsync(MailRequest request, CancellationToken ct);
}