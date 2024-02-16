using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class PlayerBulletScript : MonoBehaviour
{
    private GameObject closestEnemy;
    private GameObject[] enemies;
    private Rigidbody2D rb;
    public float force;
    private float distanceFromPlayer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        distanceFromPlayer = 10000000000000;

        foreach (GameObject enemy in enemies)
        {
            float currentEnemyDistanceFromPlayer = Vector2.Distance(player.transform.position, enemy.transform.position);
            
            if (distanceFromPlayer > currentEnemyDistanceFromPlayer)
            {
                distanceFromPlayer = currentEnemyDistanceFromPlayer;
                closestEnemy = enemy;
            }
        }

        Vector3 direction = closestEnemy.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        Invoke("DestroyBullet", 3f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Entered OnCollisionEnter2D");
        if (other.gameObject.tag == "ebullet")
        {
            Destroy(gameObject);

        }
        //Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
