using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //insert code that adds to counter
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
