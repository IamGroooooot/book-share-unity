using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using static WWWHelper;

public class LendManager : MonoBehaviour
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

        var www = UnityWebRequest.Post(OnBorrowURL, formData);

        yield return www.SendWebRequest();



        if (!www.isNetworkError && !www.isHttpError)
        {
            var return_val = JsonUtility.FromJson<OnBorrowData>(www.downloadHandler.text);

            foreach (var a in return_val.book_list)
            {
                bookSpawner.AddBookToScrollView_LendLog(a.title, a.author, a.publisher, a.lender_name, a.ISBN);
            }
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
