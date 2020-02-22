
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;

public class ImageLoader : MonoBehaviour
{
    string url = "";
    public Renderer thisRenderer;
    
    // automatically called when game started
    void Start()
    {
        StartCoroutine(LoadFromLikeCoroutine()); // execute the section independently

        // the following will be called even before the load finished
        //thisSprite.Sprite = Color.red;
        //thisRenderer.material.mainTexture = Resources.Load<Texture2D>("Backgrounds/eso1740a");
    }
    private String getWeek(){
        CultureInfo myCI = new CultureInfo("en-US");
        Calendar myCal = myCI.Calendar;
        CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
      	DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
		string week="";
        int week_number=myCal.GetWeekOfYear( DateTime.Now, myCWR, myFirstDOW);
		if (week_number<10){
			week="0"+week_number;
		}
		else{
			week=week_number.ToString();
		}
        int year = System.DateTime.Now.Year%2000;
		string date=year+week;
		return date;
	}
    // this section will be run independently
    private IEnumerator LoadFromLikeCoroutine()
    {
        url = "https://cdn.eso.org/images/screen/potw"+getWeek()+"a.jpg";
        Debug.Log("Loading ....");
        WWW wwwLoader = new WWW(url);   // create WWW object pointing to the url
                // start loading whatever in that url ( delay happens here )
        //thisSprite=Sprite.Create(wwwLoader.texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f,0.5f),100);;
        yield return wwwLoader;
        Debug.Log("Loaded");
        thisRenderer.material.color = Color.white;     // set white
        if(wwwLoader.error != null){
            thisRenderer.material.mainTexture = Resources.Load<Texture2D>("backgrounds/eso1740a"); 
            Debug.Log("exc");
        }
        else{
            thisRenderer.material.mainTexture = wwwLoader.texture;  // set loaded image
        }
        
        
    }
}