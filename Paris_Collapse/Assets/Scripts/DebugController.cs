using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class DebugController : MonoBehaviour
{

    bool showConsole;
    string input;

    public Player player;

    public static DebugCommand STOP_SAVING;
    public static DebugCommand GETMONEY;

    public List<object> commandList;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            showConsole = !showConsole;
    }
    
    private void OnGUI()
    {
        if(!showConsole){return;}

        float y = 0f;

        GUI.Box(new Rect(0, y, Screen.width, 30),"");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);
    }

    


    private void Awake()
    {

        STOP_SAVING = new DebugCommand("stop_saving", "Arrete la sauvegarde automatique et la delete", "stop_saving", 
            () =>
            {
                player.StopSaving();
            });

        GETMONEY = new DebugCommand("getmoney", "Rajoute 5000 gold", "getmoney", 
            () =>
            {
                player.coin += 5000;
            });
        
        commandList = new List<object>
        {
            STOP_SAVING, GETMONEY
        };
    }
    
    public void OnReturn(InputValue value)
    {
        if (showConsole)
        {
            HandleInput();
            input = "";
        }
    }

    public void HandleInput()
    {
        for (int i = 0; i < commandList.Count; i++)
        {
            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;

            if (input.Contains(commandBase.CommandId))
            {
                if (commandList[i] as DebugCommand != null)
                {
                    (commandList[i] as DebugCommand).Invoke();
                }
            }
        }
    }
    
}
