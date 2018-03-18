using UnityEngine;

public class KillZone : MonoBehaviour {

    public Transform respawnPosition;
    public float spawnDelay;
    
    // called by Unity when when an object enters the collision field
    //  other - data structure containing details of the entered object
    private void OnTriggerEnter(Collider other) {
        // if the player enters the field, moves them to the repawn point
        if (other.tag == "Player") {
            other.transform.position = respawnPosition.transform.position;
        }
    }
}
