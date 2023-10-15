using UnityEngine;
using UnityEngine.UI;

namespace IronMountain.AccountManagement.UI
{
    [RequireComponent(typeof(Text))]
    public class AccountDisplayLastLoginTimeText : MonoBehaviour
    {
        [SerializeField] private AccountDisplay accountDisplay;
        [SerializeField] private Text text;

        [Header("Cache")]
        private Account _account;

        private Account Account
        {
            get => _account;
            set
            {
                if (_account != null) _account.OnLastLoginTimeChanged -= Refresh;
                _account = value;
                if (_account != null) _account.OnLastLoginTimeChanged += Refresh;
                Refresh();
            }
        }

        private void Awake()
        {
            if (!accountDisplay) accountDisplay = GetComponentInParent<AccountDisplay>();
            if (!text) text = GetComponent<Text>();
        }

        private void OnValidate()
        {
            if (!accountDisplay) accountDisplay = GetComponentInParent<AccountDisplay>();
            if (!text) text = GetComponent<Text>();
        }

        private void OnEnable()
        {
            if (accountDisplay) accountDisplay.OnAccountChanged += OnAccountChanged;
            OnAccountChanged();
        }

        private void OnDisable()
        {
            if (accountDisplay) accountDisplay.OnAccountChanged -= OnAccountChanged;
        }

        private void OnAccountChanged()
        {
            Account = accountDisplay ? accountDisplay.Account : null;
        }

        private void Refresh()
        {
            if (!text) return;
            text.text = Account is {LastLoginTime: { }} ? Account.LastLoginTime : string.Empty;
        }
    }
}