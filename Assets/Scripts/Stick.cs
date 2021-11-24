using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == "Player")
		{
			collision.transform.parent = transform;
		}
    }

    // Update is called once per frame
    private void OnCollisionExit (Collision collision)
    {
		if (collision.gameObject.tag == "Player")
		{
			collision.transform.parent = null;
		}
    }
}
