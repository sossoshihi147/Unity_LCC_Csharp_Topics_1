using UnityEngine;
using UnityEngine.UI;
using static OLIVER.GameMain;

namespace OLIVER
{
    public class OptionButton : MonoBehaviour
    {
        public Button myButton; // 連結到 UI 按鈕
        public Text displayText; // 連結到 UI 文字顯示
        public CharacterStats stats;

        void Start()
        {
            if (myButton != null)
            {
                myButton.onClick.AddListener(OnButtonClick); // 設定按鈕點擊事件
            }
        }

        void OnButtonClick()
        {
        float ageCase = stats.age / 4f;
            Debug.Log(ageCase);
        }
    }

}

