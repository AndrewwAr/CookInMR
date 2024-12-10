using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Object to spawn
    [SerializeField] private GameObject objectToSpawn;

    // Method to get available spawn locations
    private List<Vector3> GetAvailableSpawnLocations()
    {
        List<Vector3> availableLocations = new List<Vector3>();

        // Find all game objects with the tag "PossibleSpawnLocation"
        GameObject[] spawnLocations = GameObject.FindGameObjectsWithTag("PossibleSpawnLocation");

        // Loop through each found game object and add its position to the list
        foreach (GameObject location in spawnLocations)
        {
            availableLocations.Add(location.transform.position);
        }

        return availableLocations;
    }

    // Method to spawn an object at a random available location
    public void SpawnObject()
    {
        // Get the list of spawn locations
        List<Vector3> spawnLocations = GetAvailableSpawnLocations();

        // Ensure there are available locations
        if (spawnLocations.Count == 0)
        {
            Debug.LogWarning("No available spawn locations found!");
            return;
        }

        // Select a random location
        int randomIndex = Random.Range(0, spawnLocations.Count);
        Vector3 spawnPosition = spawnLocations[randomIndex];

        // Spawn the object at the chosen location
        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
    }

    // Example usage: Spawn an object when the game starts
    private void Start()
    {
        if (objectToSpawn != null)
        {
            SpawnObject();
        }
        else
        {
            Debug.LogError("Object to spawn is not assigned in the SpawnManager!");
        }
    }
}