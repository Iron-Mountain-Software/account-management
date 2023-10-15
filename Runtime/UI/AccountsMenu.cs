using UnityEngine;

namespace IronMountain.AccountManagement.UI
{
    public class AccountsMenu : MonoBehaviour
    {
        [SerializeField] private AccountDisplay accountDisplayPrefab;
        [SerializeField] private Transform accountDisplaysParent;
        [SerializeField] private bool includeDefaultAccount;
        
        private void Start()
        {
            AccountsManager.RefreshAccounts();
        }

        private void OnEnable()
        {
            AccountsManager.OnAccountsChanged += RefreshButtons;
            RefreshButtons();
        }

        private void OnDisable()
        {
            AccountsManager.OnAccountsChanged -= RefreshButtons;
        }

        private void RefreshButtons()
        {
            foreach (Transform child in accountDisplaysParent)
            {
                Destroy(child.gameObject);
            }
            foreach (Account account in AccountsManager.Accounts)
            {
                if (account == null) continue;
                if (!includeDefaultAccount && account.IsDefault) continue;
                Instantiate(accountDisplayPrefab, accountDisplaysParent).Account = account;
            }
        }
    }
}
