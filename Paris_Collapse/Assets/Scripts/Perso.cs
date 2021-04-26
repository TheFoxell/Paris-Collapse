using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perso : MonoBehaviour
{
    public int Speed = 5;
    private Vector3 DirectionDeplacement = Vector3.zero;
    private CharacterController Player;
    public int Sensi;
    public int Jump = 5;
    public int gravite = 20;
    private Animator Anim;
    public int RunSpeed = 10;
    void Start()
    {
        Player = GetComponent<CharacterController>();
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        DirectionDeplacement.z = Input.GetAxisRaw("Vertical");
        DirectionDeplacement.x = Input.GetAxisRaw("Horizontal");
        DirectionDeplacement = transform.TransformDirection(DirectionDeplacement);
       
        //Deplacement
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Player.Move(DirectionDeplacement * Time.deltaTime * RunSpeed);
        }
        else
        {
            Player.Move(DirectionDeplacement * Time.deltaTime * Speed);
        }
        transform.Rotate(0,Input.GetAxisRaw("Mouse X")*Sensi,0);
        
        //Saut
        if (Input.GetKeyDown(KeyCode.Space)&& Player.isGrounded)
        {
            DirectionDeplacement.y = Jump;
        }
        //Gravité
        if (!Player.isGrounded)
        {
            DirectionDeplacement.y -= gravite * Time.deltaTime;
        }
        
        //Animations
        if (Input.GetKey(KeyCode.W)&& !Input.GetKey(KeyCode.LeftShift))
        {
            Anim.SetBool("Walk",true);
            Anim.SetBool("Run",false);
        }
        if (Input.GetKey(KeyCode.W)&& Input.GetKey(KeyCode.LeftShift))
        {
            Anim.SetBool("Walk",false);
            Anim.SetBool("Run",true);
        }
        if (!Input.GetKey(KeyCode.W))
        {
            Anim.SetBool("Walk",false);
            Anim.SetBool("Run", false);
        }

    }
}
