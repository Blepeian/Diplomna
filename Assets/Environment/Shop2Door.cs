using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop2Door : MonoBehaviour
{
    private LevelManager manager;

    private void Awake()
    {
        manager = (LevelManager)GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        DontDestroyOnLoad(manager.gameObject);
        DontDestroyOnLoad(manager.player.gameObject);
        DontDestroyOnLoad(manager.ui.gameObject);
        SceneManager.LoadScene("level3");
        manager.player.transform.position = new Vector3(0,0,0);
    }
}
