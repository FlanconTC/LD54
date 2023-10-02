using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CrateSlider : MonoBehaviour
{
    public GameObject[] boxesToSlide; 
    private float timeSinceLastSlide = 0f;
    [SerializeField] public Text _text;
    private float slideInterval = 32f; 
    public CrateBehavior behavior;
    public float offsetX;
  
    private void Start()
    {
      
        behavior = GetComponent<CrateBehavior>();
        StartCoroutine(GenerateAndSlideBox());
    }

    void Update()
    {
        timeSinceLastSlide += Time.deltaTime;
        if (slideInterval - timeSinceLastSlide - 2f > 0f) 
        { 
        _text.text = slideInterval - timeSinceLastSlide - 2f+ " s";
        
        }
        if (timeSinceLastSlide >= slideInterval)
        {
            timeSinceLastSlide = 0f;
            StartCoroutine(GenerateAndSlideBox());
        }
        
    
        
       
    }

    IEnumerator GenerateAndSlideBox()
    {
        
        int randomIndex = Random.Range(0, boxesToSlide.Length);
        if (boxesToSlide.Length > 0)
        {
            GameObject selectedBox = boxesToSlide[randomIndex];
        Vector3 startPosition = new Vector3(Camera.main.ViewportToWorldPoint(Vector3.one).x + 1f, Camera.main.transform.position.y, 0f);
        Vector3 targetPosition = new Vector3(Camera.main.transform.position.x + offsetX, (int)Camera.main.transform.position.y, 0f);
        GameObject newBox = Instantiate(selectedBox, startPosition, Quaternion.identity);
        float duration = 1f; 
            timeSinceLastSlide -= duration;
        float startTime = Time.time;
  
        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            newBox.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }
        StartCoroutine(SlideAndDestroyBox(newBox));
    }
    else
    {
        Debug.LogWarning("Aucune boîte à faire glisser n'a été spécifiée dans le tableau 'boxesToSlide'.");
    }
    }

    IEnumerator SlideAndDestroyBox(GameObject box)
    {
         
        yield return new WaitForSeconds(30f);

        behavior.calculPoint(box);
        Vector3 destination = new Vector3(Camera.main.transform.position.x, (int)Camera.main.transform.position.y + 100f, 0f);
        float duration = 1f; 
        float startTime = Time.time;
        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            box.transform.position = Vector3.Lerp(box.transform.position, destination, t);
            yield return null;
        }
       
        Destroy(box);

    }

    IEnumerator wait2f()
    {
        yield return new WaitForSeconds(2f);
    }
}
