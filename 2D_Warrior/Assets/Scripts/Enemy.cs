using UnityEngine;

// 第一次套用此腳本時，會自動添加的元件(一次RequireComponent可包含1~3個)
[RequireComponent(typeof(AudioSource), typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0, 500)]
    public float speed = 100f;
    [Header("攻擊力"), Range(0, 500)]
    public float atk = 20f;
    [Header("攻擊範圍"), Range(0, 500)]
    public float rangeAtk = 10f;
    [Header("血量"), Range(100, 5000)]
    public float hp = 2500f;

    private AudioSource m_audioSource;       // 音效來源
    private Rigidbody2D m_rigidbody2D;       // 2D 剛體
    private Animator m_animator;             // 動畫控制器

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void DoMove()
    {
        // 物理移動
        //m_rigidbody2D.velocity = new Vector2(h * speed, m_rigidbody2D.velocity.y);

        // 移動動畫
        m_animator.SetBool("walkSwitch", true);

        // 面向
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">受傷量</param>
    public void OnInjury(float damage)
    {
        hp -= damage;
        m_animator.SetTrigger("onHurt");
    }

    /// <summary>
    /// 死亡
    /// </summary>
    /// <param name="objName">碰撞到的物件名</param>
    private void OnDeath(GameObject objName)
    {

    }
}
