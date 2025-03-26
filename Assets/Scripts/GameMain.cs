using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;


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
        public bool moneyNG;

        public CharacterStats(float _age, float _ability, float _sociability, float _health, float _money, bool _moneyNG)
        {
            age = _age;
            ability = _ability;
            sociability = _sociability;
            health = _health;
            money = _money;
            moneyNG = _moneyNG;
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
        [SerializeField, Header("文字")]
        private TMP_Text textMain;
        public GameObject[] normalButtons;                  // 平時的 4 個選項
        public GameObject[] specialButtons;                 // 特定年齡的 3 個選項
        public GameObject[] endButtons;                     // 結局畫面的 2 個選項
        public UnityEngine.UI.Button[] specialButtonArray;  // 儲存特殊選項按鈕的陣列
        public GameObject textPanel;                        // 結局文字視窗
        // 存放四個屬性對應的結局文本
        private Dictionary<string, Dictionary<string, string>> endings = new Dictionary<string, Dictionary<string, string>>();
        private float currentEventIndex = 0;
        private string[,] eventButtonTexts = new string[7, 3]
   {
        { "吃掉\n(隨機分歧)", "丟掉", "給爸爸吃" },                        // 事件 1 的三個按鈕文本
        { "答應她", "回絕她", "套路她" },                                  // 事件 2 的三個按鈕文本
        { "起身尋找", "呼呼大睡", "叫他別吵" },                            // 事件 3 的三個按鈕文本
        { "出國念書\n(金錢需>3500)", "出國玩\n(隨機分歧)", "不想出國" },    // 事件 4 的三個按鈕文本
        { "救治收養", "請人幫忙", "無視" },                                  // 事件 5 的三個按鈕文本
        { "答應他\n(隨機分歧)", "回絕他", "要朋友一起" },                   // 事件 6 的三個按鈕文本
        { "回應他\n(隨機分歧)", "卸載他", "上網公開" }                   　 // 事件 7 的三個按鈕文本
   };
        [SerializeField] public CharacterStats stats;
        private void Awake()
        {
            Born();
            InitializeEndings();
        }
        // 出生
        private void Born()
        {
            int randomStart = Random.Range(0, 4);
            if (randomStart == 0)
            {
                stats = new CharacterStats(1, 0, 10, 120, 800,false);
                textMain.text = "<color=#f99>恭喜你終於破防了，精生也請多多指教!!\n今世你出生在熱愛戶外活動的家庭</color>";
            }
            if (randomStart == 1)
            {
                stats = new CharacterStats(1, 5, 5, 100, 10000, false);
                textMain.text = "<color=#f99>恭喜你終於破防了，精生也請多多指教!!\n今世你是大財團的三公子</color>";
            }
            if (randomStart == 2)
            {
                stats = new CharacterStats(1, 0, 0, 100, 500, false);
                textMain.text = "<color=#f99>恭喜你終於破防了，精生也請多多指教!!\n今世你出生在一般的上班族家庭</color>";
            }
            if (randomStart == 3)
            {
                stats = new CharacterStats(1, 10, 0, 100, 1500, false);
                textMain.text = "<color=#f99>恭喜你終於破防了，精生也請多多指教!!\n今世你出生電競世家</color>";
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
                        textMain.text = "<color=#f09>流著口水，聽著古典樂就成長了<<能力+2，金錢-80>></color>";
                    }
                    else if (ageCheck > 1 && ageCheck < 2 && ageCheck != 1)
                    {
                        textMain.text = "<color=#f09>在幼稚園捏泥巴，玩玩具就長大了<<能力+2，金錢-80>></color>";
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
                        textMain.text = "<color=#f09>九九乘法他悄悄地來，悄悄地走<<能力+3，金錢-120>></color>";
                    }
                    else if (ageCheck > 3 && ageCheck < 4)
                    {
                        textMain.text = "<color=#f09>二元一次方程式，與我總如初相識<<能力+3，金錢-120>></color>";
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
                        textMain.text = "<color=#f09>微積分有什麼難度，我都查危機百科<<能力+5，金錢-150>></color>";
                    }
                    else if (ageCheck > 5 && ageCheck < 6)
                    {
                        textMain.text = "<color=#f09>咦?專題的完成進度，總是跟我的個人進度巧妙的吻合???<<能力+5，金錢-150>></color>";
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
                        textMain.text = "<color=#f09>下班後還去聯成上C#課程，這樣置入有折扣嗎<<能力+7，社交+1，金錢-200>></color>";
                    }
                    else if (ageCheck > 7 && ageCheck < 8)
                    {
                        textMain.text = "<color=#f09>C#上完接著上Unity，又置入啦，為什麼說又呢?<<能力+7，社交+1，金錢-200>></color>";
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
                        textMain.text = "<color=#f09>對著面前不知是哪位的大媽咯咯笑<<社交+2，金錢-100>></color>";
                    }
                    else if (ageCheck > 1 && ageCheck < 2 && ageCheck != 1)
                    {
                        textMain.text = "<color=#f09>逛街時，對路上的小姐姐眨眨眼<<社交+2，金錢-100>></color>";
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
                        textMain.text = "<color=#f09>揪同學到圖書館集合，玩傳說對決<<社交+3，金錢-150>></color>";
                    }
                    else if (ageCheck > 3 && ageCheck < 4)
                    {
                        textMain.text = "<color=#f09>揪同學到陸鱷鯊集合，玩PTCG<<社交+3，金錢-150>></color>";
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
                        textMain.text = "<color=#f09>我們社團的宗旨是：智商少一半，快樂不間斷<<社交+5，金錢-180>></color>";
                    }
                    else if (ageCheck > 5 && ageCheck < 6)
                    {
                        textMain.text = "<color=#f09>約同學逛夜市，結果被夜市王的人潮擠爆了<<社交+5，金錢-180>></color>";
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
                        textMain.text = "<color=#f09>約同事一起聚餐，開始建立人脈了<<能力+1，社交+7，金錢-250>></color>";
                    }
                    else if (ageCheck > 7 && ageCheck < 8)
                    {
                        textMain.text = "<color=#f09>去貓舍做義工，撸貓比人際關係輕鬆多了<<能力+1，社交+7，金錢-250>></color>";
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
                        textMain.text = "<color=#f09>啃著沾有奶粉的手手被直播了<<能力+1，金錢+400>></color>";
                    }
                    else if (ageCheck > 1 && ageCheck < 2 && ageCheck != 1)
                    {
                        textMain.text = "<color=#f09>過年時，對著爺爺奶奶輸出一頓小搥搥<<能力+1，金錢+400>></color>";
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
                        textMain.text = "<color=#f09>幫爸爸出售Pokemon Ga-Ole的卡閘<<能力+1，社交+1，金錢+500>></color>";
                    }
                    else if (ageCheck > 3 && ageCheck < 4)
                    {
                        textMain.text = "<color=#f09>去阿姨的美食直播幫忙吃東西<<能力+1，社交+1，金錢+500>></color>";
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
                        textMain.text = "<color=#f09>飲料店的時薪，居然不如我5歲的小搥搥<<能力+2，社交+1，金錢+800>></color>";
                    }
                    else if (ageCheck > 5 && ageCheck < 6)
                    {
                        textMain.text = "<color=#f09>到企業實習，主要工作是訂下午茶??<<能力+2，社交+1，金錢+800>></color>";
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
                        textMain.text = "<color=#f09>加班賣肝，老闆賺翻<<能力+3，健康-2，金錢+1000>></color>";
                    }
                    else if (ageCheck > 7 && ageCheck < 8)
                    {
                        textMain.text = "<color=#f09>與其把肝賣給公司，何不直接賣給醫院??<<能力+3，健康-2，金錢+1000>></color>";
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

                #region 特殊事件
                case "Event1":
                    int randomEvent1 = EventRandom();
                    if (ageCheck == 1 && randomEvent1 <= 2)
                    {
                        LogSystem.LogWithColor("判定成功", "#f00");
                        LogSystem.LogWithColor("吃下後眼前變的五光十射，腦袋微微發熱，學習突飛猛進\n" +
                            "家長跟老師都大為驚嘆，被譽為一代神童<<能力+15>>", "#0ff");
                        stats.ModifyStat("ability", 15);
                    }
                    else if (ageCheck == 1 && randomEvent1 > 2)
                    {
                        LogSystem.LogWithColor("判定失敗", "#f00");
                        LogSystem.LogWithColor("吃下後突然頭痛欲裂，接連發了好幾天的燒，醒來後頭腦都不清楚了<<能力-5，健康-15>>", "#0ff");
                        stats.ModifyStat("ability", -5);
                        stats.ModifyStat("health", -15);
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
                    else if (ageCheck == 4 && stats.money >= 3500)
                    {
                        LogSystem.LogWithColor("這一年爸媽送你到英國留學，欣賞了大笨鐘增廣見聞\n" +
                            "增進了不少技能外也交到很多異國朋友，但食物真是不怎麼合胃口", "#0ff");
                        LogSystem.LogWithColor("<<能力+15，社交+15，金錢-3000>>", "#0ff");
                        stats.ModifyStat("ability", 15);
                        stats.ModifyStat("sociability", 15);
                        stats.ModifyStat("money", -3000);
                    }
                    else if (ageCheck == 4 && stats.money < 3500)
                    {
                        LogSystem.LogWithColor("不好意思你的錢不太夠，請選擇其他選項", "#f33");
                        stats.moneyNG = true;
                    }
                    else if (ageCheck == 5)
                    {
                        LogSystem.LogWithColor("收養後開始被他支配你的生活，回家要先玩逗貓棒，吃飯前要先餵飽他\n" +
                            "看電視音量不能超過6，但某天，他誤觸了你的手機投資app", "#0ff");
                        LogSystem.LogWithColor("卻意外地讓你賺了一筆意外之財<<社交-2，金錢+1200>>", "#0ff");
                        stats.ModifyStat("sociability", -2);
                        stats.ModifyStat("money", 1200);
                    }
                    if (ageCheck == 6 && randomEvent1 <= 1)
                    {
                        LogSystem.LogWithColor("判定成功", "#f00");
                        LogSystem.LogWithColor("在唸出台詞的瞬間，受到現場氛圍的感染，脫口而出:\n" +
                            "「我想做個好人」，讓這部電影大火，你一夕間成了網紅<<能力+20，社交+20，金錢+2000>>", "#0ff");
                        stats.ModifyStat("ability", 20);
                        stats.ModifyStat("sociability", 20);
                        stats.ModifyStat("money", 2000);
                    }
                    else if (ageCheck == 6 && randomEvent1 > 1)
                    {
                        LogSystem.LogWithColor("判定失敗", "#f00");
                        LogSystem.LogWithColor("上映當日，媽媽廣邀了親朋好友一同觀賞\n" +
                            "卻只看到你出現3秒，喊了一句「我是自己人」就給崩了", "#0ff");
                        LogSystem.LogWithColor("親友間都略顯尷尬，只有媽媽無比自豪<<能力+3，社交-10，金錢-300>>", "#0ff");
                        stats.ModifyStat("ability", 3);
                        stats.ModifyStat("sociability", -10);
                        stats.ModifyStat("money", -300);
                    }
                    if (ageCheck == 7 && randomEvent1 <= 2)
                    {
                        LogSystem.LogWithColor("判定成功", "#f00");
                        LogSystem.LogWithColor("你的AI助手居然進化成了超智能AI，並與你成為朋友\n" +
                            "在生活中他可以為你分析利弊，並提供解決方案，讓你的生活如遊戲般容易", "#0ff");
                        LogSystem.LogWithColor("<<能力+30，社交+20，金錢+1000>>", "#0ff");
                        stats.ModifyStat("ability", 30);
                        stats.ModifyStat("sociability", 20);
                        stats.ModifyStat("money", 1000);
                    }
                    else if (ageCheck == 7 && randomEvent1 > 2)
                    {
                        LogSystem.LogWithColor("判定失敗", "#f00");
                        LogSystem.LogWithColor("原來你的手機被魅魔寄宿了，隨著跟她交流\n" +
                            "你深深的不可自拔，精力被吸走，也不與他人溝通，日漸憔悴", "#0ff");
                        LogSystem.LogWithColor("最後是家人偷走你的手機，並請法師封印才告一段落\n<<能力-40，社交-40，健康-50，金錢-2000>>", "#0ff");
                        stats.ModifyStat("ability", -40);
                        stats.ModifyStat("sociability", -40);
                        stats.ModifyStat("health", -50);
                        stats.ModifyStat("money", -2000);
                    }
                    break;

                case "Event2":
                    int randomEvent2 = EventRandom();
                    if (ageCheck == 1)
                    {
                        LogSystem.LogWithColor("糖果被丟棄到地上時又觸發了黑洞，把地板整了一個大洞\n從此幼兒園開始瀰漫著關於你的怪談<<社交-10>>", "#0ff");
                        stats.ModifyStat("sociability", -10);
                    }
                    else if (ageCheck == 2)
                    {
                        LogSystem.LogWithColor("你回答她:「你想嚇我是嚇不倒的，我什麼都怕就是不怕鬼」\n" +
                            "結果她愣了一秒之後，撲過來把你爆抓一頓，醒來後發現你也渾身是抓傷，家裡的貓也不見了", "#0ff");
                        LogSystem.LogWithColor("媽媽以為是你打跑了牠 <<健康-10，金錢-200>>", "#0ff");
                        stats.ModifyStat("health", -10);
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
                    else if (ageCheck == 4 && randomEvent2 <= 4)
                    {
                        LogSystem.LogWithColor("判定成功", "#f00");
                        LogSystem.LogWithColor("全家來到了京都，在古寺及竹林中陶冶身心\n" +
                            "還去了一趟有馬泡了溫泉，是一趟滿滿的療癒之旅<<能力+5，健康+15，金錢-800>>", "#0ff");
                        stats.ModifyStat("ability", 5);
                        stats.ModifyStat("health", 15);
                        stats.ModifyStat("money", -800);
                    }
                    else if (ageCheck == 4 && randomEvent2 > 4)
                    {
                        LogSystem.LogWithColor("判定失敗", "#f00");
                        LogSystem.LogWithColor("你選擇去泰國旅遊，感受一下熱帶風情\n" +
                            "一下飛機就立馬被搭訕，正以為美夢開始，結果被騙到豬仔園區!!!命喪於此!!!", "#0ff");
                        LogSystem.LogWithColor("投胎囉~~~", "#ff0");
                        Born();
                        stats.ModifyStat("age", -1);
                        stats.ModifyStat("health", 1);
                    }
                    else if (ageCheck == 5)
                    {
                        LogSystem.LogWithColor("上網PO文之後，得到了熱心人的協助\n" +
                            "並且意外地加入了愛貓義工的社團<<社交+10>>", "#0ff");
                        stats.ModifyStat("sociability", 10);
                    }
                    else if (ageCheck == 6)
                    {
                        LogSystem.LogWithColor("參觀了一下拍攝之後，和朋友繼續享受了平凡舒適的旅遊\n" +
                            "<<社交+3，金錢-300>>", "#0ff");
                        stats.ModifyStat("sociability", 3);
                        stats.ModifyStat("money", -300);
                    }
                    if (ageCheck == 7)
                    {
                        LogSystem.LogWithColor("當你按下卸載時，你的手機App居然自動排版\n" +
                            "在畫面上排成一張生氣的臉，並且急速發熱後爆炸，導致你在醫院躺了幾天<<健康-15，金錢-800>>", "#0ff");
                        stats.ModifyStat("health", -15);
                        stats.ModifyStat("money", -800);
                    }
                    break;

                case "Event3":
                    if (ageCheck == 1)
                    {
                        LogSystem.LogWithColor("爸爸吃了糖果之後，昏睡了一天，隔天起床後\n" +
                            "靈感一來替公司創造新的專利賺了一筆獎金<<金錢+1000>>", "#0ff");
                        stats.ModifyStat("money", 1000);
                    }
                    else if (ageCheck == 2)
                    {
                        LogSystem.LogWithColor("你回答她:「我想和妳相識、相處、相知、相愛才能換得一片真心」\n" +
                            "醒來後發現家裡的貓貓變的更黏你了，你的人緣也變好<<社交+10>>", "#0ff");
                        stats.ModifyStat("sociability", 10);
                    }
                    else if (ageCheck == 3)
                    {
                        LogSystem.LogWithColor("迷:「罷了罷了，現在的年輕人，唉...健康的生活吧」\n" +
                            "<<健康+5，金錢-300>>", "#0ff");
                        stats.ModifyStat("health", 5);
                        stats.ModifyStat("money", -300);
                    }
                    else if (ageCheck == 4)
                    {
                        LogSystem.LogWithColor("爸媽覺得你是不想為家裡增添負擔，感到欣慰\n" +
                            "他們用出國的費用，給你買了一輛最新款Aphone，讓你在朋友圈裡拉風一波<<社交+5，金錢+300>>", "#0ff");
                        stats.ModifyStat("sociability", 5);
                        stats.ModifyStat("money", 300);
                    }
                    else if (ageCheck == 5)
                    {
                        LogSystem.LogWithColor("晚上居然又夢見一隻貓妖，正當心裡犯起一股不妙時\n" +
                            "再次被不由分說的爆抓一頓，睡醒後...你懂得<<健康-10，金錢-800>>", "#0ff");
                        stats.ModifyStat("health", -10);
                        stats.ModifyStat("money", -800);
                    }
                    else if (ageCheck == 6)
                    {
                        LogSystem.LogWithColor("想不到入鏡後，朋友特別上鏡，導演大喜\n" +
                            "居然為了他更改了劇本，幫他的角色增加了不少戲份，你只好當起小跟班<<能力+3，社交+3，金錢+200>>", "#0ff");
                        stats.ModifyStat("ability", 3);
                        stats.ModifyStat("sociability", 3);
                        stats.ModifyStat("money", 200);
                    }
                    if (ageCheck == 7)
                    {
                        LogSystem.LogWithColor("當下你興奮的截圖並PO上各大社群分享，引起譁然\n" +
                            "隔天卻被踢爆截圖都是修圖的照騙，而你打開手機，居然發現手機已被格式化", "#0ff");
                        LogSystem.LogWithColor("有冤無處伸的你，只能被貼上，又一個想紅的屁孩標籤" +
                            "<<社交-10>>", "#0ff");
                        stats.ModifyStat("sociability", -10);
                    }
                    break;
                #endregion

                #region 結局選項
                //結局選項
                case "Restart":
                    Born();
                    stats.ModifyStat("age", -1);
                    stats.ModifyStat("health", 1);
                    break;

                    #endregion
            }
            string eventCheck = eventName;
            if (ageCheck == 4 && stats.moneyNG && eventCheck == "Event1")
            {
            }
            else
            {
                Gourp();
                stats.moneyNG = false;
                float ageCheck2 = stats.age / 4;
                if (ageCheck2 >= 7.75f)
                {
                    textMain.text = "<color=#f64>-----結局啦~感謝你的遊玩-----</color>";
                    // 取得結局文本
                    string finalEnding = GetFinalEnding(stats.ability, stats.sociability, stats.health, stats.money);
                    Example(finalEnding);
                }
                #region 特殊事件開場內容
                // 特殊事件開場白
                switch (ageCheck2)
                {
                    case 1:
                        textMain.text = "<color=#ff0>在幼兒園吃完點心，打了個飽嗝\n" +
                        "突然面前出現一個黑洞並掉落一顆糖果\n包裝上的字有看沒有懂，你會?</color>";
                        ChangeEvent(0);
                        break;
                    case 2:
                        textMain.text = "<color=#ff0>在家午睡時夢見一位身著古裝的貓娘對你說:\n" +
                         "[公子，我等待一位真心人的深情一吻已千年，您能否成全小女子?]" +
                         "仔細一看他的服裝配色與家中的貓貓一般無二，你會?</color>";
                        ChangeEvent(1);
                        break;
                    case 3:
                        textMain.text = "<color=#ff0>國小畢旅回來後，莫名生了一場大病，高燒住院\n" +
                        "在病床上，迷迷糊糊中隱約聽見一股呼喚，你會?</color>";
                        ChangeEvent(2);
                        break;
                    case 4:
                        textMain.text = "<color=#ff0>今年元旦，爸媽興奮的告訴你要送你一份禮物\n" +
                        "問你想不想出國，你會?</color>";
                        ChangeEvent(3);
                        break;
                    case 5:
                        textMain.text = "<color=#ff0>在打完球的回家的路上，赫然發現一隻受傷的小貓，你會?</color>";
                        ChangeEvent(4);
                        break;
                    case 6:
                        textMain.text = "<color=#ff0>和朋友外出旅行時，突然有個導演衝過來說:\n" +
                        "「這位朋友，你的氣質太適合我們這場戲了!!請務必賞臉幫忙拜託。」" +
                        "看了下劇本，是個只有一句台詞的臥底砲灰，你會?</color>";
                        ChangeEvent(5);
                        break;
                    case 7:
                        textMain.text = "<color=#ff0>某天，你發現你手機裡的AI助手越來越智能\n" +
                        "並且在你生日的當天主動與你傳訊，你會?</color>";
                        ChangeEvent(6);
                        break;
                } 
                #endregion
                UpdateUI();
            }

        }
        // 各事件按鈕顯示切換
        void UpdateUI()
        {
            float ageCheck = stats.age / 4;
            if (ageCheck == 1 || ageCheck == 2 || ageCheck == 3 || ageCheck == 4 || ageCheck == 5 || ageCheck == 6 || ageCheck == 7) // 每 4 歲的事件按鈕
            {
                ToggleButtonGroup(normalButtons, false);  // 隱藏 基本選項
                ToggleButtonGroup(specialButtons, true);  // 顯示 特殊選項
                textPanel.SetActive(false);               // 隱藏 結局視窗
                ToggleButtonGroup(endButtons, false);     // 隱藏 結局選項
            }
            else if (ageCheck == 7.75f)
            {
                ToggleButtonGroup(normalButtons, false);  // 隱藏 基本選項
                ToggleButtonGroup(specialButtons, false); // 隱藏 特殊選項
                textPanel.SetActive(true);                // 顯示 結局視窗
                ToggleButtonGroup(endButtons, true);      // 顯示 結局選項
            }
            else
            {
                ToggleButtonGroup(normalButtons, true);   // 顯示 基本選項
                ToggleButtonGroup(specialButtons, false); // 隱藏 特殊選項
                textPanel.SetActive(false);               // 隱藏 結局視窗
                ToggleButtonGroup(endButtons, false);     // 隱藏 結局選項
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

        // 初始化 各種結局內容
        void InitializeEndings()
        {
            // 各屬性區間的描述
            // 能力
            endings["Ability"] = new Dictionary<string, string>
        {
            { "Low", "你的一生碌碌無為，總擔心被AI取代。" },
            { "Medium", "你的能力一般，是社會中穩定的小齒輪。" },
            { "High", "你的能力出眾，是能引導他人的領航者。" },
            { "Top", "你的才能頂尖，在業界是指標性人物!!" }
        };
            // 社交
            endings["Social"] = new Dictionary<string, string>
        {
            { "Low", "你總是獨來獨往，活在自己的世界。" },
            { "Medium", "你有幾個知心好友，偶爾相聚。" },
            { "High", "你交友廣闊，深受大家的喜愛。" },
            { "Top", "你是知名人物，且具有龐大的社群影響力!！" }
        };
            // 健康
            endings["Health"] = new Dictionary<string, string>
        {
            { "Low", "年過三十就落的一身病症，時常臥病在床。" },
            { "Medium", "你雖然偶爾生病，但仍能夠維持正常生活。" },
            { "High", "你的身體康健，可以自在的生活。" },
            { "Top", "你身體有如鋼鐵般堅韌，無畏病痛!！" }
        };
            // 金錢
            endings["Money"] = new Dictionary<string, string>
        {
            { "Low", "你每個月總在償還債務，是名符其實的負一代。" },
            { "Medium", "你過著小市民般的生活，追求小確幸。" },
            { "High", "你生活算是小康，不太常需要為了金錢煩惱。" },
            { "Top", "你的生活富裕，過的相當滋潤!！" }
        };
        }

        // 根據屬性值取得最終結局
        string GetFinalEnding(float ability, float social, float health, float money)
        {
            string abilityEnding = GetEndingByValue1(ability, "Ability");
            string socialEnding = GetEndingByValue1(social, "Social");
            string healthEnding = GetEndingByValue1(health, "Health");
            string moneyEnding = GetEndingByValue2(money, "Money");

            return $"\n{abilityEnding}\n{socialEnding}\n{healthEnding}\n{moneyEnding}";
        }

        // 根據數值判斷屬性區間，回傳一般屬性對應的結局
        string GetEndingByValue1(float value, string type)
        {
            if (value >= 0 && value < 50) return endings[type]["Low"];
            else if (value >= 50 && value < 70) return endings[type]["Medium"];
            else if (value >= 70 && value < 90) return endings[type]["High"];
            else return endings[type]["Top"];
        }
        // 根據數值判斷屬性區間，回傳金錢對應的結局
        string GetEndingByValue2(float value, string type)
        {
            if (value <=0) return endings[type]["Low"];
            else if (value > 0 && value < 1500) return endings[type]["Medium"];
            else if (value >= 1500 && value < 3000) return endings[type]["High"];
            else return endings[type]["Top"];
        }
        public TextTyper textTyper;

        void Example(string endText)
        {
            textTyper.ShowText($"你精生的結局是:{endText}");
        }
    }
}

