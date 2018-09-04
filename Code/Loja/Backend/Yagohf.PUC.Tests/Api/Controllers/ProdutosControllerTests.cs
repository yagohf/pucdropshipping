//using Microsoft.AspNetCore.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Yagohf.PUC.Api.Controllers;
//using Yagohf.PUC.Business.Interface.Dominio;
//using Yagohf.PUC.Model.DTO.Produto;
//using Yagohf.PUC.Model.Infraestrutura;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;

//namespace Yagohf.PUC.Tests.Api.Controllers
//{
//    [TestClass]
//    public class ProdutosControllerTests
//    {
//        private readonly Mock<IProdutoBusiness> _produtoBusinessMock;
//        private ProdutosController _produtosController;

//        public ProdutosControllerTests()
//        {
//            this._produtoBusinessMock = new Mock<IProdutoBusiness>();
//        }

//        [TestInitialize]
//        public void Inicializar()
//        {
//            this._produtosController = new ProdutosController(this._produtoBusinessMock.Object);
//        }

//        [TestMethod]
//        public async Task Testar_Get_Paginando()
//        {
//            //Arrange.
//            int pagina = 1;
//            int registrosPorPagina = 10;

//            var listaProdutos = new List<ProdutoDTO>();
//            for (int i = 0; i < registrosPorPagina; i++)
//            {
//                listaProdutos.Add(new ProdutoDTO()
//                {
//                    Id = i,
//                    Nome = $"Produto {i}",
//                    Sigla = $"Sigla {i}",
//                    IdGrupoProduto = i
//                });
//            }

//            var paginacao = new Paginacao(pagina, listaProdutos.Count, registrosPorPagina);
//            var mockListaPaginada = new Listagem<ProdutoDTO>(listaProdutos, paginacao);

//            this._produtoBusinessMock
//                .Setup(bsn => bsn.ListarAsync(null, null, null, pagina))
//                .Returns(Task.FromResult(mockListaPaginada));

//            //Act.
//            var result = await this._produtosController.Get(null, null, null, pagina);
//            var okResult = result as OkObjectResult;

//            //Assert.
//            Assert.IsNotNull(okResult);
//            Assert.IsInstanceOfType(okResult.Value, typeof(Listagem<ProdutoDTO>));
//            Assert.AreEqual(mockListaPaginada, okResult.Value as Listagem<ProdutoDTO>);
//        }

//        [TestMethod]
//        public async Task Testar_Get_SemPaginar()
//        {
//            //Arrange.
//            var listaProdutos = new List<ProdutoDTO>();
//            for (int i = 0; i < 5; i++)
//            {
//                listaProdutos.Add(new ProdutoDTO()
//                {
//                    Id = i,
//                    Nome = $"Produto {i}",
//                    Sigla = $"Sigla {i}",
//                    IdGrupoProduto = i
//                });
//            }

//            var mockListaSemPaginacao = new Listagem<ProdutoDTO>(listaProdutos);
//            this._produtoBusinessMock
//                .Setup(bsn => bsn.ListarAsync(null, null, null, null))
//                .Returns(Task.FromResult(mockListaSemPaginacao));

//            //Act.
//            var result = await this._produtosController.Get(null, null, null, null);
//            var okResult = result as OkObjectResult;

//            //Assert.
//            Assert.IsNotNull(okResult);
//            Assert.IsInstanceOfType(okResult.Value, typeof(Listagem<ProdutoDTO>));
//            Assert.AreEqual(mockListaSemPaginacao, okResult.Value as Listagem<ProdutoDTO>);
//        }

//        [TestMethod]
//        public async Task Testar_Get_PorId()
//        {
//            //Arrange.
//            int idProduto = 1;
//            ProdutoDTO mockProduto = new ProdutoDTO()
//            {
//                Id = 1,
//                Nome = "Produto 1",
//                Sigla = "Sigla 1",
//                IdGrupoProduto = 1
//            };

//            this._produtoBusinessMock
//                .Setup(bsn => bsn.SelecionarPorIdAsync(idProduto))
//                .Returns(Task.FromResult(mockProduto));

//            //Act.
//            var result = await this._produtosController.Get(idProduto);
//            var okResult = result as OkObjectResult;

//            //Assert.
//            Assert.IsNotNull(okResult);
//            Assert.IsInstanceOfType(okResult.Value, typeof(ProdutoDTO));
//            Assert.AreEqual(mockProduto, okResult.Value as ProdutoDTO);
//        }

//        [TestMethod]
//        public async Task Testar_Post()
//        {
//            //Arrange.
//            ProdutoDTO mockProduto = new ProdutoDTO()
//            {
//                Id = 1,
//                Nome = "Produto 1",
//                Sigla = "Sigla 1",
//                IdGrupoProduto = 1
//            };

//            ProdutoDTO produtoCriar = new ProdutoDTO()
//            {
//                Nome = "Produto 1",
//                Sigla = "Sigla 1",
//                IdGrupoProduto = 1
//            };

//            this._produtoBusinessMock
//                .Setup(bsn => bsn.CriarAsync(produtoCriar))
//                .Returns(Task.FromResult(mockProduto));

//            //Act.
//            var result = await this._produtosController.Post(produtoCriar);
//            var createdAtResult = result as CreatedAtActionResult;

//            //Assert.
//            Assert.IsNotNull(createdAtResult);
//            Assert.IsInstanceOfType(createdAtResult.Value, typeof(ProdutoDTO));
//            Assert.AreEqual(mockProduto, createdAtResult.Value as ProdutoDTO);

//            //Testar URL de redirecionamento.
//            Assert.AreEqual(createdAtResult.ActionName, nameof(this._produtosController.Get));
//            Assert.AreEqual(createdAtResult.RouteValues["id"], mockProduto.Id);
//        }

//        [TestMethod]
//        public async Task Testar_Put()
//        {
//            //Arrange.
//            ProdutoDTO produtoAtualizar = new ProdutoDTO()
//            {
//                Id = 1,
//                Nome = "Produto 1",
//                Sigla = "Sigla 1",
//                IdGrupoProduto = 1
//            };

//            this._produtoBusinessMock
//                .Setup(bsn => bsn.AtualizarAsync(produtoAtualizar))
//                .Returns(Task.CompletedTask);

//            //Act.
//            var result = await this._produtosController.Put(produtoAtualizar.Id, produtoAtualizar);

//            //Assert.
//            Assert.IsInstanceOfType(result, typeof(OkResult));
//        }

//        [TestMethod]
//        public async Task Testar_Delete()
//        {
//            //Arrange.
//            int idExcluir = 1;

//            this._produtoBusinessMock
//                .Setup(bsn => bsn.ExcluirAsync(idExcluir))
//                .Returns(Task.CompletedTask);

//            //Act.
//            var result = await this._produtosController.Delete(idExcluir);

//            //Assert.
//            Assert.IsInstanceOfType(result, typeof(OkResult));
//        }
//    }
//}
