using UnityEngine;

public class API : MonoBehaviour
{
    public Transform traA;

    public Transform traB;
    public SpriteRenderer srB;
    public GameObject objB;
    float x = 0.1f;

    public Camera cam;

    public void Start()
    {
        print("Cordinate:" + traA.position);
        traB.position = new Vector3(0, 1, 0);

        cam.backgroundColor = new Color(0.0f, 0.0f, 0.0f);

        print("圖片的顏色:" + srB.color);
        print("物件的圖層:" + objB.layer);
        srB.flipX = false;
        objB.layer = 5;
    }

    public void Update()
    {
        CtrlTraB();

    }

    void CtrlTraB() {
        // traB.Rotate(new Vector3(0, 0, 30));
        if (traB.position.x > 5f)
        {
            srB.flipX = true;
            x = -0.5f;
        }
        else if (traB.position.x < -5f)
        {
            srB.flipX = false;
            x = 0.5f;
        }

        traB.Translate(new Vector3(x, 0, 0), Space.World);
    }
}
