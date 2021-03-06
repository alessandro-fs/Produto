﻿using Produto.Domain.Entities;

namespace Produto.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario Login(string login, string senha);

        Usuario BuscarPorFacebookId(string facebookId);

        bool LoginExiste(string login);
    }
}
