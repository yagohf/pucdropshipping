USE Dropshipping;
/*
	Yago Ferreira - 11/09/2018
	SCRIPT PARA CARREGAR A BASE COM OS DADOS INICIAIS.
*/

SET XACT_ABORT ON;
GO

BEGIN TRANSACTION
GO

--JOBS
INSERT INTO Job(Id, Nome, UltimaExecucao, PeriodicidadeMinutos, Ativo)
VALUES
(1, 'ATUALIZAR_ESTOQUE', NULL, 1440, 1);

--PERFIS
INSERT INTO Perfil(Id, Nome, Descricao)
VALUES
(1, 'Cliente', 'São os consumidores. Acessam a plataforma para a realização de compras e acompanhamento de pedidos.'),
(2, 'Vendedor', 'São os funcionários da empresa responsáveis por levar a loja até o cliente. Acessam a plataforma para realização de vendas e acompanhamento das vendas realizadas.'),
(3, 'Atendente', 'São os funcionários da empresa responsáveis por prestar atendimentos aos clientes.'),
(4, 'Fornecedor', 'São os fornecedores da empresa responsáveis por receber pedidos e entregar aos clientes.');

--USUÁRIO
SET IDENTITY_INSERT Usuario ON;

INSERT INTO Usuario(Id, [Login], Senha)
VALUES
(1, 'integracoes.sapatosecia@sapatosecia.com', '123mudar'),
(2, 'integracoes.sapatop@sapatop.com', '123mudar'),
(3, 'yagoferreira21@gmail.com', '123mudar');

SET IDENTITY_INSERT Usuario OFF;

--USUÁRIO E PERFIS
INSERT INTO UsuarioPerfil(IdUsuario, IdPerfil)
VALUES
(1, 4),
(2, 4),
(3, 1);

--PESSOAS
SET IDENTITY_INSERT Pessoa ON;

INSERT INTO Pessoa(Id, Nome, IdUsuario, Documento, Email, Telefone)
VALUES
(1, 'Sapatos & CIA', NULL, '87068134000122', 'contato@sapatosecia.com', '11999999999'),
(2, 'Sapatop', NULL, '61818816000111', 'contato@sapatop.com', '11988888888'),
(3, 'Yago Henrique Ferreira', 3, '57544205010', 'yagoferreira21@gmail.com', '11997304540');

SET IDENTITY_INSERT Pessoa OFF;

--ENDEREÇOS
SET IDENTITY_INSERT PessoaEndereco ON;

INSERT INTO PessoaEndereco(Id,  IdPessoa, Apelido, Logradouro, Numero, Bairro, Cidade, Estado, Observacao, CEP)
VALUES
(1, 3, 'Casa', 'Rua dos Vilani', 201, 'JD. Nova Esperança', 'Boa Esperança do Sul', 'São Paulo', NULL, '14930000');

SET IDENTITY_INSERT PessoaEndereco OFF;

--FORNECEDORES
INSERT INTO Fornecedor(Id, Ativo, EnderecoCancelarPedido, EnderecoConsultarEstoque, EnderecoRealizarPedido, UsuarioServico, SenhaServico)
VALUES
(1, 1, 'https://sapatosecia-services.com', 'https://sapatosecia-services.com', 'https://sapatosecia-services.com', 'lojapucminas', '123mudar'),
(2, 1, 'https://roupasecia-services.com', 'https://roupasecia-services.com', 'https://roupasecia-services.com', 'lojapucminas', '123mudar');

--CATEGORIAS
SET IDENTITY_INSERT ProdutoCategoria ON;

INSERT INTO ProdutoCategoria(Id, Nome, Descricao)
VALUES
(1, 'Chinelos', 'Chinelos'),
(2, 'Tênis', 'Tênis'),
(3, 'Sapatilhas', 'Sapatilhas'),
(4, 'Saltos', 'Saltos'),
(5, 'Sapatões', 'Sapatões'),
(6, 'Botas', 'Botas'),
(7, 'Tamancos', 'Tamancos'),
(8, 'Sociais', 'Sociais');

SET IDENTITY_INSERT ProdutoCategoria OFF;

--PRODUTOS
SET IDENTITY_INSERT Produto ON;

INSERT INTO Produto(Id, IdFornecedor, IdProdutoCategoria, ChaveProdutoFornecedor, DataCadastro, Nome, Descricao, Disponivel, Ativo, PrecoCusto, PrecoVenda)
VALUES
--CHINELOS
(1, 1, 1, 'CHIN0001', DATEADD(MONTH, -1, GETDATE()), 'Havaianas Tradicional', 'A sandália Havaianas Tradicional marca o início da história das legítimas.', 1, 1, 7.99, 0.00),
(2, 1, 1, 'CHIN0002', DATEADD(MONTH, -3, GETDATE()), 'Havaianas You Riviera', 'A Havaianas You Riviera Maxi Cinza foi pensada para situações além praia. A tira em formato "T" com aplique de cristais Swarovski realça o pé e é uma ótima pedida para vários momentos.', 1, 1, 99.99, 0.00),
--TÊNIS
(3, 1, 2, 'TEN0001', DATEADD(DAY, -5, GETDATE()), 'Tênis Kappa Impact - Branco e Preto', 'O Tênis Kappa Impact Masculino feito para homens quem buscam conforto e estilo para suas caminhadas e atividades esportivas, também é uma ótima opção para o dia a dia.', 1, 1, 71.99, 0.00),
(4, 2, 2, 'PROD0001', DATEADD(DAY, -13, GETDATE()), 'Tênis Olympikus Spirit 2 Masculino', 'Mais amortecimento e conforto nas corridas leves. É isso que você encontra no Tênis Olympikus Spirit 2 Masculino. Além de leve e macio, o tênis tem solado em EVAMOVE injetado.', 1, 1, 109.99, 0.00),
--TÊNIS NIKE PARA COLOCAR EM PROMOÇÃO
(5, 2, 2, 'PROD0005', DATEADD(DAY, -5, GETDATE()),  'Tênis Nike Revolution 4',  'Tenha o máximo de conforto durante a corrida com este tênis de corrida masculino. Essa quarta versão do Nike Revolution chega superleve e macio.', 1, 1,  179.99, 0.00),
(6, 2, 2, 'PROD0006', DATEADD(DAY, -5, GETDATE()),  'Tênis Nike Downshifter 8',  'Chegou o Tênis Nike Downshifter 8 Masculino para ampliar o seu desempenho nas pistas. Esse tênis de corrida da Nike apresenta um design moderno e minimalista que turbina o seu estilo esportivo e oferece conforto máximo a cada passada. Composto por um cabedal em mesh respirável de camada única, esse tênis masculino oferece leveza, ventilação aos pés e um calce com suporte confortável. O cabedal do Nike Downshifter 8 possui também uma faixa no arco que se integra aos cadarços, para um ajuste cômodo e personalizado ao seu gosto e formato do seu pé.', 1, 1,  209.99, 0.00),
(7, 2, 2, 'PROD0007', DATEADD(DAY, -5, GETDATE()),  'Tênis Nike Dart 12 MSL',  'Toda a qualidade tradicional da Nike é perceptível no Tênis Nike Dart 12 MSL Masculino. Sua construção foi desenhada para oferecer conforto, leveza e suporte a um preço mais acessível em relação a alguns modelos de características semelhantes. O cabedal do tênis Nike apresenta menos quantidade de peças costuradas, característica que gera menor atrito no contato do pé com a área superior.', 1, 1,  209.99, 0.00),
(8, 2, 2, 'PROD0008', DATEADD(DAY, -5, GETDATE()),  'Tênis Nike Wmns Revolution 4',  'O conceito minimalista dos calçados de running resulta em modelos mais leves e menos tecnológicos, valorizando assim a pisada natural da corredor. Isso permite que ele sinta o toque com o solo, porém sem sofrer os danos e desconfortos que aconteceriam estando descalço numa corrida.', 1, 1,  199.99, 0.00),
(9, 2, 2, 'PROD0009', DATEADD(DAY, -5, GETDATE()),  'Tênis Nike Air Max Fury Sequent 3',  'O Tênis Nike Air Max Fury Sequent 3 contempla tecnologias que favorecem seu desempenho durante os exercícios alinhando conforto, ajuste preciso e muito estilo. Este Tênis de corrida feminino possui um design moderno que segue a tendência da moda fitness e pode ser usado tanto dentro quanto fora das pistas.', 1, 1,  395.99, 0.00),
(10, 2, 2, 'PROD0010', DATEADD(DAY, -5, GETDATE()), 'Tênis Nike Flex Essential TR', 'O Tênis Nike Flex Essential TR Feminino traz muito conforto ao seu caminhar. Ideal para o dia a dia, este Tênis Nike Running possui cabedal em malha para melhor respiração.', 1, 1, 230.99, 0.00),
(11, 2, 2, 'PROD0011', DATEADD(DAY, -5, GETDATE()), 'Tênis Nike Air Max Advantage', 'O Tênis Nike Air Max Advantage Feminino ajuda você a se sentir mais veloz em longas distâncias. Ele traz tecnologia Air Max no calcanhar que proporciona um excelente amortecimento.', 1, 1, 284.99, 0.00),
(12, 2, 2, 'PROD0012', DATEADD(DAY, -5, GETDATE()), 'Tênis Nike Air Max Sequent 3', 'O Tênis Nike Air Max Fury Sequent 3 é ideal para corridas curtas onde é necessário amortecimento. Leve, este Tênis Masculino possui cabedal em knit elástico que se molda ao pé para maior conforto.', 1, 1, 369.99, 0.00),
(13, 2, 2, 'PROD0013', DATEADD(DAY, -5, GETDATE()), 'Tênis Nike Retaliation Tr 2', 'Esteja pronto para treinar pesado com o Nike Retaliation Tr 2! Nesta nova versão, este tênis masculino conta com um design mais anatômico, para um calce confortável e maior suporte na academia.', 1, 1, 234.99, 0.00),
(14, 2, 2, 'PROD0014', DATEADD(DAY, -5, GETDATE()), 'Tênis Nike Tech Trainer ', 'Capriche na performance e no estilo com o Tênis Nike Tech Trainer nos pés! Criado para garantir maior estabilidade, este tênis nike apresenta um design moderno para você mandar na prática esportiva e também no dia a dia.', 1, 1, 354.99, 0.00),
(15, 2, 2, 'PROD0015', DATEADD(DAY, -5, GETDATE()), 'Tênis Nike Air Bella Tr ', 'Com cabedal em mesh para maior respirabilidade, o Tênis Nike Air Bella Tr Feminino oferece a tecnologia de amortecimento mais famosa da marca: a Air Max.', 1, 1, 264.99, 0.00),
(16, 2, 2, 'PROD0016', DATEADD(DAY, -5, GETDATE()), 'Tênis Nike Air Epic Speed TR 2', 'Toda esportividade do Tênis Nike Air Epic Speed TR 2 Masculino o torna perfeito para a pratica esportiva.', 1, 1, 189.99, 0.00),
--SAPATILHAS
(17, 2, 3, 'PROD0017', DATEADD(DAY, -13, GETDATE()), 'Sapatilha Somoda Verniz', 'Sinta-se bonita e confortável para ir ao trabalho ou sair com as amigas usando a Sapatilha Somoda Básica! Seu acabamento envernizado acompanha um elegante bico fino para você arrasar nas produções.', 0, 1, 39.99, 0.00),
(18, 2, 3, 'PROD0018', DATEADD(DAY, -11, GETDATE()), 'Sapatilha Pietra Fernandes Biqueira Lacinho', 'O estilo delicado da Sapatilha Pietra Fernandes Biqueira Lacinho é ideal para quem busca um modelo leve e confortável para o dia a dia. De bico redondo com aplique de laço, revela um design versátil.', 1, 0, 39.99, 0.00);

--ATUALIZAR TODOS OS PREÇOS COM 20% NO VALOR DE VENDA
UPDATE Produto
   SET PrecoVenda = CEILING(PrecoCusto * 1.2) - 0.01;

SET IDENTITY_INSERT Produto OFF;

--PROMOÇÕES
SET IDENTITY_INSERT Promocao ON;

INSERT INTO Promocao(Id, Nome, Descricao, Ativa,DataInicio, DataFim, DataFimPrevisto)
VALUES
(1, 'Tênis Nike com 40% OFF', 'Só hoje ! Tênis Nike com 40% de desconto !', 1, GETDATE(), NULL, DATETIMEFROMPARTS(DATEPART(YEAR, GETDATE()), DATEPART(MONTH, GETDATE()), DATEPART(DAY, GETDATE()), 23, 59, 59, 0)),
(2, 'Semana dos Havaianas', 'Toda a linha de Havaianas pela metade do preço somente por sete dias !', 1, GETDATE(), NULL, DATETIMEFROMPARTS(DATEPART(YEAR, DATEADD(DAY, 7, GETDATE())), DATEPART(MONTH, DATEADD(DAY, 7, GETDATE())), DATEPART(DAY, DATEADD(DAY, 7, GETDATE())), 23, 59, 59, 0)),
(3, 'Mês da Sapatilha', 'Todas as sapatilhas com 30% de desconto durante o mês !', 1, DATEFROMPARTS(DATEPART(YEAR, GETDATE()), DATEPART(MONTH, GETDATE()), 1), NULL, DATETIMEFROMPARTS(DATEPART(YEAR, DATEADD(MONTH, 1, GETDATE())), DATEPART(MONTH, DATEADD(MONTH, 1, GETDATE())), DATEPART(DAY, DATEADD(MONTH, 1, GETDATE())), 23, 59, 59, 0));

SET IDENTITY_INSERT Promocao OFF;

--PRODUTOS EM PROMOÇÃO

--TÊNIS DA NIKE
INSERT INTO ProdutoPromocao(IdProduto, IdPromocao, PrecoVenda)
SELECT Id, 1, CEILING(PrecoVenda - (PrecoVenda * 0.4)) - 0.01
  FROM Produto
 WHERE Id BETWEEN 5 AND 16;

--TODAS AS HAVAIANAS
INSERT INTO ProdutoPromocao(IdProduto, IdPromocao, PrecoVenda)
SELECT Id, 2, CEILING(PrecoVenda / 2) - 0.01
  FROM Produto
 WHERE Id IN(1, 2);

--TODAS AS SAPATILHAS
INSERT INTO ProdutoPromocao(IdProduto, IdPromocao, PrecoVenda)
SELECT Id, 3, CEILING(PrecoVenda - (PrecoVenda * 0.4)) - 0.01
  FROM Produto
 WHERE IdProdutoCategoria = 3;

--PROPAGANDAS
SET IDENTITY_INSERT Propaganda ON;

INSERT INTO Propaganda(Id, Nome, Descricao, Ativo, Posicao, Url)
VALUES
(1, 'Nike', 'Faz o mundo te ouvir', 1, 1, '/catalogo?q=nike');

SET IDENTITY_INSERT Propaganda OFF;

--PEDIDO
SET IDENTITY_INSERT Pedido ON;

INSERT INTO Pedido(Id, Data, IdCliente, IdVendedor, ValorProdutos, Desconto, ValorPago)
VALUES
(1, DATEADD(WEEK, -1, GETDATE()), 3, NULL, 187.98, 0.00, 225.98);

SET IDENTITY_INSERT Pedido OFF;

--ITENS DO PEDIDO
SET IDENTITY_INSERT PedidoItem ON;

INSERT INTO PedidoItem(Id, IdPedido, IdProduto, PrecoCusto, PrecoVenda, Desconto, Quantidade, PrecoFinal)
VALUES
(1, 1, 1, 7.99, 9.99, 0.00, 1, 9.99),
(2, 1, 5, 179.99, 215.99, 0.00, 1, 215.99);

SET IDENTITY_INSERT PedidoItem OFF;

--PEDIDO FORNECEDOR STATUS
INSERT INTO PedidoFornecedorStatus(Id, Nome, Descricao)
VALUES
(0, 'Recebido', 'Pedido foi recebido pelo fornecedor'),
(1, 'Recusado', 'Pedido foi recusado pelo fornecedor'),
(2, 'Confirmado', 'Pedido foi confirmado pelo fornecedor'),
(3, 'Embalado', 'Pedido foi embalado pelo fornecedor e encontra-se pronto para expedição'),
(4, 'Expedido', 'Pedido foi expedido pelo fornecedor'),
(5, 'Transportando', 'Pedido está sendo transportado pelo fornecedor'),
(6, 'Entregue', 'Pedido foi entregue ao cliente pelo fornecedor');

--PEDIDO FORNECEDOR
SET IDENTITY_INSERT PedidoFornecedor ON;

INSERT INTO PedidoFornecedor(Id, IdFornecedor, IdPedidoFornecedorStatus, IdPedidoItem, ChavePedidoFornecedor)
VALUES
(1, 1, 6, 1, 'PED001'),
(2, 2, 3, 2, 'PUCDROPPED001');

SET IDENTITY_INSERT PedidoFornecedor OFF;

--EVENTOS DO PEDIDO DO FORNECEDOR
SET IDENTITY_INSERT PedidoFornecedorEvento ON;

INSERT INTO PedidoFornecedorEvento(Id, IdPedidoFornecedor, IdPedidoFornecedorStatus, DataOcorrencia, InformacoesAdicionais)
VALUES
--PRIMEIRO ITEM (JÁ ENTREGUE)
(1, 1, 0, DATEADD(WEEK, 0, GETDATE()), 'Pedido recebido pelo SIS.SAPATO.CIA v1.0'),
(2, 1, 2, DATEADD(DAY, -6, GETDATE()), 'Pedido confirmado pelo SIS.SAPATO.CIA v1.0'),
(3, 1, 3, DATEADD(DAY, -5, GETDATE()), 'Pedido embalado. Aguardando expedição.'),
(4, 1, 4, DATEADD(DAY, -4, GETDATE()), 'Pedido expedido para transportadora TRANSBRASIL. Código de rastreio 0085BACD.'),
(5, 1, 5, DATEADD(DAY, -3, GETDATE()), 'Pedido em transporte.'),
(6, 1, 6, DATEADD(DAY, -1, GETDATE()), 'Pedido entregue ao cliente.'),

(7, 2, 0, DATEADD(WEEK, 0, GETDATE()), 'Pedido recebido pelo SIS.SAPATOP v1.1.B'),
(8, 2, 2, DATEADD(DAY, -6, GETDATE()), 'Pedido confirmado pelo SIS.SAPATOP v1.1.B'),
(9, 2, 3, DATEADD(DAY, -5, GETDATE()), 'Pedido embalado. Preparando expedição.'),
(10, 2, 4, DATEADD(DAY, -4, GETDATE()), 'Pedido expedido para transportadora LOGBRASIL. Código de rastreio XPTO123456.');

SET IDENTITY_INSERT PedidoFornecedorEvento OFF;

--STATUS DO PAGAMENTO
INSERT INTO PagamentoStatus(Id, Nome, Descricao)
VALUES
(0, 'Aguardando confirmação', 'Plataforma de pagamentos ainda não confirmou o pagamento'),
(1, 'Cancelado', 'Plataforma de pagamentos cancelou o pagamento por qualquer que seja o motivo'),
(2, 'Confirmado', 'Plataforma de pagamentos confirmou o pagamento');

--PAGAMENTO
SET IDENTITY_INSERT Pagamento ON;

DECLARE @ChaveMockadaPagamento VARCHAR(36) = NEWID();
INSERT INTO Pagamento(Id, IdPedido, IdPagamentoStatus, DescricaoPagamento, ChaveTransacao, XMLTransacao)
VALUES
(1, 1, 2, 'Parcelado em 2x no cartão de crédito', @ChaveMockadaPagamento, CONCAT('<?xml version="1.0" encoding="UTF-8"?><transaction><code>', @ChaveMockadaPagamento, '</code></transaction>'));

SET IDENTITY_INSERT Pagamento OFF;

--EVENTOS DO PAGAMENTO
SET IDENTITY_INSERT PagamentoEvento ON;

INSERT INTO PagamentoEvento(Id, IdPagamento, IdPagamentoStatus, DataRecebimento, XMLTransacao)
VALUES
(1, 1, 0, DATEADD(WEEK, -1, GETDATE()), CONCAT('<?xml version="1.0" encoding="UTF-8"?><transaction><code>', @ChaveMockadaPagamento, '</code></transaction>')),
(2, 1, 2, DATEADD(MINUTE, 10, DATEADD(WEEK, -1, GETDATE())), CONCAT('<?xml version="1.0" encoding="UTF-8"?><transaction><code>', @ChaveMockadaPagamento, '</code></transaction>'));

SET IDENTITY_INSERT PagamentoEvento OFF;

COMMIT TRAN;
GO