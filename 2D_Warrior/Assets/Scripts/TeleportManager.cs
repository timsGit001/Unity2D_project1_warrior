using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    [Header("另一個傳送門")]
    public Transform otherTeleport;

    private bool playerIn;
    private Transform player;

    private void Teleport()
    {
        if (playerIn && Input.GetKeyDown(KeyCode.W))
        {
            player.position = otherTeleport.position + Vector3.up * 1.5f;
        }
    }

    void Awake()
    {
        player = GameObject.Find("warrior").transform;
    }


    void Update()
    {
        Teleport();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "warrior")
            playerIn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "warrior")
            playerIn = false;
    }
}
