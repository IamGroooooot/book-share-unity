using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnReturnButtonClicked : MonoBehaviour
{
    // 반납하기 버튼을 누르면 반납 완료라는 텍스트로 바꿔준다
    public void OnReturnBookButtonClicked()
    {
        UnityEngine.UI.Text textComponent = transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
        if (textComponent.text == "책 반납하기")
        {
            textComponent.text = "반납 완료";
            textComponent.color = Color.green;
            ReturnBook();
        }
    }
    
    void ReturnBook()
    {
        Debug.Log("책 반납");
        // 반납한다는 요청 보내기 

    }
}
