using UnityEngine;
using System.Collections;
using System;

public class TP_HUD : MonoBehaviour
{

    //Global stats
    

    public static int XP = 0;


    void Start()
    {
        
    }
	
	
	void Update ()
    {
        
	}

    

    void OnGUI()
    {
        bool showQuestWindow = false;

        // Menus

        Rect questMenu = new Rect(250, 0, 150, 250);

        if (GUI.Button(new Rect(Screen.width - 190, Screen.height - 60, 60, 50), "Quest"))
        {
            showQuestWindow = true;
            System.Console.WriteLine("Button Pressed here...");
        }

        if (showQuestWindow)
        {
            questMenu = GUI.Window(0, questMenu, DoQuestMenu, "Current Quests");
        }

        // Player Information
        GUI.Box(new Rect(10, 10, Screen.width / 4 + 20, 90), "Azz");
        
        // XP Bar
        GUI.Box(new Rect(10, Screen.height - 60, 200, 50), "XP: " + TP_HUD.XP);

        // Inventory, etc
        if (GUI.Button(new Rect(Screen.width - 70, Screen.height - 60, 60, 50), "Inv"))
            Application.LoadLevel(2);
        if (GUI.Button(new Rect(Screen.width - 130, Screen.height - 60, 60, 50), "Char"))
            Application.LoadLevel(2);

        // Clock

        DateTime time = new System.DateTime();
        time = System.DateTime.Now;
        GUI.Box(new Rect(Screen.width - 110, 10, 70, 20), time.Hour + ":" + time.Minute);

        
           
    }



      void DoQuestMenu(int windowID)
        {

          System.Console.WriteLine("Button Pressed");
          if (GUI.Button(new Rect(25, 40, 250, 50), "Play"))
            Application.LoadLevel(1);
        
        }
}
