using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BounceEnemy : MonoBehaviour {

    private AudioSource audioSource;
    public AudioClip bounceSound;

    BoxCollider boxCollider; 

	void Start () 
    {
        
        boxCollider = GetComponent<BoxCollider>();
    }
	
     // cand lovim jellyfish
    IEnumerator OnTriggerEnter(Collider other)
    {
        // obtinem audio clipul
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bounceSound;
        audioSource.Play();

        
        if (other.gameObject.tag == "player1")
        {
            
            Player1 p1 = other.GetComponent<Player1>();
            if (p1 != null)
            {
                
                p1.bounce = true;
            }
        }
       
        if (other.gameObject.tag == "player2")
        {
            
            Player2 p2 = other.GetComponent<Player2>();
            if (p2 != null)
            {
                
                p2.bounce = true;
            }
        }

       
        boxCollider.enabled = false;
        yield return new WaitForSeconds(2);
        boxCollider.enabled = true;

    }

     
   
}
