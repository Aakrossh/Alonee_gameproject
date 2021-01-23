using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker_Behaviour : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenLocker()
    {
        anim.SetTrigger("Locker");
    }
}
