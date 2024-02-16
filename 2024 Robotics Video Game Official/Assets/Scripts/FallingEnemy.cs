using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingEnemy : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.down * 3 * Time.deltaTime);

        if (transform.position.y <= -12)
        {
            Destroy(gameObject);
        }
    }
}
