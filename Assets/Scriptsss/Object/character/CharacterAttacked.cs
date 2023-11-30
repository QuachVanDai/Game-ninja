using System.Collections;
using UnityEngine;

public class CharacterAttacked : MonoBehaviour
{

    public Character character;
    private int max_hp;
    public GameObject ani_Attacked;
    void Start()
    {
        character = GetComponent<Character>();
        max_hp = character._hp;
    }
    public void Attacked(int damage)
    {
        character._hp -= damage;
        character.currentHP.text = character._hp.ToString();
       // StartCoroutine(aniAcctacked());
        if (character._hp < 0)
        {
            CharacterController2D.Instance.Animator.SetBool("isDeath",true);
          //  Destroy(gameObject, 0.5f);
        }
        character.update_hp(character._hp, max_hp);
    }
    IEnumerator aniAcctacked()
    {
        ani_Attacked.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        ani_Attacked.SetActive(false);
    }
}
