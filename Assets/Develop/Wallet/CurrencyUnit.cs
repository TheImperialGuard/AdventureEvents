using System;
using UnityEngine;

public class CurrencyUnit
{
    public event Action<int> BalanceChanged;

    public CurrencyUnit(string title, Sprite icon, int balance = 0)
    {
        Title = title;
        Icon = icon;
        Balance = balance;
    }

    public string Title { get; }

    public Sprite Icon { get; }

    public int Balance { get; private set; }

    public void Deposit(int value)
    {
        if (value < 0)
        {
            Debug.LogError("The value cannot be less than 0");
            return;
        }

        Balance += value;
        BalanceChanged?.Invoke(Balance);
    }

    public void Withdraw(int value)
    {
        if (value < 0)
        {
            Debug.LogError("The value cannot be less than 0");
            return;
        }

        Balance -= value;
        BalanceChanged?.Invoke(Balance);
    }
}
