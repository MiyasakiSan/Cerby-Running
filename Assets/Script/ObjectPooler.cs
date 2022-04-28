using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton
    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion 
    public GameObject StartButton;
    public List<Pool> pools;
    public Dictionary<string,Queue<GameObject>> poolDictionary;
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0;i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.GetComponent<Bullet>().StartButton = StartButton;
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't excist");
            return null;
        }

        GameObject objecToSpwan = poolDictionary[tag].Dequeue();

        objecToSpwan.SetActive(true);
        objecToSpwan.transform.position = position;
        objecToSpwan.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objecToSpwan);

        return objecToSpwan;
    }
}
