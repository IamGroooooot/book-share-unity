using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // 대여내역 클릭
    public void LoadScene_LendLog()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    // 내 책장 클릭
    public void LoadScene_MyLib()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

    // 모든 책 클릭
    public void LoadScene_ListAllBook()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(5);
    }

    // 내 지역 설정 클릭
    public void LoadScene_SetLocation()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(6);
    }

    // 지역 인증하기 클릭
    public void OnClick_AuthLocation()
    {
        if (UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.CoarseLocation))
        {
            Debug.Log("이미 인증했습니다.");
            // 패널 띄우기
        }
        else
        {
            UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.CoarseLocation);
            Debug.Log("인증창이 뜸.");

            // 권한 창 뜸
        }
    }

    // 고객센터 클릭
    public void LoadScene_ServiceCenter()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(7);
    }

    // 설정 클릭
    public void LoadScene_Setting()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(8);
    }

    // 메인 화면으로 가기
    public void LoadScene_Main()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    
}
