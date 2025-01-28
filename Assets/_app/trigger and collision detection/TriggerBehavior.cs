using UnityEngine;

public class TriggerBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider otherCollider)
    {
        Debug.Log("[TriggerBehavior] Entered by " + otherCollider.name);
    }

    private void OnTriggerExit(Collider otherCollider)
    {
        Debug.Log("[TriggerBehavior] Exited by " + otherCollider.name);
    }
}