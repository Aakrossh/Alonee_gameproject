using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Events : MonoBehaviour
{
    public AudioSource horrorAudio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Playing horror sound");
            horrorAudio.Play();
        }
    }
}
