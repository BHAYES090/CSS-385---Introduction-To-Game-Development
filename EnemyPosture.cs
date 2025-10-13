using UnityEngine;
using UnityEngine.Events;

public class EnemyPosture : MonoBehaviour
{
    [Header("Posture")]
    public float maxPosture = 100f;
    public float decayPerSecond = 15f;
    public float staggerDuration = 1.2f;

    [Header("Health")]
    public float maxHealth = 100f;

    public UnityEvent OnStaggerStart;
    public UnityEvent OnStaggerEnd;

    float _posture;
    float _health;
    float _staggerTimer;
    bool _staggered;

    void Awake()
    {
        _health = maxHealth;
        _posture = 0f;
    }

    void Update()
    {
        if (_staggered)
        {
            _staggerTimer -= Time.deltaTime;
            if (_staggerTimer <= 0f)
            {
                _staggered = false;
                _posture = 0f;
                OnStaggerEnd?.Invoke();
            }
        }
        else
        {
            if (_posture > 0f)
            {
                _posture = Mathf.Max(0f, _posture - decayPerSecond * Time.deltaTime);
            }
        }
    }

    public void ApplyPosture(float amount)
    {
        if (_staggered) return;
        _posture = Mathf.Min(maxPosture, _posture + amount);
        if (_posture >= maxPosture)
        {
            _staggered = true;
            _staggerTimer = staggerDuration;
            OnStaggerStart?.Invoke();
        }
    }

    public bool IsStaggered() => _staggered;

    public void TakeExecutionDamage(float dmg)
    {
        _health -= dmg;
        if (_health <= 0f) Destroy(gameObject);
    }

    public float Posture01() => maxPosture <= 0f ? 0f : _posture / maxPosture;
}
