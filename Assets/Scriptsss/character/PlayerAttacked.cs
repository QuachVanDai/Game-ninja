using System.Collections;
using UnityEngine;

public class PlayerAttacked : NCKHMonoBehaviour
{
    public GameObject ani_Attacked;
    void Start()
    {

    }
    public void Attacked(int damage)
    {
        Player.Instance._currhp -= damage;
        Player.Instance.currentHP.text = Player.Instance._currhp.ToString();
        // Player.Instance.numberTxt.aniTextY(Player.Instance.currentName, Player.Instance.canvas, Player.Instance.currentName.transform, damage*(-1), new Vector3(0,1.2f,0), 1, 0.3f, Color.red);
        Player.Instance.textGUI((int)damage*-1, Color.red);
        //StartCoroutine(aniAcctacked());
        if (Player.Instance._currhp < 0)
        {
          //CharacterController2D.Instance.Animator.SetBool("isDeath",true);
           Destroy(gameObject, 0.5f);
        }
        Player.Instance.update_hp(Player.Instance._currhp, Player.Instance.HP, Player.Instance._currhp.ToString());
    }
    IEnumerator aniAcctacked()
    {
        ani_Attacked.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        ani_Attacked.SetActive(false);
    }
}
