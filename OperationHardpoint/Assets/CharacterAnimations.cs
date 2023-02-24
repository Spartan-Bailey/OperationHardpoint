using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{

    private GameObject LEGR;
    private GameObject LEGL;
    private GameObject HEAD;
    private GameObject ARMR;
    private GameObject ARML;
    private GameObject BODY;
    private GameObject CORE;

    private Rigidbody2D RB;

    private SpriteRenderer leftLegSprite;
    private SpriteRenderer rightLegSprite;
    private SpriteRenderer headSprite;
    private SpriteRenderer bodySprite;
    private SpriteRenderer rightArmSprite;
    private SpriteRenderer leftArmSprite;
    void Start()
    {
        CORE = this.gameObject;
        LEGL = CORE.transform.Find("Legs").Find("Left Leg (Rear)").gameObject;
        LEGR = CORE.transform.Find("Legs").Find("Right Leg (Front)").gameObject;
        HEAD = CORE.transform.Find("Head").gameObject;
        ARMR = CORE.transform.Find("Arms").Find("Right Arm (Front)").gameObject;
        ARML = CORE.transform.Find("Arms").Find("Left Arm (Rear)").gameObject;
        BODY = CORE.transform.Find("Torso").gameObject;

        leftLegSprite = LEGL.GetComponent<SpriteRenderer>();
        rightLegSprite = LEGR.GetComponent<SpriteRenderer>();
        headSprite = HEAD.GetComponent<SpriteRenderer>();
        bodySprite = BODY.GetComponent<SpriteRenderer>();
        rightArmSprite = ARMR.GetComponent<SpriteRenderer>();
        leftArmSprite = ARML.GetComponent<SpriteRenderer>();

        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(RB.velocity.x > 0f)
        {
            FlipSprite(false);
        }
        else if(RB.velocity.x < 0f)
        {
            FlipSprite(true);
        }
    }

    private void FlipSprite(bool flipState)
    {
        leftLegSprite.flipX = flipState;
        rightLegSprite.flipX = flipState;
        headSprite.flipX = flipState;
        bodySprite.flipX = flipState;
        rightArmSprite.flipX = flipState;
        leftArmSprite.flipX = flipState;
    }
}
