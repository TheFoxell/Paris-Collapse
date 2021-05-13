using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractScene : Interactable
{

    public string _sceneName;
    public override void Interact()
    {
        base.Interact();

        Load(_sceneName);
    }

    void Load(string sceneName)
    {
        Debug.Log("Load " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
