using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = -12.0f;
    private float tileLength = 30.0f;
    private float safeZone = 25.0f;
    private int amountTilesOnScreen = 15;
    private int lastPrefabIndex;

    private List<GameObject> activeTiles;

	private void Start ()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if (playerTransform == null)
            Debug.Log("GAME OBJECT PLAYER WAS NOT ASSIGNED");

        for (int i = 0; i < amountTilesOnScreen; i++)
        {
            if (i < 2)
                SpawnTile (0);
            else
                SpawnTile ();


        }
        lastPrefabIndex = 0;
    }

    private void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - amountTilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTitle(); 
        }
    }

    private void SpawnTile (int prefabIndex = -1)
    {
        GameObject go;
        if (prefabIndex == -1)
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;

       go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
       // go.transform.position = Vector3.forward * spawnZ;

        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    private void DeleteTitle()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIDX = lastPrefabIndex;

        while (randomIDX == lastPrefabIndex)
        {
            randomIDX = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIDX;
        return randomIDX;
    }
}
