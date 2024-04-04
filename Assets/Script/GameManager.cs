using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance ==null)
        {
            Instance = this;
        }
    }
/*    private int itemCount = 0;

    public void AddItem()
    {
        itemCount++;
        Debug.Log(itemCount);
    }*/
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
