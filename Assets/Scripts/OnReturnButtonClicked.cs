using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnReturnButtonClicked : MonoBehaviour
{
    // 반납하기 버튼을 누르면 반납 완료라는 텍스트로 바꿔준다
    public void OnReturnBookButtonClicked()
    {
        // 이 책의 정보를 가져온다
        string bookTitle = GetBookTitle();
        string bookAuthor = GetBookAuthor();
        string bookPublisher = GetBookPublisher();
        string bookLenderer = GetBookBorrower();

        Debug.Log("책 반납 시도");
        Debug.Log(" >> 반납할 책 정보 (제목: " + bookTitle + ", 저자: " + bookAuthor + ", 출판사: " + bookPublisher + ", 대여한 곳: " + bookLenderer + ")");

        // 책 반납 시도
        // 제웅형

        // 반납 성공으로 버튼 텍스트 변경
        ToggleSuccessText();

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
