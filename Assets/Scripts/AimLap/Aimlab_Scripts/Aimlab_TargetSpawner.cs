using UnityEngine;

public class Aimlab_TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab; // 타겟 프리팹
    public int targetCount = 4; // 화면에 표시될 타겟 개수
    public Vector2 spawnAreaMin; // 스폰 영역의 최소값 (왼쪽 아래)
    public Vector2 spawnAreaMax; // 스폰 영역의 최대값 (오른쪽 위)

    private GameObject[] targets;

    void Start()
    {
        targets = new GameObject[targetCount];
        SpawnInitialTargets();
    }

    void SpawnInitialTargets()
    {
        for (int i = 0; i < targetCount; i++)
        {
            SpawnNewTarget(i);
        }
    }

    public void TargetClicked(GameObject target)
    {
        int index = System.Array.IndexOf(targets, target);
        if (index != -1)
        {
            Destroy(target); // 기존 타겟 제거
            SpawnNewTarget(index); // 새로운 타겟 생성
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

      
    }
}
