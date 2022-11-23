using Ngclopedia.Application.Interfaces.Common;

namespace Ngclopedia.Application.Mailing;

public interface IEmailTemplateService : ITransientService
{
    string GenerateEmailTemplate<T>(string templateName, T mailTemplateModel);
}