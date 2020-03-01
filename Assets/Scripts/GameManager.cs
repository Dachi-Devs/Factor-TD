using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public Transform[] enemyPath;
    public Transform path;

    // Start is called before the first frame update
    void Start()
    {
        enemyPath = path.GetComponentsInChildren<Transform>();
    }
}
