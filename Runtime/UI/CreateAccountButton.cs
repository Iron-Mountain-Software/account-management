using UnityEngine;
using UnityEngine.UI;

namespace IronMountain.AccountManagement.UI
{
    [RequireComponent(typeof(Button))]
    public class CreateAccountButton : MonoBehaviour
    {
        [SerializeField] private Button button;

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
        }

        private void OnDisable()
        {
            if (button) button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            AccountsManager.CreateAccount();
        }
    }
}
