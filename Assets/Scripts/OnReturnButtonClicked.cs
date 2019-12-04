using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using static WWWHelper;

public class OnReturnButtonClicked : MonoBehaviour
{
    // 반납하기 버튼을 누르면 반납 완료라는 텍스트로 바꿔준다
    public void OnReturnBookButtonClicked()
    {

    /*
        // 이 책의 정보를 가져온다
        string bookTitle = GetBookTitle();
        string bookAuthor = GetBookAuthor();
        string bookPublisher = GetBookPublisher();
        string bookLenderer = GetBookBorrower();
    */

        StartCoroutine(OnReturnBookButtonClickedRoutine());

    }
    IEnumerator OnReturnBookButtonClickedRoutine()
    {
        var formData = new WWWForm();
        formData.AddField("borrower", StaticVar.ID);
        formData.AddField("ISBN", transform.parent.GetComponent<BookTemplateControl>().ISBN);

        var www = UnityWebRequest.Post(BookReturnURL, formData);

        yield return www.SendWebRequest();
        if (!www.isNetworkError && !www.isHttpError)
        {
            var return_val = JsonUtility.FromJson<SuccessReturn>(www.downloadHandler.text);
            if (return_val.success)
            {
                Debug.Log(" >> 반납 성공");
                ToggleSuccessText();
            }

            else
            {
                Debug.Log(" >> 실패: 아이디 중복됨");
                yield break;
            }
        }

        else
        {
            Debug.Log(" >> 오류임");
        }


    }


    // 반납 완료라고 텍스트 설정
    private void ToggleSuccessText()
    {
        UnityEngine.UI.Text textComponent = transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
        if (textComponent.text == "책 반납하기")
        {
            textComponent.text = "반납 완료";
            textComponent.color = Color.green;
        }
    }

    // 반납 실패라고 텍스트 설정
    private void ToggleFailText()
    {
        UnityEngine.UI.Text textComponent = transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
        if (textComponent.text == "책 반납하기")
        {
            textComponent.text = "반납 실패";
            textComponent.color = Color.red;
        }
    }

    private string GetBookTitle()
    {
        string text = transform.parent.GetChild(0).GetComponent<UnityEngine.UI.Text>().text;
        // "책 제목: "을 잘라서 반환
        return text.Substring(6);
    }

    private string GetBookAuthor()
    {
        string text = transform.parent.GetChild(1).GetComponent<UnityEngine.UI.Text>().text;
        // "저자: "을 잘라서 반환
        return text.Substring(4);
    }

    private string GetBookPublisher()
    {
        string text = transform.parent.GetChild(2).GetComponent<UnityEngine.UI.Text>().text;
        // "출판사: "을 잘라서 반환
        return text.Substring(5);
    }

    private string GetBookBorrower()
    {
        string text = transform.parent.GetChild(3).GetComponent<UnityEngine.UI.Text>().text;
        // "대여한 곳: "을 잘라서 반환
        return text.Substring(7);
    }
}
