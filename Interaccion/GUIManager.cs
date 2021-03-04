using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instancia;
    public Image puntero;
    public Sprite usa, normal;
    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PoneIconoUsa()
    {
        print("entra");
        puntero.sprite = usa;
    }
    public void PoneIconoNormal()
    {
        print("sale");
        puntero.sprite = normal;
    }
}
