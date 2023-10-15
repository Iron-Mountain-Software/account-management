using System;
using UnityEngine;

namespace IronMountain.AccountManagement.UI
{
    public class AccountDisplay : MonoBehaviour
    {
        public event Action OnAccountChanged;

        [Header("Cache")] 
        private Account _account;

        public Account Account
        {
            get => _account;
            set
            {
                if (_account == value) return;
                _account = value;
                OnAccountChanged?.Invoke();
            }
        }
    }
}