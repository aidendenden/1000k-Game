using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRhythmGenerator : MonoBehaviour
{
    public GameObject objectToSpawn; // 要生成的游戏物体
    public AudioSource audioSource; // 音乐源
    public float sensitivity = 2.0f; // 敏感度，用于调整节拍检测的灵敏度
    public float spawnDelay = 0.1f; // 生成物体的延迟时间
    public float spawnInterval = 0.5f; // 生成物体的间隔时间
    public float threshold = 0.01f; // 频谱数据阈值，用于判断是否为节拍

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
        // 获取频谱数据
        audioSource.GetSpectrumData(_spectrumData, 0, FFTWindow.BlackmanHarris);

        // 分析频谱数据来检测节拍
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

        // 如果检测到节拍
        if (maxSpectrumValue > sensitivity)
        {
            _beatTimer += Time.deltaTime;
            if (_beatTimer > spawnInterval-(musicPoint.point/80))
            {
                // 生成物体
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
