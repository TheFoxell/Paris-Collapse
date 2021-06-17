using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class dialogues : MonoBehaviour
{
   public GameObject Quete;
   public TextMeshProUGUI textDisplay;
   public string[] sentences;
   private int index;
   public float typingSpeed;
   public GameObject continueButton;
   void Start()
   {
      StartCoroutine(Type());
   }

    void Update()
   {
      if (textDisplay.text == sentences[index])
      {
         continueButton.SetActive(true);
      }
      else
      {
         continueButton.SetActive(false);
      }
   }

   IEnumerator Type()
   {
      foreach (char letter in sentences[index].ToCharArray())
      {
         textDisplay.text += letter;
         yield return new WaitForSeconds(typingSpeed);
      }
   }

   public void NextSentence()
   {
      continueButton.SetActive(false);
      
      if (index < sentences.Length - 1)
      {
         index++;
         textDisplay.text = "";
         StartCoroutine(Type());
      }
      else
      {
         textDisplay.text = "";
         continueButton.SetActive(false);
         if (SceneManager.GetActiveScene().name == "Intro" )
            SceneManager.LoadScene("ville");
      }
   }
}
