using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject UIPrefab;
    public Camera mainCamera;
    public AbilitySelectUI abUI;

    public GameObject ui = null;
    public GameObject player = null;

    private void Awake()
    {
        Initialize();
    }

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        if(ui == null)
        {
            ui = Instantiate(UIPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }

        if(player == null)
        {
            player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }

        mainCamera = Camera.main;
        ui.GetComponent<Canvas>().worldCamera = mainCamera;
        player.name = "Player";
        ui.name = "UI";
        player.GetComponent<PlayerStats>().enabled = true;
    }
}
