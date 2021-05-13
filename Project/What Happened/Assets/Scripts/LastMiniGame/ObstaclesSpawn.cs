using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstaclesSpawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] private Transform spawn_point;
    [SerializeField] private float min_pause;
    [SerializeField] private float max_pause;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (SceneManager.GetActiveScene().name == "LastMiniGame")
        {
            int index = Random.Range(100, 100 + obstacles.Count)%10;
            Quaternion rotation = obstacles[index].transform.rotation;
            GameObject obstacle = Instantiate(obstacles[index], spawn_point.position, rotation);
            yield return new WaitForSeconds(Random.Range(min_pause, max_pause));
        }
    }
}
