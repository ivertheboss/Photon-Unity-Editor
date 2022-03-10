using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawn : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject SpawnArea;

    public float X;
    public float Y;

    public void SpawnPlayer()
    {
        Vector2 randomPosition = new Vector2(Random.Range(X, X * -1), Random.Range(Y, Y));
        PhotonNetwork.Instantiate(PlayerPrefab.name, SpawnArea.gameObject.transform.GetChild(0).gameObject.transform.position, Quaternion.identity);
    }
}
