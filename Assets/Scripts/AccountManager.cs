using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using static WWWHelper;

public class AccountManager : MonoBehaviour
{
    // 아이디 중복 체크 성공 여부
    public bool isValidID = false; 

    // 회원가입 성공 여부
    public bool isRegisterSucceed = true; 


    // 아이디 중복 확인 버튼 눌렀을 때
    public void OnCheckIDButtonClicked()
    {

        // Get Input Data
        string id = GetID();

        Debug.Log("아이디 중복 확인 시도");
        Debug.Log(" >> 아이디: " + id);

        // 중복 확인 요청 보내기
        StartCoroutine(OnCheckCR());

    }


    IEnumerator OnCheckCR()
    {
        var formData = new WWWForm();
        formData.AddField("user_name", GetID());

        var www = UnityWebRequest.Post(OverlapUsernameURL, formData);

        yield return www.SendWebRequest();



        if (!www.isNetworkError && !www.isHttpError)
        {
            var return_val = JsonUtility.FromJson<SuccessReturn>(www.downloadHandler.text);
            if (return_val.success)
            {
                Debug.Log(" >> 성공: 아이디 중복 안 됨");

                GameObject.Find("Check_ID").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "사용 가능한 ID입니다";
                GameObject.Find("Check_ID").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().color = Color.green;
                yield break;

            }

            else
            {
                Debug.Log(" >> 실패: 아이디 중복됨");

                // 실패 시 중복된 아이디 텍스트
                GameObject.Find("Check_ID").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "중복된 ID입니다";
                GameObject.Find("Check_ID").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().color = Color.red;
                yield break;
            }
        }

        else
        {
            Debug.Log(" >> 오류임");

            // 실패 시 중복된 아이디 텍스트
            GameObject.Find("Check_ID").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "네트워크 오류";
            GameObject.Find("Check_ID").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().color = Color.red;
            yield break;
        }
    }







    // 계정 생성 버튼 눌렀을 때
    public void OnNewAccoutConfirmButtonClicked()
    {
        StartCoroutine(OnNACBCCheckCR());
    }

    IEnumerator OnNACBCCheckCR()
    {
        // Get Input Data
        string id = GetID();
        string password = GetPassword();
        Debug.Log("새로운 계정 생성 시도");
        Debug.Log(" >> 등록할 계정 정보(아이디: " + id + ", 비번: " + password + ")");

        var formData = new WWWForm();
        formData.AddField("user_name", GetID());
        formData.AddField("password", GetPassword());
        formData.AddField("user_address", GetID());// todo: 주소?

        var www = UnityWebRequest.Post(RegisterURL, formData);

        yield return www.SendWebRequest();
        



        if (!www.isNetworkError && !www.isHttpError)
        {
            var return_val = JsonUtility.FromJson<SuccessReturn>(www.downloadHandler.text);
            if (return_val.success)
            {
                Debug.Log(" >> 계정 생성 성공");

                // 회원가입 성공하면 로그인 화면으로 이동
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                yield break;

            }

            else
            {

                // 회원가입 실패 시
                Debug.Log(" >> 계정 생성 실패");
                // UI 띄울까... 
            }
        }

        else
        {
            Debug.Log(" >> 오류임");

            Debug.Log(" >> 계정 생성 실패");
            yield break;
        }
    }

    // User가 입력한 ID를 가져온다
    private string GetID()
    {
        string id = GameObject.Find("ID_InputField").GetComponent<UnityEngine.UI.InputField>().text;

        return id;
    }

    // User가 입력한 Password를 가져온다
    private string GetPassword()
    {
        string pw = GameObject.Find("PW_InputField").GetComponent<UnityEngine.UI.InputField>().text;

        return pw;
    }

}
