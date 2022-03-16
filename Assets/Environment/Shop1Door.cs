using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop1Door : MonoBehaviour
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
        SceneManager.LoadScene("level2");
        manager.player.transform.position = new Vector3(0,0,0);
    }
}
