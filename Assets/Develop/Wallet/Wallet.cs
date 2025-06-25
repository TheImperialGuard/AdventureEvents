using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    public event Action<string> WithdrawCancelled;

    private const string NotEnoughBalanceMessage = "Не хватает валюты: ";

    private Dictionary<CurrencyTypes, CurrencyUnit> _currencies;

    public Wallet(Dictionary<CurrencyTypes, CurrencyUnit> currencies)
    {
        _currencies = new Dictionary<CurrencyTypes, CurrencyUnit>(currencies);
    }

    public List<CurrencyUnit> GetWalletInfo()
    {
        List<CurrencyUnit> currencyUnits = new List<CurrencyUnit>();

        foreach (CurrencyUnit currencyUnit in _currencies.Values)
            currencyUnits.Add(currencyUnit);

        return currencyUnits;
    }

    public void Deposit(CurrencyTypes type, int value) => GetCurrencyByType(type).Deposit(value);

    public void Withdraw(CurrencyTypes type, int value)
    {
        CurrencyUnit currency = GetCurrencyByType(type);

        if (EnoughBalance(type, value))
            currency.Withdraw(value);
        else
            WithdrawCancelled?.Invoke(NotEnoughBalanceMessage + currency.Title + "(" + Math.Abs(currency.Balance - value).ToString() + ")");
    }

    private CurrencyUnit GetCurrencyByType(CurrencyTypes type)
    {
        if (_currencies.ContainsKey(type))
            return _currencies[type];

        Debug.LogError("The wallet does not contain the following type of currency");
        return null;
    }

    private bool EnoughBalance(CurrencyTypes type, int value) => GetCurrencyByType(type).Balance >= value;
}
