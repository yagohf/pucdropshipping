namespace Yagohf.PUC.Data.Interface.TransactionContainer
{
    /// <summary>
    /// TODO - Ao migrar a versão da aplicação para o .NET Core 2.1 (atualmente em preview), 
    /// remover todas as chamadas para essa interface/implementação e utilizar TransactionScope.
    /// A versão 2.0 do .NET Core e do EF Core não permite o uso de transações ambientes, com
    /// o namespace System.Transactions. Necessário utilizar as transações de banco, diretamente nos
    /// contexts. Essa interface (e sua implementação) foram criadas para abrir transações de banco
    /// diretamente, sem a necessidade de se ter acesso ao DbContext. O ISP foi aplicado para separar
    /// a interface da implementação, de forma que no futuro possamos alterar a maneira pela qual
    /// abrimos transações sem impactar o código cliente.
    /// </summary>
    public interface ITransactionContainer
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void DisposeTransaction();
    }
}
