using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroMove : MonoBehaviour
{
    [SerializeField] public float _speed;
    [SerializeField] public float _jumpForse;
    [SerializeField] private float _groundCheckRadius;
    [SerializeField] private float _reloadTime;
    [SerializeField] public int _maxAmmo;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _ground;

    private bool _isReloading = false;
    private bool _faceRight = true;
    private bool _onGround;
    private float _moveX;
    public int _currentAmmo;

    private Rigidbody2D _rb;
    private Animator _anim;
    private ShooterComponent _shoot;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _shoot = GetComponent<ShooterComponent>();
        _currentAmmo = _maxAmmo;
    }

    private void Update()
    {
        Jump();
        Walk();
        Reflec();
        ShootBullet();
    }

    private void Walk()
    {
        _moveX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(_moveX, 0, 0) * _speed * Time.deltaTime;

        _anim.SetFloat("Move", Mathf.Abs(_moveX));
    }

    private void ShootBullet()
    {
        if (_isReloading) return;

        if (Input.GetButtonDown("Fire1"))
        {
            if (_currentAmmo > 0)
            {
                _shoot.Shoot(_faceRight);
                _currentAmmo--;
                _anim.SetTrigger("Attack");
            }
            else
            {
                StartCoroutine(Reload());
            }
        }
    }

    private IEnumerator Reload()
    {
        _isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(_reloadTime);

        _currentAmmo = _maxAmmo;
        _isReloading = false;
        Debug.Log("Reload complete");
    }


    private void Reflec()
    {
        if ((_moveX > 0 && !_faceRight) || (_moveX < 0 && _faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            _faceRight = !_faceRight;
        }
    }

    private void Jump()
    {
        CheckGrounded();

        if (_onGround && Input.GetKey(KeyCode.Space))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForse);
            _anim.SetTrigger("OnGroundHero");
        }
    }

    public void Dead(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1f;
    }

    private void CheckGrounded()
    {
        _onGround = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _ground);
    }

    private void OnDrawGizmos()
    {
        if (_groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_groundCheck.position, _groundCheckRadius);
        }
    }
}
