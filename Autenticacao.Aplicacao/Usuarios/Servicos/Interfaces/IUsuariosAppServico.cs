using Autenticacao.DataTransfer.Utils.Responses;
using Autenticacao.Dominio.Usuarios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autenticacao.Aplicacao.Usuarios.Servicos.Interfaces
{
    public interface IUsuariosAppServico
    {
        List<CodigoDescricaoResponse> Listar();
    }
}
