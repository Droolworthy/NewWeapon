using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class ShotgunBullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private int _spread;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();

        var direction = transform.rotation * Vector2.up;

        Vector2 perpendicular = Vector2.Perpendicular(direction) * Random.Range(-_spread, _spread);

        _rigidbody.velocity = direction * perpendicular * _spread;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);

            Destroy(gameObject);
        }
    }
}
