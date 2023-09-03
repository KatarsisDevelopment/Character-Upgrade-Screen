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
        // Aktif Hale Getirileblecek Obje Sayýsýnýn Listenin Dýþýna Çýkmamsýný Saðla
        if (UprageObjects.Length > ActiveObjCount)
        {
            UprageObjects[ActiveObjCount].gameObject.SetActive(true);
        }
        else
        {
            LevelUpButton.interactable = false;
            MaxText.gameObject.SetActive(true);
        }
        // Objeyi y ekseni etrafýnda döndür
        Player.transform.Rotate(Vector3.up, 30f * Time.deltaTime);
    }


    // Butona Týklandýðý Zaman Yükseltme Ýþlemini Yap
    public void Purchase()
    {
        ClickNumber += 1;
        if (ClickNumber != 0)
        {
            // Týklama Sayýsýný 5'e Bölümünden Kalan 0 Ýse Aktif Obje Sayýsýný Arttýr (Bu Sayede 5'in Katý Olan Her Sayýda Listemizde Sýrada Olan Objeyi Aktif Hale Getireceðiz)
            if (ClickNumber % 5 == 0)
            {
                ActiveObjCount += 1;
                // Aktif Obje Sayýsý Her Arttýðýnda Confetti Efektini Baþlat
                ConfettiEffect.Play();
            }
        }
    }
}
