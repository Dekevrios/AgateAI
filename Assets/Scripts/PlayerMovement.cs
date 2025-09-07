using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;

using UnityEngine.SceneManagement;

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
    [SerializeField]
    public int health;
    [SerializeField]
    private TMP_Text healthTxt;
    [SerializeField]
    private Transform respawnPoint;


    private Coroutine powerUpCoroutine;

    private bool isPowerActive = false;

    public void Dead()
    {
        health -= 1;

        if(health > 0)
        {
            transform.position = respawnPoint.position;
        }
        else
        {
            health = 0;
            SceneManager.LoadScene("LoseScreen");
            //Debug.Log("Game Over!");
        }

        UpdateUI();
    }

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
        UpdateUI();
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

    private void UpdateUI()
    {
        healthTxt.text = "Health: " + health;
    }

}
