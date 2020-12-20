using UnityEngine;

public class Car : MonoBehaviour
{
    /* 基本設定 */
    [Header("基本設定")]
    [Tooltip("汽車高度(公尺)"), Min(1)]
    public int height = 1;                                   // 高度
    [Tooltip("汽車重量(噸)"), Range(0.01f, 5.00f)]
    public float weight = 0.01f;                             // 重量
    [Tooltip("汽車品牌")]
    public string brand = "請填品牌";                         // 品牌
    [Tooltip("是否有天窗設計")]
    public bool hasTopWindow = false;                        // 是否 有天窗
    [Tooltip("車體顏色")]
    public Color color = new Color(0.0f, 0.0f, 0.0f, 1.0f);  // 顏色
    [Tooltip("汽車位置")]
    public Vector4 location = new Vector4(1.1f,3.1f,0f,9.0f); // 座標

    [Tooltip("駕駛")]
    public GameObject driver;
    [Tooltip("加速器")]
    public ParticleSystem n2;
    [Tooltip("監視器")]
    public Camera cam;


    /* 機密設定 */
    [Header("機密設定")]
    [Tooltip("馬力"), Range(300, 5000), SerializeField]
    private int power = 300;                             // 馬力
    [Tooltip("駕駛位置")]
    private Vector2Int driverLocation = Vector2Int.zero; // 駕駛座標
    [Tooltip("造型噴漆"), SerializeField]
    private Sprite painting;                             // 造型噴漆
    [Tooltip("特色樂"), SerializeField]
    private AudioClip bgm;                               // 特色樂
}
