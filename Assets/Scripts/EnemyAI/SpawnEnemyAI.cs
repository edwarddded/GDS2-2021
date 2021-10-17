using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyAI : MonoBehaviour
{
    public GameObject Enemy1, Enemy2, Enemy3, Enemy4;
    public GameObject SpawnEffects;

    [Header("EnemySpawnRange")]
    public int xPosMin;
    public int xPosMax;
    public int zPosMin;
    public int zPosMax;

    private int xPos;
    private int zPos;
    public int enemyCount;
    [SerializeField]
    private int numberofEnemyInWave =3;
    public bool isSpawnEnemy = false;


    void Start()
    {
        
    }

    private void Update()
    {
        bool Night = GameObject.Find("DayNightCycle").GetComponent<DayNightCycle>().IsNight;
        bool Morning = GameObject.Find("DayNightCycle").GetComponent<DayNightCycle>().IsMorning;
        int Days = GameObject.Find("DayNightCycle").GetComponent<DayNightCycle>().days;
        if (Night && !isSpawnEnemy)
        {
            //int Days = GameObject.Find("DayNightCycle").GetComponent<DayNightCycle>().days;
            //if (Days == 1 || Days == 5 || Days == 10 || Days == 20)
            //{
                StartCoroutine(EnemyDrop());
                isSpawnEnemy = true;
            //}
        }
        if (Morning && isSpawnEnemy)
        {
            isSpawnEnemy = false;
            numberofEnemyInWave += Days;
            Debug.LogWarning(numberofEnemyInWave);
            enemyCount = 0;
        }
    }
    IEnumerator EnemyDrop()
    {
        Instantiate(SpawnEffects, gameObject.transform);
        while (enemyCount <numberofEnemyInWave)
        {
            xPos = Random.Range(xPosMin, xPosMax);
            zPos = Random.Range(zPosMin, zPosMax);
            Instantiate(Enemy1, new Vector3(transform.position.x + xPos, transform.position.y, transform.position.z + zPos), Quaternion.identity);
            Instantiate(Enemy2, new Vector3(transform.position.x + xPos, transform.position.y, transform.position.z + zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;    
        }       
    }
}
