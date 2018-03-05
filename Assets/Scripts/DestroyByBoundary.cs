using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    public FloatReference hostHealth;

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(hostHealth.variable.value);
        // Destroy everything that leaves the trigger

        if (other.tag == "Enemy")
        {
            hostHealth.variable.Value = hostHealth.variable.value - 5f;
        }
        else if (other.tag == "GoodCell")
        {
            hostHealth.variable.Value = hostHealth.variable.value - 1f;
        }

        Destroy(other.gameObject);
    }
}
