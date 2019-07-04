using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persist : MonoBehaviour
{
    public bool Persistent;
    // Start is called before the first frame update
    void Start()
    {
        if (Persistent == true)
        {
            DontDestroyOnLoad(gameObject);
        }
        if (Persistent == false)
        {

        }
        
    }

}
