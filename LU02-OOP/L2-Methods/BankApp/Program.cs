BankAccount myAccount = new BankAccount("Alex", 100.00);

// Interaction happens through methods, not by touching the fields directly
Console.WriteLine(myAccount.Deposit(50));

Console.WriteLine(myAccount.Withdraw(30));
Console.WriteLine(myAccount.Withdraw(500)); // This will trigger "Denied"