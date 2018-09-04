//using AutoMapper;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Yagohf.PUC.Business.Dominio;
//using Yagohf.PUC.Business.Extensions;
//using Yagohf.PUC.Business.Interface.Validacao.Produto;
//using Yagohf.PUC.Business.Mappings;
//using Yagohf.PUC.Data.Interface.Queries;
//using Yagohf.PUC.Data.Interface.Repository;
//using Yagohf.PUC.Infraestrutura.Exception;
//using Yagohf.PUC.Model.DTO.Produto;
//using Yagohf.PUC.Model.Entidades;
//using Yagohf.PUC.Model.Infraestrutura;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Yagohf.PUC.Tests.Business
//{
//    [TestClass]
//    public class ProdutoBusinessTests
//    {
//        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
//        private readonly Mock<IProdutoQuery> _produtoQueryMock;
//        private readonly IMapper _mapper;
//        private ProdutoBusiness _produtoBusiness;

//        public ProdutoBusinessTests()
//        {
//            this._produtoRepositoryMock = new Mock<IProdutoRepository>();
//            this._produtoQueryMock = new Mock<IProdutoQuery>();

//            MapperConfiguration mapperConfiguration = new MapperConfiguration(mConfig =>
//            {
//                mConfig.AddProfile(new BusinessMapProfile());
//            });

//            this._mapper = mapperConfiguration.CreateMapper();
//        }

//        [TestInitialize]
//        public void Inicializar()
//        {
//            this._produtoBusiness = new ProdutoBusiness(this._produtoRepositoryMock.Object,
//                                                                      this._produtoQueryMock.Object,
//                                                                      this._mapper);
//        }

//        [TestMethod]
//        public async Task Testar_ListarAsync_Paginando()
//        {
//            //Arrange.
//            int pagina = 1;
//            int registrosPorPagina = 10;

//            var listaProdutos = new List<Produto>();
//            for (int i = 0; i < registrosPorPagina; i++)
//            {
//                listaProdutos.Add(new Produto()
//                {
//                    Id = i,
//                    Nome = $"Prod {i}",
//                    IdGrupoProduto = i,
//                    Sigla = $"Sigla {i}"
//                });
//            }

//            var paginacao = new Paginacao(pagina, listaProdutos.Count, registrosPorPagina);
//            var mockListaOriginal = new Listagem<Produto>(listaProdutos, paginacao);
//            var mockListaPaginada = new Listagem<ProdutoDTO>(listaProdutos.Mapear<Produto, ProdutoDTO>(this._mapper), paginacao);

//            this._produtoRepositoryMock
//                .Setup(rep => rep.ListarPaginandoAsync(It.IsAny<IQuery<Produto>>(), pagina, registrosPorPagina))
//                .Returns(Task.FromResult(mockListaOriginal));

//            //Act.
//            var result = await this._produtoBusiness.ListarAsync(null, null, null, pagina);

//            //Assert.
//            Assert.IsNotNull(result);
//            Assert.IsNotNull(result.Lista);
//            Assert.IsNotNull(result.Paginacao);
//            CollectionAssert.AreEquivalent(mockListaOriginal.Lista.Select(x => x.Id).ToList(), result.Lista.Select(x => x.Id).ToList());
//            Assert.AreEqual(mockListaPaginada.Lista.Count(), result.Lista.Count());
//        }

//        [TestMethod]
//        public async Task Testar_ListarAsync_SemPaginar()
//        {
//            //Arrange.
//            int registrosPorPagina = 10;
//            var listaLocalidadesTipo = new List<Produto>();
//            for (int i = 0; i < registrosPorPagina; i++)
//            {
//                listaLocalidadesTipo.Add(new Produto()
//                {
//                    Id = i,
//                    Nome = $"Prod {i}",
//                    IdGrupoProduto = i,
//                    Sigla = $"Sigla {i}"
//                });
//            }

//            var mockListaOriginal = new Listagem<Produto>(listaLocalidadesTipo);
//            this._produtoRepositoryMock
//                .Setup(rep => rep.ListarAsync(It.IsAny<IQuery<Produto>>()))
//                .Returns(Task.FromResult(listaLocalidadesTipo as IEnumerable<Produto>));

//            //Act.
//            var result = await this._produtoBusiness.ListarAsync(null, null, null, null);

//            //Assert.
//            Assert.IsNotNull(result);
//            Assert.IsNotNull(result.Lista);
//            Assert.IsNull(result.Paginacao);
//            Assert.AreEqual(mockListaOriginal.Lista.Count(), result.Lista.Count());
//            CollectionAssert.AreEquivalent(mockListaOriginal.Lista.Select(x => x.Id).ToList(), result.Lista.Select(x => x.Id).ToList());
//        }

//        [TestMethod]
//        public async Task Testar_SelecionarPorIdAsync()
//        {
//            //Arrange.
//            int idProduto = 1;
//            Produto mockProduto = new Produto()
//            {
//                Id = idProduto,
//                Nome = $"Prod 1",
//                IdGrupoProduto = 1,
//                Sigla = $"Sigla 1"
//            };

//            this._produtoRepositoryMock
//                .Setup(rep => rep.SelecionarUnicoAsync(It.IsAny<IQuery<Produto>>()))
//                .Returns(Task.FromResult(mockProduto));

//            //Act.
//            var result = await this._produtoBusiness.SelecionarPorIdAsync(idProduto);

//            //Assert.
//            Assert.IsNotNull(result);
//            Assert.AreEqual(mockProduto.Id, result.Id);
//        }

//        [TestMethod]
//        public async Task Testar_ExcluirAsync_Valido()
//        {
//            //Arrange.
//            int idProduto = 1;

//            this._produtoRepositoryMock
//                .Setup(rep => rep.ExcluirAsync(idProduto))
//                .Returns(Task.CompletedTask);

//            this._produtoExcluirValidadorMock
//                .Setup(val => val.ValidarAsync(It.IsAny<ProdutoDTO>()))
//                .Returns(Task.FromResult(true));

//            //Act.
//            await this._produtoBusiness.ExcluirAsync(idProduto);
//        }

//        [TestMethod]
//        [ExpectedException(typeof(BusinessException))]
//        public async Task Testar_ExcluirAsync_Invalido()
//        {
//            //Arrange.
//            int idProduto = 1;

//            this._produtoRepositoryMock
//                .Setup(rep => rep.ExcluirAsync(idProduto))
//                .Returns(Task.CompletedTask);

//            this._produtoExcluirValidadorMock
//                .Setup(val => val.ValidarAsync(It.IsAny<ProdutoDTO>()))
//                .Returns(Task.FromResult(false));

//            //Act.
//            await this._produtoBusiness.ExcluirAsync(idProduto);
//        }

//        [TestMethod]
//        public async Task Testar_CriarAsync_Valido()
//        {
//            //Arrange.
//            ProdutoDTO produtoCriar = new ProdutoDTO()
//            {
//                Id = 1,
//                Nome = $"Prod 1",
//                IdGrupoProduto = 1,
//                Sigla = $"Sigla 1"
//            };

//            this._produtoCriarValidadorMock
//                .Setup(val => val.ValidarAsync(It.IsAny<ProdutoDTO>()))
//                .Returns(Task.FromResult(true));

//            this._produtoRepositoryMock
//                .Setup(rep => rep.InserirAsync(It.IsAny<Produto>()))
//                .Returns(Task.CompletedTask);

//            //Act.
//            var result = await this._produtoBusiness.CriarAsync(produtoCriar);

//            //Assert.
//            Assert.IsNotNull(result);
//            Assert.AreEqual(produtoCriar.Nome, result.Nome);
//            this._produtoCriarValidadorMock.Verify(val => val.ValidarAsync(It.IsAny<ProdutoDTO>()), Times.Once);
//            this._produtoRepositoryMock.Verify(rep => rep.InserirAsync(It.IsAny<Produto>()), Times.Once);
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ValidacaoDTOException))]
//        public async Task Testar_CriarAsync_Invalido()
//        {
//            //Arrange.
//            ProdutoDTO produtoCriar = new ProdutoDTO()
//            {
//                Id = 1,
//                Nome = $"Prod 1",
//                IdGrupoProduto = 1,
//                Sigla = $"Sigla 1"
//            };

//            this._produtoCriarValidadorMock
//                .Setup(val => val.ValidarAsync(It.IsAny<ProdutoDTO>()))
//                .Returns(Task.FromResult(false));

//            this._produtoRepositoryMock
//                .Setup(rep => rep.InserirAsync(It.IsAny<Produto>()))
//                .Returns(Task.CompletedTask);

//            //Act.
//            await this._produtoBusiness.CriarAsync(produtoCriar);
//        }

//        [TestMethod]
//        public async Task Testar_AtualizarAsync_Valido()
//        {
//            //Arrange.
//            ProdutoDTO produtoAlterar = new ProdutoDTO()
//            {
//                Id = 1,
//                Nome = $"Prod 1",
//                IdGrupoProduto = 1,
//                Sigla = $"Sigla 1"
//            };

//            this._produtoAlterarValidadorMock
//                .Setup(val => val.ValidarAsync(It.IsAny<ProdutoDTO>()))
//                .Returns(Task.FromResult(true));

//            this._produtoRepositoryMock
//                .Setup(rep => rep.AtualizarAsync(It.IsAny<Produto>()))
//                .Returns(Task.CompletedTask);

//            //Act.
//            await this._produtoBusiness.AtualizarAsync(produtoAlterar);

//            //Assert.
//            this._produtoAlterarValidadorMock.Verify(val => val.ValidarAsync(It.IsAny<ProdutoDTO>()), Times.Once);
//            this._produtoRepositoryMock.Verify(rep => rep.AtualizarAsync(It.IsAny<Produto>()), Times.Once);
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ValidacaoDTOException))]
//        public async Task Testar_AtualizarAsync_Invalido()
//        {
//            //Arrange.
//            ProdutoDTO produtoAlterar = new ProdutoDTO()
//            {
//                Id = 1,
//                Nome = $"Prod 1",
//                IdGrupoProduto = 1,
//                Sigla = $"Sigla 1"
//            };

//            this._produtoAlterarValidadorMock
//                .Setup(val => val.ValidarAsync(It.IsAny<ProdutoDTO>()))
//                .Returns(Task.FromResult(false));

//            this._produtoRepositoryMock
//                .Setup(rep => rep.AtualizarAsync(It.IsAny<Produto>()))
//                .Returns(Task.CompletedTask);

//            //Act.
//            await this._produtoBusiness.AtualizarAsync(produtoAlterar);
//        }
//    }
//}
