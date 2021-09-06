using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 2021.09.06 / code by Tae Hyung Kim.
 */
public enum EVENT_TYPE { LOADING };
 
public class EventManager : MonoBehaviour {
    private static EventManager _instance = null;
    public static EventManager Instance
    {
        get { return _instance; }
        set {}
    }
    
    void Awake()
    {
        if (_instance == null)
            _instance = this;
            
        else
            DestroyImmediate(this);
    }
}
