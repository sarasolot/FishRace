using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentTrigger : MonoBehaviour {

    [SerializeField] GameObject currentObject = null;
    public float fastSpeed;
    
    void OnTriggerEnter(Collider other)
    {
        if (currentObject.CompareTag("current"))
        {
            Player1 p1 = other.GetComponent<Player1>();
            Player2 p2 = other.GetComponent<Player2>();
            if (p1 != null)
            {
                p1.current = true;
            }
            else if (p2 != null)
            {
                p2.current = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (currentObject.CompareTag("current"))
        {
            Player1 p1 = other.GetComponent<Player1>();
            Player2 p2 = other.GetComponent<Player2>();
            if (p1 != null)
            {
                p1.current = false;
            }
            else if (p2 != null)
            {
                p2.current = false;
            }
        }
    }
}
