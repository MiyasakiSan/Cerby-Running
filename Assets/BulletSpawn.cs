using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    int count = 0;
    ObjectPooler objectPooler;
    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int x1 = Random.Range(-36, 36);
        int y1 = Random.Range(-20, 20);
        float x = x1 * 0.25f;
        float y = y1 * 0.25f;

        if (collision.gameObject.name == "BulletTop(Clone)")
        {
            objectPooler.SpawnFromPool("BulletTop", new Vector3(x, 6, 0), Quaternion.identity);
        }
        else if (collision.gameObject.name == "BulletBottom(Clone)")
        {
            objectPooler.SpawnFromPool("BulletBottom", new Vector3(x, -6, 0), Quaternion.identity);
        }
        else if (collision.gameObject.name == "BulletLeft(Clone)")
        {
            objectPooler.SpawnFromPool("BulletLeft", new Vector3(-10, y, 0), Quaternion.identity);
        }
        else if (collision.gameObject.name == "BulletRight(Clone)")
        {
            objectPooler.SpawnFromPool("BulletRight", new Vector3(10, y, 0), Quaternion.identity);
        }
    }
}
