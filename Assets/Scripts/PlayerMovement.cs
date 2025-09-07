using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody rb;

    public Action OnPowerUpStart;
    public Action OnPowerUpEnd;

    [SerializeField]
    private float _speed;
    [SerializeField]
    private Transform cam;
    [SerializeField]
    private float powerUpDuration;
    private Coroutine powerUpCoroutine;

    private bool isPowerActive = false;
    public void PickPowerUp()
    {
        Debug.Log("Power Up Collected!");
        if(powerUpCoroutine != null)
        {
            StopCoroutine(powerUpCoroutine);
        }
     

        powerUpCoroutine = StartCoroutine(StartPowerUp());
    }

    private IEnumerator StartPowerUp()
    {
        isPowerActive = true;

        if (OnPowerUpStart != null)
        {
            OnPowerUpStart();
        }
        yield return new WaitForSeconds(powerUpDuration);

        isPowerActive = false;

        if (OnPowerUpEnd != null)
        {
            OnPowerUpEnd();
        }
    }



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

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isPowerActive)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<Enemy>().Dead();
            }
        }
    }

}
