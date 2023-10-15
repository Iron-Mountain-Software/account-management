using UnityEngine;
using UnityEngine.UI;

namespace IronMountain.AccountManagement.UI
{
    [RequireComponent(typeof(Text))]
    public class AccountDisplayIDText : MonoBehaviour
    {
        [SerializeField] private AccountDisplay accountDisplay;
        [SerializeField] private Text text;

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
            if (accountDisplay) accountDisplay.OnAccountChanged += Refresh;
            Refresh();
        }

        private void OnDisable()
        {
            if (accountDisplay) accountDisplay.OnAccountChanged -= Refresh;
        }

        private void Refresh()
        {
            if (!text) return;
            text.text = accountDisplay && accountDisplay.Account is {ID: { }} 
                ? accountDisplay.Account.ID
                : string.Empty;
        }
    }
}
