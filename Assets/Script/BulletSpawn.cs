using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    ObjectPooler objectPooler;
    int PoolSize;
    public GameObject StartButton;
    public GameObject WelcomeText;
    ScoreCollector scoreCollector;
    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
        PoolSize = objectPooler.pools[0].size;
        scoreCollector = GameObject.Find("ScoreManager").GetComponent<ScoreCollector>();
    }
    public void StartGame()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().isMove = true;
        scoreCollector.Score = 0;
        SpawnTop(PoolSize);
        SpawnBottom(PoolSize);
        SpawnLeft(PoolSize);
        SpawnRight(PoolSize);
        StartButton.SetActive(false);
        WelcomeText.SetActive(false);
    }
    void SpawnRight(int size)
    {
        for (int i = 0; i <= size; i++)
        {
            objectPooler.SpawnFromPool("BulletRight", new Vector3(12 + i, i % 4, 0), Quaternion.identity);
        }
    }
    void SpawnLeft(int size)
    {
        for (int i = 0; i <= size; i++)
        {
            objectPooler.SpawnFromPool("BulletLeft", new Vector3(-12 - i, i % 4, 0), Quaternion.identity);
        }
    }
    void SpawnBottom(int size)
    {
        for (int i = 0; i <= size; i++)
        {
            objectPooler.SpawnFromPool("BulletBottom", new Vector3(-i % 8, -9 - i, 0), Quaternion.identity);
        }
    }
    void SpawnTop(int size)
    {
        for (int i = 0; i <= size; i++)
        {
            objectPooler.SpawnFromPool("BulletTop", new Vector3(i % 8, 9 + i, 0), Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int x = Random.Range(-9, 9);
        int y = Random.Range(-5, 5);

        if (collision.gameObject.name == "BulletTop(Clone)")
        {
            collision.transform.position = new Vector3(x, 7, 0);
            scoreCollector.updateScore(1);
            collision.gameObject.GetComponent<Bullet>().Speed += 0.001f;
        }
        else if (collision.gameObject.name == "BulletBottom(Clone)")
        {
            collision.transform.position = new Vector3(x, -7, 0);
            scoreCollector.updateScore(1);
            collision.gameObject.GetComponent<Bullet>().Speed += 0.001f;
        }
        else if (collision.gameObject.name == "BulletLeft(Clone)")
        {
            collision.transform.position = new Vector3(-11, y, 0);
            scoreCollector.updateScore(1);
            collision.gameObject.GetComponent<Bullet>().Speed += 0.001f;
        }
        else if (collision.gameObject.name == "BulletRight(Clone)")
        {
            collision.transform.position = new Vector3(11, y, 0);
            scoreCollector.updateScore(1);
            collision.gameObject.GetComponent<Bullet>().Speed += 0.001f;
        }
    }
}
