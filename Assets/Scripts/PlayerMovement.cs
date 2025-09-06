using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Rigidbody rb;
    


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        rb.linearVelocity = movement * _speed * Time.fixedDeltaTime;

        Debug.Log("Horizontal: " + horizontal + ", Vertical: " + vertical);
    }

}
