using System
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 2021.09.06 / code by Tae Hyung Kim.
 */
public class UILoading : MonoBehaviour {
    public GameObject LoadingIcon;
    public Text LoadingReasonText;

    [SerializeField] private float rotationAngle;
    [SerializeField] private float rotationTerm;

    // Start is called before the first frame update
    void Start() {
        EventManager.OnEndLoading += DestroyLoadingUI;
        EventManager.OnChangeLoadingReason += ChangeReasonString;

        StartCoroutine(RotationLoadingIcon());
    }
    
    void OnDestroy() {
        EventManager.OnEndLoading -= DestroyLoadingUI;
        EventManager.OnChangeLoadingReason -= ChangeReasonString;
    }

    #region 로딩 상태가 지속되는 동안 반복되어질 루틴.
    // void Update() {
    //      LoadingIcon.transform.Rotate(0, 0, -rotationAngle);
    // }
    IEnumerator RotationLoadingIcon() {
        var _rotationTerm = new WaitForSeconds(rotationTerm);

        while (true) {
            LoadingIcon.transform.Rotate(0, 0, -rotationAngle);

            yield return _rotationTerm;
        }
    }
    #endregion
    
    #region 이벤트 발동 시 사용이 필요한 함수 (event Action 체인에 포함).
    public void DestroyLoadingUI()
    {
        StopCoroutine(RotationLoadingIcon());
        Destroy(gameObject);
    }
    
    public void ChangeReasonString(int errorCode)
    {
        if (errReasonDic != null)
            LoadingReasonText.text = errReasonDic[errorCode];
    }
    #endregion
}
