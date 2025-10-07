using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public enum State { Patrol, Chase, Attack }
    public State currentState = State.Patrol;

    public Transform[] patrolPoints;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float chaseDistance = 10f;
    public float attackDistance = 2f;

    private int currentPatrolIndex = 0;
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                if (distanceToPlayer < chaseDistance)
                    currentState = State.Chase;
                break;

            case State.Chase:
                Chase();
                if (distanceToPlayer < attackDistance)
                    currentState = State.Attack;
                else if (distanceToPlayer > chaseDistance)
                    currentState = State.Patrol;
                break;

            case State.Attack:
                Attack();
                if (distanceToPlayer > attackDistance)
                    currentState = State.Chase;
                break;
        }
        float limit = 15f;
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -limit, limit);
        pos.z = Mathf.Clamp(pos.z, -limit, limit);
        transform.position = pos;
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;
        Transform targetPoint = patrolPoints[currentPatrolIndex];
        MoveTowards(targetPoint.position, patrolSpeed);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.5f)
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    void Chase()
    {
        MoveTowards(player.position, chaseSpeed);
    }

    void Attack()
    {
        Debug.Log("Attack!");
    }

    void MoveTowards(Vector3 target, float speed)
    {
        Vector3 direction = (target - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(target);
    }
}