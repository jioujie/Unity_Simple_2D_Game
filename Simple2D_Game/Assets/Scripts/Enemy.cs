using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int hprage = 5;
    public int hp;
    public float boundary;
    public bool isEnemy = true;


    private void Start()
    {
        hp = hprage;
    }

    private void Update()
    {
        boundary = Mathf.Abs(GetComponent<Transform>().position.x);
        if (boundary > 11)
        {
            Destroy(gameObject);
            SpawnMob.mobDestroy();
        }

    }

    public void Damage(int damageCount)
    {
        hp -= damageCount;

        /*
        MonsterMove damage = new MonsterMove();
        damage.damage(damageCount);
        */

        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500f));


        if(hp <= 0)
        {
            Destroy(gameObject);
            SpawnMob.mobDestroy();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet shot = collision.gameObject.GetComponent<Bullet>();
        Sword chop = collision.gameObject.GetComponent<Sword>();

        if(shot != null)
        {
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);
                Destroy(shot.gameObject);
            }
        }
        if(chop != null)
        {
            if (chop.isEnemyAttck != isEnemy)
            {
                Damage(chop.damage);
            }
        }
    }
}
