using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 대여하기 버튼을 눌렀을 때
public class OnLendRequestButtonClicked : MonoBehaviour
{
    // 대여하기 요청했을 때, 성공여부 
    public bool didLendRequestSucceed = true;

    // 대여하기 버튼을 눌렀을 때
    private void OnLendBookButtonClicked()
    {
        // 책 대여하기 시도
        Debug.Log("책 대여 시도");


        // 대여하기 성공하면 대여완료 텍스트 출력
        if(didLendRequestSucceed)
        {
            ToggleSuccessText();
        }
        else
        {
            ToggleFailText();
        }
        
    }

    // 대여 완료라는 텍스트로 바꿔준다
    private void ToggleSuccessText()
    {
        UnityEngine.UI.Text textComponent = transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
        if (textComponent.text == "책 대여하기")
        {
            Debug.Log(" - 책 대여 성공!");
            textComponent.text = "대여 완료";
            textComponent.color = Color.green;
        }
    }

    // 대여하기 버튼을 누르면 대여 불가라는 텍스트를 바꿔준다
    public void ToggleFailText()
    {
        UnityEngine.UI.Text textComponent = transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
        if (textComponent.text == "책 대여하기")
        {
            Debug.Log(" - 책 대여 불가!");
            textComponent.text = "대여 불가";
            textComponent.color = Color.red;
        }
    }
}
