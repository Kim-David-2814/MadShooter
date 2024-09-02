using Scripts.Component;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;

    [SerializeField] private float _speed;
    [SerializeField] private float _patrolSpeed;
    [SerializeField] private float _attackInterval;
    [SerializeField] private float _attackRange;  
    [SerializeField] private float _detectRange;

    [SerializeField] private int _scoreValue;


    private bool _isAttacking = false;

    private Transform _targetPoint;
    private Rigidbody2D _rb;

    private float _attackTimer = 0f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _targetPoint = _pointA;
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _player.position);

        if (distanceToPlayer <= _detectRange)
        {
            if (distanceToPlayer <= _attackRange)
            {
                AttackPlayer();
            }
            else
            {
                ChasePlayer();
            }
        }
        else
        {
            Patrol();
        }

        UpdateAnimation();
        UpdateAttackTimer();
    }

    private void ChasePlayer()
    {

        _isAttacking = false;

        Vector2 direction = (_player.position - transform.position).normalized;
        _rb.velocity = direction * _speed;
        Flip(direction.x);
    }

    private void AttackPlayer()
    {

        _isAttacking = true;

        _rb.velocity = Vector2.zero;

        _attackTimer += Time.deltaTime;

        if (_attackTimer >= _attackInterval)
        {

            _animator.SetTrigger("Attack");
            _attackTimer = 0f;

            if (_player.TryGetComponent(out HealthComponent playerHealth))
            {
                playerHealth.TakeDamage(1);
            }
        }
    }

    private void Patrol()
    {

        _isAttacking = false;

        if (Vector2.Distance(transform.position, _targetPoint.position) <= 0.1f)
        {
            _targetPoint = _targetPoint == _pointA ? _pointB : _pointA;
        }

        Vector2 direction = (_targetPoint.position - transform.position).normalized;
        _rb.velocity = direction * _patrolSpeed;
        Flip(direction.x);
    }

    private void UpdateAnimation()
    {
        _animator.SetBool("isWalking", _rb.velocity.x != 0);
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

    private void UpdateAttackTimer()
    {
        if (_isAttacking)
        {
            _attackTimer += Time.deltaTime;
        }
    }

    private void Flip(float directionX)
    {
        if (directionX > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (directionX < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _detectRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(_pointA.position, _pointB.position);
        Gizmos.DrawSphere(_pointA.position, 0.1f);
        Gizmos.DrawSphere(_pointB.position, 0.1f);
    }

}
