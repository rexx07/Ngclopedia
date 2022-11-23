using Ngclopedia.Application.Interfaces.Common;
using Ngclopedia.Domain.Common;

namespace Ngclopedia.Application.FileStorage;

public interface IFileStorageService : ITransientService
{
    public Task<string> UploadAsync<T>(FileUploadRequest? request, FileType supportedFileType,
        CancellationToken cancellationToken = default)
        where T : class;

    public void Remove(string? path);
}