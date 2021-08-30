using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyAI : MonoBehaviour
{
    public GameObject Enemy;
    public int xPos;
    public int zPos;
    public int enemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount <10)
        {
            xPos = Random.Range(-80, -100);
            zPos = Random.Range(5, -5);
            Instantiate(Enemy, new Vector3(xPos, 23, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
