using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMob : MonoBehaviour
{
    static public int Mob = 5;
    bool direc;
    public float direction = 1f;
    public Transform MobPrefab;
    public float hight = -1.64f;

    public bool isCloud = true;

    void Update()
    {
        if (Mob > 0 && (Time.fixedTime % 2 == 0))
        {
            direc = (Random.value > 0.5f);

            if (direc)
            {
                direction *= -1;
            }

            if (direc)
            {
                MobSpawn(MobPrefab);
            }
        }
    }
    static public void mobDestroy()
    {
        Mob += 1;
    }

    void MobSpawn(Transform MobPrefab)
    {
        var mobTransform = Instantiate(MobPrefab) as Transform;
        mobTransform.position = new Vector3(direction * -10, hight, 0);
        mobTransform.localScale = new Vector3(direction * -mobTransform.localScale.x, 1, 1);
        mobTransform.gameObject.GetComponent<MonsterMove>().direction = this.direction;
        Mob -= 1;
    }
}
