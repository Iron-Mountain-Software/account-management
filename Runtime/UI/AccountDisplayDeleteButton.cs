using UnityEngine;
using UnityEngine.UI;

namespace IronMountain.AccountManagement.UI
{
    [RequireComponent(typeof(Button))]
    public class AccountDisplayDeleteButton : MonoBehaviour
    {
        [SerializeField] private AccountDisplay accountDisplay;
        [SerializeField] private Button button;

        private void Awake()
        {
            if (!accountDisplay) accountDisplay = GetComponentInParent<AccountDisplay>();
            if (!button) button = GetComponent<Button>();
        }

        private void OnValidate()
        {
            if (!accountDisplay) accountDisplay = GetComponentInParent<AccountDisplay>();
            if (!button) button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            if (button) button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            if (button) button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            if (!accountDisplay) return;
            AccountsManager.Delete(accountDisplay.Account);
        }
    }
}