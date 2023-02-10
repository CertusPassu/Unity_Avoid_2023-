using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject[] roadPrefabs;
    private Transform playerTrasform;
    private float spawnZ = 0f;
    private float roadLength = 5.2f;
    private int numRoadsOnScreen = 8;
    private float safeZone = 15f;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeRoads = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        playerTrasform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < numRoadsOnScreen; i++)
        {
            if (i < 4)
                SpawnRoad(0);
            else
                SpawnRoad();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTrasform.position.z - safeZone > (spawnZ - numRoadsOnScreen * roadLength))
        {
            SpawnRoad();
            DeleteRoad();
        }
    }
    private void SpawnRoad(int prefabIndex = -1) {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(roadPrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(roadPrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += roadLength;
        activeRoads.Add(go);
    
    }
    private void DeleteRoad() {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }
    private int RandomPrefabIndex()
    {
        if (roadPrefabs.Length <= 1)
            return 0;
        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, roadPrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    
    }
}
