using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_1_Manager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject UIPrefab;
    public Camera mainCamera;

    private void Start()
    {
        GameObject player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject ui = Instantiate(UIPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        ui.GetComponent<Canvas>().worldCamera = mainCamera;
        mainCamera.GetComponent<CameraMovement>().player = player.transform;
    }
}
