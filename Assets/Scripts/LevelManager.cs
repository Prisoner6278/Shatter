using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] ShaftPrefabs;
    public float zSpawn = 0;
    public float shaftLength = 30;
    public int numberOfShaft = 5;
    public Transform playerTransform;
    private List<GameObject> activeShafts = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < numberOfShaft; i++)
        {
            if(i == 0)
            {
                SpawnShaft(0);
            }
            else
            {
               SpawnShaft(Random.Range(0, ShaftPrefabs.Length));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - 35 > zSpawn - (numberOfShaft * shaftLength))
        {
            SpawnShaft(Random.Range(0, ShaftPrefabs.Length));
            DeleteShaft();
        }
    }

    public void SpawnShaft(int shaftIndex)
    {
        GameObject go = Instantiate(ShaftPrefabs[shaftIndex], transform.forward * zSpawn, transform.rotation);
        activeShafts.Add(go);
        zSpawn += shaftLength;
    }

    private void DeleteShaft()
    {
        Destroy(activeShafts[0]);
        activeShafts.RemoveAt(0);
    }
}
