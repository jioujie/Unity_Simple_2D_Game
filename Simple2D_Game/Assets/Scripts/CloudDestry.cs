using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudDestry : MonoBehaviour
{
    public float boundary;

    private void Update()
    {
        boundary = Mathf.Abs(GetComponent<Transform>().position.x);
        if (boundary > 11)
        {
            Destroy(gameObject);
            Cloud.cloudDestroy();
        }
    }
}
