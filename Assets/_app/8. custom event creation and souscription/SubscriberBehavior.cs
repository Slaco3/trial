using UnityEngine;

public class SubscriberBehavior : MonoBehaviour
{
    [SerializeField] private TriggerWithCustomEventBehavior triggerWithCustomEventBehavior;
    
    private void OnEnable()
    {
        if (triggerWithCustomEventBehavior != null)
        {
            triggerWithCustomEventBehavior.onTriggerEnterEvent.AddListener(OnTriggerEnterEventByScript);
            triggerWithCustomEventBehavior.onTriggerExitEvent.AddListener(OnTriggerExitEventByScript);
        }
    }
    
    private void OnDisable()
    {
        if (triggerWithCustomEventBehavior != null)
        {
            triggerWithCustomEventBehavior.onTriggerEnterEvent.RemoveListener(OnTriggerEnterEventByScript);
            triggerWithCustomEventBehavior.onTriggerExitEvent.RemoveListener(OnTriggerExitEventByScript);
        }
    }
    
    private void OnTriggerEnterEventByScript()
    {
        Debug.Log("[SubscriberBehavior] Trigger Enter Event by script");
    }
    
    private void OnTriggerExitEventByScript()
    {
        Debug.Log("[SubscriberBehavior] Trigger Exit Event by script");
    }
    
    public void OnTriggerEnterEventByInspector()
    {
        Debug.Log("[SubscriberBehavior] Trigger Enter Event by inspector");
    }
    
    public void OnTriggerExitEventByInspector()
    {
        Debug.Log("[SubscriberBehavior] Trigger Exit Event by inspector");
    }
}