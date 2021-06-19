using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nombrealé : MonoBehaviour
{
    public Text txt;
    public InputField ifText;
    [SerializeField] 
    int nb, nbCoup; 
    bool endGame = false;
    public Player player;

    private void Start()
    {
        InitNb();
    }
    void InitNb()
    {
        ifText.interactable = true;
        endGame = false;
        nb = Random.Range(1, 100);
        nbCoup = 0;
        txt.text = "Propose un nombre entre 1 et 100";
        IfGetFocus();
    }

    public void Validation()
    {
        nbCoup++;
        int n = int.Parse(ifText.text);
        ifText.text = null;

        if (n == nb)
        {
            txt.text = "Bravo, trouvez en " + nbCoup + " coups";
            endGame = true;
            ifText.interactable = false;
        }
        else if(n < nb)
        {
            txt.text = "Plus Grand, " + nbCoup + " coups";
        }
        else if(n > nb)
        {
            txt.text = "Plus Petit, " + nbCoup + " coups";
        }
        
        IfGetFocus();
    }

    void IfGetFocus()
    {
        ifText.Select();
        ifText.ActivateInputField();
    }
    void Update()
    {
        if (endGame && Input.GetKeyDown(KeyCode.E))
        {

            if (nbCoup <= 3)
                player.coin += 20;
            if (nbCoup <= 5)
                player.coin += 15;
            else
                player.coin -= 10;
            
            SceneManager.LoadScene("GameScene");
        }
    }
}
