using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


[System.Serializable]
public struct QuestionInfo
{
    public string text;
    public bool answer;
}

public class ZombieSpawnner : MonoBehaviour
{
    public GameObject[] zombie;
    public GameObject[] Question;
    public Transform spawnPoint;
    float minX = -3f;
    float maxX = 3f;
    [SerializeField] protected float SpawncoolTime = 0.5f;
    private float SpawncurTime;
    public int SpawnCount;
    public bool isQuestion;

    public List<QuestionInfo> questionInfos = new List<QuestionInfo>();
    private void Start()
    {
        foreach (var item in CSVReader.Read("Test")) // CSV의 라인 딕셔너리의 개수 만큼 
        {
            QuestionInfo info = new QuestionInfo();
            foreach (var value in item.Values)
            {
                if (!int.TryParse(value.ToString(), out int result)) info.text = value.ToString();
                else info.answer = result == 0 ? false : true;
            }
            questionInfos.Add(info);
        }
    }

    void Update()
    {
        if (!isQuestion)
            Spawn();
    }


    void Spawn()
    {

        if (SpawnCount >= 10)
        {
            int QuestionPrefabs = Random.Range(0, Question.Length);
            SpawnCount = 0;
            isQuestion = true;
            Instantiate(Question[QuestionPrefabs], transform.position + new Vector3(0, 2, 0), Quaternion.identity);
            Invoke("QuestionTime", 7f);
        }
        if (SpawncurTime <= 0)
        {
            int zombiePrefab = Random.Range(0, zombie.Length);
            Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), spawnPoint.transform.position.y, spawnPoint.transform.position.z);
            Instantiate(zombie[zombiePrefab], spawnPos, Quaternion.identity);
            SpawncurTime = SpawncoolTime;
            SpawnCount++;
        }
        else
        {
            SpawncurTime -= Time.deltaTime;
        }

    }
    void QuestionTime()
    {
        isQuestion = false;

    }
}
