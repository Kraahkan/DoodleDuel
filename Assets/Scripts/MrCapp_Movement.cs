using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Caleb Belcourt

//Debug.Log(); -- to debug

public class MrCapp_Movement : MonoBehaviour
{

    public CharacterController2D controller;

    public Animator animator;

    public float runSpeed = 400f;

    float horizontalMove = 0f;

    bool jump = false;

    bool crouch = false;

    //public bool getWeapon;

    //public GameObject weapon_sprite;

    void Start(){
        //getWeapon = false;
        //weapon_sprite.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        //Get input
        horizontalMove = Input.GetAxisRaw("Capp_Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        //Jump
        if (Input.GetButtonDown("Capp_Jump"))
        {
            jump = true;
            //SoundManagerScript.PlaySound("jump");
        }

        //crouch
        if (Input.GetButtonDown("Capp_Crouch"))
        {
            crouch = true;

        } else if (Input.GetButtonUp("Capp_Crouch"))
        {
            crouch = false;
        }

        /*
        if (getWeapon){
            weapon_sprite.SetActive(true);
        }
        */
    }

    void FixedUpdate()
    {
        //Move our character (apply input)
        //parameters (how much to move, should crouch? , should jump?)
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
