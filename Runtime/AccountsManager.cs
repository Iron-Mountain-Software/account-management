using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace IronMountain.AccountManagement
{
    public static class AccountsManager
    {
        public static event Action OnAccountsChanged;
        public static event Action OnLastLoggedInAccountChanged;

        public static readonly List<Account> Accounts = new ();

        private const string LastLoggedInAccountKey = "Last Logged In Account ID";

        public static Account LastLoggedInAccount
        {
            get
            {
                string id = PlayerPrefs.GetString(LastLoggedInAccountKey, string.Empty);
                if (string.IsNullOrWhiteSpace(id) || id == Account.DefaultID) return null;
                return Accounts.Find(account => account != null && account.ID == id);
            }
            set
            {
                PlayerPrefs.SetString(LastLoggedInAccountKey, value?.ID);
                OnLastLoggedInAccountChanged?.Invoke();
            }
        }

        private static bool _initialized;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            if (_initialized) return;
            _initialized = true;
            RefreshAccounts();
        }

        public static Account CreateAccount()
        {
            string id = Guid.NewGuid().ToString();
            Account account = new Account(id);
            account.Version = Application.version;
            account.Initialize();
            RegisterAccount(account);
            return account;
        }

        public static void Login(Account account)
        {
            if (account == null) return;
            Account.Current = account;
            LastLoggedInAccount = account;
        }
        
        public static void LogOut()
        {
            Account.Current = null;
        }
        
        public static void RefreshAccounts() 
        {
            Accounts.Clear();
            DirectoryInfo[] profileDirectories = SaveSystem.SaveSystem.GetDirectoryInfo(Account.AccountsDirectory);
            foreach (DirectoryInfo profileDirectory in profileDirectories)
            {
                string accountID = profileDirectory.Name;
                Accounts.Add(new Account(accountID));
            }
            OnAccountsChanged?.Invoke();
        }

        public static void Delete(Account account)
        {
            if (account == null) return;
            if (Account.Current == account) LogOut();
            if (SaveSystem.SaveSystem.DeleteDirectory(account.Directory))
            {
                UnregisterAccount(account);
            }
        }

        public static void DeleteAllAccounts()
        {
            LogOut();
            if (SaveSystem.SaveSystem.DeleteDirectory(Account.AccountsDirectory))
            {
                Accounts.Clear();
                OnAccountsChanged?.Invoke();
            }
        }
        
        private static void RegisterAccount(Account account)
        {
            if (account == null || Accounts.Contains(account)) return;
            Accounts.Add(account);
            OnAccountsChanged?.Invoke();
        }
        
        private static void UnregisterAccount(Account account)
        {
            if (account == null || !Accounts.Contains(account)) return;
            Accounts.Remove(account);
            OnAccountsChanged?.Invoke();
        }
    }
}