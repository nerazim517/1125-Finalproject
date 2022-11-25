using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Experimental.GraphView;

public class EventSystem : MonoBehaviour
{
    public GameObject backpack;
    public GameObject ItemDetail;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseBackpack()
    {
        backpack.SetActive(false);
    }
    
    public void OpenBackpack()
    {
        if (backpack.active)
        {
            backpack.SetActive(false);
        }
        else
        {
            backpack.SetActive(true);
        }
        
        
    }

    public void OpenItemDetail(GameObject buttonGameObject = null)
    {
        ItemDetail.SetActive(true);
        print(buttonGameObject.tag);
        print(GameObject.FindWithTag("DataBase").GetComponent<Item_Database>().MyDic2[buttonGameObject.tag].Item_Name);
        print(GameObject.FindWithTag("DataBase").GetComponent<Item_Database>().MyDic2[buttonGameObject.tag].Count);
        print(GameObject.FindWithTag("DataBase").GetComponent<Item_Database>().MyDic2[buttonGameObject.tag].Item_Statement);
        ItemDetail.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = GameObject
            .FindWithTag("DataBase").GetComponent<Item_Database>().MyDic2[buttonGameObject.tag].Item_Name;
        ItemDetail.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "Amount: "+GameObject
            .FindWithTag("DataBase").GetComponent<Item_Database>().MyDic2[buttonGameObject.tag].Count.ToString();
        ItemDetail.transform.GetChild(2).gameObject.GetComponent<Image>().sprite = GameObject
            .FindWithTag("DataBase").GetComponent<Item_Database>().MyDic2[buttonGameObject.tag].ItemIcon;
    }    
    
    public void CloseItemDetail()
    {
        ItemDetail.SetActive(false);
    }    
}
