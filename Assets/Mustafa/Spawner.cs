using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Spawner : MonoBehaviour
{
    public List<Enemy> enemies;
    public float spawnInterval = 1.0f;

    [SerializeField] private float timer;

    [SerializeField] float intervalMinus = 0.01f;
    Coroutine SpawningCor;
    public List<Enemy> SpawnedEnemies = new List<Enemy>();
    private void OnEnable()
    {
        Stone.OnStoneDestroyed += StopSpawning;
    }

    private void Start()
    {
        StartWorking();
    }
    private void OnDisable()
    {
        Stone.OnStoneDestroyed -= StopSpawning;
    }
    private void StopSpawning()
    {
        if (SpawningCor != null)
        {
            StopCoroutine(SpawningCor);
        }

    }

    public void StartWorking()
    {
        SpawningCor = StartCoroutine(SpawnEnemiesCor());
    }


    private IEnumerator SpawnEnemiesCor()
    {
        while (true)
        {
            var enemy = Instantiate(enemies[Random.Range(0, enemies.Count())], PlayerWrapper.instance.transform.position + CreateRandomPosition(), transform.rotation);
            SpawnedEnemies.Add(enemy);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    /*
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            Instantiate(enemies[Random.Range(0, enemies.Count())], PlayerWrapper.instance.transform.position + CreateRandomPosition(), transform.rotation);
            timer = 0;
            if (spawnInterval > 0.15f)
            {
                spawnInterval -= intervalMinus;
            }           
        }
    }*/



    IEnumerator CreateWave(int enemyAmount)
    {
        while (enemyAmount > 0)
        {
            Instantiate(enemies[Random.Range(0, enemies.Count())], PlayerWrapper.instance.transform.position + CreateRandomPosition(), transform.rotation);
            enemyAmount--;
            yield return new WaitForSeconds(intervalMinus);
        }

    }

    Vector3 CreateRandomPosition()
    {
        return new Vector3(Random.Range(5, 20), 0.5f, Random.Range(5, 20));
    }

}