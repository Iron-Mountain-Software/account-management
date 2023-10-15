using UnityEngine;
using UnityEngine.UI;

namespace IronMountain.AccountManagement.UI
{
    [RequireComponent(typeof(Text))]
    public class CurrentAccountIDText : MonoBehaviour
    {
        [SerializeField] private Text text;
        
        private void Awake()
        {
            if (!text) text = GetComponent<Text>();
        }

        private void OnValidate()
        {
            if (!text) text = GetComponent<Text>();
        }

        private void OnEnable()
        {
            Account.OnLoaded += Refresh;
            Refresh();
        }

        private void OnDisable()
        {
            Account.OnLoaded -= Refresh;
        }

        private void Refresh()
        {
            if (!text) return;
            text.text = Account.Current is {ID: { }} ? Account.Current.ID : string.Empty;
        }
    }
}
