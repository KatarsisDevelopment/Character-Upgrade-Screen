using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Uprage : MonoBehaviour
{
    [SerializeField] private int ClickNumber,ActiveObjCount;
    public GameObject[] UprageObjects;
    public GameObject Player,MaxText;
    public Button LevelUpButton;
    public ParticleSystem ConfettiEffect;
    private void Start()
    {
        MaxText.gameObject.SetActive(false);
    }
    void Update()
    {
        // Objeleri Aktif Hale Getir
        // Aktif Hale Getirileblecek Obje Say�s�n�n Listenin D���na ��kmams�n� Sa�la
        if (UprageObjects.Length > ActiveObjCount)
        {
            UprageObjects[ActiveObjCount].gameObject.SetActive(true);
        }
        else
        {
            LevelUpButton.interactable = false;
            MaxText.gameObject.SetActive(true);
        }
        // Objeyi y ekseni etraf�nda d�nd�r
        Player.transform.Rotate(Vector3.up, 30f * Time.deltaTime);
    }


    // Butona T�kland��� Zaman Y�kseltme ��lemini Yap
    public void Purchase()
    {
        ClickNumber += 1;
        if (ClickNumber != 0)
        {
            // T�klama Say�s�n� 5'e B�l�m�nden Kalan 0 �se Aktif Obje Say�s�n� Artt�r (Bu Sayede 5'in Kat� Olan Her Say�da Listemizde S�rada Olan Objeyi Aktif Hale Getirece�iz)
            if (ClickNumber % 5 == 0)
            {
                ActiveObjCount += 1;
                // Aktif Obje Say�s� Her Artt���nda Confetti Efektini Ba�lat
                ConfettiEffect.Play();
            }
        }
    }
}
