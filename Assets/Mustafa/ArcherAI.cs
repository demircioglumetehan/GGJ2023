using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAI : MonoBehaviour
{
    public Transform target;
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;

    void Update()
    {
        // Hedefi takip et
        transform.LookAt(target);

        // Hedefine yeterli mesafede deðilse yaklaþ
        if (Vector3.Distance(transform.position, target.position) > 10f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 5f * Time.deltaTime);
        }
        // Hedefine yeterli mesafede ise ok at
        else
        {
            FireArrow();
        }
    }

    void FireArrow()
    {
        // Ok nesnesi oluþtur
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);

        // Ok nesnesinin hedefini belirle
        arrow.GetComponent<Arrow>().SetTarget(target);
    }
}