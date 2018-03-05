using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    public FloatReference hostHealth;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(hostHealth.variable.Value);
        // Destroy everything that leaves the trigger

        if (other.tag == "Enemy")
        {   
            hostHealth.variable.Value = hostHealth.variable.Value - 5f;
        }
        else if (other.tag == "GoodCell")
        {
            hostHealth.variable.Value = hostHealth.variable.Value - 1f;
        }

        Destroy(other.gameObject);
    }
}
