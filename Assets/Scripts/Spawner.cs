using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    [SerializeField] float spawnRate = 1.0f;
    [SerializeField] float minHeight = -1.0f;
    [SerializeField] float maxHeight = 1.0f;

    private int prefabIndex;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn)); 
    }

    private void Spawn()
    {
        prefabIndex = Random.Range(0, prefabs.Length);

        GameObject pipes = Instantiate(prefabs[prefabIndex], transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);        
    }
}
