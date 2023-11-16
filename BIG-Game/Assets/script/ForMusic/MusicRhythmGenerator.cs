using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRhythmGenerator : MonoBehaviour
{
    public GameObject objectToSpawn; // Ҫ���ɵ���Ϸ����
    public AudioSource audioSource; // ����Դ
    public float sensitivity = 2.0f; // ���жȣ����ڵ������ļ���������
    public float spawnDelay = 0.1f; // ����������ӳ�ʱ��
    public float spawnInterval = 0.5f; // ��������ļ��ʱ��
    public float threshold = 0.01f; // Ƶ��������ֵ�������ж��Ƿ�Ϊ����

    private float[] _spectrumData = new float[8192];
    private float _lastSpawnTime = -1.0f;
    private float _beatTimer = 0f;
    private MusicPoint musicPoint;


    void Start()
    {

        musicPoint = GameObject.FindGameObjectWithTag("PManager").GetComponent<MusicPoint>();
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void Update()
    {
        // ��ȡƵ������
        audioSource.GetSpectrumData(_spectrumData, 0, FFTWindow.BlackmanHarris);

        // ����Ƶ��������������
        float maxSpectrumValue = 0f;
        int maxSpectrumIndex = 0;
        for (int i = 0; i < _spectrumData.Length; i++)
        {
            if (_spectrumData[i] > maxSpectrumValue && _spectrumData[i] > threshold)
            {
                maxSpectrumValue = _spectrumData[i];
                maxSpectrumIndex = i;
            }
        }

        // �����⵽����
        if (maxSpectrumValue > sensitivity)
        {
            _beatTimer += Time.deltaTime;
            if (_beatTimer > spawnInterval-(musicPoint.point/80))
            {
                // ��������
                StartCoroutine(SpawnObjectWithDelay(spawnDelay));
                _beatTimer = 0f;
            }
        }
    }

    private IEnumerator SpawnObjectWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }
}
