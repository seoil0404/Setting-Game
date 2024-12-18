using System.Collections;
using UnityEngine;

public class Aimlab_TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public int maxTargets = 6;
    public Vector2 spawnAreaMin;
    public Vector2 spawnAreaMax;
    public float spawnInterval = 0.5f; // 타겟 생성 속도 (슬라이더로 조절)
    public float targetSize = 1.0f;    // 타겟 크기 (슬라이더로 조절)
    public float targetFadeDuration = 2.5f;

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
        newTarget.transform.localScale = Vector3.one * targetSize; // 타겟 크기 적용

        Aimlab_Target targetScript = newTarget.GetComponent<Aimlab_Target>();
        if (targetScript != null)
        {
            targetScript.OnTargetDestroyed += () =>
            {
                DestroyTargetManually(newTarget, index);
            };
        }

        targets[index] = newTarget;
        StartCoroutine(FadeAndDestroyTarget(newTarget, index, targetFadeDuration));
    }

    IEnumerator FadeAndDestroyTarget(GameObject target, int index, float fadeDuration)
    {
        if (target == null) yield break;

        SpriteRenderer renderer = target.GetComponent<SpriteRenderer>();
        if (renderer == null) yield break;

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

        DestroyTargetManually(target, index);
    }

    void DestroyTargetManually(GameObject target, int index)
    {
        if (target != null)
        {
            Destroy(target);
            targets[index] = null;

            if (targetCounter != null)
            {
                targetCounter.IncrementTargetCount();
            }
        }
    }

    public void TargetClicked(GameObject target)
    {
        int index = System.Array.IndexOf(targets, target);

        if (index != -1 && targets[index] != null)
        {
            Destroy(target);
            targets[index] = null;

            if (targetCounter != null)
            {
                targetCounter.IncrementTargetCount();
            }
        }
        else
        {
            Debug.LogWarning("Target not found or already destroyed.");
        }
    }

}
