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
    public void Initialize_BookTemplateData(string title, string author, string publisher, string lenderer)
    {
        SetTitle(title);
        SetAuthor(author);
        SetPublisher(publisher);
        SetLenderer(lenderer);
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
        GameObject.Find("Content").GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, GameObject.Find("Content").GetComponent<RectTransform>().rect.height + bookTemplateHeight);
    }

    public void SetRectLocalPosition(Vector2 pos)
    {
        GetComponent<RectTransform>().localPosition = pos;
    }

    private void SetTitle(string title)
    {
        transform.Find("Title").GetComponent<UnityEngine.UI.Text>().text = "책 제목: " + title;
    }

    private void SetAuthor(string author)
    {
        transform.Find("Author").GetComponent<UnityEngine.UI.Text>().text = "저자: " + author;
    }

    private void SetPublisher(string publisher)
    {
        transform.Find("Publisher").GetComponent<UnityEngine.UI.Text>().text = "출판사: " + publisher;
    }

    private void SetLenderer(string lenderer)
    {
        transform.Find("Lenderer").GetComponent<UnityEngine.UI.Text>().text = "대여한 곳: " + lenderer;
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

    private void OnBecameInvisible()
    {
        //this.gameObject.SetActive(false);
    }

    private void OnBecameVisible()
    {
        //this.gameObject.SetActive(true);
    }
}
