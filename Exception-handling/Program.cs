

using Exception_handling;
using System;

class MyException
{
    public static async Task Main(string[] args)
    {
        BankAccount myAccount = new BankAccount(1000);
        var exception = "";

        try
        {
            myAccount.Withdraw(2000);
        }
        catch (CustomException ex)
        {
            exception = ex.Message;
            Console.WriteLine($"{ex.Message}. Account Balance: {ex.accBalance}"); ;
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            if (exception.Length == 0) {
                Console.WriteLine("Transaction Completed !");
            } else
            {
                Console.WriteLine($"Transaction could not complete due to this error: {exception}");
            }
        }

        // Async await implementation
        AsyncAwait asyncAwait = new AsyncAwait();
        var number = await asyncAwait.AyncAwaitSample();
        Console.WriteLine($"Number After Delay: {number}");

        // Fetch data asynchronously
        await asyncAwait.FetchDataAsync();

    }
}

public class BankAccount
{
    private decimal balance;

    public BankAccount(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public void Withdraw(decimal amount)
    {
        if (amount > balance)
        {
            throw new CustomException("Insufficient funds to make the transaction.", balance);
        }

        balance -= amount;
        Console.WriteLine($"Successfully withdrawn {amount}. New balance: {balance}");
    }
}

public class CustomException : Exception
{
    public decimal accBalance;

    public CustomException(string message, decimal balance) : base(message)
    {
        accBalance = balance;
    }
}
