using UnityEngine;

public class RagdollTrigger : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        // if there is a ragdoll, turn it on
        Ragdoll ragdoll = other.gameObject.GetComponentInParent<Ragdoll>();
        if (ragdoll != null)
            ragdoll.RagdollOn = true;
    }
}
