using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishSpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Vector3 spawnValuesFirst;
    public Vector3 spawnValuesSecond;

    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public static bool stopSpawning;
    int randEnemy;

    void Start()
    {
        StartCoroutine(JellySpawner());
    }

    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator JellySpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stopSpawning)
        {
            randEnemy = Random.Range(0, 2);

            Vector3 spawnPosition = new Vector3(Random.Range(spawnValuesFirst.x, spawnValuesSecond.x), -1, Random.Range(spawnValuesFirst.z, spawnValuesSecond.z));
            Vector3 p1Position = GameObject.FindGameObjectWithTag("player1").transform.position;
            Vector3 p2Position = GameObject.FindGameObjectWithTag("player2").transform.position;
            Vector3 leaderPos;
   
            if (p1Position.z >= p2Position.z)
            {
                leaderPos = p1Position;
            }
            else
            {
                leaderPos = p2Position;
            }

            leaderPos = leaderPos + new Vector3(transform.position.x-leaderPos.x, 0, 70);
            Instantiate(enemies[randEnemy], spawnPosition + leaderPos, gameObject.transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }
}