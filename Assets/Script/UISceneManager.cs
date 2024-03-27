using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UISceneManager : MonoBehaviour
{
    public static UISceneManager UIscene;

    //public Button leftButton, rightButton;
    //public GameObject platform;
    public List<GameObject> veicales;
    public List<GameObject> scenePanals;
    public List<Button> buttons;
    public GameObject deffcultLevelParent;
    public int diffcultLevel;
    private int indexCount = 2;
    private void Start()
    {
       /* leftButton.onClick.AddListener(() => { LeftButton(); });
        rightButton.onClick.AddListener(() => { RightButton(); });*/
        //PlatformMove(); 
        AllVhaicalOff();
        AllPanals();
        ButtonsBubbleMove();
        veicales[2].SetActive(true);
        scenePanals[0].SetActive(true);
    }

    private void Update()
    {
        //platform.transform.Rotate(Vector3.up * 10f * Time.deltaTime);
    }

    public void AllVhaicalOff()
    {
        for (int i = 0; i < veicales.Count; i++)
        {
            veicales[i].SetActive(false);
        }
    }

    public void AllPanals()
    {
        for (int i = 0; i < scenePanals.Count; i++)
        {
            scenePanals[i].SetActive(false);
        }
        //platform.SetActive(false);
    }

    
    public void DeffacultOfSelection(int index)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].transform.DOScale(1.5f,0.001f).SetEase(Ease.Linear);
        }
        diffcultLevel = index;
        buttons[index].transform.DOScale(1.7f, 0.1f).SetEase(Ease.Linear);
        //tap sound
        //this is called in index can use switch case to setactive fall game objects 
    }

    public void ButtonsBubbleMove()
    {
        deffcultLevelParent.transform.DOMoveY(transform.position.y + 1.5f, 1f).SetEase(Ease.Linear).OnComplete(() =>
        deffcultLevelParent.transform.DOMoveY(transform.position.y - 3, 1.5f).SetEase(Ease.Linear).OnComplete(() => ButtonsBubbleMove()));
    }

    /* public void LeftButton()
   {
       indexCount--;
       AllVhaicalOff();
       veicales[indexCount].SetActive(true);
       if (indexCount == 0)
       {
           leftButton.gameObject.SetActive(false);
       }
       else
       {
           leftButton.gameObject.SetActive(true);
           rightButton.gameObject.SetActive(true);
       }
   }

   public void RightButton()
   {
       indexCount++;
       AllVhaicalOff();
       veicales[indexCount].SetActive(true);
       if (indexCount == veicales.Count - 1)
       {
           rightButton.gameObject.SetActive(false);
       }
       else
       {
           rightButton.gameObject.SetActive(true);
           leftButton.gameObject.SetActive(true);
       }
   }

   //this is not using for now but it will
        public void PlatformMove()
   {
       Debug.Log("555");
       platform.transform.DORotate(Vector3.up * 3.0f * Time.deltaTime, 2f);
   }*/
}
