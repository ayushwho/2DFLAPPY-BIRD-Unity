using UnityEngine;

public class pipemovescript : MonoBehaviour
{
    [Header("Movement Settings")]
    public float movespeed = 5f;
    public float deadzone = -54f;

    [Header("Smoke Effect Settings")]
    public GameObject smokeEffect; // assign your smoke prefab here
    [Range(0f, 1f)]
    public float smokeSpawnChance = 0.3f; // 30% chance to spawn each cycle
    public float smokeInterval = 1.5f; // how often we check to maybe spawn smoke
    public float smokeYOffset = 3f; // how high above the pipe smoke appears

    private float smokeTimer = 0f;

    void Update()
    {
        // Move pipe left
        transform.position += Vector3.left * movespeed * Time.deltaTime;

        // Random smoke generation over time
        smokeTimer += Time.deltaTime;
        if (smokeTimer >= smokeInterval)
        {
            TrySpawnSmoke();
            smokeTimer = 0f;
        }

        // Destroy pipe when off-screen
        if (transform.position.x < deadzone)
        {
            Debug.Log("Pipe Deleted");
            Destroy(gameObject);
        }
    }

    void TrySpawnSmoke()
    {
        // Randomly decide whether to spawn smoke this cycle
        if (smokeEffect != null && Random.value < smokeSpawnChance)
        {
            // Try to find the pipe’s visible top (using Renderer bounds)
            Renderer pipeRenderer = GetComponentInChildren<Renderer>();
            float pipeTopY = transform.position.y + smokeYOffset;

            if (pipeRenderer != null)
                pipeTopY = pipeRenderer.bounds.max.y + 0.5f;

            // Spawn smoke slightly above the top of the pipe
            Vector3 smokePos = new Vector3(transform.position.x, pipeTopY, transform.position.z);
            Instantiate(smokeEffect, smokePos, Quaternion.identity);
        }
    }
}