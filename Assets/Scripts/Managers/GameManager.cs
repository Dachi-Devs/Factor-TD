using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public Transform[] enemyPath;
    public Transform path;

    public GameObject gameUI;
    public GameObject deadUI;

    // Start is called before the first frame update
    void Start()
    {
        enemyPath = path.GetComponentsInChildren<Transform>();
    }

    public void LostGame()
    {
        Time.timeScale = 0.6f;
        gameUI.SetActive(false);
        deadUI.SetActive(true);
    }
}
