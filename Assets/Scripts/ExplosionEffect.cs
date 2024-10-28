using UnityEngine;
using System.Collections;

public class ExplosionEffect : MonoBehaviour
{
    public GameObject explosionPrefab; // Assign the explosion prefab in the inspector
    public float explosionDelay = 4f; // Delay before explosion
    public Vector3 newDronePosition; // Set this to the new location for the drone
    public float respawnDelay = 2f; // Delay before the drone respawns

    private void Start()
    {
        StartCoroutine(TriggerExplosion());
    }

    private IEnumerator TriggerExplosion()
    {
        yield return new WaitForSeconds(explosionDelay); // Wait for explosion delay

        // Get the position of the drone
        Vector3 dronePosition = transform.position;

        // Instantiate the explosion at the drone's position
        Instantiate(explosionPrefab, dronePosition, Quaternion.identity);

        // Remove the drone from the scene
        gameObject.SetActive(false); // Deactivate the drone

        // Wait for respawn delay
        yield return new WaitForSeconds(respawnDelay);

        // Respawn the drone at the new location
        transform.position = newDronePosition; // Set the new position
        gameObject.SetActive(true); // Reactivate the drone
    }
}
