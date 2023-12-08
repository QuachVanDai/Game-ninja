using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : NCKHMonoBehaviour
{
    private static gameManager instance;
    public static  gameManager Instance { get { return instance; } }

    [SerializeField]
    private bool isPlayGame;
    public bool IsPlaygame {  get { return isPlayGame; } set { isPlayGame = value; } }
    protected override void Awake()
    {
        base.Awake();
        gameManager.instance = this;
        isPlayGame = true;
    }

}
