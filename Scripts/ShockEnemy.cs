using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShockEnemy : MonoBehaviour
{

    BoxCollider boxCollider;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    
    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player1")
        {
            Player1 p1 = other.GetComponent<Player1>();
            if (p1 != null)
            {
                p1.shock = true;        
            }
        }
        if (other.gameObject.tag == "player2")
        {
            Player2 p2 = other.GetComponent<Player2>();
            if (p2 != null)
            {
                p2.shock = true;
            }
        }
        boxCollider.enabled = false;
        yield return new WaitForSeconds(4f);
        boxCollider.enabled = true;


    }
    
    

}

