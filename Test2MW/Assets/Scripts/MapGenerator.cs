using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Transform playerTransform;

    public GameObject[] tilePrefabs;

    private List<GameObject> activeTiles;

    private int ammOfTileonScreen = 3;
    private int lastPrefabIndex = 0;

    private float tileLength = 60f;
    private float spawnZ = -30.0f;
    private float safeZone = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();

        SpawnTile(0);

        for (int i = 0; i < ammOfTileonScreen - 1; i++)
        {
            SpawnTile(RandomPrefabIndex());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - ammOfTileonScreen * tileLength))
        {
            SpawnTile(RandomPrefabIndex());
            DeleteTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject newTile;
        newTile = Instantiate(tilePrefabs[prefabIndex]);
        newTile.transform.SetParent(transform);
        newTile.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(newTile);

    }

    private void DeleteTile()
    {
        gameObject.GetComponentInChildren<CoinGenerator>().DestroyCoin();
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
        {
            return 0;
        }
        int randomIndex = lastPrefabIndex;

        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(1, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;

        return randomIndex;
    }
}
