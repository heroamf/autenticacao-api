using Autenticacao.DataTransfer.Utils.Responses;
using Autenticacao.Dominio.Usuarios.Entidades;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autenticacao.Aplicacao.Usuarios.Profiles
{
    public class UsuariosProfile : Profile
    {
        public UsuariosProfile()
        {
            CreateMap<Usuario, CodigoDescricaoResponse>()
                .ForMember(x => x.Descricao, x => x.MapFrom(source => source.Nome));
        }
    }
}
