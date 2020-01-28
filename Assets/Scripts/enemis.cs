using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemis : MonoBehaviour
{
    public GameObject player;
    public float lookRadius = 10f;
    public AudioSource exitAudio;
    Transform target;
    NavMeshAgent agent;
    bool m_HasAudioPlayed;

    public float fadeDuration = 0f;
    public float displayImageDuration = 1f;
    
    public CanvasGroup exitBackgroundImageCanvasGroup;

    bool m_IsPlayerAtExit;
    float m_Timer;


     void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
            m_HasAudioPlayed = true;
        }
    }

    void Start()
    {
        target = player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       float distance = Vector3.Distance(target.position, transform.position);
       if (distance <= lookRadius)
       {
           agent.SetDestination(target.position);
       }
        if(m_IsPlayerAtExit)
        {
            EndLevel ();
        }
         if(!m_HasAudioPlayed)
        {
          exitAudio.Play();
        }
    }
    void OnDrawongGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void EndLevel ()
    {
        m_Timer += Time.deltaTime;

        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if(m_Timer > fadeDuration + displayImageDuration)
        {
            Application.Quit ();
        }
    }
}
