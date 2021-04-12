using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecordSpawn : MonoBehaviour
{
    [Header("Lists")]
    [SerializeField] private List<GameObject> _grass = new List<GameObject>();
    [SerializeField] private List<GameObject> streetLights = new List<GameObject>();
    [SerializeField] private List<GameObject> _sunflowers = new List<GameObject>();

    [Header("Spawn")]
    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    [Header("Grass spawn pause")]
    [SerializeField] private float _maxGrassSpawnPause;
    [SerializeField] private float _minGrassSpawnPause;

    [Header("Streetlights spawn pause")]
    [SerializeField] private float _maxStreetLightSpawnPause;
    [SerializeField] private float _minStreetLightSpawnPause;

    [Header("Sunflower spawn pause")]
    [SerializeField] private float _maxSunflowerSpawnPause;
    [SerializeField] private float _minSunflowerSpawnPause;
    private void Start()
    {
        StartCoroutine(GrassSpawn());
        StartCoroutine(StreetLightSpawn());
        StartCoroutine(SunflowersSpawn());
    }

    private IEnumerator GrassSpawn()
    {
        while (true)
        {
            Spawn(_grass, 0);
            yield return new WaitForSeconds(Random.Range(_minGrassSpawnPause, _maxGrassSpawnPause));
        }
    }

    private IEnumerator StreetLightSpawn()
    {
        while (true)
        {
            Spawn(streetLights, 1);
            yield return new WaitForSeconds(Random.Range(_minStreetLightSpawnPause, _maxStreetLightSpawnPause));
        }
    }
    private IEnumerator SunflowersSpawn()
    {
        while (true)
        {
            Spawn(_sunflowers, 0);
            yield return new WaitForSeconds(Random.Range(_minSunflowerSpawnPause, _maxSunflowerSpawnPause));
        }
    }

    private void Spawn(List<GameObject> list, int spawnPointIndex)
    {
        int index = Random.Range(0, list.Count); 
        Transform spawnPoint = _spawnPoints[spawnPointIndex];
        GameObject currentSunflower = Instantiate(list[index], spawnPoint.position, list[index].transform.rotation);
    }
}
