using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Pickable : MonoBehaviour
{
    [SerializeField]
    public PickableType type;
    public Action<Pickable> OnPicked;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger: " + type) ;
            OnPicked(this);
            Destroy(gameObject);

        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Debug.Log("Holding " + gameObject.name);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        Debug.Log("Dropped " + gameObject.name);
    //    }
    //}

}
