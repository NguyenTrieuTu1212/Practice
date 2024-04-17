using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public Skin[] skins;
    private Animator animator;
    private Skin skin;
    bool ischange = true;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeAnimation();
        }
    }



    private void ChangeAnimation()
    {
        ischange = !ischange;
        animator.SetBool("isMoving", ischange);
    }


    private void SkinChangeCallback(TypeSkin typeSkin)
    {
        Debug.Log("Skin is" + typeSkin);
        if (typeSkin == TypeSkin.Ninja) skin = FindIDSkin("Ninja");
        else if (typeSkin == TypeSkin.GirlCave) skin = FindIDSkin("Girl");
        gameObject.GetComponent<SpriteRenderer>().sprite = skin.sprite;
        animator.runtimeAnimatorController = skin.aniamtor.runtimeAnimatorController;
    }


    private void OnEnable()
    {
        TypeChangeSkin.OnSelectSkin += SkinChangeCallback;
    }



    private Skin FindIDSkin(string IDSkin)
    {
        foreach(var skin in skins)
        {
            if (skin.IDSkin == IDSkin) return skin;
        }
        return null;
    }

    private void OnDisable()
    {
        TypeChangeSkin.OnSelectSkin -= SkinChangeCallback;
    }
}
