using UnityEditor;

namespace IronMountain.AccountManagement.Editor
{
    public static class MenuItems
    {
        [MenuItem("Save System/Delete All Accounts")]
        private static void DeleteAllAccounts()
        {
            AccountsManager.DeleteAllAccounts();
        }
    }
}