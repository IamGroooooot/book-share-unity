using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddNewBook : MonoBehaviour
{
    GameObject addNewBookPanel;

    // Start is called before the first frame update
    void Start()
    {
        addNewBookPanel = GameObject.Find("AddNewBookPanel");
        addNewBookPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //상단의 +버튼 눌렀을 때 새 책 등록창 띄우기
    public void OnAddNewBookPanelClicked()
    {
        addNewBookPanel.SetActive(true);
    }

    // 등록하기 버튼 눌렀을 때
    public void OnConfirmButtonClicked()
    {
        // 새책 추가
        GameObject.Find("BookSpawnManager").GetComponent<BookSpawnerManager>().AddBookToScrollView_MyLib("펭수의 일기", "고주형", "중앙대", "원범쓰");

        // 창 닫음
        addNewBookPanel.SetActive(false);
    }
}
