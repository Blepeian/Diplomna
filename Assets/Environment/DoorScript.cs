using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    private LevelManager manager;

    private void Awake()
    {
        manager = (LevelManager)GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            DontDestroyOnLoad(manager.gameObject);
            DontDestroyOnLoad(manager.player.gameObject);
            
            switch(manager.levelNum)
            {
                case 1:
                    manager.levelNum++;
                    SceneManager.LoadScene("shop1");
                    break;
                case 2:
                    manager.levelNum++;
                    SceneManager.LoadScene("level2");
                    break;
                case 3:
                    manager.levelNum++;
                    SceneManager.LoadScene("shop2");
                    break;
                case 4:
                    manager.levelNum++;
                    SceneManager.LoadScene("level3");
                    break;
            }
            manager.player.transform.position = new Vector3(0,0,0);
        }
    }
}
