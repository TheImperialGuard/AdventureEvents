using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public event Action<string> WithdrawCancelled;

    private const string NotEnoughBalanceMessage = "Не хватает валюты: ";

    [SerializeField] private string _goldName;
    [SerializeField] private string _gemsName;
    [SerializeField] private string _energyName;

    [SerializeField] private Sprite _goldSprite;
    [SerializeField] private Sprite _gemsSprite;
    [SerializeField] private Sprite _energySprite;

    private Dictionary<CurrencyTypes, CurrencyUnit> _currencies;

    private void Awake()
    {
        _currencies = new Dictionary<CurrencyTypes, CurrencyUnit>()
        {
            { CurrencyTypes.Gold, new CurrencyUnit(_goldName, _goldSprite) },
            { CurrencyTypes.Energy, new CurrencyUnit(_energyName, _energySprite) },
            { CurrencyTypes.Gem, new CurrencyUnit(_gemsName, _gemsSprite) },
        };
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
