using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster_Player
{
    public Monster_Player()
    {
        
    }
    public GameObject GO;
}

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
    
    public GameObject Mutant_;
    public GameObject Mutant_Player_;
    public GameObject Arachnid_;
    public GameObject Arachnid_Player_;
    public GameObject Juggernaut_;
    public GameObject Juggernaut_Player_;
    
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
    
    
    static public Monster Mutant = new Monster(100,10,7,new Dictionary<string, float>()
    {
        {"Health_Bottle",20}
    });
    
    static public Monster_Player Mutant_Player = new Monster_Player();
    
    static public Monster Arachnid = new Monster(100,10,7,new Dictionary<string, float>()
    {
        {"Health_Bottle",20}
    });
    
    static public Monster_Player Arachnid_Player = new Monster_Player();
    
    static public Monster Juggernaut = new Monster(100,10,7,new Dictionary<string, float>()
    {
        {"Health_Bottle",20}
    });
    
    static public Monster_Player Juggernaut_Player = new Monster_Player();
    



    //(3)新增怪物名稱對照表
    public Dictionary<string, Monster> MyDic = new Dictionary<string, Monster>( )
    {
        {"Goblin",Goblin},{"Wolf",Wolf},
        {"Troll",Troll},{"Mutant",Mutant},
        {"Arachnid",Arachnid}, {"Juggernaut",Juggernaut}
    };
    
    public Dictionary<string, Monster_Player> MyDic2 = new Dictionary<string, Monster_Player>( )
    {
        {"Mutant",Mutant_Player},{"Arachnid", Arachnid_Player},
        {"Juggernaut", Juggernaut_Player}
    };
    
    private void Start()
    {
        
        //(4)新增對應GAMEOBJECT
        Goblin.GO = Goblin_;
        Wolf.GO = Wolf_;
        Troll.GO = Troll_;
        
        Mutant.GO = Mutant_;
        Mutant_Player.GO = Mutant_Player_;
        Arachnid.GO = Arachnid_;
        Arachnid_Player.GO = Arachnid_Player_;
        Juggernaut.GO = Juggernaut_;
        Juggernaut_Player.GO = Juggernaut_Player_;
        foreach (KeyValuePair<string, Monster> item in MyDic)
        {
            Monster_List.Add(item.Key);
            print(item.Value.GO.tag);
        }
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
