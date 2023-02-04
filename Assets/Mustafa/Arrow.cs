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
        // Hedef bulunamad�ysa �al��ma
        if (target == null)
            return;

        // Hedefe do�ru git
        transform.position = Vector3.MoveTowards(transform.position, target.position, 20f * Time.deltaTime);

        // Hedefe ula�t�ysa nesneyi yok et
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