using UnityEngine;
using System.Collections.Generic;

public class GardenOfCubes : MonoBehaviour
{
    public GameObject cubePrefab;

    private List<GameObject> garden = new List<GameObject>();
    private float timer = 0f;

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
                Debug.Log("This cube is special: " + cube.name);
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
