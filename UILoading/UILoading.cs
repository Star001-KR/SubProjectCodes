using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 2021.09.03 / code by Tae Hyung Kim.
 */

public class UILoading : MonoBehaviour
{
    public GameObject LoadingIcon;
    public Text LoadingReasonText;
    public GameObject BG_Dim;

    private bool _isLoading = true;
    public bool isLoading { get { return _isLoading; } set { _isLoading = value; } }

    [SerializeField] private float rotationAngle;
    [SerializeField] private float rotationTerm;
    [SerializeField] private int errorCode;

    // Start is called before the first frame update
    void Start()
    {
        if (!isLoading)
            Destroy(gameObject);

        StartCoroutine(RotationLoadingIcon());
    }

#region Loading Reasource Routine
    IEnumerator RotationLoadingIcon()
    {
        int _errorCode = errorCode;

        while (true)
        {
            if (!isLoading)
                Destroy(gameObject);

            // change reason text if loading reason changed.
            ChangeLoadingReasonString(_errorCode);

            LoadingIcon.transform.Rotate(0, 0, -rotationAngle);
            
            yield return new WaitForSeconds(rotationTerm);
        }
    }

    void ChangeLoadingReasonString(int _errorCode)
    {
        if (_errorCode != errorCode)
            LoadingReasonText.text = _errorCode.ToString();
    }
#endregion
}
