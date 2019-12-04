using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using static WWWHelper;
using Newtonsoft.Json;

public class ListAllBooksManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LendedBook());
    }
    IEnumerator LendedBook()
    {
        BookSpawnerManager bookSpawner = GameObject.Find("BookSpawnManager").GetComponent<BookSpawnerManager>();

        var www = UnityWebRequest.Get(BookFindURL);

        yield return www.SendWebRequest();



        if (!www.isNetworkError && !www.isHttpError)
        {
            var return_val = JsonConvert.DeserializeObject<AllBookData>(www.downloadHandler.text);

            foreach (var a in return_val.book_list)
            {
                bookSpawner.AddBookToScrollView_ListAll(a.title, a.author, a.publisher, a.lenderer, a.ISBN);
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
