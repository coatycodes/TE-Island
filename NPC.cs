using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialogePanel;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public GameObject contButton;
    public float wordSpeed;
    public bool playerIsClose;

    // Update is called once per frame
    void Update()
    {   

        //F to interact and checking if playIsClose
        if(Input.GetKeyDown(KeyCode.F) && playerIsClose) {
            
            //If no player then say nothing
            if(dialogePanel.activeInHierarchy) {
                zeroText();
            }


            //Start talking
            else {
                dialogePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }

        if(dialogueText.text == dialogue[index]) {
            contButton.SetActive(true);
        }

    }


    //Say nothing
    public void zeroText() {
        dialogueText.text = "";
        index = 0;
        dialogePanel.SetActive(false);
    }

    IEnumerator Typing() {
        foreach (char letter in dialogue[index].ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine() {

        contButton.SetActive(false);

        //Going through array and displaying all text to user
        if(index < dialogue.Length - 1) {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        } else {
            zeroText();
        }
    }

    //If player is in Collider box, playerIsClose = true;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            playerIsClose = true;
        }
    }


    //If player is not in Collider box, say nothing
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            playerIsClose = false;
            zeroText();
        }
    }
}
