using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public bool isEnemyShot = false;
    public float direc;
    public float bulletSpeed = 500f;

    void Start()
    {
        Destroy(gameObject, 3);
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(direc*bulletSpeed,0));
    }
}
