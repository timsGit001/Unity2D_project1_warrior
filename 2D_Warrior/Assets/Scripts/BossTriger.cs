using UnityEngine;

public class BossTriger : MonoBehaviour
{
    [Header("魔王血條")]
    public GameObject objHp;
    [Header("魔王本人")]
    public GameObject objBoss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            objHp.SetActive(true);
            objBoss.SetActive(true);
        }
    }
}
