using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public Transform targetTransform;
    public EnemyScript targetComponent;

    [Header("Turret stats")]
    public float range = 15f;

    [Header("Bullet type turret stats (default)")]
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public GameObject bulletPrefab;

    [Header("Laser type turret stats")]
    public bool userLaser = false;
    public int damageOverTime = 30;
    public float slowFactor = .5f;

    public ParticleSystem laserParticles;
    public Light laserGlowLight;
    public LineRenderer lineRenderer;
    

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform headRotationObject;
    public float turnSpeed = 7.5f;
    public Transform firePoint;

    // Use this for initialization
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    //Method that updates at a less frequent time
    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            targetTransform = nearestEnemy.transform;
            targetComponent = nearestEnemy.GetComponent<EnemyScript>();
        }
        else
        {
            targetTransform = null;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //target lockdown
        if (targetTransform == null)
        {
            if (userLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    laserParticles.Stop();
                    laserGlowLight.enabled = false;
                }
            }
            return;
        }
        LockOnTarget();
        if (userLaser)
        {
            Laser();
        }
        else
        {
            //target shooting
            if (fireCountdown <= 0f)
            {
                ShootEnemy();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    private void LockOnTarget()
    {
        Vector3 direction = targetTransform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(headRotationObject.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        headRotationObject.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    private void Laser()
    {
        //Damage stuff
        targetComponent.TakeDamage(2*damageOverTime * Time.deltaTime);
        targetComponent.Slow(slowFactor);

        //Graphic stuff
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            laserParticles.Play();
            laserGlowLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, targetTransform.position);

        Vector3 particleDirection = firePoint.position - targetTransform.position;
        laserParticles.transform.rotation = Quaternion.LookRotation(particleDirection);
        laserParticles.transform.position = targetTransform.position + particleDirection.normalized;
    }

    private void ShootEnemy()
    {
        GameObject bulletGameObject = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BulletScript bulletScript = bulletGameObject.GetComponent<BulletScript>();

        if (bulletScript != null)
        {
            bulletScript.Seek(targetTransform);
        }
    }

    //Method for range axis drawing
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}