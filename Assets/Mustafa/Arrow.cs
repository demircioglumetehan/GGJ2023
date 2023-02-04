using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Transform target;

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    void Update()
    {
        // Hedef bulunamadýysa çalýþma
        if (target == null)
            return;

        // Hedefe doðru git
        transform.position = Vector3.MoveTowards(transform.position, target.position, 20f * Time.deltaTime);

        // Hedefe ulaþtýysa nesneyi yok et
        if (Vector3.Distance(transform.position, target.position) < 0.10f)
        {
            Destroy(gameObject);
        }
        else
        {
                Destroy(gameObject);
            
        }
    }
}