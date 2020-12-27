using UnityEngine;

public class Player : MonoBehaviour
{
# region 角色設定
    /* 公開 設定 */
    // 角色相關
    [Header("移動速度"), Range(0,1000)]
    public float moveSpeed  = 10.5f; // 移動速度
    [Header("跳躍高度"), Range(0, 3000)]
    public int jumpHeight  = 100;    // 跳躍高度
    [Header("是否在地板上"), Tooltip("是否在地板上?(是:T 否:F)")]
    public bool isOnFloor  = false;  // 是否在地板上
    [Range(0, 200)]
    public float hp = 100;             // 血量

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
    private AudioSource m_audioSource; // 音效來源
    private Rigidbody2D m_rigidbody2D; // 2D 剛體
    private Animator m_animator;       // 動畫控制器
    #endregion

#region 角色基本功能
    /// <summary>
    /// 移動
    /// </summary>
    private void DoMove()
    {
        
    }

    /// <summary>
    /// 跳耀
    /// </summary>
    private void DoJump()
    {

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
