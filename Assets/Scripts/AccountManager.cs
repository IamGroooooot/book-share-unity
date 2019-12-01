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
        // 성공하면 성공 텍스트
        GameObject.Find("Check_ID").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "사용 가능한 ID입니다";
        GameObject.Find("Check_ID").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().color = Color.green;
        // 실패 시 다시 시도 텍스트
        // GameObject.Find("Check_ID").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "중복된 ID입니다";
        // GameObject.Find("Check_ID").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().color = Color.red;
    }

    public void OnNewAccoutConfirmButtonClicked()
    {
        Debug.Log("새로운 계정 생성");
        

        // 성공하면 로그인 화면으로 이동
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        
        // 실패시?

    }
}
