public class BankAccount
{
    public string Owner { get; set; }
    // Private auto-implemented setter
    public double Balance { get; private set; } // only this class can set the balance

    public BankAccount(string owner, double initialBalance)
    {
        Owner = owner;
        Balance = initialBalance;
    }

    // Make sure to add a documentation comment
    public string Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            return $"Deposited ${amount}. New Balance: ${Balance}";
        }
        else
        {
            return "Invalid deposit amount.";
        }
    }

    public string Withdraw(double amount)
    {
        //Deny withdrawal if insufficient funds or invalid amount
        if (amount <= Balance && amount > 0)
        {
            Balance -= amount;
            return $"Withdrew ${amount}. New Balance: ${Balance}";
        }

        return "Transaction Denied: Insufficient funds or invalid amount.";
    }
}