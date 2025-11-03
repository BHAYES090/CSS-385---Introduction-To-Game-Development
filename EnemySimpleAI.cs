using UnityEngine;

public class EnemySimpleAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackRange = 2f;
    public float attackCooldown = 2f;

    Transform _player;
    float _cooldown;
    PlayerAttack _playerAttack;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _playerAttack = _player.GetComponent<PlayerAttack>();
    }

    void Update()
    {
        if (!_player) return;

        float d = Vector3.Distance(transform.position, _player.position);
        if (d > attackRange)
        {
            Vector3 dir = (_player.position - transform.position).normalized;
            transform.position += dir * moveSpeed * Time.deltaTime;
        }
        else
        {
            if (_cooldown <= 0f)
            {
                _playerAttack.NotifyEnemyAttackStart();
                _cooldown = attackCooldown;
            }
        }

        if (_cooldown > 0f) _cooldown -= Time.deltaTime;
    }
}
