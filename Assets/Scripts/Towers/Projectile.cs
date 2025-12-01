// MARIANO CODUTTI ALARCON
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float explosionRadius = 0f;
    [SerializeField] private float damageToEnemy = 1f;

    [SerializeField] private GameObject impactEffect;

    private Transform enemyTarget;

    private bool canHitGround;
    private bool canHitAir;


    private void Update()
    {
        if (enemyTarget == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = enemyTarget.GetComponent<EnemyHealth>().TargetPoint.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
        transform.LookAt(enemyTarget.GetComponent<EnemyHealth>().TargetPoint);
    }


    public void SeekTarget(Transform _target)
    {
        enemyTarget = _target;
    }

    private void HitTarget()
    {
        GameObject impactGO = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(impactGO, 2f);
        

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            DamageTarget(enemyTarget);
        }

        Destroy(gameObject);
    }

    private void DamageTarget(Transform _target)
    {
        EnemyHealth target = _target.GetComponent<EnemyHealth>();

        if (target == null)
            return;

        if (!IsValidEnemyType(target.Type))
            return;

        target.TakeDamage(damageToEnemy);
    }

    private bool IsValidEnemyType(EnemyHealth.EnemyType _enemyType)
    {
        if (_enemyType == EnemyHealth.EnemyType.Ground && canHitGround)
            return true;

        if (_enemyType == EnemyHealth.EnemyType.Air && canHitAir)
            return true;

        return false;
    }

    private void Explode()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider target in targets)
        {
            if (target.tag == "Enemy")
            {
                DamageTarget(target.transform);
            }
        }
    }

    public void ConfigureDamageFilters(bool _hitsGround,  bool _hitsAir)
    {
        canHitGround = _hitsGround;
        canHitAir = _hitsAir;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
