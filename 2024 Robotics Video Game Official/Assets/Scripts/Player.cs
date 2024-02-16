using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AdaptivePerformance.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool moveLeft;
    private bool moveRight;

    private float horizontalMove;
    public float speed = 5f;
    public float jumpForce = 5;
    public float delayBeforeDoubleJump;

    private int healthInt;
    public TextMeshProUGUI healthText;

    public GameObject gameOverPanel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveLeft = false;
        moveRight = false;
        healthInt = 3;
    }

    void Update()
    {
        healthText.text = healthInt.ToString();

        if (healthInt <= 0)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
        }

        if (moveLeft == true && transform.position.x > -13)
        {
            horizontalMove = -speed;
        }
        else if (moveRight == true && transform.position.x < 7)
        {
            horizontalMove = speed;
        }
        else
        {
            horizontalMove = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpeedBoost"))
        {
            speed *= 2;
            jumpForce += 2;
            Destroy(collision.gameObject);
            Invoke("ReturnPlayerToNormal", 3f);
        }

        if (collision.CompareTag("TimeSlow"))
        {
            Time.timeScale = 0.5f;
            Destroy(collision.gameObject);
            Invoke("ReturnTimeToNormal", 3f);
        }

        if (collision.CompareTag("ebullet"))
        {
            healthInt--;
        }

        if (collision.CompareTag("FallingEnemy"))
        {
            healthInt--;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("BelowEnemy"))
        {
            healthInt -= 3;
        }
    }

    private void ReturnPlayerToNormal()
    {
        speed /= 2;
        jumpForce -= 2;
    }

    private void ReturnTimeToNormal()
    {
        Time.timeScale = 1f;
    }

    public void jumpButton()
    {
        if (Feet.isGrounded == true)
        {
            Feet.isGrounded = false;
            rb.velocity = Vector2.up * jumpForce;
            Invoke("EnableDoubleJump", delayBeforeDoubleJump);
        }

        if (Feet.canDoubleJump == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            Feet.canDoubleJump = false;
        }
    }

    void EnableDoubleJump()
    {
        Feet.canDoubleJump = true;
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    public void PointerDownRight()
    {
        moveRight = true;
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }

    public void ShootButton()
    {

    }
}
