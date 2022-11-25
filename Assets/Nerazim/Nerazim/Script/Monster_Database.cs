using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster
{
    public Monster(int HP,int Dam,float Speed,Dictionary<string, float> DropItem)
    {
        Monster_HP = HP;
        Monster_Damage = Dam;
        
        Drop_Item = DropItem;
    }
    public GameObject GO;
    public int Monster_HP;
    public int Monster_Damage;
    public float Monster_Speed;
    public Dictionary<string, float> Drop_Item;
}

public class Monster_Database : MonoBehaviour
{
    //(1)新增怪物
    public GameObject Player_;
    public GameObject Goblin_;
    public GameObject Wolf_;
    public GameObject Troll_;
    public List<string> Monster_List = new List<string>();
    
    //(2)新增怪物血量、傷害、移動速度、掉落物品
    static public Monster Goblin = new Monster(100,10,5, new Dictionary<string, float>()
    {
        {"Health_Bottle",10},//掉落物,掉落機率(%)
        {"Rock",20}
    });
    static public Monster Troll = new Monster(200,15,3,new Dictionary<string, float>()
    {
        {"Health_Bottle",20}
    });
    static public Monster Wolf = new Monster(100,10,7,new Dictionary<string, float>()
    {
        {"Health_Bottle",20}
    });
    
    //(3)新增怪物名稱對照表
    public Dictionary<string, Monster> MyDic = new Dictionary<string, Monster>( )
    {
        {"Goblin",Goblin},{"Wolf",Wolf},
        {"Troll",Troll}
    };
    private void Start()
    {
        foreach (KeyValuePair<string, Monster> item in MyDic)
        {
            Monster_List.Add(item.Key);
        }
        //(4)新增對應GAMEOBJECT
        Goblin.GO = Goblin_;
        Wolf.GO = Wolf_;
        Troll.GO = Troll_;
    }
    
    public int Get_Monster_HP(string Monster_Name)
    {
        
        return MyDic[Monster_Name].Monster_HP;
    }
    
    public int Get_Monster_Damage(string Monster_Name)
    {
        return MyDic[Monster_Name].Monster_Damage;
    }
    
    public float Get_Monster_Speed(string Monster_Name)
    {
        return MyDic[Monster_Name].Monster_Speed;
    }
    
}
