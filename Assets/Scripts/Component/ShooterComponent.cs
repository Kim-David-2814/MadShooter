using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterComponent : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletPoint;
    [SerializeField] private float _fireSpeed;

    public void Shoot(bool faceRight)
    {
        GameObject currentBullet = Instantiate(_bullet, _bulletPoint.position, Quaternion.identity);
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

        float direction = faceRight ? 1f : -1f;
        currentBulletVelocity.velocity = new Vector2(direction * _fireSpeed, 0f);
    }
}
