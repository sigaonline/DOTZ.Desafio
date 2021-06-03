using DOTZ.Desafio.Model.Request;
using DOTZ.Desafio.Model.Result;
using System.Threading.Tasks;

namespace DOTZ.Desafio.Service.Interface.Services
{
    public interface IAccessTokenService
    {
        Task<UserResult> GenerateToken(LoginRequesty userRequest);
    }
}
