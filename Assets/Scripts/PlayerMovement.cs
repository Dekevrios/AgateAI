using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;

    [SerializeField]
    private float _speed;
    [SerializeField]
    private Transform cam;

    
    


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        HideandLockCursor();
    }

    private void HideandLockCursor()
    {
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 horDirection = horizontal * cam.right;
        Vector3 verDirection = vertical * cam.forward;

        horDirection.y = 0;
        verDirection.y = 0;

        Vector3 movement = horDirection + verDirection;
        rb.linearVelocity = movement * _speed * Time.fixedDeltaTime;

        Debug.Log("Horizontal: " + horizontal + ", Vertical: " + vertical);
    }

}
