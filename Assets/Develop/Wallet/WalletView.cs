using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalletView : MonoBehaviour
{
    [SerializeField] private LayoutGroup _resourcePanel;

    [SerializeField] private CurrencyView _resourceViewPrefab;

    private Wallet _wallet;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;

        List<CurrencyUnit> units = new List<CurrencyUnit>();

        units = _wallet.GetWalletInfo();

        foreach (CurrencyUnit unit in units)
        {
            CurrencyView currencyView = Instantiate(_resourceViewPrefab, _resourcePanel.transform);
            currencyView.Initialize(unit);
        }
    }    
}
