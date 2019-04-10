﻿using Produto.Application.Interface;
using Produto.Domain.Entities;
using Produto.Domain.Interfaces.Services;

namespace Produto.Application
{

    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        /// <summary>
        /// CONTRUTOR BASE, INJEÇÃO DE DEPENDÊNCIA
        /// </summary>
        /// <param name="usuarioService"></param>
        public UsuarioAppService(IUsuarioService usuarioService)
            : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }
    }
}