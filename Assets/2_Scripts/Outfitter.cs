using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class Outfitter : MonoBehaviour
{
    private List<SpriteResolver> resolvers;
    private ChararcterType chartype;


    private enum ChararcterType
    {
        Ork,
        Bandit
    }

    private void Awake()
    {
        resolvers = GetComponentsInChildren<SpriteResolver>().ToList();
    }

     void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            chartype = chartype == ChararcterType.Ork ? ChararcterType.Bandit : ChararcterType.Ork;
            ChangeOutfit();
        }
    }

    public void ChangeOutfit()
    {
        foreach(SpriteResolver resolver in resolvers) 
        { 
            resolver.SetCategoryAndLabel(resolver.GetCategory(), chartype.ToString());



            if (resolver.GetCategory() == "Weapon")
            {
                resolver.gameObject.SetActive(resolver.GetLabel() == "Bandit");
            }

            Sprite sprite = resolver.spriteLibrary.GetSprite(resolver.GetCategory(), resolver.GetLabel());
            Debug.Log($"sprite : {sprite}");
        }
    }

   
}
