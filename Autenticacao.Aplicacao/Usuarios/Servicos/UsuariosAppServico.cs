using Autenticacao.Aplicacao.Usuarios.Servicos.Interfaces;
using Autenticacao.DataTransfer.Utils.Responses;
using Autenticacao.Dominio.Usuarios.Entidades;
using Autenticacao.Dominio.Usuarios.Repositorios;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autenticacao.Aplicacao.Usuarios.Servicos
{
    public class UsuariosAppServico : IUsuariosAppServico
    {
        private readonly IUsuariosRepositorio usuariosRepositorio;
        private readonly IMapper mapper;

        public UsuariosAppServico(IUsuariosRepositorio usuariosRepositorio, IMapper mapper)
        {
            this.usuariosRepositorio = usuariosRepositorio;
            this.mapper = mapper;
        }

        public List<CodigoDescricaoResponse> Listar()
        {
            return usuariosRepositorio.Query().Select(x => mapper.Map<CodigoDescricaoResponse>(x)).ToList();
        }
    }
}
