using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject container;

    [FormerlySerializedAs("prefab")] [SerializeField]
    private GameObject prefabToSpawn;

    [SerializeField] private Vector3 instantiatedRotation;

    private async void Awake()
    {
        await SpawnAfterDelay(2);
        await SpawnAfterDelay(2);
        await SpawnAfterDelay(2);
    }

    private async Task SpawnAfterDelay(int delayInSeconds = 0)
    {
        await Task.Delay(TimeSpan.FromSeconds(delayInSeconds));
        var instantiatedGameObject = Instantiate(prefabToSpawn, container.transform);
        instantiatedGameObject.transform.rotation = Quaternion.Euler(instantiatedRotation);
    }
}