using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForTest_ListAllBook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BookSpawnerManager bookSpawner = GameObject.Find("BookSpawnManager").GetComponent<BookSpawnerManager>();
        bookSpawner.AddBookToScrollView_ListAll("걸리버여행1", "고주형", "중앙출판사", "김호성");
        bookSpawner.AddBookToScrollView_ListAll("걸리버여행2", "고주형", "중앙출판사", "김호성");
        bookSpawner.AddBookToScrollView_ListAll("걸리버여행3", "고주형", "중앙출판사", "김호성");
        bookSpawner.AddBookToScrollView_ListAll("걸리버여행4", "고주형", "중앙출판사", "김호성");
        bookSpawner.AddBookToScrollView_ListAll("걸리버여행5", "고주형", "중앙출판사", "김호성");
        bookSpawner.AddBookToScrollView_ListAll("걸리버여행6", "고주형", "중앙출판사", "김호성");
        bookSpawner.AddBookToScrollView_ListAll("걸리버여행7", "고주형", "중앙출판사", "김호성");
        bookSpawner.AddBookToScrollView_ListAll("걸리버여행8", "고주형", "중앙출판사", "김호성");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
