using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField]
    Texture2D mouseCursor;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(mouseCursor, new Vector2(1f,1f),CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
