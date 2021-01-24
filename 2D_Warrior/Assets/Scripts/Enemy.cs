using UnityEngine;
using UnityEngine.UI;

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

    [Header("血量值")]
    public Text textHp;
    [Header("血量圖片")]
    public Image imgHp;

    private AudioSource m_audioSource;       // 音效來源
    private Rigidbody2D m_rigidbody2D;       // 2D 剛體
    private Animator m_animator;             // 動畫控制器
    private Player m_player; // Player腳本
    private float hpMax;

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_player = FindObjectOfType<Player>(); // 用類型尋找物件 (小心場上同時有重複的類型，你會不知他抓到誰)
        hpMax = hp;
        textHp.text = hp.ToString();
    }

    private void Update()
    {
        if (hp > 0) {
            DoMove();
        }
        
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void DoMove()
    {
        float direction = 1.0f; // 正:往右 負:往左
        // 面向玩家處理
        // transform.eulerAngles = (transform.position.x < m_player.transform.position.x) ? Vector3.zero : new Vector3(0, 180, 0);
        if (transform.position.x < m_player.transform.position.x)
            transform.eulerAngles = Vector3.zero;
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            direction = -1.0f;
        }

        // 物理移動 方法二:往某座標移動 (同樣也會產生出加速度)
        m_rigidbody2D.MovePosition(transform.position + transform.right * speed * Time.deltaTime);

        // 移動動畫 (判斷是否有加速度)
        m_animator.SetBool("walkSwitch", m_rigidbody2D.velocity.magnitude > 0);
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">受傷量</param>
    public void OnInjury(float damage)
    {
        hp -= damage;

        // 受傷
        m_animator.SetTrigger("onHurt");

        if (hp <= 0.0f) OnDeath(); // 死亡

        textHp.text = hp.ToString();
        imgHp.fillAmount = hp / hpMax;
    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void OnDeath()
    {
        hp = 0.0f;
        m_animator.SetBool("dieSwitch", true);
        GetComponent<CapsuleCollider2D>().enabled = false;
    }
}
