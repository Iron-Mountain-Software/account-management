using System;
using System.IO;
using IronMountain.SaveSystem;
using UnityEngine;

namespace IronMountain.AccountManagement
{
    [Serializable]
    public class Account
    {
        public const string AccountsDirectory = "Accounts";
        public const string DefaultID = "Default";

        public static event Action OnLoad;
        public static event Action OnLoaded;
        public static event Action OnInitialization;
        
        private static Account _current;

        public static Account Current
        {
            get
            {
                if (_current != null) return _current;
                _current = new Account(DefaultID);
                _current.Version = Application.version;
                _current.LastLoginTime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                _current.Initialize();
                return _current;
            }
            set
            {
                if (_current == value) return;
                _current = value;
                if (_current != null) _current.LastLoginTime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                OnLoad?.Invoke();
                OnLoaded?.Invoke();
            }
        }
        
        public event Action OnVersionChanged;
        public event Action OnCreationTimeChanged;
        public event Action OnLastLoginTimeChanged;

        private SavedString _version;
        private SavedString _creationTime;
        private SavedString _lastLoginTime;
        
        public string ID { get; }
        public string Directory { get; }
        public string SessionID { get; }

        public bool IsDefault => string.Equals(ID, DefaultID);

        public string Version
        {
            get => _version.Value;
            set => _version.Value = value;
        }
        
        public string CreationTime 
        {
            get => _creationTime.Value;
            set => _creationTime.Value = value;
        }
        
        public string LastLoginTime 
        {
            get => _lastLoginTime.Value;
            set => _lastLoginTime.Value = value;
        }

        public virtual void Initialize()
        {
            CreationTime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            OnInitialization?.Invoke();
        }

        public Account(string id)
        {
            ID = id;
            SessionID = Guid.NewGuid().ToString();
            Directory = Path.Combine(AccountsDirectory, ID);
            
            _version = new SavedString(Directory, "Version.txt", string.Empty, () => OnVersionChanged?.Invoke());
            _creationTime = new SavedString(Directory, "Creation Time.txt", string.Empty, () => OnCreationTimeChanged?.Invoke());
            _lastLoginTime = new SavedString(Directory, "Last Login Time.txt", string.Empty, () => OnLastLoginTimeChanged?.Invoke());
        }
    }
}