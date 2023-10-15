using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace IronMountain.AccountManagement.UI
{
    [RequireComponent(typeof(Button))]
    public class ContinueButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private UnityEvent OnInteractable;
        [SerializeField] private UnityEvent OnNotInteractable;
        
        private void Awake()
        {
            if (!button) button = GetComponent<Button>();
        }

        private void OnValidate()
        {
            if (!button) button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            if (button) button.onClick.AddListener(OnClick);
            AccountsManager.OnAccountsChanged += Refresh;
            AccountsManager.OnLastLoggedInAccountChanged += Refresh;
            Refresh();
        }

        private void OnDisable()
        {
            if (button) button.onClick.RemoveListener(OnClick);
            AccountsManager.OnAccountsChanged -= Refresh;
            AccountsManager.OnLastLoggedInAccountChanged -= Refresh;
        }

        private void Refresh()
        {
            bool interactable = AccountsManager.LastLoggedInAccount != null;
            if (button) button.interactable = interactable;
            if (interactable) OnInteractable?.Invoke();
            else OnNotInteractable?.Invoke();
        }

        private void OnClick()
        {
            Account account = AccountsManager.LastLoggedInAccount;
            if (account != null) AccountsManager.Login(account);
        }
    }
}