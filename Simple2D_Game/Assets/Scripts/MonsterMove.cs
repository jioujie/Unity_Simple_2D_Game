using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    private Rigidbody2D rig;
    private Transform trans;
    private float moveSpeed;
    public float direction = -1;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        trans = GetComponent<Transform>();
        moveSpeed = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (trans.position.y > -1.63)
            moveSpeed = -3.5f;
        else
            moveSpeed = 3.5f;
        rig.velocity = new Vector2(moveSpeed * direction, rig.velocity.y);
    }

    public void damage(int damage)
    {
        rig.AddForce(new Vector2(100f,100f));
    }
}
