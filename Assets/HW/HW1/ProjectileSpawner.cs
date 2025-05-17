using UnityEngine;
using System.Collections.Generic;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectilePrefab;
    private List<GameObject> pool = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject go = Instantiate(projectilePrefab);
            go.SetActive(false);
            pool.Add(go);
        }
    }

    void Update()
    {
        GameObject proj = pool.Find(p => !p.activeInHierarchy);
        if (proj != null)
        {
            proj.transform.position = transform.position;
            proj.SetActive(true);
        }
        else
        {
            GameObject newProj = Instantiate(projectilePrefab);
            newProj.transform.position = transform.position;
            newProj.SetActive(true);
            pool.Add(newProj); 
        }
    }
}

/*
1. What’s wrong with how the pool is growing? 
The pool is growing indefinitely, which can lead to memory issues and performance degradation. 
Instead, we could have a fixed-size pool and recycle objects, or limit the size of the pool.
2. What does List.Find() do internally, and why is it slow when the list is large? 
(according to google) List.Find() iterates through the list to find the first inactive object, which is an O(n) operation. 
This can be slow for large lists as it requires checking each element until it finds a match.
3. Which frame profiler category is affected by Instantiate() and GC pressure?

 */