using UnityEngine;

public class CollisionBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("[CollisionBehavior] Entered by " + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("[CollisionBehavior] Exited by " + collision.gameObject.name);
    }
}
