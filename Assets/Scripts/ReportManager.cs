using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 유저 리포트(신고하기) 관련 스크립트
public class ReportManager : MonoBehaviour
{
    // 문의하신 내용이 접수했습니다 창
    GameObject alertPanel;

    // Start is called before the first frame update
    void Start()
    {
        alertPanel = GameObject.Find("Alert");
        alertPanel.SetActive(false);
    }

    public void OnReportButtonClicked()
    {
        // get data
        string reportUserName = GetReportUserName();
        string reportContent = GetReportContent();

        Debug.Log("신고하기 시도");
        Debug.Log( ">> Reported User: "+ reportUserName + ", 신고 내용: " + reportContent);

        // 리포트 보내기 
        // 제웅형


        // 문의하신 내용이 접수했습니다 창 띄우기
        alertPanel.SetActive(true);
    }

    // 창 누르면 나가기
    public void OnAlertPanelClicked()
    {
        // main창으로 이동
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    // 유저가 입력한 사용자 명 가져오기
    private string GetReportUserName()
    {
        return GameObject.Find("InputField_UserName").GetComponent<UnityEngine.UI.InputField>().text;
    }

    // 유저가 입력한 신고 내용 가져오기
    private string GetReportContent()
    {
        return GameObject.Find("InputField_Report").GetComponent<UnityEngine.UI.InputField>().text;
    }
}
