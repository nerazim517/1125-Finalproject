using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Canvas : MonoBehaviour
{
    public Transform Orange;
    public Transform Orange_Text;
    public Transform FinishedScanText;
    public Transform HpBar;
    public Transform MpBar;
    public Transform ShieldBar;
    public Transform HpBar_Text;
    public Transform MpBar_Text;
    public Transform ShieldBar_Text;
    public float Current_Amount = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //let the changing progress only appear during scanning 
        if (Current_Amount == 0)
        {
            Orange_Text.gameObject.SetActive(false);
        }
        else//let the progress UI swift with mouse
        {
            Orange_Text.gameObject.SetActive(true);
            Vector2 position;
            RectTransform rect = GameObject.Find ("Canvas").transform as RectTransform;
            Vector2 point = Input.mousePosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle (rect, point, null, out position);
            
            Orange.transform.localPosition = position+new Vector2(0,0);
            Orange_Text.transform.localPosition = position+new Vector2(0,-40);
        }
        //print(Current_Amount);
        
        //set value to the canvas
        Orange.GetComponent<Image>().fillAmount = Current_Amount/100f;
        Orange_Text.GetComponent<TextMeshProUGUI>().text = ((int)Current_Amount).ToString() + "%";
        FinishedScanText.GetComponent<TextMeshProUGUI>().text = "Finished Scan: " + GameObject.FindWithTag("Player").GetComponent<Changing>().Scanned_Monster;
        HpBar.GetComponent<Image>().fillAmount = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>().HP/GameObject.FindWithTag("Player").GetComponent<PlayerStatus>().InitHP;
        MpBar.GetComponent<Image>().fillAmount = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>().MP/GameObject.FindWithTag("Player").GetComponent<PlayerStatus>().InitMP;
        ShieldBar.GetComponent<Image>().fillAmount = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>().Shield/GameObject.FindWithTag("Player").GetComponent<PlayerStatus>().InitHP;
        HpBar_Text.GetComponent<TextMeshProUGUI>().text = "HP: " + GameObject.FindWithTag("Player").GetComponent<PlayerStatus>().HP + "/" + GameObject.FindWithTag("Player").GetComponent<PlayerStatus>().InitHP;
        MpBar_Text.GetComponent<TextMeshProUGUI>().text = "MP: " + GameObject.FindWithTag("Player").GetComponent<PlayerStatus>().MP + "/" + GameObject.FindWithTag("Player").GetComponent<PlayerStatus>().InitMP;
        ShieldBar_Text.GetComponent<TextMeshProUGUI>().text = "Shield: " + GameObject.FindWithTag("Player").GetComponent<PlayerStatus>().Shield;

    }
}
