using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float speed;
    [SerializeField] protected int damage;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float attackCooldown;

    protected bool isAttacking = false;
    protected Transform target;
    public PlayerMovement player;
    protected float nextAttackTime = 0f;
    protected Animator animator;

    protected virtual void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = target.GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        Debug.Log(health);
        if (!target || Vector3.Distance(target.position, transform.position) >= 20f)
        {
            return;
        }

        MoveTowardsTarget();

        if (Time.time >= nextAttackTime)
        {
            if (IsTargetInRange(attackRange))
            {
                StartCoroutine(Attack());
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }

    protected virtual void MoveTowardsTarget()
    {
        float dist = Vector3.Distance(target.position, transform.position);

        if (dist > attackRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        Vector3 direction = target.position - transform.position;
        if (direction.x < 0 && transform.localScale.x > 0)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        else if (direction.x > 0 && transform.localScale.x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    protected virtual bool IsTargetInRange(float r)
    {
        float dist = Vector3.Distance(transform.position, target.position);
        return dist <= r;
    }

    protected virtual IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetBool("IsAttacking", isAttacking);

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float animationDuration = stateInfo.length;

        yield return new WaitForSeconds(animationDuration);

        isAttacking = false;
        animator.SetBool("IsAttacking", isAttacking);
    }

    public void TakeDamage(float damage, int id)
    {
        health -= damage;
        if (health <= 0)
        {
            GunController g = target.GetChild(0).GetComponent<GunController>();
            g.AddBullet(id);
            Die();
        }
    }

    public virtual void DealDamage(){
        PlayerController.health -= damage;
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
