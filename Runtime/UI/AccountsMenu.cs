using UnityEngine;

namespace IronMountain.AccountManagement.UI
{
    public class AccountsMenu : MonoBehaviour
    {
        [SerializeField] private AccountDisplay accountDisplayPrefab;
        [SerializeField] private RectTransform emptyAccountDisplayPrefab;
        [SerializeField] private Transform accountDisplaysParent;
        [SerializeField] private int minimumAccountDisplaysSpawned = 0;
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

        private void DestroyAllChildren()
        {
            if (!accountDisplaysParent) return;
            foreach (Transform child in accountDisplaysParent)
            {
                Destroy(child.gameObject);
            }
        }

        private void RefreshButtons()
        {
            DestroyAllChildren();
            int spawns = 0;
            foreach (Account account in AccountsManager.Accounts)
            {
                if (!accountDisplayPrefab) break;
                if (account == null) continue;
                if (!includeDefaultAccount && account.IsDefault) continue;
                Instantiate(accountDisplayPrefab, accountDisplaysParent).Account = account;
                spawns++;
            }
            while (spawns < minimumAccountDisplaysSpawned)
            {
                if (!emptyAccountDisplayPrefab) break;
                Instantiate(emptyAccountDisplayPrefab, accountDisplaysParent);
                spawns++;
            }
        }

        private void OnValidate()
        {
            minimumAccountDisplaysSpawned = Mathf.Clamp(minimumAccountDisplaysSpawned, 0, int.MaxValue);
        }
    }
}
