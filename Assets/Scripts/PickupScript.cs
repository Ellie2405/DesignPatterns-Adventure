using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    static public Action<GameObject> Picked;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.AddPickup(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Picked.Invoke(gameObject);
        Destroy(gameObject);
    }
}
