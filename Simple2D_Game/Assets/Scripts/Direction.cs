using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    static public float direction = 1f;
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            direction = Input.GetAxisRaw("Horizontal");
        }
    }

    static public float Direc()
    {
        return direction;
    }
}
