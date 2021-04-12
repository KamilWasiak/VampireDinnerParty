using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTexture : MonoBehaviour
{
    public Material[] materials;
    private Renderer Object;
    public GameObject model;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetRandomTexture()
    {
        foreach (Transform child in model.transform)
        {
            if (child.GetComponent<Renderer>() != null)
            {
                Object = child.GetComponent<Renderer>();
                System.Random rand = new System.Random();
                int index = rand.Next(materials.Length);
                Object.material = materials[index];
            }
            
        }
            
         
    }


}

