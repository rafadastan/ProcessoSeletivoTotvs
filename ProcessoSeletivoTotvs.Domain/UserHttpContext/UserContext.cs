using Microsoft.AspNetCore.Http;
using ProcessoSeletivoTotvs.Domain.Contracts.User;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ProcessoSeletivoTotvs.Domain.UserHttpContext
{
    public class UserContext : IUser
    {
        private readonly IHttpContextAccessor _accessor;

        public UserContext(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }
    }
}
