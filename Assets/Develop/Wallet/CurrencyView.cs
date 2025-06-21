using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private Image _icon;

    [SerializeField] private TMP_Text _titleText;
    [SerializeField] private TMP_Text _balanceText;

    private CurrencyUnit _currencyUnit;

    public void Inizialize(CurrencyUnit unit)
    {
        _currencyUnit = unit;

        _icon.sprite = unit.Icon;
        _titleText.text = unit.Title;
        _balanceText.text = unit.Balance.ToString();

        unit.BalanceChanged += OnBalanceChanged;
    }

    private void OnDestroy()
    {
        _currencyUnit.BalanceChanged -= OnBalanceChanged;
    }

    private void OnBalanceChanged(int balance)
    {
        _balanceText.text = balance.ToString();
    }
}
