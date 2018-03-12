using UnityEngine;

public class Hacker : MonoBehaviour {

    //Game configuration data
    const string menuHint = "You may type menu at any time";
    string[] level1Passwords = { "books","aisle","shelf","font","borrow" };
    string[] level2Passwords = { "planet", "ship", "star", "falcon", "tesla" };
    string[] level3Passwords = { "cheat", "invade", "steal", "white", "trump"};

    //game state
    int level;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;
    string password;

    // Use this for initialization
    void Start() {
        ShowMainMenu();
    }
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for Library");
        Terminal.WriteLine("Press 2 for SpaceX");
        Terminal.WriteLine("Press 3 for NSA");
    }


	void OnUserInput(string input)
    {
        if(input == "menu")
        {
            ShowMainMenu();
        }
        else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

    }



    void RunMainMenu(string input)
    {
        bool IsValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (IsValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please choose a valid option");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        GenerateRandomPassword();
        Terminal.WriteLine("Enter Your Password, Hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void GenerateRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid Level Number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if(input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("LIBRARY MAINFRAME ACCESS GRANTED!");

                 Terminal.WriteLine(@"
    _________
   /       //
  /       //
 /       //
(_______(/
");
                break;
            case 2:
                Terminal.WriteLine("SPACEX MAINFRAME ACCESS GRANTED!");
                Terminal.WriteLine(@"
       / \
      / _ \
     |.o '.|
     |'._.'|
   ,'|  |  |`.
  /  |  |  |  \
  |,-'--|--'-.|
");
                break;
            case 3:
                Terminal.WriteLine("NSA MAINFRAME ACCESS GRANTED!");
                Terminal.WriteLine(@"
 _   _  _____         
 | \ | |/ ____|  /\    
 |  \| | (___   /  \   
 | . ` |\___ \ / /\ \  
 | |\  |____) / ____ \ 
 |_| \_|_____/_/    \_\
");
                break;
            default:
                Debug.LogError("Invalid Level Reached");
                break;
        }
    }
}
