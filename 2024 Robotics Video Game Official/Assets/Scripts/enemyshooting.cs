using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshooting : MonoBehaviour
{
    UnityEngine.Camera cam;
    public GameObject bullet;
    public Transform bulletPos;

    private int health;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        cam = UnityEngine.Camera.main;
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Vector3 viewPos = cam.WorldToViewportPoint(this.gameObject.transform.position);

        if (timer > 8 && viewPos.x > 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1)
        { 
            timer = 0;
            shoot();
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pbullet"))
        {
            health--;

            if (health == 2)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
            }

            if (health == 1)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0, 0, 1);
            }
        }
    }

    void shoot()
    { 
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
