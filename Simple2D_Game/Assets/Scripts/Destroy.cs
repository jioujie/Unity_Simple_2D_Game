using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float boundary;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 20f);
    }

    private void Update()
    {
        boundary = Mathf.Abs(GetComponent<Transform>().position.x);
        if(boundary > 11)
        {
            Destroy(gameObject);
        }
    }
}
