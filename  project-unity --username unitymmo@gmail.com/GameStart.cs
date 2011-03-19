using UnityEngine;
using System.Collections;

public class GameStart : MonoBehaviour
{
    public string BuildVersion = "0.17";

    Rect MainWindowRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 200, 300, 300);
    Rect HelpWindowRect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 200, 300, 300);

    // Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnGUI()
    {
        BuildGUI();
    }

    void BuildGUI()
    {
        // Build information
        GUI.Label(new Rect(20, 40, 120, 20), "Version: " + BuildVersion);

        MainWindowRect = GUI.Window(0, MainWindowRect, DoMyWindow, "Project Unity"); 
       
    }

    void DoMyWindow(int windowID)
    {
        if (GUI.Button(new Rect(25, 40, 250, 50), "Play"))
            Application.LoadLevel(1);
        if (GUI.Button(new Rect(25, 100, 250, 50), "Options"))
            Application.LoadLevel(2);
        if (GUI.Button(new Rect(25, 160, 250, 50), "Help"))
            HelpWindowRect = GUI.Window(1, HelpWindowRect, DoHelpWindow, "Help");
        if (GUI.Button(new Rect(25, 220, 250, 50), "Exit"))
            Application.Quit();

        // Make window 0 draggable
        GUI.DragWindow(new Rect(0, 0, 10000, 10000));
    }

    void DoHelpWindow(int windowID)
    {
        if (GUI.Button(new Rect(25, 40, 250, 50), "Play"))
            Application.LoadLevel(1);
    }
}
