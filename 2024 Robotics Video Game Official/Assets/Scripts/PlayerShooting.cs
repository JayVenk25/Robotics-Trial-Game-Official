using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    bool canBeUsed = true;


    private float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void ShootButton()
    {
        if (canBeUsed)
        {
            canBeUsed = false;
            shoot();
            StartCoroutine(Wait());
        }   
    }

    void shoot()
        {
            Instantiate(bullet, bulletPos.position, Quaternion.identity);
        }

    IEnumerator Wait()
        {
            yield return new WaitForSeconds(Random.Range(1, 2));
            canBeUsed = true;
        }

    
}