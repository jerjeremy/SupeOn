using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private static MainManager instance;
    public static MainManager Instance // constructor
    {
        get
        {
            if (instance == null)
            {
                Initialize();
            }
            return instance;
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }   
        else
        {
            Destroy(gameObject);
        }
    }

    // create instance if none exists
    private static void Initialize()
    {
        if (instance == null)
        {
            GameObject gObj = new GameObject();
            gObj.name = "Game Manager";
            instance = gObj.AddComponent<MainManager>();
            DontDestroyOnLoad(gObj);
        }
    }

    // speed up egg drops
    public void DecreaseDropDelay(float delayDecrement)
    {
        GameObject chickenHolder = GameObject.Find("Chicken Holder");
        foreach (EggSpawner child in chickenHolder.transform.GetComponentsInChildren<EggSpawner>())
        {
            // TODO: decrease timer on each child
        }
    }
}
