using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class NoteGroup : MonoBehaviour
{
    [SerializeField] private int noteMaxNum = 5;
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private GameObject noteSpawn;
    [SerializeField] private float noteGroupGap = 6f;

    [SerializeField] private SpriteRenderer btnSpriteRenderer;
    [SerializeField] private Sprite normalBtnSprite;
    [SerializeField] private Sprite selectBtnSprite;
    [SerializeField] private TextMeshPro keyCodeTmp;

    [SerializeField] private Animation anim;
    private KeyCode keyCode;

     AudioSource audioSource;

    public AnimationClip spawnanim;
    public AnimationClip Btnanim;

    public void Start()
    {
        anim.clip = spawnanim;
        anim.Play();
        anim.clip = Btnanim;
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
    public KeyCode KeyCode
    {
        get
        {
            return keyCode;
        }
    }

    private List<Note> noteList = new List<Note>();
    public void Create(KeyCode keyCode)
    {
        this.keyCode = keyCode;
        keyCodeTmp.text = keyCode.ToString();

        for (int i = 0; i < noteMaxNum; i++)
        {
            CreateNote(true);
        }
        InputManager.Instance.AddKeyCode(keyCode);

    }

    private void CreateNote(bool isApple)
    {
        GameObject noteGameObj = Instantiate(notePrefab);
        noteGameObj.transform.SetParent(noteSpawn.transform);

        noteGameObj.transform.localPosition = Vector3.up * noteList.Count *  noteGroupGap;
        Note note = noteGameObj.GetComponent<Note>();
        note.SetSprite(isApple);
        noteList.Add(note);
    }

    void Update()
    {

    }

    public void OnInput(bool isApple)
    {

        if (noteList.Count == 0)
            return;
        //노트 삭제
        Note delNote = noteList[0];
        delNote.DeleteNote();
        noteList.RemoveAt(0);

        //노트생성
        CreateNote(isApple);

        //정렬
        for (int i = 0; i < noteList.Count; i++)
            noteList[i].transform.localPosition = Vector3.up * i * noteGroupGap;


        //노트 애니메이션
        anim.Play();
        btnSpriteRenderer.sprite = selectBtnSprite;



    }
    public void callAniDone()
    {
        btnSpriteRenderer.sprite = normalBtnSprite;
    }
}
