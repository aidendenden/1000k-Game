using UnityEngine;

public class SpawnNiuKou : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // Ԥ��������

    void Start()
    {
        // ��Ԥ�������������ѡ��һ��Ԥ����
        int randomIndex = Random.Range(0, prefabsToSpawn.Length);
        GameObject selectedPrefab = prefabsToSpawn[randomIndex];

        // ʵ����ѡ���Ԥ������Ϊ�Լ���������
        GameObject spawnedObject = Instantiate(selectedPrefab, new Vector3 (2,6,0), Quaternion.identity, transform);

    }
}