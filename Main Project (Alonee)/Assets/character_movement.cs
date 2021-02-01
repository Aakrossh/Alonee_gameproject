using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_movement : MonoBehaviour
{
    public float moveSpeed;
    public float gravityModifier;

    private CharacterController char_controller;
    private void Start()
    {
        char_controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        moveH *= moveSpeed * Time.deltaTime;
        moveV *= moveSpeed * Time.deltaTime;
        Vector3 player_move = new Vector3(moveH, - gravityModifier * Time.deltaTime, moveV);
        char_controller.Move(player_move);


    }
}
