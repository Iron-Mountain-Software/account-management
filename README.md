# Account Management
*Version: 1.1.1*
## Description: 
A system for saving, loading, and deleting player accounts.
## Dependencies: 
* com.iron-mountain.save-system (1.0.4)
## Package Mirrors: 
[<img src='https://img.itch.zone/aW1nLzEzNzQ2ODg3LnBuZw==/original/npRUfq.png'>](https://github.com/Iron-Mountain-Software/account-management.git)[<img src='https://img.itch.zone/aW1nLzEzNzQ2ODkyLnBuZw==/original/Fq0ORM.png'>](https://www.npmjs.com/package/com.iron-mountain.account-management)[<img src='https://img.itch.zone/aW1nLzEzNzQ2ODk4LnBuZw==/original/Rv4m96.png'>](https://iron-mountain.itch.io/account-management)
---
## Key Scripts & Components: 
1. public class **Account**
   * Actions: 
      * public event Action ***OnVersionChanged*** 
      * public event Action ***OnCreationTimeChanged*** 
      * public event Action ***OnLastLoginTimeChanged*** 
   * Properties: 
      * public String ***ID***  { get; }
      * public String ***Directory***  { get; }
      * public String ***SessionID***  { get; }
      * public Boolean ***IsDefault***  { get; }
      * public String ***Version***  { get; set; }
      * public String ***CreationTime***  { get; set; }
      * public String ***LastLoginTime***  { get; set; }
   * Methods: 
      * public virtual void ***Initialize***()
1. public static class **AccountsManager**
### Saved Values
1. public class **AccountScriptedSavedBool** : ScriptedSavedBool
   * Properties: 
      * public String ***Directory***  { get; }
1. public class **AccountScriptedSavedFloat** : ScriptedSavedFloat
   * Properties: 
      * public String ***Directory***  { get; }
1. public class **AccountScriptedSavedInt** : ScriptedSavedInt
   * Properties: 
      * public String ***Directory***  { get; }
1. public class **AccountScriptedSavedList** : ScriptedSavedList
   * Properties: 
      * public String ***Directory***  { get; }
1. public class **AccountScriptedSavedString** : ScriptedSavedString
   * Properties: 
      * public String ***Directory***  { get; }
### U I
1. public class **AccountDisplay** : MonoBehaviour
   * Actions: 
      * public event Action ***OnAccountChanged*** 
   * Properties: 
      * public Account ***Account***  { get; set; }
1. public class **AccountDisplayCreationTimeText** : MonoBehaviour
1. public class **AccountDisplayDeleteButton** : MonoBehaviour
1. public class **AccountDisplayIDText** : MonoBehaviour
1. public class **AccountDisplayLastLoginTimeText** : MonoBehaviour
1. public class **AccountDisplayLoginButton** : MonoBehaviour
1. public class **AccountsMenu** : MonoBehaviour
1. public class **ContinueButton** : MonoBehaviour
1. public class **CreateAccountButton** : MonoBehaviour
1. public class **CurrentAccountIDText** : MonoBehaviour
1. public class **DeleteAllAccountsButton** : MonoBehaviour
1. public class **LogOutButton** : MonoBehaviour
