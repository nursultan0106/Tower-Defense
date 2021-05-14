using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public GameObject impactEffect;
    public int damage = 50;
    public float speed = 70f;
    public float explotionRadius = 0f;
    public void Seek(Transform anotherTarget)
    {
        target = anotherTarget;
    }
    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }
    private void HitTarget()
    {
        GameObject effectInstance = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInstance, 5f);
        if (explotionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }
    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explotionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    private void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explotionRadius);
    }
}