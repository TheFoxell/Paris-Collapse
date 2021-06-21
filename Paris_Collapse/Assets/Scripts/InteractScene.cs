using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractScene : Interactable
{

    public string _sceneName;
    public Player player = null;
    public override void Interact()
    {
        base.Interact();

        Load(_sceneName);
    }

    void Load(string sceneName)
    {
        if (player != null)
        {
            if(player.level >= 100)
                SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("Load " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
    }
}
