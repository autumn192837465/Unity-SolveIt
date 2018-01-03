using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DragAndDrop : MonoBehaviour {

    Image copyImage;
    Image oriImage;
    bool Dragging;
    public int remCard;

    public Canvas canvas;
    public GameObject ProblemPanel;

    public GameObject correct;
    public GameObject wrong;
    public GameObject ok;
    int ans;

    public string sceneName;

	// Use this for initialization
	void Start () {
             
    }
	
	// Update is called once per frame
	void Update () {
        if (Dragging)
        {            
            copyImage.transform.position = Input.mousePosition;
            if (Input.GetMouseButton(0))
            {
                Dragging = true;
            }
            else
            {
                Dragging = false;
                EndDrag();                
                Destroy(copyImage.gameObject);
            }
        }
	}

    public void BeginDrag(Image img)
    {        
        // mobile device
        if (Input.touchCount == 1 || Input.GetMouseButton(0))
        {
            Dragging = true;
            oriImage = img;
            copyImage = Instantiate(img, canvas.transform);
            img.gameObject.SetActive(false);
        }
        

        //pc device
        /*
        if (Input.GetMouseButton(0))
        {
            Dragging = true;
            oriImage = img;            
            copyImage = Instantiate(img, canvas.transform);                      
            img.gameObject.SetActive(false);
        }
        */
    }

    public void EndDrag()
    {        
        Dragging = false;
        bool placeSuccess=false;
        for(int i = 0; i < ProblemPanel.transform.childCount; i++)
        {
            GameObject child = ProblemPanel.transform.GetChild(i).gameObject;
            if(Vector2.Distance(child.transform.position, Input.mousePosition) < 65 && child.GetComponent<ProblemCardInfo>().CanPlace)
            {
                child.transform.GetChild(0).gameObject.SetActive(true);
                child.transform.GetChild(0).GetChild(0).GetComponent<Text>().text=copyImage.transform.GetChild(0).GetComponent<Text>().text;
                child.GetComponent<ProblemCardInfo>().CheckAns(int.Parse(copyImage.transform.GetChild(0).GetComponent<Text>().text));
                child.transform.GetChild(0).gameObject.SetActive(true);
                child.GetComponent<ProblemCardInfo>().CanPlace = false;
                remCard--;
                Result();
                placeSuccess = true;
            }            
        }
        if (placeSuccess == false)
        {
            oriImage.gameObject.SetActive(true);
        }
        Destroy(copyImage.gameObject);
    }

    public void Restart()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void ChangeToLevelScene()
    {
        SceneManager.LoadScene("LevelScene");
    }
    public void Result()
    {
        if (remCard == 0)
        {
            bool res = true;
            for(int i = 0; i < ProblemPanel.transform.childCount; i++)
            {
                if(ProblemPanel.transform.GetChild(i).GetComponent<ProblemCardInfo>().correct == false)
                {
                    res = false;                    
                    break;
                }
            }

            if(res == false)
            {
                wrong.gameObject.SetActive(true);
            }
            else
            {
                correct.gameObject.SetActive(true);
                PlayerPrefs.SetInt(sceneName, 1);
            }
            StartCoroutine(OK());            
        }
    }
    IEnumerator OK()
    {
        yield return new WaitForSeconds(0.4f);
        ok.SetActive(true);        
    }




}
