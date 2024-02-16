using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float length;
    public float speed;
    public string HorizontalOrVertical;
    private float startPosX;
    private float startPosY;

    private void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
    }

    void Update()
    {
        if (HorizontalOrVertical.Equals("Horizontal"))
        {
            transform.position = new Vector2(PingPongPlatform(Time.time * speed, startPosX - length, startPosX + length, startPosX), transform.position.y);

        } else if (HorizontalOrVertical.Equals("Vertical"))
        {
            transform.position = new Vector2(transform.position.x, PingPongPlatform(Time.time * speed, startPosY - length, startPosY + length, startPosY));
        }
    }

    float PingPongPlatform(float aValue, float aMin, float aMax, float originalX)
    {
        float offset = originalX - aMin;
        return Mathf.PingPong(aValue + offset, aMax - aMin) + aMin;
    }
}
