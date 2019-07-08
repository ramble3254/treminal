using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
    const string ToMenu = "輸入menu可回到主畫面";

    string[] leve1_password = { "123", "321", "123456", "12345678" };
    string[] leve2_password = { "888", "50059", "5050", "99999" };

    int level;
    string password;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen = Screen.MainMenu;


    // Use this for initialization
    void Start ()
    {
        ShowMainMenu();
	}

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("嗨,阿宅");
        Terminal.WriteLine("請問你想選擇什麼難度");
        Terminal.WriteLine("輸入 1 為普通難度");
        Terminal.WriteLine("輸入 2 為難一點點");
        Terminal.WriteLine(ToMenu);
        Terminal.WriteLine("請輸入： ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheakPassword(input); 
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("請不要亂輸入");
        }   
    }
    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("你選擇的是難度" + level);
        Terminal.WriteLine("請輸入密碼： ");
        Terminal.WriteLine("提示: " + password.Anagram());
        Terminal.WriteLine(ToMenu);

    }
    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = leve1_password[Random.Range(0, leve1_password.Length)];
                break;
            case 2:
                password = leve2_password[Random.Range(0, leve2_password.Length)];
                break;
            default:
                Debug.LogError("不是有效的等級");
                break;
        }
    }
    void CheakPassword(string input)
    {
        if (input == password)
        {
            WinGame();
        }
        else
        {
            AskForPassword();
        }
    }
    void WinGame()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }
    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("恭喜, 你在難度 " + level + " 過關了");
                Terminal.WriteLine(@"
\        /   |   |\  |
 \  /\  /    |   | \ |
  \/  \/     |   |  \|
");
                break;
            case 2:
                Terminal.WriteLine("恭喜, 你在難度 " + level + " 過關了");
                Terminal.WriteLine(@"
\        /   |   |\  |
 \  /\  /    |   | \ |
  \/  \/     |   |  \|
");
                break;
        }
        Terminal.WriteLine(ToMenu);
    }


    // Update is called once per frame
    void Update ()
    {
		
	}
}
