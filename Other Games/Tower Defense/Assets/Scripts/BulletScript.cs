using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Transform target;

    public float speed = 45f;
    public float explosionRadius = 0f;
    public GameObject impactParticles;

    public int damage = 50;

    // Update is called once per frame
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
        GameObject particles = (GameObject)Instantiate(impactParticles, transform.position, transform.rotation);
        Destroy(particles, 2f);
        if (explosionRadius > 0f)
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
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    private void Damage(Transform enemy)
    {
        EnemyScript e = enemy.GetComponent<EnemyScript>();
        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    public void Seek(Transform target)
    {
        this.target = target;
    }
}