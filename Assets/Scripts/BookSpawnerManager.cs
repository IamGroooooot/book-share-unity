using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scroll View에 북 UI 스폰함
public class BookSpawnerManager : MonoBehaviour
{
    public GameObject prefab_BookTemplate;
    Transform bookParent;

    private void Awake()
    {
        bookParent = GameObject.Find("Content").transform;

    }

    // Start is called before the first frame update
    void Start()
    {
        bookParent = GameObject.Find("Content").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 책을 스크롤 뷰 UI에 추가해줍니다
    public void AddBookToScrollView_MyLib(string title, string author, string publisher, string borrower)
    {
        GameObject go = Instantiate(prefab_BookTemplate, bookParent);
        //go.transform.SetParent(bookParent);
        go.GetComponent<BookTemplateControl>().Initialize_BookTemplateData_MyLib(title, author, publisher, borrower);
        go.GetComponent<BookTemplateControl>().ExtendContainerSize();
        go.GetComponent<BookTemplateControl>().AllignPosition();
    }

    // 책을 스크롤 뷰 UI에 추가해줍니다
    public void AddBookToScrollView_LendLog(string title, string author, string publisher, string lenderer)
    {
        GameObject go = Instantiate(prefab_BookTemplate, bookParent);
        //go.transform.SetParent(bookParent);
        go.GetComponent<BookTemplateControl>().Initialize_BookTemplateData_LendLog(title, author, publisher, lenderer);
        go.GetComponent<BookTemplateControl>().ExtendContainerSize();
        go.GetComponent<BookTemplateControl>().AllignPosition();
    }

    // 책을 스크롤 뷰 UI에 추가해줍니다
    public void AddBookToScrollView_ListAll(string title, string author, string publisher, string lenderer)
    {
        GameObject go = Instantiate(prefab_BookTemplate, bookParent);
        //go.transform.SetParent(bookParent);
        go.GetComponent<BookTemplateControl>().Initialize_BookTemplateData_ListAll(title, author, publisher, lenderer);
        go.GetComponent<BookTemplateControl>().ExtendContainerSize();
        go.GetComponent<BookTemplateControl>().AllignPosition();
    }
}
