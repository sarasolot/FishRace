using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player2 : MonoBehaviour
{

    private Rigidbody thisRigid; 
    public float slowSpeed; 
    public float fastSpeed; 
    public float horizontalSpeed; 
    public float enemyAffectTime; 
    public bool current = false; 
    public bool bounce = false; 
    public bool shock = false; 
    public bool countdown = true; 
    float speedZ; 
    bool cantMove = false;

    MeshRenderer rend;
    Color originalCol;

    public static bool playerTwoWon = false;

    Quaternion originalRotation;

    float speedX;
    
    BoxCollider boxCollider;

    GameObject bubbleSystem;
    ParticleSystem bubbles;

    void Start()
    {
        JellyfishSpawner.stopSpawning = false;
        thisRigid = GetComponent<Rigidbody>();
        rend = GetComponent<MeshRenderer>();
        originalCol = rend.materials[0].color;
        originalRotation = transform.rotation;
        bubbleSystem = GameObject.FindGameObjectWithTag("bubbles2");
        bubbles = bubbleSystem.GetComponent<ParticleSystem>();
        boxCollider = GetComponent<BoxCollider>();
    }

   
    void Update()
    {
        speedX = 0;

        if (Input.GetKey(KeyCode.D))
        {
            speedX = horizontalSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            speedX = -horizontalSpeed;
        }

        if (!bounce && !shock)
        {
            if (current)
            {
                speedZ = fastSpeed;
            }
            else
            {
                speedZ = slowSpeed;
            }
        }

        if (bounce)
        {
            StartCoroutine(BounceForSeconds(enemyAffectTime));
            StopCoroutine(BounceForSeconds(enemyAffectTime));
        }

        if (shock)
        {
            StartCoroutine(ShockForSeconds(enemyAffectTime));
            StopCoroutine(ShockForSeconds(enemyAffectTime));
        }

        if (countdown)
        {
            StartCoroutine(CountdownWait(3.0f));
            StopCoroutine(CountdownWait(3.0f));
        }

        if (cantMove)
        {
            speedX = 0;
            speedZ = 0;
        }

        thisRigid.velocity = new Vector3(speedX, 0, speedZ);

        UIManager.SecondUpdateSlider(transform.position.z);

    }

    public static bool CheckStatus()
    {
        return playerTwoWon;
    }

    public void Winner()
    {
        playerTwoWon = true;
        bubbles.Stop();
        JellyfishSpawner.stopSpawning = true;
        UIManager.SetWinner(2);
        StartCoroutine(WaitAndStop(1.5f));
    }

    public void Loser()
    {
        bubbles.Stop();
        StartCoroutine(WaitAndStop(1.5f));
    }

    IEnumerator WaitAndStop(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        slowSpeed = 0;
        fastSpeed = 0;
        horizontalSpeed = 0;
        speedZ = 0;
    }

    public IEnumerator BounceForSeconds(float seconds)
    {
        speedZ = -speedZ - 40;
        yield return new WaitForSeconds(0.5f);
        bounce = false;
    }

    public IEnumerator ShockForSeconds(float seconds)
    {
        cantMove = true;
        StartCoroutine(ShockRoutine());
        shock = false;
        yield return new WaitForSeconds(seconds);
        cantMove = false;
    }

    IEnumerator ShockRoutine()
    {
        Color flashColor = Color.white;
        bool blink = false;
        float startTime = Time.time;
        while (startTime + enemyAffectTime > Time.time)
        {
            blink = !blink;
            if (blink)
            {
                foreach (Material mat in rend.materials)
                {
                    mat.color = flashColor;
                }
            }
            else
            {
                foreach (Material mat in rend.materials)
                {
                    mat.color = originalCol;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
        foreach (Material mat in rend.materials)
        {
            mat.color = originalCol;
        }

        blink = false;
    }

    IEnumerator CountdownWait(float seconds)
    {
        bubbles.Pause();
        speedX = 0;
        speedZ = 0;
        yield return new WaitForSeconds(seconds);
        countdown = false;
        bubbles.Play();
    }

    IEnumerator OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player1")
        {
            thisRigid.isKinematic = true;
            boxCollider.enabled = false;
            yield return new WaitForSeconds(0.01f);
            thisRigid.isKinematic = false;
            transform.rotation = originalRotation;

            boxCollider.enabled = true;
        }
    }

}
