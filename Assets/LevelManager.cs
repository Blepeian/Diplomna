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

    public int levelNum;

    private void Awake()
    {
        levelNum = 1;
        Initialize();
    }

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        if(player == null)
        {
            player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }

        mainCamera = Camera.main;
        player.name = "Player";
        player.GetComponent<PlayerStats>().enabled = true;
    }

    public void ActivateAbSelectUI(AbilityItem item)
    {
        abUI.gameObject.SetActive(true);
        abUI.GetAbility(item);
    }
}
