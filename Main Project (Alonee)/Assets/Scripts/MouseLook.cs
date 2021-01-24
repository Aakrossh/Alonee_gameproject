using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    #region Mouse_Proporties
    [SerializeField]
    private Transform playerRoot, lookRoot;

    [SerializeField]
    private bool invert;

    [SerializeField]
    private bool can_Unlock = true;

    [SerializeField]
    private float sensivity = 5f;

    [SerializeField]
    private int smooth_Steps = 10;

    [SerializeField]
    private float smooth_Weight = 0.4f;

    [SerializeField]
    private float roll_Angle = 10f;

    [SerializeField]
    private float roll_Speed = 3f;

    [SerializeField]
    private Vector2 default_Look_Limits = new Vector2(-70f, 80f);

    private Vector2 look_Angles;

    private Vector2 current_Mouse_Look;
    #endregion

    [SerializeField]
    private bool interractable;

    [SerializeField]
    private Transform raycastOrigin;
    // private Vector2 smooth_Move;

    // private float current_Roll_Angle;

    // private int last_Look_Frame;

   // [SerializeField]
    // private UI_Manager uiManager;

    [SerializeField]
    private Drawer_Behaviour drawer;

    [SerializeField]
    private Door_Behaviour door;

    [SerializeField]
    private Locker_Behaviour locker;

    [SerializeField]
    private bool openDoor;
    [SerializeField]
    private bool openDrawer;
    [SerializeField]
    private bool openLocker;


    void Start () {

        Cursor.lockState = CursorLockMode.Locked;

        
	}
	
	void Update () {

        LockAndUnlockCursor();
        Dectector();

        if(Cursor.lockState == CursorLockMode.Locked) {
            LookAround();
        }

        Interract();

    }

    void LockAndUnlockCursor() {

        if(Input.GetKeyDown(KeyCode.Escape)) {

            if(Cursor.lockState == CursorLockMode.Locked) {

                Cursor.lockState = CursorLockMode.None;


            } else {

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

            }

        }

    } // lock and unlock

    void LookAround() {

        current_Mouse_Look = new Vector2(
            Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));

        look_Angles.x += current_Mouse_Look.x * sensivity * (invert ? 1f : -1f);
        look_Angles.y += current_Mouse_Look.y * sensivity;

        look_Angles.x = Mathf.Clamp(look_Angles.x, default_Look_Limits.x, default_Look_Limits.y);

        //current_Roll_Angle =
            //Mathf.Lerp(current_Roll_Angle, Input.GetAxisRaw(MouseAxis.MOUSE_X)
                       //* roll_Angle, Time.deltaTime * roll_Speed);

        lookRoot.localRotation = Quaternion.Euler(look_Angles.x, 0f, 0f);
        playerRoot.localRotation = Quaternion.Euler(0f, look_Angles.y, 0f);


    } // look around

    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Door")
        {

        }
    }*/

    private void Dectector()
    {
        RaycastHit hit;
        if(Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, 3f))
        {
            if(hit.collider.tag == "Door")
            {
                interractable = true;
                Debug.Log("Hitting Door");
                openDoor = true;
                //  uiManager.Interract(true);
            }
            else
            {
                openDoor = false;
            }

            if (hit.collider.tag == "Drawer")
            {
                interractable = true;
                Debug.Log("Hitting Drawer");
                openDrawer = true;

            }
            else
            {
                 openDrawer = false;
            }

            if (hit.collider.tag == "Locker")
            {
                interractable = true;
                Debug.Log("Hitting Locker");
                openLocker = true;
            }
            else
            {
                openLocker = false;
            }

        }
        else if(hit.collider == null)
        {
           // uiManager.Interract(false);
        }

        Debug.DrawRay(transform.position, transform.forward * 5f, Color.green, 2f);
    }

    private void Interract()
    {
        if (Input.GetKeyDown(KeyCode.E) && interractable == true)
        {
            if(openDoor == true)
            {
                Debug.Log("Input openDoor");
                door.OpenDoor();
            }

            if(openDrawer == true)
            {
                Debug.Log("Input openDrawer");
                drawer.OpenDrawer();
            }

            if(openLocker == true)
            {
                Debug.Log("Input openLocker");
                locker.OpenLocker();
            }
        }
    }


}













































