using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public GameObject player;

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadGame();
        if (data == null) return;

        Vector3 pos = new Vector3(data.pos[0], data.pos[1], data.pos[2]);
        player.GetComponent<PlayerHealth>().health = data.health;
        player.GetComponent<PlayerHealth>().SetHealthBar();
        player.transform.position = pos;
    }
}
