using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] pos;
    public GameObject enemy;
    public float frequency;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 10f, frequency);
    }

    void Update()
    {

    }

    private void SpawnEnemy()
    {
        int randIndex = UnityEngine.Random.Range(0, pos.Length);
        Transform randPos = pos[randIndex];
        Instantiate(enemy, randPos.position, Quaternion.identity);
    }
}
