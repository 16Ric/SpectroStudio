using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhisperingAudio : MonoBehaviour
{
    public Transform john;           
    public Transform altar;         
    public AudioSource whisperAudio; 
    private float initialDistance;  

    void Start()
    {
        initialDistance = Vector3.Distance(john.position, altar.position);

        whisperAudio.volume = 0.5f;
    }

    void Update()
    {
        float currentDistance = Vector3.Distance(john.position, altar.position);
        
        float normalizedDistance = Mathf.Clamp01(currentDistance / initialDistance);

        whisperAudio.volume = 1 - normalizedDistance;
    }
}


