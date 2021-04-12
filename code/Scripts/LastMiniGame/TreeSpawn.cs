using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> _trees = new List<GameObject>();
    [SerializeField] private List<GameObject> _spawnPoints = new List<GameObject>();
    [SerializeField] private float _object_size;
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true) {
            int index = Random.Range(100, 100 + _trees.Count) % 10;
            GameObject tree = Instantiate(_trees[index], _spawnPoints[Random.Range(0, _spawnPoints.Count)].transform.position, Quaternion.Euler(90, 0 ,0));
            tree.transform.localScale *= _object_size;
            yield return new WaitForSeconds(Random.Range(1, 2));
        }
    }
}
