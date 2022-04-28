using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour , IPooledObject
{
    public float Speed = 0.01f;
    public float StartSpeed;
    public void OnObjectSpawn()
    {
        Speed += 0.1f;
    }
    void Start()
    {
        StartSpeed = Speed;
    }
    // Update is called once per frame
    void Update()
    {
        if (name == "BulletTop(Clone)")
        {
            this.transform.position += new Vector3(0, -Speed, 0);
        }
        else if (name == "BulletBottom(Clone)")
        {
            this.transform.position += new Vector3(0, Speed, 0);
        }
        else if (name == "BulletLeft(Clone)")
        {
            this.transform.position += new Vector3(Speed, 0, 0);
        }
        else if (name == "BulletRight(Clone)")
        {
            this.transform.position += new Vector3(-Speed, 0, 0);
        }
    }
}
