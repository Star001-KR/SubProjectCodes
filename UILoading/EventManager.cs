using System
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 2021.09.06 / code by Tae Hyung Kim.
 */
public class EventManager : MonoBehaviour {
    #region 이벤트 매니저 클래스를 싱글턴으로 생성
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
    #endregion
 
    public event Action OnEndLoading;
    public EndLoading()
    {
        OnEndLoading?.Invoke();
    }
 
    public event Action<int> OnChangeLoadingReason;
    public ChangeLoadingReason(int errorCode)
    {
        OnChangeLoadingReason?.Invoke(errorCode);
    }
}
