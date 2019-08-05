using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    static private int cloud = 5;
    bool direc;
    public float direction = 1f;
    public Transform cloudPrefab1;
    public Transform cloudPrefab2;
    public float cloudSpeed;
    public float hight;

    public bool isCloud = true;

    void Update()
    {
        if (cloud > 0 && (Time.fixedTime % 3 == 0)) {
            direc = (Random.value > 0.5f);
            cloudSpeed = Random.Range(100f, 200f);
            hight = Random.Range(3f, 4.4f);

            if (direc)
            {
                direction *= -1;
            }

            if (direc)
            {
                SpawnCloud(cloudPrefab1);
            }
            else
            {
                SpawnCloud(cloudPrefab2);
            }
        }
        
    }
    static public void cloudDestroy()
    {
        cloud += 1;
    }

    void SpawnCloud(Transform cloudPrefab)
    {
        var cloudTransform = Instantiate(cloudPrefab) as Transform;
        cloudTransform.position = new Vector3(direction * -11, hight, 0);
        cloudTransform.localScale = new Vector3(direction * cloudTransform.localScale.x, 1, 1);
        cloudTransform.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction * cloudSpeed, 0));
        cloud -= 1;
    }
}
