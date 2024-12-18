using System.Collections;
using UnityEngine;

public class Aimlab_TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public int maxTargets = 6;
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;
    public float spawnInterval = 0.5f;

    public Aimlab_TargetCounter targetCounter; 

    private GameObject[] targets;

    void Start()
    {
        targets = new GameObject[maxTargets];
        StartCoroutine(SpawnTargetsContinuously());
    }

    IEnumerator SpawnTargetsContinuously()
    {
        while (true)
        {
            for (int i = 0; i < maxTargets; i++)
            {
                if (targets[i] == null)
                {
                    SpawnNewTarget(i);
                    yield return new WaitForSeconds(spawnInterval);
                }
            }
            yield return null;
        }
    }

    void SpawnNewTarget(int index)
    {
        Vector2 randomPosition = new Vector2(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );

        GameObject newTarget = Instantiate(targetPrefab, randomPosition, Quaternion.identity);
        targets[index] = newTarget;

        
        StartCoroutine(FadeAndDestroyTarget(newTarget, index));
    }

    IEnumerator FadeAndDestroyTarget(GameObject target, int index)
    {
        if (target == null) yield break;

        SpriteRenderer renderer = target.GetComponent<SpriteRenderer>();
        if (renderer == null) yield break;

        float fadeDuration = 2.5f;
        float elapsedTime = 0f;

        Color initialColor = renderer.color;

        while (elapsedTime < fadeDuration)
        {
            if (target == null) yield break;
            elapsedTime += Time.deltaTime;

            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            renderer.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha);
            yield return null;
        }

        
        if (target != null)
        {
            Destroy(target);
            targets[index] = null;
        }
    }

    public void TargetClicked(GameObject target)
    {
        Debug.Log($"TargetClicked called for {target.name}");

        int index = System.Array.IndexOf(targets, target);

        if (index != -1 && targets[index] != null)
        {
            Debug.Log($"Target found at index {index}, destroying...");
            DestroyTargetManually(target, index);
        }
        else
        {
            Debug.LogWarning($"Target not found in the array or already destroyed: {target.name}");
        }
    }



    void DestroyTargetManually(GameObject target, int index)
    {
        if (target != null)
        {
            Debug.Log($"Destroying target at index {index}");

            Destroy(target);
            targets[index] = null;

            if (targetCounter != null)
            {
                Debug.Log("Incrementing target counter...");
                targetCounter.IncrementTargetCount(); // 타겟 카운터 증가
            }
            else
            {
                Debug.LogWarning("TargetCounter is not assigned!");
            }
        }
        else
        {
            Debug.LogWarning("Target is null, cannot destroy.");
        }
    }


}
