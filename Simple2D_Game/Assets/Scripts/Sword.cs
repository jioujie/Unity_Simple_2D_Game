using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float direction;
    public bool isEnemyAttck = false;
    public int damage = 2;

    public float chopingRate = 0.1f;
    private float chopCooldown;
    private bool chop = false;

    private Vector3 position = new Vector3(1.3f,0.4f,0f);

    public float choping;
    void Start()
    {
        gameObject.GetComponent<Transform>().localPosition = position;
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Chop();
        }
        if (chopCooldown > 0 & !chop)
        {
            chopCooldown -= Time.deltaTime;
        }
        if (chopCooldown < chopingRate & chop)
        {
            chopCooldown += Time.deltaTime;
        }
        if (chopCooldown >= chopingRate)
        {
            chop = false;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }
        direction = Direction.Direc();
        choping = chopCooldown / chopingRate;

        gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, -(120 * choping * direction));
        gameObject.GetComponent<Transform>().localPosition = position + new Vector3(0.9f * choping,-0.8f * choping);
    }

    public void Chop()
    {
        if (CanChop())
        {
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            chop = true;
        }
    }

    public bool CanChop()
    {
        return chopCooldown <= 0f;
    }
}
