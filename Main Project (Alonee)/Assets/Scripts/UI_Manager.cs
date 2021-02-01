using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject doorPanel;


    public void Interract(bool showPanel)
    {
        if(showPanel == true)
        {
            doorPanel.SetActive(true);
        }
        else
        {
            doorPanel.SetActive(false);
        }
    }
}
