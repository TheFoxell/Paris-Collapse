using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioMenu : MonoBehaviour
{
    public static AudioMenu instance;
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "ville" || SceneManager.GetActiveScene().name == "Lose" )
        {
            Destroy(gameObject);
        }
    }
}
