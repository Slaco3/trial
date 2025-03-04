using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerListenerBehavior : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private float forceSpawn;
    [SerializeField] private InputActionReference spawnAction;

    private void OnEnable()
    {
        if (spawnAction != null)
        {
            spawnAction.action.performed += OnSpawnPerformed;
        }
    }
    
    private void OnDisable()
    {
        if (spawnAction != null)
        {
            spawnAction.action.performed -= OnSpawnPerformed;
        }
    }

    private void OnSpawnPerformed(InputAction.CallbackContext context)
    {
        Spawn();
    }

    public void Spawn()
    {
        var spawnedObject = Instantiate(prefabToSpawn, container.transform);
        spawnedObject.GetComponent<Rigidbody>().AddForce(transform.forward * forceSpawn);
        Destroy(spawnedObject, 5);
    }
}