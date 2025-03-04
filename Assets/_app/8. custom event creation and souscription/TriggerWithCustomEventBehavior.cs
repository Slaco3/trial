using UnityEngine;

public class TriggerWithCustomEventBehavior : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent onTriggerEnterEvent;
    public UnityEngine.Events.UnityEvent onTriggerExitEvent;
    
    private void OnTriggerEnter(Collider otherCollider)
    {
        Debug.Log("[TriggerWithCustomEventBehavior] Entered by " + otherCollider.name);
        onTriggerEnterEvent.Invoke();
    }

    private void OnTriggerExit(Collider otherCollider)
    {
        Debug.Log("[TriggerWithCustomEventBehavior] Exited by " + otherCollider.name);
        onTriggerExitEvent.Invoke();
    }
}