using UnityEngine;

public class WalletUser : MonoBehaviour
{
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
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
