using Scripts.Component;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    [SerializeField] private float detectionRadius;
    [SerializeField] private float fireDelay;
    [SerializeField] private int _scoreValue;
    [SerializeField] private ShooterComponent shooter;
    [SerializeField] private Animator _anim;

    private Transform player;

    private float fireTimer;
    private bool faceRight = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("GG").transform;
        fireTimer = fireDelay;
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRadius)
            {
                if (player.position.x < transform.position.x && faceRight)
                {
                    Flip();
                }
                else if (player.position.x > transform.position.x && !faceRight)
                {
                    Flip();
                }

                fireTimer -= Time.deltaTime;
                if (fireTimer <= 0f)
                {
                    _anim.SetTrigger("Attack");
                    shooter.Shoot(faceRight);
                    fireTimer = fireDelay;
                }
            }
        }
    }

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDestroy()
    {

        GameObject player = GameObject.FindGameObjectWithTag("GG");
        if (player != null)
        {
            PointComponent playerScore = player.GetComponent<PointComponent>();
            if (playerScore != null)
            {
                playerScore.AddScore(_scoreValue);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

}
