using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public static bool Level1Locked;
    public static bool Level2Locked;
    public static bool Level3Locked;
    public static bool Level4Locked;

    // Start is called before the first frame update
    void Start()
    {
        Level1Locked = false;
        Level2Locked = true;
        Level3Locked = true;
        Level4Locked = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
