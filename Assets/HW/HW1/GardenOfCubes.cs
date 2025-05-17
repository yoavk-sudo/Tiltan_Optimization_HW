using UnityEngine;
using System.Collections.Generic;
using System.Text;

public class GardenOfCubes : MonoBehaviour
{
    public GameObject cubePrefab;

    private List<GameObject> garden = new List<GameObject>();
    private float timer = 0f;
    StringBuilder sb = new StringBuilder();

    void Start()
    {
        for (int i = 0; i < 300; i++)
        {
            GameObject cube = Instantiate(cubePrefab);
            cube.transform.position = new Vector3(i % 20, 0f, i / 20);
            cube.name = "Cube_" + i;
            garden.Add(cube);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        foreach (var cube in garden)
        {
            // Looks harmless, but slow over many objects
            cube.transform.position += Vector3.up * Mathf.Sin(Time.time + cube.transform.position.x) * 0.001f;

            // Repeated string creation and GC alloc (subtle)
            if (cube.name.Contains("42"))
            {
                sb.Clear();
                sb.Append("This cube is special: ");
                sb.Append(cube.name);
                Debug.Log(sb.ToString());
            }

            // Avoidable tag checks
            if (cube.CompareTag("Untagged"))
            {
                cube.GetComponent<Renderer>().material.color = Color.Lerp(Color.white, Color.green, Mathf.PingPong(Time.time, 1));
            }
        }

        if (timer >= 5f)
        {
            Debug.Log("Garden is peaceful... but something is off.");
            timer = 0f;
        }
    }
}

/*
1. Which part of the script is allocating GC memory? 
The string creation in the line `Debug.Log("This cube is special: " + cube.name);` is allocating GC memory.
2. What function in the Profiler appears to spike during Update()? 
4. How did you reduce or eliminate GC allocations? 
I replaced the string concatenation with a StringBuilder
5. What was the GC Alloc delta before and after the change? 
before - 9.3% after - 0.9%
6. Did the rendering or visual behavior break after changes? 

*/