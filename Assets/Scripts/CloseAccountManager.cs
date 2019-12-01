using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 회원 탈퇴
public class CloseAccountManager : MonoBehaviour
{
    GameObject closeAccountSuccessPanel;
    GameObject closeAccountFailPanel;

    // Start is called before the first frame update
    void Start()
    {
        closeAccountFailPanel = GameObject.Find("Alert_Fail");
        closeAccountFailPanel.SetActive(false);
        closeAccountSuccessPanel = GameObject.Find("Alert_Success");
        closeAccountSuccessPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 탈퇴에 성공한 경우 성공했다는 판넬 띄우기
    void CloseAccountSuccess()
    {
        closeAccountSuccessPanel.SetActive(true);
    }

    // 탈퇴에 성공한 경우 실패했다는 판넬 띄우기
    void CloseAccountFail()
    {
        closeAccountFailPanel.SetActive(true);
    }

    // 탈퇴하기 버튼 눌렀을 때
    public void OnCloseAccountButtonClicked()
    {
        // 응답을 받아와서 

        // 성공하면
        CloseAccountSuccess();

        // 실패하면 
        //CloseAccountFail();

    }

    public void OnAlertFailPanelClicked()
    {
        closeAccountFailPanel.SetActive(false);
    }

    // 탈퇴 성공 후에는 로그인 창으로 보낸다
    public void OnAlertSuccessPanelClicked()
    {
        // 로그인 창으로 이동
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
