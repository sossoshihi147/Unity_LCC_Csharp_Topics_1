using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace OLIVER
{
    /// <summary>
    /// 人物屬性
    /// </summary>
    [System.Serializable]
    public class CharacterStats
    {
        public float age;
        public float ability;
        public float sociability;
        public float health;
        public float money;

        public CharacterStats(float _age, float _ability, float _sociability, float _health, float _money)
        {
            age = _age;
            ability = _ability;
            sociability = _sociability;
            health = _health;
            money = _money;
        }

        public void ModifyStat(string statName, int value)
        {
            switch (statName)
            {
                case "age": age += value; break;
                case "ability": ability += value; break;
                case "sociability": sociability += value; break;
                case "health": health += value; break;
                case "money": money += value; break;
            }
        }
    }
    /// <summary>
    /// 主腳本
    /// </summary>
    public class GameMain : MonoBehaviour
    {
        public GameObject[] normalButtons;  // 平時的4個選項
        public GameObject[] specialButtons; // 特定年齡的3個選項
        public UnityEngine.UI.Button[] specialButtonArray;  // 儲存特殊選項按鈕的陣列
        private float currentEventIndex = 0;
        private string[,] eventButtonTexts = new string[7, 3]
   {
        { "吃掉", "丟掉", "給爸爸吃" },                         // 事件 1 的三個按鈕文本
        { "答應她", "回絕她", "套路她" },                       // 事件 2 的三個按鈕文本
        { "起身尋找", "呼呼大睡", "叫他別吵" },                 // 事件 3 的三個按鈕文本
        { "出國念書\n金錢需>4000", "出國玩", "不想出國" },     　// 事件 4 的三個按鈕文本
        { "收養牠", "請人幫忙", "無視" },                    　 // 事件 5 的三個按鈕文本
        { "答應他", "回絕他", "要朋友一起" },                   // 事件 6 的三個按鈕文本
        { "回應他", "卸載他", "上網公開" }                   　 // 事件 7 的三個按鈕文本
   };
        [SerializeField] public CharacterStats stats;
        private void Awake()
        {
            LogSystem.LogWithColor("恭喜你終於破防了，精生也請多多指教!!", "#f0f");
            Born();
        }
        // 出生
        private void Born()
        {
            int randomStart = Random.Range(0, 4);
            if (randomStart == 0)
            {
                stats = new CharacterStats(1, 0, 10, 120, 800);
                LogSystem.LogWithColor("今世你出生在熱愛戶外活動的家庭", "#f99");
            }
            if (randomStart == 1)
            {
                stats = new CharacterStats(1, 5, 5, 100, 10000);
                LogSystem.LogWithColor("今世你是大財團的三公子", "#f99");
            }
            if (randomStart == 2)
            {
                stats = new CharacterStats(1, 0, 0, 100, 500);
                LogSystem.LogWithColor("今世你出生在一般的上班族家庭", "#f99");
            }
            if (randomStart == 3)
            {
                stats = new CharacterStats(1, 10, 0, 100, 1500);
                LogSystem.LogWithColor("今世你出生電競世家", "#f99");
            }
        }
        // 成長
        private void Gourp()
        {
            LogSystem.LogWithColor("又長大一歲囉~~~<<年齡+1，健康-1>>", "#8f0");
            stats.ModifyStat("age", 1);
            stats.ModifyStat("health", -1);
        }

        public void TriggerEvent(string eventName)
        {

            float ageCheck = stats.age / 4;

            switch (eventName)
            {
                #region 一般選項
                case "Learn":
                    #region 幼年時期
                    // 幼年時期
                    if (ageCheck < 1)
                    {
                        LogSystem.LogWithColor("流著口水，聽著古典樂就成長了<<能力+2，金錢-80>>", "#f09");
                    }
                    else if (ageCheck > 1 && ageCheck < 2 && ageCheck != 1)
                    {
                        LogSystem.LogWithColor("在幼稚園捏泥巴，玩玩具就長大了<<能力+2，金錢-80>>", "#f09");
                    }
                    if (ageCheck < 2 && ageCheck != 1)
                    {
                        stats.ModifyStat("ability", 2);
                        stats.ModifyStat("money", -80);
                    }
                    #endregion

                    #region 少年時期
                    // 少年時期
                    if (ageCheck > 2 && ageCheck < 3)
                    {
                        LogSystem.LogWithColor("九九乘法他悄悄地來，悄悄地走<<能力+3，金錢-120>>", "#f09");
                    }
                    else if (ageCheck > 3 && ageCheck < 4)
                    {
                        LogSystem.LogWithColor("二元一次方程式，與我總如初相識<<能力+3，金錢-120>>", "#f09");
                    }
                    if (ageCheck > 2 && ageCheck < 4 && ageCheck != 3)
                    {
                        stats.ModifyStat("ability", 3);
                        stats.ModifyStat("money", -120);
                    }
                    #endregion

                    #region 青年時期
                    // 青年時期
                    if (ageCheck > 4 && ageCheck < 5)
                    {
                        LogSystem.LogWithColor("微積分有什麼難度，我都查危機百科<<能力+5，金錢-150>>", "#f09");
                    }
                    else if (ageCheck > 5 && ageCheck < 6)
                    {
                        LogSystem.LogWithColor("咦?專題的完成進度，總是跟我的個人進度巧妙的吻合???<<能力+5，金錢-150>>", "#f09");
                    }
                    if (ageCheck > 4 && ageCheck < 6 && ageCheck != 5)
                    {
                        stats.ModifyStat("ability", 5);
                        stats.ModifyStat("money", -150);
                    }
                    #endregion

                    #region 壯年時期
                    // 狀年時期
                    if (ageCheck > 6 && ageCheck < 7)
                    {
                        LogSystem.LogWithColor("下班後還去聯成上C#課程，這樣置入有折扣嗎<<能力+7，社交+1，金錢-200>>", "#f09");
                    }
                    else if (ageCheck > 7 && ageCheck < 8)
                    {
                        LogSystem.LogWithColor("C#上完接著上Unity，又置入啦，為什麼說又呢?<<能力+7，社交+1，金錢-200>>", "#f09");
                    }
                    if (ageCheck > 6 && ageCheck < 8 && ageCheck != 7)
                    {
                        stats.ModifyStat("ability", 7);
                        stats.ModifyStat("sociability", 1);
                        stats.ModifyStat("money", -200);
                    }
                    #endregion
                    break;
                case "Social":
                    #region 幼年時期
                    // 幼年時期
                    if (ageCheck < 1)
                    {
                        LogSystem.LogWithColor("對著面前不知是哪位的大媽咯咯笑<<社交+2，金錢-100>>", "#f09");
                    }
                    else if (ageCheck > 1 && ageCheck < 2 && ageCheck != 1)
                    {
                        LogSystem.LogWithColor("逛街時，對路上的小姐姐眨眨眼<<社交+2，金錢-100>>", "#f09");
                    }
                    if (ageCheck < 2 && ageCheck != 1)
                    {
                        stats.ModifyStat("sociability", 2);
                        stats.ModifyStat("money", -100);
                    }
                    #endregion

                    #region 少年時期
                    // 少年時期
                    if (ageCheck > 2 && ageCheck < 3)
                    {
                        LogSystem.LogWithColor("揪同學到圖書館集合，玩傳說對決<<社交+3，金錢-150>>", "#f09");
                    }
                    else if (ageCheck > 3 && ageCheck < 4)
                    {
                        LogSystem.LogWithColor("揪同學到陸鱷鯊集合，玩PTCG<<社交+3，金錢-150>>", "#f09");
                    }
                    if (ageCheck > 2 && ageCheck < 4 && ageCheck != 3)
                    {
                        stats.ModifyStat("sociability", 3);
                        stats.ModifyStat("money", -150);
                    }
                    #endregion

                    #region 青年時期
                    // 青年時期
                    if (ageCheck > 4 && ageCheck < 5)
                    {
                        LogSystem.LogWithColor("我們社團的宗旨是：智商少一半，快樂不間斷<<社交+5，金錢-180>>", "#f09");
                    }
                    else if (ageCheck > 5 && ageCheck < 6)
                    {
                        LogSystem.LogWithColor("約同學逛夜市，結果被夜市王的人潮擠爆了<<社交+5，金錢-180>>", "#f09");
                    }
                    if (ageCheck > 4 && ageCheck < 6 && ageCheck != 5)
                    {
                        stats.ModifyStat("sociability", 5);
                        stats.ModifyStat("money", -180);
                    }
                    #endregion

                    #region 壯年時期
                    // 狀年時期
                    if (ageCheck > 6 && ageCheck < 7)
                    {
                        LogSystem.LogWithColor("約同事一起聚餐，開始建立人脈了<<能力+1，社交+7，金錢-250>>", "#f09");
                    }
                    else if (ageCheck > 7 && ageCheck < 8)
                    {
                        LogSystem.LogWithColor("去貓舍做義工，撸貓比人際關係輕鬆多了<<能力+1，社交+7，金錢-250>>", "#f09");
                    }
                    if (ageCheck > 6 && ageCheck < 8 && ageCheck != 7)
                    {
                        stats.ModifyStat("ability", 1);
                        stats.ModifyStat("sociability", 7);
                        stats.ModifyStat("money", -250);
                    }
                    #endregion
                    break;
                case "Work":
                    #region 幼年時期
                    // 幼年時期
                    if (ageCheck < 1)
                    {
                        LogSystem.LogWithColor("啃著沾有奶粉的手手被直播了<<能力+1，金錢-400>>", "#f09");
                    }
                    else if (ageCheck > 1 && ageCheck < 2 && ageCheck != 1)
                    {
                        LogSystem.LogWithColor("過年時，對著爺爺奶奶輸出一頓小搥搥<<能力+1，金錢-400>>", "#f09");
                    }
                    if (ageCheck < 2 && ageCheck != 1)
                    {
                        stats.ModifyStat("ability", 1);
                        stats.ModifyStat("money", 400);
                    }
                    #endregion

                    #region 少年時期
                    // 少年時期
                    if (ageCheck > 2 && ageCheck < 3)
                    {
                        LogSystem.LogWithColor("幫爸爸出售Pokemon Ga-Ole的卡閘<<能力+1，社交+1，金錢+500>>", "#f09");
                    }
                    else if (ageCheck > 3 && ageCheck < 4)
                    {
                        LogSystem.LogWithColor("去阿姨的美食直播幫忙吃東西<<能力+1，社交+1，金錢+500>>", "#f09");
                    }
                    if (ageCheck > 2 && ageCheck < 4 && ageCheck != 3)
                    {
                        stats.ModifyStat("ability", 1);
                        stats.ModifyStat("sociability", 1);
                        stats.ModifyStat("money", 500);
                    }
                    #endregion

                    #region 青年時期
                    // 青年時期
                    if (ageCheck > 4 && ageCheck < 5)
                    {
                        LogSystem.LogWithColor("飲料店的時薪，居然不如我5歲的小搥搥<<能力+2，社交+1，金錢+800>>", "#f09");
                    }
                    else if (ageCheck > 5 && ageCheck < 6)
                    {
                        LogSystem.LogWithColor("到企業實習，主要工作是訂下午茶??<<能力+2，社交+1，金錢+800>>", "#f09");
                    }
                    if (ageCheck > 4 && ageCheck < 6 && ageCheck != 5)
                    {
                        stats.ModifyStat("ability", 2);
                        stats.ModifyStat("sociability", 1);
                        stats.ModifyStat("money", 800);
                    }
                    #endregion

                    #region 壯年時期
                    // 狀年時期
                    if (ageCheck > 6 && ageCheck < 7)
                    {
                        LogSystem.LogWithColor("加班賣肝，老闆賺翻<<能力+3，健康-2，金錢+1000>>", "#f09");
                    }
                    else if (ageCheck > 7 && ageCheck < 8)
                    {
                        LogSystem.LogWithColor("與其把肝賣給公司，何不直接賣給醫院??<<能力+3，健康-2，金錢+1000>>", "#f09");
                    }
                    if (ageCheck > 6 && ageCheck < 8 && ageCheck != 7)
                    {
                        stats.ModifyStat("ability", 3);
                        stats.ModifyStat("health", -2);
                        stats.ModifyStat("money", 1000);
                    }
                    #endregion
                    break;
                case "Rest":
                    #region 幼年時期
                    // 幼年時期
                    if (ageCheck < 1)
                    {
                        LogSystem.LogWithColor("安安靜靜，世界和平<<健康+2，金錢-50>>", "#f09");
                    }
                    else if (ageCheck > 1 && ageCheck < 2 && ageCheck != 1)
                    {
                        LogSystem.LogWithColor("聽著Baby Shark，看著巧虎，終於歇停了會兒<<健康+2，金錢-50>>", "#f09");
                    }
                    if (ageCheck < 2 && ageCheck != 1)
                    {
                        stats.ModifyStat("health", 2);
                        stats.ModifyStat("money", -50);
                    }
                    #endregion

                    #region 少年時期
                    // 少年時期
                    if (ageCheck > 2 && ageCheck < 3)
                    {
                        LogSystem.LogWithColor("每天9點準時就寢，爸媽覺得擔心<<健康+3，金錢-50>>", "#f09");
                    }
                    else if (ageCheck > 3 && ageCheck < 4)
                    {
                        LogSystem.LogWithColor("和媽媽一起去上瑜珈課，放鬆身心<<健康+3，金錢-50>>", "#f09");
                    }
                    if (ageCheck > 2 && ageCheck < 4 && ageCheck != 3)
                    {
                        stats.ModifyStat("health", 3);
                        stats.ModifyStat("money", -50);
                    }
                    #endregion

                    #region 青年時期
                    // 青年時期
                    if (ageCheck > 4 && ageCheck < 5)
                    {
                        LogSystem.LogWithColor("在家是想多陪伴家人，絕對不是沒朋友什麼的<<健康+5，金錢-50>>", "#f09");
                    }
                    else if (ageCheck > 5 && ageCheck < 6)
                    {
                        LogSystem.LogWithColor("俗話說的好，在哪裡跌倒就在哪裡躺下<<健康+5，金錢-50>>", "#f09");
                    }
                    if (ageCheck > 4 && ageCheck < 6 && ageCheck != 5)
                    {
                        stats.ModifyStat("health", 5);
                        stats.ModifyStat("money", -50);
                    }
                    #endregion

                    #region 壯年時期
                    // 狀年時期
                    if (ageCheck > 6 && ageCheck < 7)
                    {
                        LogSystem.LogWithColor("都20好幾了，你以為還能躺著發育嗎<<能力-3，社交-3，健康+7，金錢-100>>", "#f09");
                    }
                    else if (ageCheck > 7 && ageCheck < 8)
                    {
                        LogSystem.LogWithColor("都這個時候了，肯定不是躺平，這是戰略性休息<<能力-3，社交-3，健康+7，金錢-100>>", "#f09");
                    }
                    if (ageCheck > 6 && ageCheck < 8 && ageCheck != 7)
                    {
                        stats.ModifyStat("ability", -3);
                        stats.ModifyStat("sociability", -3);
                        stats.ModifyStat("health", 7);
                        stats.ModifyStat("money", -100);
                    }
                    #endregion
                    break;
                #endregion

                case "Event1":
                    int randomEvent = EventRandom();
                    if (ageCheck == 1 && randomEvent <= 2)
                    {
                        LogSystem.LogWithColor("判定成功", "#f00");
                        LogSystem.LogWithColor("吃下後突然頭痛欲裂，接連發了好幾天的燒，醒來後頭腦都不清楚了<<能力-5，健康-15>>", "#0ff");
                        stats.ModifyStat("ability", -5);
                        stats.ModifyStat("health", -15);
                    }
                    else if (ageCheck == 1 && randomEvent > 2)
                    {
                        LogSystem.LogWithColor("判定失敗", "#f00");
                        LogSystem.LogWithColor("吃下後眼前變的五光十射，腦袋微微發熱，學習突飛猛進\n" +
                            "家長跟老師都大為驚嘆，被譽為一代神童<<能力+15>>", "#0ff");
                        stats.ModifyStat("ability", 15);
                    }
                    else if (ageCheck == 2)
                    {
                        LogSystem.LogWithColor("當她吻上你後，你感到渾身無力又沉沉睡去，醒來後在客廳發現一個錦盒\n" +
                            "裡面有一些寶石，但家裡的貓貓也離奇失蹤了<<健康-15，金錢+800>>", "#0ff");
                        stats.ModifyStat("health", -15);
                        stats.ModifyStat("money", 800);
                    }
                    else if (ageCheck == 3)
                    {
                        LogSystem.LogWithColor("你以為會有奇遇嗎?，並沒有，你只是夢遊\n" +
                            "而且造成了醫護人員額外的負擔，被護理師白眼了<<社交-10，金錢-500>>", "#0ff");
                        stats.ModifyStat("sociability", -10);
                        stats.ModifyStat("money", -500);
                    }
                    break;
                case "Event2":
                    if (ageCheck == 1)
                    {
                        LogSystem.LogWithColor("糖果被丟棄到地上時又觸發了黑洞，把地板整了一個大洞\n從此幼兒園開始瀰漫著關於你的怪談<<社交-10>>", "#0ff");
                        stats.ModifyStat("sociability", -10);
                    }
                    else if (ageCheck == 2)
                    {
                        LogSystem.LogWithColor("你回答她:「你想嚇我是嚇不倒的，我什麼都怕就是不怕鬼」\n" +
                            "結果她愣了一秒之後，撲過來把你爆抓一頓，醒來後發現你也渾身是抓傷，家裡的貓也不見了\n" +
                            "媽媽以為是你打跑了牠<<健康-5，金錢-200>>", "#0ff");
                        stats.ModifyStat("health", -5);
                        stats.ModifyStat("money", -200);
                    }
                    else if (ageCheck == 3)
                    {
                        LogSystem.LogWithColor("在睡夢中，你聽見有人稱讚你性情堅定\n" +
                            "睡醒後感到神清氣爽，看世界都變得更清晰<<能力+10，健康+10，金錢-300>>", "#0ff");
                        stats.ModifyStat("ability", 10);
                        stats.ModifyStat("health", 10);
                        stats.ModifyStat("money", -300);
                    }
                    break;
                case "Event3":
                    if (ageCheck == 1)
                    {
                        LogSystem.LogWithColor("爸爸吃了糖果之後，昏睡了一天，隔天起床後\n靈感一來替公司創造新的專利賺了一筆獎金<<金錢+1000>>", "#0ff");
                        stats.ModifyStat("money", 1000);
                    }
                    else if (ageCheck == 2)
                    {
                        LogSystem.LogWithColor("你回答她:「我想和妳相識、相處、相知、相愛才能換得一片真心」\n" +
                            "醒來後發現家裡的貓貓變的更黏你了，你的人緣也變好<<社交+10>>", "#0ff");
                        stats.ModifyStat("sociability", 10);
                    }
                    break;
            }
            Gourp();
            float ageCheck2 = stats.age / 4;
            // 特殊事件開場白
            switch (ageCheck2)
            {
                case 1:
                    LogSystem.LogWithColor("在幼兒園吃完點心，打了個飽嗝\n" +
                    "突然面前出現一個黑洞並掉落一顆糖果\n包裝上的字有看沒有懂，你會?", "#ff0");
                    ChangeEvent(0);
                    break;
                case 2:
                    LogSystem.LogWithColor("在家午睡時夢見一位身著古裝的貓娘對你說:\n" +
                     "「公子，我等待一位真心人的深情一吻已千年，您能否成全小女子?」\n" +
                     "仔細一看他的服裝配色與家裡的貓貓一般無二，你會?", "#ff0");
                    ChangeEvent(1);
                    break;
                case 3:
                    LogSystem.LogWithColor("國小畢旅回來後，莫名生了一場大病，高燒住院\n" +
                    "在病床上，迷迷糊糊中隱約聽見一股呼喚，你會?", "#ff0");
                    ChangeEvent(2);
                    break;
                case 4:
                    LogSystem.LogWithColor("今年元旦，爸媽興奮的告訴你要送你一份禮物\n" +
                    "問你想不想出國，你會?", "#ff0");
                    ChangeEvent(3);
                    break;
                case 5:
                    LogSystem.LogWithColor("在家午睡時夢見一位身著古裝的貓娘對你說:\n" +
                    "「公子，我等待一位真心人的深情一吻已千年，您能否成全小女子?」，你會?", "#ff0");
                    ChangeEvent(4);
                    break;
                case 6:
                    LogSystem.LogWithColor("在家午睡時夢見一位身著古裝的貓娘對你說:\n" +
                    "「公子，我等待一位真心人的深情一吻已千年，您能否成全小女子?」，你會?", "#ff0");
                    ChangeEvent(5);
                    break;
                case 7:
                    LogSystem.LogWithColor("某天，你發現你手機裡的AI助手越來越智能\n" +
                    "並且在你生日的當天主動與你傳訊，你會?", "#ff0");
                    ChangeEvent(6);
                    break;
            }
            UpdateUI();

        }
        // 各事件按鈕顯示切換
        void UpdateUI()
        {
            float ageCheck = stats.age / 4;
            if (ageCheck == 1 || ageCheck == 2 || ageCheck == 3 || ageCheck == 4 || ageCheck == 5 || ageCheck == 6 || ageCheck == 7) // 每 4 歲的事件按鈕
            {
                ToggleButtonGroup(normalButtons, false); // 隱藏 基本選項
                ToggleButtonGroup(specialButtons, true); // 顯示 特殊選項 1, 2, 3
            }

            else
            {
                ToggleButtonGroup(normalButtons, true);  // 顯示 基本選項
                ToggleButtonGroup(specialButtons, false); // 隱藏 特殊選項 1, 2, 3
            }
        }

        // 顯示或隱藏按鈕群組
        void ToggleButtonGroup(GameObject[] buttons, bool isActive)
        {
            foreach (GameObject btn in buttons)
            {
                btn.SetActive(isActive);
            }
        }

        // 事件職骰判斷
        int EventRandom()
        {
            return Random.Range(0, 5);
        }

        // 更改特殊事件選項
        void UpdateButtonsText()
        {
            for (int i = 0; i < specialButtonArray.Length; i++)
            {
                // 確保按鈕數量不會超出範圍
                if (i < specialButtonArray.Length)
                {
                    TextMeshProUGUI buttonText = specialButtonArray[i].GetComponentInChildren<TextMeshProUGUI>();
                    if (buttonText != null)
                    {
                        // 根據當前事件索引更新按鈕文本
                        buttonText.text = eventButtonTexts[(int)currentEventIndex, i];
                    }
                }
            }
        }

        // 模擬更改事件索引
        public void ChangeEvent(int newEventIndex)
        {
            if (newEventIndex >= 0 && newEventIndex < 7) // 確保事件索引在範圍內
            {
                currentEventIndex = newEventIndex;
                UpdateButtonsText();  // 更新按鈕文本
            }
        }
    }
}
