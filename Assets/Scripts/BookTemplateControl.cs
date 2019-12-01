using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTemplateControl : MonoBehaviour
{
    // variables
    private static float bookTemplateHeight = 250f;
    static float offset = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 북 템플릿 데이터 초기화할 때 이거 쓰시면 됩니당
    // LendLog 씬용
    public void Initialize_BookTemplateData_LendLog(string title, string author, string publisher, string lenderer)
    {
        SetTitle("책 제목: " + title);
        SetAuthor("저자: " + author);
        SetPublisher("출판사: " + publisher);
        SetLenderer("대여한 곳: " + lenderer);
    }

    // 북 템플릿 데이터 초기화할 때 이거 쓰시면 됩니당
    // MyLib 씬용
    public void Initialize_BookTemplateData_MyLib(string title, string author, string publisher, string borrower)
    {
        SetTitle("책 제목: " + title);
        SetAuthor("저자: " + author);
        SetPublisher("출판사: " + publisher);
        SetLenderer("빌려간 사람: " + borrower);
    }

    // 북 템플릿 데이터 초기화할 때 이거 쓰시면 됩니당
    // ListAll 씬용
    public void Initialize_BookTemplateData_ListAll(string title, string author, string publisher, string owner)
    {
        SetTitle("책 제목: " + title);
        SetAuthor("저자: " + author);
        SetPublisher("출판사: " + publisher);
        SetLenderer("책 주인: "+ owner);
        SetLendButton(true);
    }

    public void SetLendButton(bool isActive)
    {
        transform.GetChild(4).gameObject.SetActive(isActive);
    }

    // 자동 배치 :: 가장 밑에 있는 북 찾아서 그 아래에 바로 배치
    public void AllignPosition()
    {
        // 가장 밑에 있는 것 찾음
        float lowest = FindLowestBookTemplateLocalPosition();

        // 가장 아래에 offset만큼 띄우고 배치
        SetRectLocalPosition(new Vector2(0,lowest-offset-bookTemplateHeight));
    }

    // Container Size를 Book Template만큼 늘려준다.
    public void ExtendContainerSize()
    {
        int spawnedBookLength = GameObject.FindGameObjectsWithTag("BookTemplate").Length;
        // Container가 북을 다 담을 만큼 크기 않는지 확인
        float bookCoveredSize = (bookTemplateHeight + offset)*spawnedBookLength;
        if (GameObject.Find("Content").GetComponent<RectTransform>().rect.height < bookCoveredSize)
        {
            GameObject.Find("Content").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, GameObject.Find("Content").GetComponent<RectTransform>().rect.height + bookTemplateHeight);
        }
    }

    public void SetRectLocalPosition(Vector2 pos)
    {
        GetComponent<RectTransform>().localPosition = pos;
    }

    private void SetTitle(string title)
    {
        transform.Find("Title").GetComponent<UnityEngine.UI.Text>().text = title;
    }

    private void SetAuthor(string author)
    {
        transform.Find("Author").GetComponent<UnityEngine.UI.Text>().text = author;
    }

    private void SetPublisher(string publisher)
    {
        transform.Find("Publisher").GetComponent<UnityEngine.UI.Text>().text = publisher;
    }

    private void SetLenderer(string lenderer)
    {
        transform.Find("Lenderer").GetComponent<UnityEngine.UI.Text>().text = lenderer;
    }

    private float FindLowestBookTemplateLocalPosition()
    {
        float min = 1419f;
        foreach (var item in GameObject.FindGameObjectsWithTag("BookTemplate"))
        {
            if (min > item.GetComponent<RectTransform>().localPosition.y) {
                min = item.GetComponent<RectTransform>().localPosition.y;
            }
        }
        return min;
    }
    
}
