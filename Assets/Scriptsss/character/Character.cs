using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Head characterHead;
    [SerializeField] private Body characterBody;
    [SerializeField] private Leg characterLeg;

    [Header("Thay đổi trang phục khi mặc trang bị")]
    [SerializeField] ItemSO avatarSO;
    [SerializeField] ItemSO clothSO;
    [SerializeField] ItemSO pantSO;

    // Hàm tự động tìm các đối tượng, chỉ thực thi trong Editor
    private void OnValidate()
    {
        characterHead = GetComponentInChildren<Head>();
        characterBody = GetComponentInChildren<Body>();
        characterLeg = GetComponentInChildren<Leg>();
    }

    private void Update()
    {
        // Thay đổi Tóc
        if(avatarSO != null)
        {
            CharacterCustomization(characterHead.headIdle, avatarSO.GetSpriteIdle);
            CharacterCustomization(characterHead.headRun, avatarSO.GetSpriteRun);
            CharacterCustomization(characterHead.headAttack, avatarSO.GetSpriteAttack);
            CharacterCustomization(characterHead.headDown, avatarSO.GetSpriteDown);
        }    

        //// Thay đổi Áo
        if(clothSO != null)
        {
            CharacterCustomization(characterBody.bodyIdle, clothSO.GetSpriteIdle);
            CharacterCustomization(characterBody.bodyRun, clothSO.GetSpriteRun);
           CharacterCustomization(characterBody.bodyAttack, clothSO.GetSpriteAttack);
           CharacterCustomization(characterBody.bodyDown, clothSO.GetSpriteDown);
        }

        //// Thay đổi Quần

        if(pantSO != null)
        {
            CharacterCustomization(characterLeg.legIdle, pantSO.GetSpriteIdle);
            CharacterCustomization(characterLeg.legRun, pantSO.GetSpriteRun);
            CharacterCustomization(characterLeg.legAttack, pantSO.GetSpriteAttack);
            CharacterCustomization(characterLeg.legDown, pantSO.GetSpriteDown);
        }
    }

    // Hàm thay đổi trang phục
    private void CharacterCustomization(GameObject[] outfits, Sprite[] sprites)
    {

        if (outfits.Length > 0)
        {
            if (sprites != null && sprites.Length > 0)
            {
                for (int i = 0; i < outfits.Length; i++)
                {
                    outfits[i].GetComponent<SpriteRenderer>().sprite = sprites[i];
                }
            }

        }
    }

}
