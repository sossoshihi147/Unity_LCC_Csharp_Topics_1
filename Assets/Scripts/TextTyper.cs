using System.Collections;
using UnityEngine;
using TMPro;

public class TextTyper : MonoBehaviour
{
    public GameObject textPanel; // 文字視窗 (Panel)
    public TMP_Text dialogueText; // TextMeshPro 文字元件
    public float typingSpeed = 0.05f; // 逐字顯示速度

    private string currentText; // 要顯示的完整文字
    private Coroutine typingCoroutine;


    // 顯示對話框並逐字顯示文字
    public void ShowText(string message)
    {
        textPanel.SetActive(true); // 顯示視窗
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine); // 停止當前的輸出

        typingCoroutine = StartCoroutine(TypeText(message)); // 開始逐字顯示
    }

    // 逐字顯示文字的 Coroutine
    IEnumerator TypeText(string message)
    {
        dialogueText.text = ""; // 清空現有文字
        currentText = message;

        foreach (char letter in currentText.ToCharArray())
        {
            dialogueText.text += letter; // 一個字一個字顯示
            yield return new WaitForSeconds(typingSpeed); // 等待下一個字
        }
    }
}