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


    // ĳ���� ����
    public void CharacterSelectButton()
    {
        // ĳ���� ����ȭ�� setactive
    }

    public void EnterButton()
    {
        // �г����� �ùٸ��� �����ٸ�

        SceneManager.LoadScene("MainScene");
    }
}
