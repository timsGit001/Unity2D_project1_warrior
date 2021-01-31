using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2ndAtk : MonoBehaviour
{

    [Header("第二階段攻擊力")]
    public float atk = 50.0f;

    /// <summary>
    /// 粒子碰撞事件 (需要先勾選Collision 與 Send Message才有效!)
    /// </summary>
    /// <param name="other"></param>
    private void OnParticleCollision(GameObject other)
    {
        Player player = other.GetComponent<Player>();
        if (player)
        {
            player.OnInjury(atk);
        }
    }
}
