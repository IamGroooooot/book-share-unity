using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnReportButtonClicked()
    {
        // 리포트 보내기 POST

        // main창으로 이동
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
}
