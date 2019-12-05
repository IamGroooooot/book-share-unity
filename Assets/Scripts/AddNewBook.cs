using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using static WWWHelper;
// 2_MyLib 씬에서 책 추가용
public class AddNewBook : MonoBehaviour
{
    GameObject addNewBookPanel;

    // Start is called before the first frame update
    void Start()
    {
        addNewBookPanel = GameObject.Find("AddNewBookPanel");

        // 현재 유저명을 불러와서 초기화해주세요
        // 제웅형
        SetUserName(StaticVar.ID);

        addNewBookPanel.SetActive(false);
    }

    //상단의 +버튼 눌렀을 때 새책 등록창 띄우기
    public void OnAddNewBookPanelClicked()
    {
        addNewBookPanel.SetActive(true);
    }

    // 새책 등록하기 버튼 눌렀을 때
    public void OnConfirmButtonClicked()
    {
        StartCoroutine(OnConfirmButtonClickedRoutine());
    }
    
    public IEnumerator OnConfirmButtonClickedRoutine()
    {

        // get data 
        // 사용자명 가져옴
        string userName = GetUserName();
        //User가 입력한 정보를 가져옴
        string ISBN = GetISBN();
        string status = GetBookStatus();

        Debug.Log("새책 등록하기 시도");
        Debug.Log(" >> 등록할 책 정보(책주인: " + userName + ", ISBN:" + ISBN + ", 책 상태: " + status + ")");

        var formData = new WWWForm();
        formData.AddField("lender_name", StaticVar.ID);
        formData.AddField("ISBN", ISBN);
        formData.AddField("status", status);

        var www = UnityWebRequest.Post(AddBookURL, formData);

        yield return www.SendWebRequest();


        if (!www.isNetworkError && !www.isHttpError)
        {
            var return_val = JsonUtility.FromJson<SuccessReturn>(www.downloadHandler.text);
            if (return_val.success)
            {
                Debug.Log(" >> 성공");
                UnityEngine.SceneManagement.SceneManager.LoadScene(
                    UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
                    );
            }
            else
            {
                Debug.Log(" >> 실패: 이것도 오류");

            }
        }

        else
        {
            Debug.Log(" >> 오류남!");
        }
    }

    // 닫기 버튼 눌렀을 때
    public void OnCloseButtonClicked()
    {
        // 창 닫음
        addNewBookPanel.SetActive(false);
    }

    // user가 입력한 책의 ISBN를 가져온다
    private string GetISBN()
    {
        string isbn = GameObject.Find("ISBN_InputField").GetComponent<UnityEngine.UI.InputField>().text;
        return isbn;
    }

    private void SetUserName(string name)
    {
        GameObject.Find("lender_name").GetComponent<UnityEngine.UI.Text>().text = "사용자 명: " + name;
    }

    // 유저명을 가져온다
    private string GetUserName()
    {
        string nameText = GameObject.Find("lender_name").GetComponent<UnityEngine.UI.Text>().text;
        if (nameText.Length<=7)
        {
            Debug.Log("오류, 사용자 명 불러올 수 없음");
            Debug.Log(" >> SetUserName했는지 확인해주세용");
        }

        // "사용자 명: " 잘라서 반환
        return nameText.Substring(7);
    }

    // user가 입력한 책의 상태를 가져온다
    private string GetBookStatus()
    {
        string status = GameObject.Find("Status_InputField").GetComponent<UnityEngine.UI.InputField>().text;
        return status;
    }

    // UI에 새책 추가
    private void AddBook(string title, string author, string publisher, string borrower, string ISBN)
    {
        GameObject.Find("BookSpawnManager").GetComponent<BookSpawnerManager>().AddBookToScrollView_MyLib(title, author, publisher, borrower, ISBN);
    }
}
