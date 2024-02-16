using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BelowEnemy : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        Invoke("MoveUp", 10f);
    }

    public void MoveUp()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
