using UnityEngine;

public class ExecutionWindow : MonoBehaviour
{
    public EnemyPosture target;
    public float radius = 2.0f;
    public KeyCode executeKey = KeyCode.E;
    public float executeDamage = 999f;
    Transform _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        target.OnStaggerStart.AddListener(EnableWindow);
        target.OnStaggerEnd.AddListener(DisableWindow);
        gameObject.SetActive(false);
    }

    void EnableWindow()  { gameObject.SetActive(true); }
    void DisableWindow() { gameObject.SetActive(false); }

    void Update()
    {
        if (!gameObject.activeSelf) return;
        if (!_player) return;

        float d = Vector3.Distance(_player.position, target.transform.position);
        if (d <= radius && Input.GetKeyDown(executeKey))
        {
            target.TakeExecutionDamage(executeDamage);
            DisableWindow();
        }
    }
}
