using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using static WWWHelper;
using Newtonsoft.Json;

// 대여하기 버튼을 눌렀을 때
public class OnLendRequestButtonClicked : MonoBehaviour
{
    // 대여하기 요청했을 때, 성공여부 
    public bool didLendRequestSucceed = true;

    // 대여하기 버튼을 눌렀을 때
    private void OnLendBookButtonClicked()
    {
        StartCoroutine(OnLendBookButtonClickedRoutine());
    }
    IEnumerator OnLendBookButtonClickedRoutine()
    {
        string ISBN;
        var www = UnityWebRequest.Post(
                GetRentBookURL(ISBN = transform.parent.GetComponent<BookTemplateControl>().ISBN),
                ""
            );

        yield return www.SendWebRequest();



        if (!www.isNetworkError && !www.isHttpError)
        {
            var ret = Newtonsoft.Json.JsonConvert.DeserializeObject<ArchiveDetailData>(www.downloadHandler.text);
            foreach (var book in ret.book_data_list)
            {
                var formData = new WWWForm();
                formData.AddField("ISBN", ISBN);
                formData.AddField("borrower", StaticVar.ID);
                formData.AddField("lender", book.owner_name);

                var www2 = UnityWebRequest.Post(
                        RentBookURL,
                        formData
                    );

                yield return www2.SendWebRequest();
                if (!www2.isNetworkError && !www2.isHttpError)
                {
                    var ret2 = Newtonsoft.Json.JsonConvert.DeserializeObject<SuccessReturn>(www.downloadHandler.text);
                    if (ret2.success)
                    {
                        ToggleSuccessText();
                        yield break;
                    }
                }
            }

                   
        }
        ToggleFailText();
    }

    // 대여 완료라는 텍스트로 바꿔준다
    private void ToggleSuccessText()
    {
        UnityEngine.UI.Text textComponent = transform.GetChild(0).GetComponent<UnityEngine.UI.Text>();
        if (textComponent.text == "책 대여하기")
        {
            Debug.Log(" >> 책 대여 성공!");
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
            Debug.Log(" >> 책 대여 불가!");
            textComponent.text = "대여 불가";
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

    private string GetBookLenderer()
    {
        string text = transform.parent.GetChild(3).GetComponent<UnityEngine.UI.Text>().text;
        // "책 주인: "을 잘라서 반환
        return text.Substring(6);
    }
}
