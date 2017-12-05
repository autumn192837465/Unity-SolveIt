using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour {

    Image copyImage;
    Image oriImage;
    bool Dragging;
    

    public Canvas canvas;

    public GameObject ProblemPanel;
    int ans;

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
        if (Input.touchCount == 1)
        {
            Dragging = true;
            oriImage = img;
            copyImage = Instantiate(img, canvas.transform);
            img.gameObject.SetActive(false);
        }

        //pc device
        if (Input.GetMouseButton(0))
        {
            Dragging = true;
            oriImage = img;            
            copyImage = Instantiate(img, canvas.transform);                      
            img.gameObject.SetActive(false);
        }

    }

    public void EndDrag()
    {        
        Dragging = false;
        bool placeSuccess=false;
        for(int i = 0; i < ProblemPanel.transform.childCount; i++)
        {            
            if(Vector2.Distance(ProblemPanel.transform.GetChild(i).transform.position, Input.mousePosition) < 65 && ProblemPanel.transform.GetChild(i).GetComponent<ProblemCardInfo>().CanPlace)
            {
                ProblemPanel.transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
                ProblemPanel.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<Text>().text=copyImage.transform.GetChild(0).GetComponent<Text>().text;
                ProblemPanel.transform.GetChild(i).GetComponent<ProblemCardInfo>().CheckAns(int.Parse(copyImage.transform.GetChild(0).GetComponent<Text>().text));
                placeSuccess = true;
            }            
        }
        if (placeSuccess == false)
        {
            oriImage.gameObject.SetActive(true);
        }
        Destroy(copyImage.gameObject);
    }
}
