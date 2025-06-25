using System.Collections.Generic;
using UnityEngine;

public class WalletExample : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;
    [SerializeField] private AlertMessage _alertMessageView;

    [SerializeField] private string _goldName;
    [SerializeField] private string _gemsName;
    [SerializeField] private string _energyName;

    [SerializeField] private Sprite _goldSprite;
    [SerializeField] private Sprite _gemsSprite;
    [SerializeField] private Sprite _energySprite;

    private Wallet _wallet;
    
    private void Awake()
    {
        Dictionary<CurrencyTypes, CurrencyUnit> currencies = new Dictionary<CurrencyTypes, CurrencyUnit>()
        {
            { CurrencyTypes.Gold, new CurrencyUnit(_goldName, _goldSprite) },
            { CurrencyTypes.Energy, new CurrencyUnit(_energyName, _energySprite) },
            { CurrencyTypes.Gem, new CurrencyUnit(_gemsName, _gemsSprite) },
        };

        _wallet = new Wallet(currencies);

        _walletView.Initialize(_wallet);
        _alertMessageView.Initialize(_wallet);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _wallet.Deposit(CurrencyTypes.Gold, 10);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            _wallet.Withdraw(CurrencyTypes.Gold, 15);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            _wallet.Deposit(CurrencyTypes.Energy, 10);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            _wallet.Withdraw(CurrencyTypes.Energy, 10);

        if (Input.GetKeyDown(KeyCode.Alpha5))
            _wallet.Deposit(CurrencyTypes.Gem, 10);

        if (Input.GetKeyDown(KeyCode.Alpha6))
            _wallet.Withdraw(CurrencyTypes.Gem, 10);
    }
}
