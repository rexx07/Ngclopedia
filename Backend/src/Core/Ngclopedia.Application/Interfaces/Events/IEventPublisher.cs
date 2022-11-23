using Ngclopedia.Application.Interfaces.Common;
using Ngclopedia.Domain.Contracts;

namespace Ngclopedia.Application.Interfaces.Events;

public interface IEventPublisher : ITransientService
{
    Task PublishAsync(IEvent @event);
}