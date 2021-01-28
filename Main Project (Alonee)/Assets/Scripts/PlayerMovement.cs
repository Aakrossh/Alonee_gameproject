using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

    private CharacterController character_Controller;

    private Vector3 move_Direction;

    public float speed = 5f;
    private float gravity = 20f;

    public float jump_Force = 10f;
    private float vertical_Velocity;

    void Awake() {
        character_Controller = GetComponent<CharacterController>();
    }
	
	void Update () {
        MoveThePlayer();
	}

    void MoveThePlayer() {

        float move_h = CrossPlatformInputManager.GetAxis("Horizontal");
        float move_v = CrossPlatformInputManager.GetAxis("Vertical");

        move_Direction = new Vector3(move_h, 0f, move_v);


        move_Direction = transform.TransformDirection(move_Direction);
        move_Direction *= speed * Time.deltaTime;

        ApplyGravity();

        character_Controller.Move(move_Direction);


    } // move player

    void ApplyGravity() {

        vertical_Velocity -= gravity * Time.deltaTime;

        // jump
        PlayerJump();

        move_Direction.y = vertical_Velocity * Time.deltaTime;

    } // apply gravity

    void PlayerJump() {

        if(character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            vertical_Velocity = jump_Force;
        }

    }

} // class


































