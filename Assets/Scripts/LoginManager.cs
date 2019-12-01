using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginManager : MonoBehaviour
{
    public static bool isValid = true;
    GameObject alertPanel;

    private void Start()
    {
        alertPanel = GameObject.Find("Alert");
        alertPanel.SetActive(false);
    }

    public void OnLoginButtonClicked()
    {
        if (isValid)
        {
            Debug.Log("로그인 성공");
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
        else
        {
            Debug.Log("로그인 실패");
            //실패창 띄우기
            alertPanel.SetActive(true);
        }

    }

    public void OnSignupButtonClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    // 실패창 누르면 닫음
    public void OnAlertPanelClicked()
    {
        alertPanel.SetActive(false);
    }
}
