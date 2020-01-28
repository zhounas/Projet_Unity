using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    public CharacterController controller;
    public float speed =12f;
    Animator m_Animator;
    public AudioSource exitAudio;
     
     
    
    void Start ()
    {
        m_Animator = GetComponent<Animator> ();
        
    }

    void Update ()
    {
        float x = Input.GetAxis ("Horizontal");
        float z = Input.GetAxis ("Vertical");
        

        bool hasHorizontalInput = !Mathf.Approximately (x, 0f);
        bool hasVerticalInput = !Mathf.Approximately (z, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        bool m_HasAudioPlayed = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool ("IsWalking", isWalking);
        if(m_HasAudioPlayed == true)
        {
            exitAudio.Play();
        }


        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move *speed * Time.deltaTime);
    }

}