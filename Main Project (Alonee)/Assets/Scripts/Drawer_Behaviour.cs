using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer_Behaviour : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OpenDrawer()
    {
        anim.SetTrigger("Drawer");
    }
}
