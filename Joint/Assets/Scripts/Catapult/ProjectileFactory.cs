using UnityEngine;

public class ProjectileFactory : MonoBehaviour 
{
    [SerializeField] private CatapultController _controller;
    [SerializeField] private Bullet _bullet;

    private void OnEnable()
    {
        _controller.CatapultLoaded += CreateBullet;
    }

    private void OnDisable()
    {
        _controller.CatapultLoaded -= CreateBullet;
    }

    private void CreateBullet(Transform transform)
    {
        Instantiate(_bullet, transform.position, Quaternion.identity);
    }
}
