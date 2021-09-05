using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 2021.09.05 / code by Tae Hyung Kim.
 */
public class UILoading : MonoBehaviour {
    public GameObject LoadingIcon;
    public Text LoadingReasonText;

    [SerializeField] private float rotationAngle;
    [SerializeField] private float rotationTerm;

    // Start is called before the first frame update
    void Start() {
        EventManager.Instance.AddListener(EVENT_TYPE.LOADING_STATE, this);
        EventManager.Instance.AddListener(EVENT_TYPE.LOADING_REASON, this);

        StartCoroutine(RotationLoadingIcon());
    }

    #region 로딩 상태가 지속되는 동안 반복되어질 루틴.
    IEnumerator RotationLoadingIcon() {
        var _rotationTerm = new WaitForSeconds(rotationTerm);

        while (true) {
            LoadingIcon.transform.Rotate(0, 0, -rotationAngle);

            yield return _rotationTerm;
        }
    }
    #endregion
    
    #region 이벤트 발동 시 이벤트 메니저에서 사용되어질 함수들.
    public void OnEndLoading()
    {
        StopCoroutine(RotationLoadingIcon());
        Destroy(gameObject);
    }

    public void OnChangeLoadingReason(int errorCode)
    {
        if (errReasonDic != null)
            LoadingReasonText.text = errReasonDic[errorCode];
    }
    #endregion
}
