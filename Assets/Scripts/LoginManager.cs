﻿using System.Collections;
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
        // get data
        string id = GetUserID();
        string password = GetUserPassword();

        Debug.Log("로그인 시도");
        Debug.Log(" >> 로그인 정보(ID: "+ id + ", Password: " + password + ")");
       
        // 로그인 시도
        // 제웅형
        // isValid = 로그인성공여부

        if (isValid)
        {
            Debug.Log(" >> 로그인 성공");
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
        else
        {
            Debug.Log(" >> 로그인 실패");
            //실패창 띄우기
            alertPanel.SetActive(true);
        }

    }

    // 회원가입 버튼 눌렀을 때
    public void OnSignupButtonClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    // 실패창 누르면 닫음
    public void OnAlertPanelClicked()
    {
        alertPanel.SetActive(false);
    }

    // 유저가 입력한 ID 가져옴
    private string GetUserID()
    {
        return GameObject.Find("ID_InputField").GetComponent<UnityEngine.UI.InputField>().text;
    }

    // 유저가 입력한 Password 가져옴
    private string GetUserPassword()
    {
        return GameObject.Find("PW_InputField").GetComponent<UnityEngine.UI.InputField>().text;
    }
}
