using System.Threading;
using System.Threading.Tasks;

namespace Stl.Fusion.Authentication
{
    public interface IAuthService
    {
        Task LogoutAsync(bool force, Session? session = null, CancellationToken cancellationToken = default);
        Task SaveSessionInfoAsync(SessionInfo sessionInfo, Session? session = null, CancellationToken cancellationToken = default);
        Task UpdatePresenceAsync(Session? session = null, CancellationToken cancellationToken = default);

        [ComputeMethod(KeepAliveTime = 10)]
        Task<bool> IsLogoutForcedAsync(Session? session = null, CancellationToken cancellationToken = default);
        [ComputeMethod(KeepAliveTime = 10)]
        Task<User> GetUserAsync(Session? session = null, CancellationToken cancellationToken = default);
        [ComputeMethod(KeepAliveTime = 10)]
        Task<SessionInfo> GetSessionInfoAsync(Session? session = null, CancellationToken cancellationToken = default);
        [ComputeMethod]
        Task<SessionInfo[]> GetUserSessions(Session? session = null, CancellationToken cancellationToken = default);
    }

    public interface IServerSideAuthService : IAuthService
    {
        Task LoginAsync(User user, Session? session = null, CancellationToken cancellationToken = default);
    }
}
