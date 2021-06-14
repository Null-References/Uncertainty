using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolBase<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T prefab;

    public static PoolBase<T> Instance { get; private set; }

    private Queue<T> _objects = new Queue<T>();

    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this);
            return;
        }

        Instance = this;
        //DontDestroyOnLoad(this.gameObject);
    } 

    
    public void ReturnToPool(T returnObject)
    {
        returnObject.gameObject.SetActive(false);   
        _objects.Enqueue(returnObject);
    }

    public T Get()
    {
        if (_objects.Count<1)
        {
            AddToPool(1);
        }

        return _objects.Dequeue();
    }

    private void AddToPool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var newObject = Instantiate(prefab);
            newObject.gameObject.SetActive(false);
            _objects.Enqueue(newObject);
        }
    }
    
}
