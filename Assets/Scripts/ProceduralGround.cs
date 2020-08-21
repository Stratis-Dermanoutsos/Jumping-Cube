using System.Collections.Generic;
using UnityEngine;

public class ProceduralGround : MonoBehaviour
{
    // General Variables
    private List<GameObject> spawnedFloorPieces; // List containing every spawned <floorPiece>
    private int consecutiveGaps = 0; // Only allow 1 gap at a time
    private float zPositionToSpawnNext; // Position in the z axis to spawn the next <floorPiece

    [SerializeField] private Transform player;

    [SerializeField] private GameObject startingFloor; // The first spawned <floorPiece>

    [SerializeField] private GameObject[] floorPieces; // Array of objects available to spawn

    void Start()
    {
        // Initialize the floor list
        spawnedFloorPieces = new List<GameObject>();
        spawnedFloorPieces.Insert(0, startingFloor);
        zPositionToSpawnNext = 125F;
    }

    void LateUpdate()
    {
        if (player == null) return; // Stop if the <player> is dead

        // Always keep 5 <floorPieces> spawned
        if (spawnedFloorPieces.Count < 6) SpawnFloorPiece();

        // Remove pieces left behind by the player
        if (spawnedFloorPieces.Count == 6)
            if (player.transform.position.z >= spawnedFloorPieces[3].transform.position.z)
                DespawnFloorPiece();
    }

    void SpawnFloorPiece() 
    {
        // If <consecutiveGaps> is 1, we MUST spawn <floorPiece>
        int selectedPiece = (consecutiveGaps == 0) ? Random.Range(0, 5) : Random.Range(0, 4);

        GameObject lastPiece; // The last piece to be spawned

        // 4/5 is a new <floorPiece>, 1/5 is a gap for the player to jump
        if (selectedPiece <= 3) { // If <floorPiece>, ...
            // Spawn the <lastPiece>
            lastPiece = Instantiate(
                floorPieces[selectedPiece],
                new Vector3(0, 0, zPositionToSpawnNext),
                Quaternion.identity
            );

            spawnedFloorPieces.Insert(0, lastPiece); // Add the <lastPiece> of the floor to our list

            consecutiveGaps = 0; // Reset the <consecutiveGaps>
        } else { // If not <floorPiece>, ...
            consecutiveGaps = 1; // Set the <consecutiveGaps> to 1 to avoid a 2nd one
        }

        // If gap, spawn the next <floorPiece> closer
        zPositionToSpawnNext += (selectedPiece != 4) ? 40F : 17.5F;
    }

    // Destroy the last <floorPiece> to save memory
    void DespawnFloorPiece()
    {
        Destroy(spawnedFloorPieces[spawnedFloorPieces.Count - 1]); // Destroy it from ingame
        spawnedFloorPieces.RemoveAt(spawnedFloorPieces.Count - 1); // Remove it from the list

        Debug.Log(spawnedFloorPieces.Count);
    }
}
