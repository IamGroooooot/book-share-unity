using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLendRequestButtonClicked : MonoBehaviour
{
    // 대여하기 버튼을 누르면 대여 완료라는 텍스트로 바꿔준다
    public void ToggleSuccessText()
    {
        UnityEngine.UI.Text textComponent = transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
        if (textComponent.text == "책 대여하기")
        {
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
            textComponent.text = "대여 불가";
            textComponent.color = Color.red;
        }
    }
}
