using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bullet;

    private float direction;

    public Transform shotPrefab;

    private Vector3 position = new Vector3(1.3f, 0.4f, 0f);
    public float Recoil;
    
    public float shootingRate = 0.25f;
    private float shootCooldown;

    private void Awake()
    {
        bullet.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Transform>().localPosition = position;
        shootCooldown = shootingRate;
    }

    // Update is called once per frame
    void Update()
    {
        direction = GetComponent<Transform>().lossyScale.x;
        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack(false);
        }
        direction = Direction.Direc();

        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }

        Recoil = shootCooldown * 100f * direction;
        gameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, Recoil);
        gameObject.GetComponent<Transform>().localPosition = new Vector3(1.66f, shootCooldown);
    }
    public void Attack(bool isEnemy)
    {
        if (CanFire())
        {
            shootCooldown = shootingRate;

            var shotTransform = Instantiate(shotPrefab) as Transform;
            shotTransform.position = bullet.transform.position;
            shotTransform.localScale = shotTransform.localScale * new Vector2(direction,1);

            Bullet shot = shotTransform.gameObject.GetComponent<Bullet>();
            shot.direc = direction;

            if(shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }
        }
    }

    public bool CanFire()
    {
        return shootCooldown <= 0f;
    }
}
