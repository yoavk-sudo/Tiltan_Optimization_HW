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
