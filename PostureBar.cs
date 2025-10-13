using UnityEngine;
using UnityEngine.UI;

public class PostureBar : MonoBehaviour
{
    public EnemyPosture target;
    public Image fill;

    void Update()
    {
        if (target && fill) fill.fillAmount = target.Posture01();
    }
}
