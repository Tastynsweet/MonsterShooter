using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRocking : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float bopAmount;
    [SerializeField] private float bopSpeed;
    [SerializeField] private float lerpSpeed;

    private Vector2 originalPos;
    private RectTransform rect;
    [SerializeField] private bool isBoat;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        originalPos = rect.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float bop = Mathf.Sin(Time.time * bopSpeed) * bopAmount;                                              //Calculate Y offset
        Vector2 targetPos;
        
        if (isBoat)
        {
            targetPos = originalPos + new Vector2(0, bop);                                                    //move boat
        }
        else
        {
            targetPos = originalPos + new Vector2(bop, 0);                                                   //Move clouds
        }

        rect.anchoredPosition = Vector2.Lerp(rect.anchoredPosition, targetPos, Time.deltaTime * lerpSpeed);           //Smooth transition

    }
}
