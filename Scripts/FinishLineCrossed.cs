using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineCrossed : MonoBehaviour {

    [SerializeField] GameObject finishObject = null;

    private void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Collider>().CompareTag("player1"))
        {
            if (finishObject.CompareTag("finish"))
            {
                Player1 player1 = col.transform.root.GetComponentInChildren<Player1>();
                if (Player1.CheckStatus() == false && Player2.CheckStatus() == false)
                {
                    player1.Winner();
                }
                else
                {
                    player1.Loser();
                }
            }
        }
        if (col.GetComponent<Collider>().CompareTag("player2"))
        {
            if (finishObject.CompareTag("finish"))
            {
                Player2 player2 = col.transform.root.GetComponentInChildren<Player2>();
                if (Player1.CheckStatus() == false && Player2.CheckStatus() == false)
                {
                    player2.Winner();
                }
                else
                {
                    player2.Loser();
                }
            }
        }
    }
}
