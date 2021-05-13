using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public Player player;
    public Interactable pnj;
    public GameObject quete;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InInteraction();
    }


    public void InInteraction()
    {
        if (pnj.hasInteracted)
        {
            quete.SetActive(true);
        }
        else
        {
            quete.SetActive(false);
        }
    }
}
