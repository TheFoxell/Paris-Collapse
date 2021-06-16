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
    
    public int Speed = 5;
    private Vector3 DirectionDeplacement = Vector3.zero;
    private CharacterController Player;
    public int Sensi;
    public int Jump = 5;
    public int gravite = 20;
    private Animator Anim;
    public int RunSpeed = 10;
    public bool Inwalk;
    private Vector3 tmp;



    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
        
        Player = GetComponent<CharacterController>();
        Anim = GetComponent<Animator>();
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
                tmp = Input.mousePosition;
                // Deplace au point cliqué
                Anim.SetBool("Walk", true);
                
                Debug.Log("Walking");

                Inwalk = true;
                
                motor.MoveToPoint(hit.point);

                RemoveFocus();
            }
        }
        if (tmp.x == transform.position.x)
            Inwalk = false;

        if (!Inwalk)
            Anim.SetBool("Walk",false);


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
