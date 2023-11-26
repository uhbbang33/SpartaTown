using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField] Image _characterImage;

    void Start()
    {

    }

    void Update()
    {

    }


    // 캐릭터 선택
    public void CharacterSelectButton()
    {
        // 캐릭터 선택화면 setactive
    }

    public void EnterButton()
    {
        // 닉네임을 올바르게 적었다면

        SceneManager.LoadScene("MainScene");
    }
}
