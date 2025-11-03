using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float hitRange = 2f;
    public float posturePerLight = 12f;
    public float posturePerParry = 50f;
    public float parryWindow = 0.2f;

    float _enemyAttackTimer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryApplyPosture(posturePerLight);
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (_enemyAttackTimer > 0f)
            {
                TryApplyPosture(posturePerParry);
                _enemyAttackTimer = 0f;
            }
        }

        if (_enemyAttackTimer > 0f) _enemyAttackTimer -= Time.deltaTime;
    }

    void TryApplyPosture(float amount)
    {
        if (Physics.SphereCast(transform.position, 0.3f, transform.forward, out RaycastHit hit, hitRange))
        {
            var posture = hit.collider.GetComponentInParent<EnemyPosture>();
            if (posture != null) posture.ApplyPosture(amount);
        }
    }

    public void NotifyEnemyAttackStart()
    {
        _enemyAttackTimer = parryWindow;
    }
}
