using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static int points = 0;
    public GameObject thisObject = null;

    void Awake()
    {
        if (thisObject == null)
        {
            thisObject = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else if (thisObject != this)
        {
            Destroy(gameObject);
        }
    }
}