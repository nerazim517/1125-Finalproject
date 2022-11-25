using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changing : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    private bool IsHitingMonster = false;
    bool ishit = false;
    public float t = 0f;
    private string Selected_monster_name;
    private string Last_selected_monster_name;
    public string Scanned_Monster;
    private GameObject Scanned_Monster_;
    public int status =0; //0:player 1:monster
    // Start is called before the first frame update
    void Start()
    {
        Scanned_Monster = "";
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Input.GetKey(KeyCode.Q) && Physics.Raycast(ray, out hit))
        {
            //check if hiting monster 
            foreach (string Monster_name in GameObject.FindWithTag("DataBase").GetComponent<Monster_Database>()
                         .Monster_List)
            {
                if (hit.collider.gameObject.transform.tag == Monster_name)
                {
                    IsHitingMonster = true;
                }
            }
            
            if (IsHitingMonster)
            {
                Selected_monster_name = hit.collider.gameObject.transform.tag;
            
                if (Last_selected_monster_name != Selected_monster_name)
                {
                    t=0;
                }
                else
                {
                    t++;
                }

                Last_selected_monster_name = Selected_monster_name;
            
                ishit = true;
                
                IsHitingMonster = false;
            }
            else
            {
                ishit = false;
                t = 0f;
            }
            //print(hit.collider.gameObject.transform.tag);
        }
        else
        {
            ishit = false;
            t = 0f;
        }
        
        //make sure the progress canvas text won't exceed 100%
        if (t / 3 <= 100)
        {
            GameObject.FindWithTag("Canvas").GetComponent<Canvas>().Current_Amount = t/3;
        }
        else if(t / 3 >= 100)
        {
            Scanned_Monster = hit.collider.gameObject.transform.tag;
            Scanned_Monster_ = GameObject.FindWithTag("DataBase").GetComponent<Monster_Database>()
                .MyDic[Scanned_Monster].GO;
            print("Finish Scan:" + Scanned_Monster);
        }
        
        //if currently you are in human state and finished scanning,then press P to change to the monster you've scanned  
        
       // if (Input.GetKey(KeyCode.E)&&(status==0)) 
        if (Input.GetKey(KeyCode.E))
        {
            if (Scanned_Monster_)
            {
                ChangeToMonster();
            }
            else//if the monster you scanned is not in the mon_db
            {
                print("Scanned_Monster current not exist in monster database");
            }
        }
        
        //if you are in the monster state,then press R to return human state
        if (Input.GetKey(KeyCode.R)&&(status==1))
        {
            Instantiate(GameObject.FindWithTag("DataBase").GetComponent<Monster_Database>().Player_, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }

    }

    public void ChangeToMonster()
    {
        GameObject new_player = Instantiate(Scanned_Monster_, this.transform.position, this.transform.rotation);
        GameObject.FindWithTag("MainCamera").transform.parent = new_player.transform;
        new_player.GetComponent<Changing>().enabled = true;
        new_player.GetComponent<Changing>().status = 1;
        new_player.GetComponent<MonsterStatus>().enabled = false;
        new_player.GetComponent<PlayerStatus>().enabled = true;
        new_player.GetComponent<MonsterMove>().enabled = true;
        new_player.transform.tag = "Player";
        new_player.transform.name = "Player";
        Destroy(this.gameObject);
    }
}
