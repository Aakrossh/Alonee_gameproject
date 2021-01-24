﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Behaviour : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        anim.SetBool("openDoor", true);
        Debug.Log("Opening Door");
    }
}
