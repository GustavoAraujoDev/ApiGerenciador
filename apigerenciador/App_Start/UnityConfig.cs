using System.Web.Http;
using Unity;
using Unity.WebApi;
using apigerenciador.Application.UseCases;
using apigerenciador.Infrastructure.Data;
using apigerenciador.Infrastructure.Logging;
using apigerenciador.Infrastructure.Data.DAO;
using Unity.Lifetime;

namespace apigerenciador
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // Configuração das dependências
            container.RegisterType<ConnectionManager, ConnectionManager>(new HierarchicalLifetimeManager());
            container.RegisterType<ProdutoDAO, ProdutoDAO>(new HierarchicalLifetimeManager());
            container.RegisterType<SerilogLogger, SerilogLogger>(new HierarchicalLifetimeManager());
            container.RegisterType<ProdutoRepository, ProdutoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<AdicionarProdutoUseCase, AdicionarProdutoUseCase>(new HierarchicalLifetimeManager());
            container.RegisterType<AtualizarProdutoUseCase, AtualizarProdutoUseCase>(new HierarchicalLifetimeManager());
            container.RegisterType<DeletarProdutoUseCase, DeletarProdutoUseCase>(new HierarchicalLifetimeManager());
            container.RegisterType<ObterProdutoPorIdUseCase, ObterProdutoPorIdUseCase>(new HierarchicalLifetimeManager());
            container.RegisterType<ObterTodosProdutosUseCase, ObterTodosProdutosUseCase>(new HierarchicalLifetimeManager());
            container.RegisterType<Conexao, Conexao>(new HierarchicalLifetimeManager());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}