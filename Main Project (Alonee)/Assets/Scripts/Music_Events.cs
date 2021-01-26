using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Events : MonoBehaviour
{
    public AudioSource horrorAudio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("horror"))
        {
            Debug.Log("Playing Horror sound");
            horrorAudio.Play();
        }
    }
}
