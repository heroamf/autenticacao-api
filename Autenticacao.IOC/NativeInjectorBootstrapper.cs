using Autenticacao.Aplicacao.Usuarios.Profiles;
using Autenticacao.Aplicacao.Usuarios.Servicos;
using Autenticacao.Infra.Usuarios.Mapeamentos;
using Autenticacao.Infra.Usuarios.Repositorios;
using AutoMapper;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Driver;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Autenticacao.IOC
{
    public class NativeInjectorBootstrapper
    {
        private static ISessionFactory CreateSession(string connectionString)
        {
            return Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(connectionString)
                    .Driver<MySqlDataDriver>()
                    .ShowSql()
                    .FormatSql())
                .Mappings(c => c.FluentMappings.AddFromAssemblyOf<UsuariosMap>())
                .BuildConfiguration()
                .BuildSessionFactory();
        }

        public static void Configuracao(IConfiguration configuration, IServiceCollection services)
        {
            var sessionFactory = CreateSession(configuration.GetSection("Mysql").Value);
            services.AddSingleton(sessionFactory);
            services.AddScoped(Factory => sessionFactory.OpenSession());
            services.Scan(scan => scan.
                                    FromAssemblyOf<UsuariosAppServico>()
                                    .AddClasses()
                                    .AsImplementedInterfaces()
                                    .WithTransientLifetime());

            services.Scan(scan => scan.
                                    FromAssemblyOf<UsuariosRepositorio>()
                                    .AddClasses()
                                    .AsImplementedInterfaces()
                                    .WithTransientLifetime());


            services.AddAutoMapper(typeof(UsuariosProfile).GetTypeInfo().Assembly);
            
            //adicionar scan para dominio/servicos
        }
    }
}
