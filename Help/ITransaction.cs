using SimpleBank.Model;

namespace SimpleBank.Help
{
    /// <summary>
    /// Пополнение и снятие денег со счета
    /// </summary>
    public interface  ITransactionWithAccount<out T>
    {
        T Put(Account account, decimal amount);
        T Withdraw(Account account, decimal amount);
    }
}
