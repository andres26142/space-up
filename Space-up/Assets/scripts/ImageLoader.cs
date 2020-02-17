
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ImageLoader : MonoBehaviour
{
    public string url = "https://cdn.eso.org/images/screen/potw2004a.jpg";
    public Renderer thisRenderer;
    
    // automatically called when game started
    void Start()
    {
        StartCoroutine(LoadFromLikeCoroutine()); // execute the section independently

        // the following will be called even before the load finished
        //thisSprite.Sprite = Color.red;
        //thisRenderer.material.mainTexture = Resources.Load<Texture2D>("Backgrounds/eso1740a");
    }

    // this section will be run independently
    private IEnumerator LoadFromLikeCoroutine()
    {
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