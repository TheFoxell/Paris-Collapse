using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{

    public Interactable focus;
    public LayerMask movementMask;
    Camera cam;
    PlayerMotor motor;
    
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // Si on appuie sur le bouton gauche de la souris
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                // Deplace au point cliqué
                motor.MoveToPoint(hit.point);


                RemoveFocus();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                // Deplace au point cliqué


                Interactable interactable = hit.collider.GetComponent<Interactable>();
                
                // Si il est un magasin
                if (interactable != null)
                {
                    SetFocus(interactable);
                }
                
            }
        }

        
        // Si on appuie sur E : ouvre l'inventaire
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Inventaire");
        }
        
        
        // Si on appuie sur F
        if (Input.GetKeyDown(KeyCode.F))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                //Debug.Log("We hit" + hit.collider.name + " " + hit.point);

                // Verifie ce qu'est l'interactable

                Interactable interactable = hit.collider.GetComponent<Interactable>();
                
                // Si il est un magasin
                if (interactable.name == "Store")
                {
                    
                    Debug.Log("TEST OK");
                    SceneManager.LoadScene("Store");
                }
				
				
            }
			
        }
        void SetFocus (Interactable newFocus)
        {
            if (newFocus != focus)
            {
                if(focus != null)
                    focus.OnDefocused();

            
                focus = newFocus;
                motor.FollowTarget(newFocus);
            }

            newFocus.OnFocused(transform);
           
        }

        void RemoveFocus()
        {
            if (focus != null)
                focus.OnDefocused();

            focus = null;
            motor.StopFollowingTarget();
        }
    }
}
