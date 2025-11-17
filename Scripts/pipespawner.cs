using UnityEngine;

public class pipespawner : MonoBehaviour
{
    [Header("Pipe Settings")]
    public GameObject pipe;
    public float Spawnrate = 2f;
    private float timer = 0f;
    public float heightoffset = 10f;

    [Header("Smoke Effect Settings")]
    public GameObject smokeEffect; // assign your smoke prefab here in the Inspector
    [Range(0f, 1f)]
    public float smokeSpawnChance = 0.5f; // 0.5 = 50% chance for smoke to appear
    public float smokeYOffset = 3f; // how far above the pipe the smoke appears

    void Start()
    {
        spawnpipe();
    }

    void Update()
    {
        if (timer < Spawnrate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnpipe();
            timer = 0f;
        }
    }

    void spawnpipe()
    {
        float lowestpoint = transform.position.y - heightoffset;
        float highestpoint = transform.position.y + heightoffset;

        // Spawn pipe
        Vector3 pipePos = new Vector3(transform.position.x, Random.Range(lowestpoint, highestpoint), 0);
        GameObject newPipe = Instantiate(pipe, pipePos, transform.rotation);

        // Randomly spawn smoke on top
        // Randomly spawn smoke on top
        if (smokeEffect != null && Random.value < smokeSpawnChance)
        {
    // Get the pipe’s Renderer height
            Renderer pipeRenderer = newPipe.GetComponentInChildren<Renderer>();
            float pipeTopY = 0f;

            if (pipeRenderer != null)
            {
               pipeTopY = pipeRenderer.bounds.max.y; // topmost Y point of pipe
            }
            else
            {
               pipeTopY = newPipe.transform.position.y + smokeYOffset; // fallback
         }

    // Create smoke and make it a child of the pipe
            GameObject smoke = Instantiate(smokeEffect, new Vector3(newPipe.transform.position.x, pipeTopY, 0), Quaternion.identity, newPipe.transform);

    // Optional: match pipe rotation if needed
            smoke.transform.rotation = newPipe.transform.rotation;
        }
    }
}