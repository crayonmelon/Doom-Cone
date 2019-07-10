using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{

    public int GameScore;

    private int Mutiplier;
    private int Bonus;
    private float BonusTime;
    private bool bonusActive;
    public GameObject bonusText;

    public AudioClip clapping;
    private AudioSource source;

    TextMeshProUGUI textmeshPro;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        textmeshPro = gameObject.GetComponent<TextMeshProUGUI>();

    }

    private void FixedUpdate()
    {
        textmeshPro.text = "Score: " + GameScore;
        if (BonusTime > 0)
        {
            BonusTime -= Time.deltaTime;
        }

        if(BonusTime <= 0 && bonusActive == true)
        {
            AddScore();
        }
        
    }

    public void StartScore()
    {
        Mutiplier++;
        Bonus= Bonus + 10;
        BonusTime = .5f;
        bonusActive = true;
    }

    public void AddScore()    
    {

        if (Mutiplier > 1)
        {
            source.PlayOneShot(clapping, 3f);
            bonusText.SetActive(true);
            StartCoroutine(Died());
        }

        GameScore = Mutiplier * Bonus + GameScore + 10;
        Mutiplier = 0;
        Bonus = 0;
        bonusActive = false;

    }

    private IEnumerator Died()
    {
        yield return new WaitForSeconds(2);
        bonusText.SetActive(false);
    }
}
