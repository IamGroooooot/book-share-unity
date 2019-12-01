using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccountManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCheckIDButtonClicked()
    {
        Debug.Log("아이디 중복 확인");


    }

    public void OnNewAccoutConfirmButtonClicked()
    {
        Debug.Log("새로운 계정 생성");

        // 성공하면 로그인 화면으로 이동
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        
        // 아니면 ? 

    }
}
