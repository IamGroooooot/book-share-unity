using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportManager : MonoBehaviour
{
    GameObject alertPanel;
    // Start is called before the first frame update
    void Start()
    {
        alertPanel = GameObject.Find("Alert");
        alertPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnReportButtonClicked()
    {
        // 리포트 보내기 POST

        // Alert 패널 띄우기
        alertPanel.SetActive(true);

    }

    public void OnAlertPanelClicked()
    {
        // main창으로 이동
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
