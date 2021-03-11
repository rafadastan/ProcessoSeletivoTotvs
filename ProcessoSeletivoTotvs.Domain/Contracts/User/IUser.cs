using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ProcessoSeletivoTotvs.Domain.Contracts.User
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
    }
}
