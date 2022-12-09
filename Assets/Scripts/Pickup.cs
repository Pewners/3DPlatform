using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    ScoreManager sm;

    void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        sm.score++;
        Destroy(gameObject);
    }
}