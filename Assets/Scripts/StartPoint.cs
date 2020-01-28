using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{public float fadeDuration = 1f;
    public float displayImageDuration = 0.2f;
    public GameObject player;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    //public AudioSource exitAudio;
    bool m_IsPlayerAtStartPoint;
    float m_Timer;
    //bool m_HasAudioPlayed;

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtStartPoint = true;
           // m_HasAudioPlayed = true;
        }
    }

    void Update ()
    {
        if(m_IsPlayerAtStartPoint = true)
        {
            StartLevel ();
        }
        //if(!m_HasAudioPlayed)
        //{
        //    exitAudio.Play();
        //}
    }

    void StartLevel ()
    {
        m_Timer += Time.deltaTime;

        exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;

        if(m_Timer > fadeDuration + displayImageDuration)
        {
         exitBackgroundImageCanvasGroup.alpha = 0;
        }
    }
}
