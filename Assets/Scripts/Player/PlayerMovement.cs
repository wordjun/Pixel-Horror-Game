using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    public float sensitivity = 3f;
    Rigidbody rb1;
    // Start is called before the first frame update
    void Start()
    {
        rb1 = GetComponent<Rigidbody>();//get the rigidbody component from player

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //update every movement
        Movement();
        CameraMovement();

        //will trigger at the moment ESC is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;

        if(Input.GetMouseButtonDown(0))
            Cursor.lockState = CursorLockMode.Locked;
    }
    void Movement(){
        Vector3 finalVelocity = Vector3.zero;
        Vector3 horizontal = Vector3.zero;
        Vector3 vertical = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
            horizontal = transform.right;
        else if (Input.GetKey(KeyCode.A))
            horizontal = - transform.right;
        else
            horizontal = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            vertical = transform.forward;
        else if (Input.GetKey(KeyCode.S))
            vertical = - transform.forward;
        else
            vertical = Vector3.zero;

        rb1.velocity = (horizontal + vertical) * speed;

    }
    public float smooth = 2f;
    Vector2 finalMovement;
    Vector2 smoothValue;
    void CameraMovement(){
        Vector2 movement = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        //
        movement = Vector2.Scale(movement, new Vector2(sensitivity * smooth, sensitivity * smooth));

        //linear interpolation: move an object from point a to point b, at a time value t
        smoothValue.x = Mathf.Lerp(smoothValue.x, movement.x, 1f / smooth);
        smoothValue.y = Mathf.Lerp(smoothValue.y, movement.y, 1f / smooth);

        finalMovement += smoothValue;
        finalMovement.y = Mathf.Clamp(finalMovement.y, -90, 90);

        Camera.main.gameObject.transform.localRotation = Quaternion.AngleAxis(-finalMovement.y, Vector3.right);
        transform.localRotation = Quaternion.AngleAxis(finalMovement.x, transform.up);

    }
}
