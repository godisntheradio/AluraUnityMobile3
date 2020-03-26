using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject PoolObject;
    [SerializeField]
    private int PoolSize;

    Stack<GameObject> Pool;

    private void Awake()
    {
        Pool = new Stack<GameObject>();
    }
    private void Start()
    {
        InstantiatePool();
    }
    private void InstantiatePool()
    {
        for (int i = 0; i < PoolSize; i++)
        {
            InstantiatePoolObject();            
         
        }
    }

    /// <summary>
    /// Gets object from pool. Instantiates a new object if necessary.
    /// </summary>
    /// <returns></returns>
    public GameObject GetObjectFromPool()
    {
        if (Pool.Count == 0)
            InstantiatePoolObject();

        GameObject pop = Pool.Pop();
        pop.GetComponent<IPoolable>().OnGetFromPool();
        return pop;
    }

    /// <summary>
    /// Deactivates and returns object to pool
    /// </summary>
    /// <param name="gameObj"></param>
    public void ReturnObject(GameObject gameObj)
    {
        gameObj.SetActive(false);
        gameObj.GetComponent<IPoolable>().OnReturnToPool();
        Pool.Push(gameObj);
    }

    /// <summary>
    /// Instantiates prefab, deactivates it and adds it to the pool
    /// </summary>
    /// <returns></returns>
    private GameObject InstantiatePoolObject()
    {
        GameObject gameObj = Instantiate(PoolObject, transform);
        Pool.Push(gameObj);
        Poolable poolable = gameObj.GetComponent<Poolable>();
        if (poolable == null)
            poolable = gameObj.AddComponent<Poolable>();
        poolable.Pool = this;
        gameObj.SetActive(false);
        return gameObj;
    }
    private void OnValidate()
    {
        var reservavel = this.PoolObject.GetComponent<IPoolable>();
        if (reservavel == null)
        {
            this.PoolObject = null;
            throw new System.Exception("Atributo [PoolObject] requer um objeto que contenha a implementação da interface [IPoolable]");
        }
    }
}
