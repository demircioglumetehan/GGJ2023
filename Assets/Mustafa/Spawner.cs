using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public float spawnInterval = 1.0f;

    [SerializeField] private float timer;

    [SerializeField] float intervalMinus = 0.01f;
    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            Instantiate(enemies[Random.Range(0,4)], PlayerWrapper.instance.transform.position + CreateRandomPosition(), transform.rotation);
            timer = 0;
            if (spawnInterval > 0.15f)
            {
                spawnInterval -= intervalMinus;
            }           
        }
    }



    IEnumerator CreateWave(int enemyAmount)
    {
        while (enemyAmount > 0)
        {
            Instantiate(enemies[Random.Range(0, 4)], PlayerWrapper.instance.transform.position + CreateRandomPosition(), transform.rotation);
            enemyAmount--;
            yield return new WaitForSeconds(intervalMinus);
        }
       
    }

    Vector3 CreateRandomPosition()
    {
        return new Vector3(Random.Range(5, 20), 0.5f, Random.Range(5, 20));
    }

}
