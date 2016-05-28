using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menu : MonoBehaviour {
	
	[HideInInspector] public string state = "title";
    private bool colorblind = false;
    private int altTileNum = 0;
    [SerializeField] private GameObject defaultTile;
	[SerializeField] private GameObject title;
    [SerializeField] private GameObject mainMenu;
    private int score = 0;
    private int currentLevelNum = 0;
    private AudioSource[] sounds;
    
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject optionsOn;
    [SerializeField] private GameObject optionsOff;
    [SerializeField] private GameObject menuButtonsPanel;
    [SerializeField] private GameObject backButtonPanel;
    [SerializeField] private GameObject backButtonPanel_Inverse;
    [SerializeField] private GameObject optionsButtonsPanel;
    [SerializeField] private GameObject timerPanel;
    [SerializeField] private GameObject scorePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject level_Panel_1;
    [SerializeField] private GameObject level_Panel_2;
    [SerializeField] private GameObject level_Panel_3;
    [SerializeField] private GameObject level_Panel_4;
    [SerializeField] private GameObject level_Panel_5;
    [SerializeField] private GameObject level_Panel_6;
    [SerializeField] private GameObject level_Panel_7;
    [SerializeField] private GameObject level_Panel_8;

    [Header("Colors 0.1")]
    [SerializeField] private Color[] tileColors_0;
    [SerializeField] private Color[] tileColors_1;
    [SerializeField] private Color[] tileColors_2;
    [SerializeField] private Color[] tileColors_3;
    [SerializeField] private Color[] tileColors_4;
    [SerializeField] private Color[] tileColors_5;
    [SerializeField] private Color[] tileColors_6;
    [SerializeField] private Color[] tileColors_7;
    [SerializeField] private Color[] tileColors_8;
    [SerializeField] private Color[] tileColors_9;
    [SerializeField] private Color[] tileColors_10;
    [SerializeField] private Color[] tileColors_11;

    [Header("Colors 0.2")]
    [SerializeField] private Color[] tileColors_1_0;
    [SerializeField] private Color[] tileColors_1_1;
    [SerializeField] private Color[] tileColors_1_2;
    [SerializeField] private Color[] tileColors_1_3;
    [SerializeField] private Color[] tileColors_1_4;

    [Header("Colors 0.3")]
    [SerializeField] private Color[] tileColors_2_0;
    [SerializeField] private Color[] tileColors_2_1;
    [SerializeField] private Color[] tileColors_2_2;
    [SerializeField] private Color[] tileColors_2_3;
    [SerializeField] private Color[] tileColors_2_4;
    [SerializeField] private Color[] tileColors_2_5;
    [SerializeField] private Color[] tileColors_2_6;
    [SerializeField] private Color[] tileColors_2_7;
    [SerializeField] private Color[] tileColors_2_8;
    [SerializeField] private Color[] tileColors_2_9;
    [SerializeField] private Color[] tileColors_2_10;
    [SerializeField] private Color[] tileColors_2_11;
    [SerializeField] private Color[] tileColors_2_12;
    [SerializeField] private Color[] tileColors_2_13;
    [SerializeField] private Color[] tileColors_2_14;
    [SerializeField] private Color[] tileColors_2_15;
    [SerializeField] private Color[] tileColors_2_16;
    [SerializeField] private Color[] tileColors_2_17;
    [SerializeField] private Color[] tileColors_2_18;

    private Color lastColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);


    void Awake()
    {

        title.GetComponent<SpriteRenderer>().enabled = true;
        StartCoroutine(HideTitle());
        sounds = Camera.main.GetComponents<AudioSource>();

    }
	
	
	void Start ()
	{

        

    }


    private IEnumerator HideTitle ()
    {

        if (title.GetComponent<SpriteRenderer>().color.a == 1.0f)
        {
            yield return new WaitForSeconds(1.5f);
        }

        yield return new WaitForSeconds(0.05f);

        Color newA = title.GetComponent<SpriteRenderer>().color;
        newA = new Color(newA.r, newA.g, newA.b, newA.a - 0.05f);
        title.GetComponent<SpriteRenderer>().color = newA;

        if (title.GetComponent<SpriteRenderer>().color.a > 0.0f)
        {
            StartCoroutine(HideTitle());
        }
        else
        {
            title.GetComponent<SpriteRenderer>().enabled = false;

            yield return new WaitForSeconds(0.75f);

            mainMenu.GetComponent<SpriteRenderer>().enabled = true;
            menuButtonsPanel.SetActive(true);
            state = "mainMenu";
            //sounds[1].Play();
        }

    }


    public void MenuButtons (string type)
    {

        if (type == "play")
        {
            sounds[0].Play();

            mainMenu.GetComponent<SpriteRenderer>().enabled = false;
            menuButtonsPanel.SetActive(false);
            backButtonPanel.SetActive(true);
            timerPanel.SetActive(true);
            timerPanel.GetComponent<Image>().fillAmount = 1.0f;
            scorePanel.SetActive(true);

            state = "level_1";
            currentLevelNum = 1;

            score = 0;
            scorePanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = score.ToString();

            GameObject tempNew = GameObject.Find("New Game Object");
            if (tempNew != null)
                Destroy(tempNew.gameObject);

            CreateLevel();

            sounds[2].Play();
        }
        else if (type == "tutorial")
        {
            sounds[0].Play();

            mainMenu.GetComponent<SpriteRenderer>().enabled = false;
            menuButtonsPanel.SetActive(false);
            //backButtonPanel.transform.FindChild("backArrow").gameObject.GetComponent<SpriteRenderer>().color = new Color(0.85f, 0.85f, 0.85f);
            backButtonPanel_Inverse.SetActive(true);

            state = "tutorial";
            tutorial.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (type == "about")
        {
            sounds[0].Play();

            mainMenu.GetComponent<SpriteRenderer>().enabled = false;
            menuButtonsPanel.SetActive(false);
            //backButtonPanel.transform.FindChild("backArrow").gameObject.GetComponent<SpriteRenderer>().color = new Color(0.85f, 0.85f, 0.85f);
            backButtonPanel_Inverse.SetActive(true);

            state = "options";
            optionsButtonsPanel.SetActive(true);

            if (!colorblind)
                optionsOff.GetComponent<SpriteRenderer>().enabled = true;
            else
                optionsOn.GetComponent<SpriteRenderer>().enabled = true;
        }
        else if (type == "colorblind")
        {
            sounds[0].Play();

            colorblind = !colorblind;

            if (!colorblind)
            {
                optionsOn.GetComponent<SpriteRenderer>().enabled = false;
                optionsOff.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                optionsOff.GetComponent<SpriteRenderer>().enabled = false;
                optionsOn.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else if (type == "back")
        {
            sounds[0].Play();

            level_Panel_1.SetActive(false);
            level_Panel_2.SetActive(false);
            level_Panel_3.SetActive(false);
            level_Panel_4.SetActive(false);
            level_Panel_5.SetActive(false);
            level_Panel_6.SetActive(false);
            level_Panel_7.SetActive(false);
            level_Panel_8.SetActive(false);

            currentLevelNum = 0;

            backButtonPanel.SetActive(false);
            backButtonPanel_Inverse.SetActive(false);

            state = "mainMenu";
            mainMenu.GetComponent<SpriteRenderer>().enabled = true;
            menuButtonsPanel.SetActive(true);

            tutorial.GetComponent<SpriteRenderer>().enabled = false;
            optionsOn.GetComponent<SpriteRenderer>().enabled = false;
            optionsOff.GetComponent<SpriteRenderer>().enabled = false;

            optionsButtonsPanel.SetActive(false);

            timerPanel.SetActive(false);

            scorePanel.SetActive(false);

            StopAllCoroutines();

            GameObject tempNew = GameObject.Find("New Game Object");
            if (tempNew != null)
                Destroy(tempNew.gameObject);
        }
        else if (type == "replay")
        {
            sounds[0].Play();

            level_Panel_1.SetActive(false);
            level_Panel_2.SetActive(false);
            level_Panel_3.SetActive(false);
            level_Panel_4.SetActive(false);
            level_Panel_5.SetActive(false);
            level_Panel_6.SetActive(false);
            level_Panel_7.SetActive(false);
            level_Panel_8.SetActive(false);

            currentLevelNum = 0;

            backButtonPanel.SetActive(false);

            optionsButtonsPanel.SetActive(false);

            timerPanel.SetActive(false);

            scorePanel.SetActive(false);

            timerPanel.SetActive(true);
            timerPanel.GetComponent<Image>().fillAmount = 1.0f;
            scorePanel.SetActive(true);

            backButtonPanel.SetActive(true);
            gameOverPanel.SetActive(false);

            state = "level_1";
            currentLevelNum = 1;

            score = 0;
            scorePanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = score.ToString();

            GameObject tempNew = GameObject.Find("New Game Object");
            if (tempNew != null)
                Destroy(tempNew.gameObject);

            CreateLevel();

            sounds[2].Play();
        }
        else if (type == "backToMain")
        {
            sounds[0].Play();

            level_Panel_1.SetActive(false);
            level_Panel_2.SetActive(false);
            level_Panel_3.SetActive(false);
            level_Panel_4.SetActive(false);
            level_Panel_5.SetActive(false);
            level_Panel_6.SetActive(false);
            level_Panel_7.SetActive(false);
            level_Panel_8.SetActive(false);

            currentLevelNum = 0;

            backButtonPanel.SetActive(false);

            optionsButtonsPanel.SetActive(false);

            timerPanel.SetActive(false);

            scorePanel.SetActive(false);

            gameOverPanel.SetActive(false);

            state = "level_1";
            currentLevelNum = 1;

            score = 0;
            scorePanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = score.ToString();

            state = "mainMenu";
            mainMenu.GetComponent<SpriteRenderer>().enabled = true;
            menuButtonsPanel.SetActive(true);

            GameObject tempNew = GameObject.Find("New Game Object");
            if (tempNew != null)
                Destroy(tempNew.gameObject);
        }

    }


    public void TileButtons (int buttonNum)
    {

        if (buttonNum == altTileNum)
        {
            sounds[1].Play();

            score += 100;
            scorePanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = score.ToString();

            StopAllCoroutines();
            currentLevelNum++;
            state = "level_" + currentLevelNum.ToString();

            if (currentLevelNum == 2)
            {
                level_Panel_1.SetActive(false);
            }
            else if (currentLevelNum == 3)
            {
                level_Panel_2.SetActive(false);
            }
            else if (currentLevelNum == 4)
            {
                level_Panel_3.SetActive(false);
            }
            else if (currentLevelNum == 5)
            {
                level_Panel_4.SetActive(false);
            }
            else if (currentLevelNum == 6)
            {
                level_Panel_5.SetActive(false);
            }
            else if (currentLevelNum == 7)
            {
                level_Panel_6.SetActive(false);
            }
            else if (currentLevelNum == 8)
            {
                level_Panel_7.SetActive(false);
            }

            CreateLevel();
        }
        else
        {
            sounds[1].Play();

            score -= 50;
            scorePanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = score.ToString();

            StopAllCoroutines();
            StartCoroutine(SetTimer(-1));
        }

    }


    void CreateLevel ()
    {

        GameObject tempNew = GameObject.Find("New Game Object");
        if (tempNew != null)
            Destroy(tempNew.gameObject);

        if (state == "level_1")
        {
            level_Panel_1.SetActive(true);
        }
        else if (state == "level_2")
        {
            level_Panel_2.SetActive(true);
        }
        else if (state == "level_3")
        {
            level_Panel_3.SetActive(true);
        }
        else if (state == "level_4")
        {
            level_Panel_4.SetActive(true);
        }
        else if (state == "level_5")
        {
            level_Panel_5.SetActive(true);
        }
        else if (state == "level_6")
        {
            level_Panel_6.SetActive(true);
        }
        else if (state == "level_7")
        {
            level_Panel_7.SetActive(true);
        }
        else if (state == "level_8")
        {
            level_Panel_8.SetActive(true);
        }

        ColorTiles();

    }


    void ColorTiles ()
    {

        //Color Palette 0.1
        /*int colorPalette = Random.Range(0, 12);
        int tone = Random.Range(0, 7);*/

        //Color Palette 0.2
        /*int colorPalette = Random.Range(0, 5);
        int tone = Random.Range(0, 13);*/

        //Color Palette 0.3
        int colorPalette = Random.Range(0, 18);
        int tone = Random.Range(0, 8);

        int altTone = 0;
        Color randColor = Color.white;
        Color altColor = Color.white;

        if (tone == 0)
            altTone = 1;
        else if (tone == 7)
            altTone = 6;
        else
        {
            int diffColor = Random.Range(0, 2);

            if (diffColor == 0)
                altTone = tone - 1;
            else if (diffColor == 1)
                altTone = tone + 1;
        }

        //Color Palette 0.1
        /*if (colorPalette == 0)
        {
            randColor = tileColors_0[tone];
            altColor = tileColors_0[altTone];
        }
        else if (colorPalette == 1)
        {
            randColor = tileColors_1[tone];
            altColor = tileColors_1[altTone];
        }
        else if (colorPalette == 2)
        {
            randColor = tileColors_2[tone];
            altColor = tileColors_2[altTone];
        }
        else if (colorPalette == 3)
        {
            randColor = tileColors_3[tone];
            altColor = tileColors_3[altTone];
        }
        else if (colorPalette == 4)
        {
            randColor = tileColors_4[tone];
            altColor = tileColors_4[altTone];
        }
        else if (colorPalette == 5)
        {
            randColor = tileColors_5[tone];
            altColor = tileColors_5[altTone];
        }
        else if (colorPalette == 6)
        {
            randColor = tileColors_6[tone];
            altColor = tileColors_6[altTone];
        }
        else if (colorPalette == 7)
        {
            randColor = tileColors_7[tone];
            altColor = tileColors_7[altTone];
        }
        else if (colorPalette == 8)
        {
            randColor = tileColors_8[tone];
            altColor = tileColors_8[altTone];
        }
        else if (colorPalette == 9)
        {
            randColor = tileColors_9[tone];
            altColor = tileColors_9[altTone];
        }
        else if (colorPalette == 10)
        {
            randColor = tileColors_10[tone];
            altColor = tileColors_10[altTone];
        }
        else if (colorPalette == 11)
        {
            randColor = tileColors_11[tone];
            altColor = tileColors_11[altTone];
        }*/

        //Color Palette 0.2
        /*if (colorPalette == 0)
        {
            randColor = tileColors_1_0[tone];
            altColor = tileColors_1_0[altTone];
        }
        else if (colorPalette == 1)
        {
            randColor = tileColors_1_1[tone];
            altColor = tileColors_1_1[altTone];
        }
        else if (colorPalette == 2)
        {
            randColor = tileColors_1_2[tone];
            altColor = tileColors_1_2[altTone];
        }
        else if (colorPalette == 3)
        {
            randColor = tileColors_1_3[tone];
            altColor = tileColors_1_3[altTone];
        }
        else if (colorPalette == 4)
        {
            randColor = tileColors_1_4[tone];
            altColor = tileColors_1_4[altTone];
        }*/

        //Color Palette 0.3
        if (colorPalette == 0)
        {
            randColor = tileColors_2_0[tone];
            altColor = tileColors_2_0[altTone];
        }
        else if (colorPalette == 1)
        {
            randColor = tileColors_2_1[tone];
            altColor = tileColors_2_1[altTone];
        }
        else if (colorPalette == 2)
        {
            randColor = tileColors_2_2[tone];
            altColor = tileColors_2_2[altTone];
        }
        else if (colorPalette == 3)
        {
            randColor = tileColors_2_3[tone];
            altColor = tileColors_2_3[altTone];
        }
        else if (colorPalette == 4)
        {
            randColor = tileColors_2_4[tone];
            altColor = tileColors_2_4[altTone];
        }
        else if (colorPalette == 5)
        {
            randColor = tileColors_2_5[tone];
            altColor = tileColors_2_5[altTone];
        }
        else if (colorPalette == 6)
        {
            randColor = tileColors_2_6[tone];
            altColor = tileColors_2_6[altTone];
        }
        else if (colorPalette == 7)
        {
            randColor = tileColors_2_7[tone];
            altColor = tileColors_2_7[altTone];
        }
        else if (colorPalette == 8)
        {
            randColor = tileColors_2_8[tone];
            altColor = tileColors_2_8[altTone];
        }
        else if (colorPalette == 9)
        {
            randColor = tileColors_2_9[tone];
            altColor = tileColors_2_9[altTone];
        }
        else if (colorPalette == 10)
        {
            randColor = tileColors_2_10[tone];
            altColor = tileColors_2_10[altTone];
        }
        else if (colorPalette == 11)
        {
            randColor = tileColors_2_11[tone];
            altColor = tileColors_2_11[altTone];
        }
        else if (colorPalette == 12)
        {
            randColor = tileColors_2_12[tone];
            altColor = tileColors_2_12[altTone];
        }
        else if (colorPalette == 13)
        {
            randColor = tileColors_2_13[tone];
            altColor = tileColors_2_13[altTone];
        }
        else if (colorPalette == 14)
        {
            randColor = tileColors_2_14[tone];
            altColor = tileColors_2_14[altTone];
        }
        else if (colorPalette == 15)
        {
            randColor = tileColors_2_15[tone];
            altColor = tileColors_2_15[altTone];
        }
        else if (colorPalette == 16)
        {
            randColor = tileColors_2_16[tone];
            altColor = tileColors_2_16[altTone];
        }
        else if (colorPalette == 17)
        {
            randColor = tileColors_2_17[tone];
            altColor = tileColors_2_17[altTone];
        }
        else if (colorPalette == 18)
        {
            randColor = tileColors_2_18[tone];
            altColor = tileColors_2_18[altTone];
        }

        if (randColor != lastColor)
        {
            GameObject tempLayout = new GameObject();

            if (state == "level_1")
                tempLayout = level_Panel_1.transform.FindChild("Level_Layout").gameObject;
            else if (state == "level_2")
                tempLayout = level_Panel_2.transform.FindChild("Level_Layout").gameObject;
            else if (state == "level_3")
                tempLayout = level_Panel_3.transform.FindChild("Level_Layout").gameObject;
            else if (state == "level_4")
                tempLayout = level_Panel_4.transform.FindChild("Level_Layout").gameObject;
            else if (state == "level_5")
                tempLayout = level_Panel_5.transform.FindChild("Level_Layout").gameObject;
            else if (state == "level_6")
                tempLayout = level_Panel_6.transform.FindChild("Level_Layout").gameObject;
            else if (state == "level_7")
                tempLayout = level_Panel_7.transform.FindChild("Level_Layout").gameObject;
            else
                tempLayout = level_Panel_8.transform.FindChild("Level_Layout").gameObject;

            GameObject[] tileArray = new GameObject[tempLayout.transform.childCount];

            for (int i = 0; i < tempLayout.transform.childCount; i++)
            {
                tileArray[i] = tempLayout.transform.GetChild(i).gameObject;
            }

            for (int i = 0; i < tileArray.Length; i++)
            {
                tileArray[i].GetComponent<Image>().color = new Color(randColor.r, randColor.g, randColor.b, 1.0f);
            }

            int lonelyTile = Random.Range(0, tempLayout.transform.childCount);
            altTileNum = lonelyTile;

            tempLayout.transform.GetChild(lonelyTile).gameObject.GetComponent<Image>().color = new Color(altColor.r, altColor.g, altColor.b, 1.0f);

           //backButtonPanel.transform.FindChild("backArrow").gameObject.GetComponent<SpriteRenderer>().color = new Color(randColor.r, randColor.g, randColor.b, 1.0f);

            //timerPanel.GetComponent<Image>().color = new Color(randColor.r, randColor.g, randColor.b, 1.0f);

            lastColor = new Color(randColor.r, randColor.g, randColor.b, 1.0f);

            StartCoroutine(SetTimer(0));
        }
        else
        {
            ColorTiles();
        }

    }

    IEnumerator SetTimer (int duration)
    {

        float tempCurrentFill = timerPanel.GetComponent<Image>().fillAmount;
        float tempFill = 0.025f;

        if (duration == 0)
        {
            timerPanel.GetComponent<Image>().fillAmount += 0.15f;
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(SetTimer(1));
        }
        else if (duration == -1)
        {
            tempCurrentFill -= 5*tempFill;

            timerPanel.GetComponent<Image>().fillAmount = tempCurrentFill;
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(SetTimer(1));
        }
        else
        {
            if (tempCurrentFill > 0.0f)
            {
                tempCurrentFill -= tempFill;

                timerPanel.GetComponent<Image>().fillAmount = tempCurrentFill;
                yield return new WaitForSeconds(0.1f);
                int tempDuration = duration + 1;
                StartCoroutine(SetTimer(tempDuration));
            }
            else
            {
                state = "gameOver";
                GameOver();
            }
        }

    }


    private void GameOver ()
    {
        sounds[2].Stop();

        //bool newHighScore = false;
        gameOverPanel.SetActive(true);
        backButtonPanel.SetActive(false);
        scorePanel.SetActive(false);
        timerPanel.SetActive(false);

        level_Panel_1.SetActive(false);
        level_Panel_2.SetActive(false);
        level_Panel_3.SetActive(false);
        level_Panel_4.SetActive(false);
        level_Panel_5.SetActive(false);
        level_Panel_6.SetActive(false);
        level_Panel_7.SetActive(false);
        level_Panel_8.SetActive(false);

        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
                //newHighScore = true;
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
            //newHighScore = true;
        }

        GameObject uiScore = gameOverPanel.transform.FindChild("ScoreText").gameObject;

        uiScore.GetComponent<Text>().text = score.ToString();

        //GameObject uiBestScore = gameOverPanel.transform.FindChild("BestText").gameObject;

        //uiBestScore.GetComponent<Text>().text = "Best Score: " + PlayerPrefs.GetInt("highScore").ToString();

        //GameObject newHighText = gameOverPanel.transform.FindChild("NewText").gameObject;

        /*if (newHighScore == true)
            newHighText.SetActive(true);
        else
            newHighText.SetActive(false);*/

    }


    void Update ()
    {



    }

}
