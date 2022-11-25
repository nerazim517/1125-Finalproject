using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class Block
{
    public GameObject Block_;
    public bool IsEmpty = true;
    public int Count = 0;
    public string Item_Name;
    public string Item_Statement;
    public Sprite ItemIcon;
}

public class Item_Database : MonoBehaviour
{
    public GameObject Block01_;
    public GameObject Block02_;
    public GameObject Block03_;
    public GameObject Block04_;
    
    //(1)新增物品
    public GameObject Rock;
    public GameObject Health_Pack;
    public GameObject Snow;
    
    //(2)新增物品Icon
    public Sprite Rock_Icon;
    public Sprite Health_Pack_Icon;
    public Sprite Snow_Icon;

    private void Start()
    {
        
        MyDic = new Dictionary<string, GameObject>()//(3)新增物品名稱對照表
        {
            {"Rock",Rock},
            {"Health_Pack",Health_Pack},
            {"Snow",Snow}
        };
        
        Item_Detail = new Dictionary<string, string>()//(4)新增物品敘述
        {
            { "Rock", "這是一顆石頭" },
            { "Health_Pack", "這是一個補血包" },
            { "Snow", "這是雪花" }
        };
        
        Item_Sprite = new Dictionary<string, Sprite>()//(5)新增物品圖片對照表
        {
            { "Rock", Rock_Icon},
            { "Health_Pack", Health_Pack_Icon },
            { "Snow", Snow_Icon }
        };
        
        Block01.Block_ = Block01_;
        Block02.Block_ = Block02_;
        Block03.Block_ = Block03_;
        Block04.Block_ = Block04_;
    }

    private void Update()
    {
        
    }

    //(5)新增物品使用效果
    public void Rock_Effect()
    {
        
    }
    
    public void Health_Bottle_Effect()
    {
        
    }
    /// ////////////////////////////////////////////////新增物品改上面///////////////////////////////////////////////
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////
    static Block Block01 = new Block();
    static Block Block02 = new Block();
    static Block Block03 = new Block();
    static Block Block04 = new Block();
    static Block Block05 = new Block();
    static Block Block06 = new Block();
    static Block Block07 = new Block();
    static Block Block08 = new Block();
    static Block Block09 = new Block();
    static Block Block10 = new Block();
    static Block Block11 = new Block();
    static Block Block12 = new Block();
    static Block Block13 = new Block();
    static Block Block14 = new Block();
    static Block Block15 = new Block();
    static Block Block16 = new Block();
    static Block Block17 = new Block();
    static Block Block18 = new Block();
    static Block Block19 = new Block();
    static Block Block20 = new Block();
    static Block Block21 = new Block();
    static Block Block22 = new Block();
    static Block Block23 = new Block();
    static Block Block24 = new Block();
    static Block Block25 = new Block();
    static Block Block26 = new Block();
    static Block Block27 = new Block();
    static Block Block28 = new Block();
    
    public Dictionary<string, GameObject> MyDic;
    
    public Dictionary<string, Block> MyDic2 = new Dictionary<string, Block>()
    {
        {"Block01",Block01},{"Block02",Block02},{"Block03",Block03},{"Block04",Block04}
    };
    
    public Dictionary<string, string> Item_Detail;
    
    public Dictionary<string, Sprite> Item_Sprite;
    
    public void Spawn_Item(string Monster_Name,Vector3 position_,Quaternion rotation_)
    {
        foreach (KeyValuePair<string, float> dropitem in GameObject.FindWithTag("DataBase").GetComponent<Monster_Database>()
                     .MyDic[Monster_Name].Drop_Item)
        {
            if (dropitem.Value >= Random.Range(1, 101))
            {
                Instantiate(MyDic[dropitem.Key], position_, rotation_);
                print(Item_Detail[dropitem.Key]);
            }
        }
    }

    public void HelloWorld()
    {
        print("HelloWorld");
    }
    public void PutItemIntoBackpack(string item_name)
    {
        string Block = "Block";
        
        
        for (int i = 1; i <= 4; i++)
        {
            string block_ = Block;
            if (i < 10)
            {
                block_ += "0";
            }
            block_ += i.ToString();
            if (MyDic2[block_].Item_Name==item_name)
            {
                MyDic2[block_].Count++;
                return;
            }
        }
        
        
        
        for (int i = 1; i <= 4; i++)
        {
            
            string block_ = Block;
            if (i < 10)
            {
                block_ += "0";
            }
            block_ += i.ToString();
            //print(block_);
            if (MyDic2[block_].IsEmpty)
            {
                MyDic2[block_].IsEmpty = false;
                MyDic2[block_].Item_Name = item_name;
                MyDic2[block_].Item_Statement = Item_Detail[item_name];
                MyDic2[block_].ItemIcon = Item_Sprite[item_name];
                MyDic2[block_].Count++;
                MyDic2[block_].Block_.transform.GetChild(0).gameObject.GetComponent<Image>().enabled = true;
                MyDic2[block_].Block_.transform.GetChild(0).gameObject.GetComponent<Image>().tag = block_;
                MyDic2[block_].Block_.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = Item_Sprite[item_name];
                return;
            }
        }


    }
    
}
