using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockbreak : MonoBehaviour
{
    /*public GameObject breakers;
    public GameObject breaker2;
    public GameObject range;*/
    // Start is called before the first frame update
    void Start()
    {
   
       

    }

    // Update is called once per frame
    void Update()
    {
        //if blocks is inside range then start randomized timer
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        /*Debug.Log("Entered OnCollisionEnter2D");
        if (other.gameObject.tag == "block") 
        {
            StartCoroutine(Wait());
            breakers = other.gameObject;
            Invoke("Block1Respawn", 5f);

        }

        if (other.gameObject.tag == "block")
        {
            StartCoroutine(Wait2());
            breaker2 = other.gameObject;
            Invoke("Block2Respawn", 5f);
        }*/

        if (other.collider.tag == "Player")
        {
            Debug.Log("hit player");
            Invoke("BlockDisappear", 1f);
            Invoke("BlockRespawn", 6f);
        }

    }
    //randomized timer(s)
    IEnumerator Wait()
    {   
        //breakers.SetActive(true);
         // Set the object inactive.
        yield return new WaitForSeconds(Random.Range(1, 2));
        //breakers.SetActive(false);// Set the object active.
    }
    IEnumerator Wait2()
    {
        //breaker2.SetActive(true);
        // Set the object inactive.
        yield return new WaitForSeconds(Random.Range(3, 4));
        //breaker2.SetActive(false);// Set the object active.
    }

    private void BlockRespawn()
    {
        this.gameObject.SetActive(true);
    }

    private void BlockDisappear()
    {
        this.gameObject.SetActive(false);
    }

    private void Block2Respawn()
    {
        //breaker2.SetActive(true);
    }
}
