using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using static WWWHelper;
using Newtonsoft.Json;

public class MyLibManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LendedBook());
    }
    IEnumerator LendedBook()
    {
        BookSpawnerManager bookSpawner = GameObject.Find("BookSpawnManager").GetComponent<BookSpawnerManager>();
        var formData = new WWWForm();
        formData.AddField("borrower", StaticVar.ID);

        var www = UnityWebRequest.Post(OnLendURL, formData);

        yield return www.SendWebRequest();



        if (!www.isNetworkError && !www.isHttpError)
        {
            var return_val = JsonConvert.DeserializeObject<OnLendData>(www.downloadHandler.text);

            foreach (var a in return_val.book_list)
            {
                bookSpawner.AddBookToScrollView_ListAll(a.title, a.author, a.publisher, a.borrower_name, a.ISBN);
            }
            //bookSpawner.AddBookToScrollView_ListAll("걸리버여행8", "고주형", "중앙출판사", "김호성");
        }
        else
        {
            Debug.Log(" >> 오류임");
            yield break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
