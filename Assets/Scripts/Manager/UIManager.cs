using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] GameObject _characterCreateCanvas;
    [SerializeField] GameObject _imageSelectCanvas;
    [SerializeField] GameObject _nickNameInputCanvas;
    [SerializeField] GameObject _attendanceCanvas;

    [Header("Panel")]
    [SerializeField] GameObject _dialogueButtonPanel;
    [SerializeField] GameObject _dialoguePanel;

    [Header("NickNameInput")]
    [SerializeField] TextMeshProUGUI _playerNameInput;
    [SerializeField] TextMeshProUGUI _playerName;
    [SerializeField] GameObject _nicknameWarning;

    [Header("Sprite")]
    [SerializeField] Image _playerTempImage;
    [SerializeField] Sprite _penguinSprite;
    [SerializeField] Sprite _jellySprite;

    [Header("AnimatorController")]
    [SerializeField] RuntimeAnimatorController _penguinAnimController;
    [SerializeField] RuntimeAnimatorController _jellyAnimController;

    [Header("Player")]
    [SerializeField] GameObject _playerSprite;

    //[Header("NPC")]
    //[SerializeField] List<TextMeshProUGUI> _npcName;

    [Header("Text")]
    [SerializeField] TextMeshProUGUI _timeText;
    [SerializeField] TextMeshProUGUI _attendanceNameText;
    [SerializeField] TextMeshProUGUI _dialogueButtonPanelText;

    List<string> _nameList;

    private static UIManager _instance;
    public static UIManager Instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _nameList = new List<string>();

        // Find
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NpcName");
        foreach (GameObject npc in npcs)
            _nameList.Add(npc.GetComponent<TextMeshProUGUI>().text);

        // NPC를 하나하나 등록 (List)
        //foreach (TextMeshProUGUI obj in _npcName) {
        //    _attendanceNameText.text += obj.text + "\n";
        //}
    }

    private void Update()
    {
        _timeText.text = DateTime.Now.ToString("HH : mm");
    }

    public void CharacterSelectButton()
    {
        _imageSelectCanvas.SetActive(true);
    }

    public void EnterButton()
    {
        if (_playerNameInput.text.Length > 2 && _playerNameInput.text.Length < 12)
        {
            _playerName.text = _playerNameInput.text;
            _characterCreateCanvas.SetActive(false);
            _nickNameInputCanvas.SetActive(false);

            GameManager.Instance.SetTimeScale(1.0f);
        }
        else
            _nicknameWarning.SetActive(true);
    }

    public void SelectPenguinCharacter()
    {
        _playerSprite.GetComponent<Animator>().runtimeAnimatorController = _penguinAnimController;
        _playerSprite.GetComponent<SpriteRenderer>().sprite = _penguinSprite;
        // 캐릭터 선택창
        _playerTempImage.sprite = _penguinSprite;
        _playerTempImage.transform.localScale = Vector3.one;
        _imageSelectCanvas.SetActive(false);
    }

    public void SelectJellyCharacter()
    {
        _playerSprite.GetComponent<Animator>().runtimeAnimatorController = _jellyAnimController;
        _playerSprite.GetComponent<SpriteRenderer>().sprite = _jellySprite;

        _playerTempImage.sprite = _jellySprite;
        _playerTempImage.transform.localScale = Vector3.one / 3;
        _imageSelectCanvas.SetActive(false);
    }

    public void ChangeNameButton()
    {
        _nickNameInputCanvas.SetActive(true);
        GameManager.Instance.SetTimeScale(0.0f);
    }

    public void ShowAttendanceButton()
    {
        if (_attendanceCanvas.activeSelf) _attendanceCanvas.SetActive(false);
        else
        {
            // update attendance
            _attendanceNameText.text = string.Empty;
            foreach (string nameText in _nameList)
                _attendanceNameText.text += nameText + "\n";

            _attendanceNameText.text += _playerName.text;

            _attendanceCanvas.SetActive(true);
        }
    }

    public void AddTextAttendanceDisplay(string text)
    {
        _attendanceNameText.text += text + "\n";
    }

    public void ShowDialogueButtonPanel(bool isActive, string npcObject)
    {
        _dialogueButtonPanel.SetActive(isActive);
        _dialogueButtonPanelText.text = npcObject;
        _dialoguePanel.SetActive(false);
    }

    public void ConversationButton()
    {
        _dialogueButtonPanel.SetActive(false);
        _dialoguePanel.SetActive(true);
    }

    public void SetDialogueMessage(string data)
    {
        _dialoguePanel.GetComponentInChildren<TextMeshProUGUI>().text = data;
    }

    public void ExitDialogue()
    {
        _dialoguePanel.SetActive(false);
    }
}
