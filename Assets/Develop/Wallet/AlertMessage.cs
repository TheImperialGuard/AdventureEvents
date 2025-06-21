using System.Collections;
using TMPro;
using UnityEngine;

public class AlertMessage : MonoBehaviour
{
    [SerializeField] private TMP_Text _messageText;

    [SerializeField] private float _messageTime;

    [SerializeField] private Wallet _wallet;

    private Coroutine _alertProcess;

    private void Awake()
    {
        _wallet.WithdrawCancelled += OnWithdrawCancelled;
    }

    private void OnDestroy()
    {
        _wallet.WithdrawCancelled -= OnWithdrawCancelled;
    }

    private void OnWithdrawCancelled(string message)
    {
        if (_alertProcess != null)
            StopCoroutine(_alertProcess);

        _alertProcess = StartCoroutine(AlertProcess(message));
    }

    private IEnumerator AlertProcess(string message)
    {
        _messageText.text = message;

        yield return new WaitForSeconds(_messageTime);

        _messageText.text = "";

        _alertProcess = null;
    }
}
