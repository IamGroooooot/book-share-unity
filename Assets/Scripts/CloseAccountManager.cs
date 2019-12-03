using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 회원 탈퇴
public class CloseAccountManager : MonoBehaviour
{
    // 탈퇴 성공 여부
    public bool didClossAccountSucceed = true;

    // 탈퇴 성공여부 메시지 띄우는 창들
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

    // 탈퇴하기 버튼 눌렀을 때
    public void OnCloseAccountButtonClicked()
    {
        // get data
        // 제웅형
        // string userID = "나의 아이디";

        Debug.Log("탈퇴 시도");
        // 탈퇴시도하기
        // 제웅형

        // 탈퇴 성공하면
        if (didClossAccountSucceed)
        {
            Debug.Log("탈퇴 성공 - 메인창으로 돌아감");
            // 저장된 유저 데이터 모두 초기화
            // 제웅형

            CloseAccountSuccess();
        }
        else
        {
            Debug.Log("탈퇴 실패");
            // 탈퇴 실패하면
            CloseAccountFail();
        }
    }

    // 탈퇴 실패창 눌렀을 때 창 닫음
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

    // 탈퇴에 성공한 경우 성공했다는 판넬 띄우기
    private void CloseAccountSuccess()
    {
        closeAccountSuccessPanel.SetActive(true);
    }

    // 탈퇴에 성공한 경우 실패했다는 판넬 띄우기
    private void CloseAccountFail()
    {
        closeAccountFailPanel.SetActive(true);
    }
}
