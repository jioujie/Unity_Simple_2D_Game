using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody2D rig;
    private float jumpForce;
    private float horizontal;
    private float moveSpeed;
    private float move;
    public float direction;
    private int jump = 2;

    public GameObject Sword;
    public GameObject Gun;
    bool isGun = true;
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        jumpForce = 300f;
        moveSpeed = 5.5f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jump > 0)
        {
            rig.AddForce(new Vector2(0, jumpForce));
            jump -= 1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rig.AddForce(new Vector2(0, -jumpForce*10));
        }

        horizontal = Input.GetAxis("Horizontal");
        direction = Input.GetAxisRaw("Horizontal");
        move = horizontal * moveSpeed;
        rig.velocity = new Vector2(move, rig.velocity.y);

        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && direction != 0)
            GetComponent<Renderer>().transform.localScale = new Vector3(direction, 1, 1);

        if (Input.GetKeyDown(KeyCode.R))
        {
            Change();
        }
    }
    private void FixedUpdate()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        jump = 2;
    }

    void Change()
    {
        Gun.SetActive(isGun);
        Sword.SetActive(!isGun);
        isGun = !isGun;
    }
}
