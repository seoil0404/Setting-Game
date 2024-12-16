using UnityEngine;

public class Aimlab_TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab; // Ÿ�� ������
    public int targetCount = 4; // ȭ�鿡 ǥ�õ� Ÿ�� ����
    public Vector2 spawnAreaMin; // ���� ������ �ּҰ� (���� �Ʒ�)
    public Vector2 spawnAreaMax; // ���� ������ �ִ밪 (������ ��)

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
            Destroy(target); // ���� Ÿ�� ����
            SpawnNewTarget(index); // ���ο� Ÿ�� ����
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
