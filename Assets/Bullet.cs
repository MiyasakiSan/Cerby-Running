using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour , IPooledObject
{
    public float Speed = 0.01f;
    float StartSpeed;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = new Vector3(0, 0, 0);
            collision.gameObject.GetComponent<CharacterController>().isMove = false;
            GameObject[] AllBullet = GameObject.FindGameObjectsWithTag("Bullet");
            foreach(GameObject bullet in AllBullet)
            {
                bullet.GetComponent<Bullet>().Speed = StartSpeed;
                bullet.SetActive(false);
            }
        }
    }
}
