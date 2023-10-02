using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class CrateBehavior : MonoBehaviour
{
    [SerializeField] public Text Score;
    private int totalPoints = 0;
    [SerializeField] public Text lifeNumber;
    public int numberOflife = 3;
    public bool canLooseLife = true;
    public TimeController _time;

    public void Update()
    {
        lifeNumber.text = numberOflife + " ";
        Score.text = "" + totalPoints;
    }

    public int calculPoint(GameObject crate)
    {
        int ajoutPoint = 0;
        bool ajout = true;
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        GameObject[] places = GameObject.FindGameObjectsWithTag("pos");
        List<GameObject> usedPlaces = new List<GameObject>();
      
        foreach (GameObject box in boxes)
        {
            int compteurPoint = 0;
            Transform[] points = new Transform[4];
            for (int i = 1; i <= 4; i++)
            {
                Transform point = box.transform.Find("point" + i);
                if (point != null)
                {
                   
                    points[i - 1] = point;
                }
            }

           

            foreach (Transform point in points)
            {
               

                foreach (GameObject place in places)
                {
                    BoxCollider2D placeBox = place.GetComponent<BoxCollider2D>();
                    BoxCollider2D pointBox = point.GetComponent<BoxCollider2D>();
                    if (!usedPlaces.Contains(place))
                    {
                        if (placeBox.bounds.min.x < pointBox.bounds.min.x && placeBox.bounds.max.x > pointBox.bounds.max.x)
                        {
                            if (placeBox.bounds.min.y < pointBox.bounds.min.y && placeBox.bounds.max.y > pointBox.bounds.max.y) 
                            {
                                usedPlaces.Add(place);
                                compteurPoint++;
                                break; 
                            }
                        }
                    }
                }
            }
     
            if (compteurPoint == 4)
            {
                ajoutPoint += 100;
            }
            else if(compteurPoint != 0)
            {
                if (canLooseLife) 
                { 
                numberOflife --;
                ajout = false;
                    canLooseLife = false;
                }
            }

        }

        if(ajoutPoint < 300) 
        {
            if (canLooseLife)
            {
                ajout = false;
                numberOflife--;
                canLooseLife = false;
            }
        }

        if (ajout) 
        {
            totalPoints += ajoutPoint;
        }
        foreach (GameObject box in boxes)
        {
            Destroy(box);
        }
        if(numberOflife == 0) 
        {
            _time.GameOver(totalPoints);
            gameOvr();
        }
        canLooseLife = true;
        return totalPoints;
    }


    public void gameOvr()
    {
        numberOflife = 3;

        totalPoints = 0;
    }

   
}
