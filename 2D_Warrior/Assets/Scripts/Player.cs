using UnityEngine;

public class Player : MonoBehaviour
{
    #region 角色設定
    /* 公開 設定 */
    // 角色相關
    [Header("移動速度"), Range(0, 1000)]
    public float moveSpeed = 10.5f; // 移動速度
    [Header("跳躍高度"), Range(0, 3000)]
    public int jumpHeight = 100;    // 跳躍高度
    [Header("是否在地板上"), Tooltip("是否在地板上?(是:T 否:F)")]
    public bool isOnFloor = true;  // 是否在地板上
    [Range(0, 200)]
    public float hp = 100;             // 血量
    [Header("Gizmos Offset")]
    public Vector3 offset;
    [Header("Gizmos Radius")]
    public float radius;

    // 武器相關
    [Header("子彈"), Tooltip("請提供子彈物件")]
    public GameObject bullet;        // 子彈物件
    [Header("子彈生成點"), Tooltip("請提供座標")]
    public Transform bulletBirthLoc; // 子彈生成點
    [Range(0, 5000)]
    public int bulletSpeed = 800;    // 子彈速度
    [Header("開槍音效"), Tooltip("請提供開槍音效")]
    public AudioClip shootAudio;     // 開槍音效

    /* 私人 設定 */
    private AudioSource m_audioSource;       // 音效來源
    private Rigidbody2D m_rigidbody2D;       // 2D 剛體
    private Animator m_animator;             // 動畫控制器
    private SpriteRenderer m_spriteRenderer; // 圖片相關
    private float h; // 水平控制量值
    private float v; // 垂直控制量值
    #endregion

    #region 角色基本功能
    /// <summary>
    /// 在unity上繪製圖形 (玩家是看不到的)
    /// </summary>
    private void OnDrawGizmos()
    {
        // 調顏色
        Gizmos.color = new Color(1, 0, 0, 0.35f);
        // 以角色pos為中心 繪製半徑為1.0的球形
        Gizmos.DrawSphere(transform.position + offset, radius);
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void DoMove()
    {
        // 物理移動
        m_rigidbody2D.velocity = new Vector2(h * moveSpeed, m_rigidbody2D.velocity.y);

        // 移動動畫
        m_animator.SetBool("runSwitch", (isOnFloor && h != 0));

        // 面向
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            transform.localEulerAngles = Vector3.zero;
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            transform.localEulerAngles = new Vector3(0, 180, 0);
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void DoJump()
    {
        // [判斷跳躍動作]
        if (isOnFloor && Input.GetKeyDown(KeyCode.Space))
        {
            // 物理移動
            m_rigidbody2D.AddForce(new Vector2(0, jumpHeight));
            // 觸發跳躍動畫
            m_animator.SetTrigger("doJump");
        }

        // [是否接觸地板]
        // 取 以角色pos+offset為中心 半徑為1.0的圓形 與 第8層Layer(目前是設為地板的Layer)的碰撞
        Collider2D hit = Physics2D.OverlapCircle(transform.position + offset, radius, 1 << 8);
        isOnFloor = (hit!=null);

        // 設定動畫參數
        m_animator.SetFloat("jumping", m_rigidbody2D.velocity.y);
        m_animator.SetBool("onFloor", isOnFloor);
    }
    /// <summary>
    /// 開槍
    /// </summary>
    private void DoShoot()
    {

    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">受傷量</param>
    private void OnInjury(float damage)
    {

    }

    /// <summary>
    /// 死亡
    /// </summary>
    /// <param name="objName">碰撞到的物件名</param>
    private void OnDeath(GameObject objName)
    {

    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        GetHorizontal();
        DoMove();
        DoJump();
    }

    /// <summary>
    /// 取得 水平控制量值
    /// </summary>
    private void GetHorizontal()
    {
        h = Input.GetAxis("Horizontal");
    }
}
