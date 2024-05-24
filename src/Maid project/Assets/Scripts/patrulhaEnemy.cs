using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;
    public float rotationSpeed = 5f; // velocidade de rotação
    public float targetReachedTolerance = 0.1f; // ajuste este valor conforme necessário

    private int targetPoint;

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, patrolPoints[targetPoint].position);
        if (distanceToTarget <= targetReachedTolerance)
        {
            IncreaseTargetPoint();
        }

        MoveTowardsTarget();
    }

    void MoveTowardsTarget()
    {
        // Movendo-se em direção ao alvo
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);

        // Rotacionando em direção ao alvo
        Vector3 direction = (patrolPoints[targetPoint].position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }

    void IncreaseTargetPoint()
    {
        targetPoint = (targetPoint + 1) % patrolPoints.Length;
    }
}