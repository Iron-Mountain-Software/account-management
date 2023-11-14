using System.IO;
using IronMountain.SaveSystem;
using UnityEngine;

namespace IronMountain.AccountManagement.SavedValues
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Accounts/Scripted Values/Float")]
    public class AccountScriptedSavedFloat : ScriptedSavedFloat
    {
        public override string Directory
        {
            get
            {
                string accountDirectory = Path.Combine(Account.AccountsDirectory, Account.Current.ID);
                return !string.IsNullOrWhiteSpace(directory)
                    ? Path.Combine(accountDirectory, directory)
                    : accountDirectory;
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            Account.OnLoad += InitializeSavedData;
            Account.OnLoaded += InvokeOnValueChanged;
        }

        protected virtual void OnDisable()
        {
            Account.OnLoad -= InitializeSavedData;
            Account.OnLoaded -= InvokeOnValueChanged;
        }
    }
}