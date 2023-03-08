
using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Sounds")]
    [SerializeField] AudioSource typingSound;

    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.01f;

    [Header("Player")]
    [SerializeField] PlayerController playerController;

    [Header("load GLobals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject continueIcon;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private PlayerInputBinds playerInputBinds;
    private InputAction dialogueSkipButton;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private bool canContinueToNextLine = false;

    private Coroutine displayLineCoroutine;

    private static DialogueManager instance;

    private DialogueVariables dialogueVariables;

    private bool spacebarPressed = false;
    private bool storyContinued = false;
    private void Awake()
    {
        //playerInputBinds = new PlayerInputBinds();
        //dialogueSkipButton = playerInputBinds.Player.SkipDialogue;
        //playerInputBinds.Player.Enable();

        if (instance != null)
        {
            Debug.LogWarning("2 or more Dialogue Manager");
        }
        instance = this;

        dialogueVariables = new DialogueVariables(loadGlobalsJSON);
    }

    //private void OnDisable()
    //{
    //    playerInputBinds.Player.Disable();
    //}

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }
    private void Update()
    {
        if(!dialogueIsPlaying){return;}
        if(!canContinueToNextLine)
        {
            if(Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                spacebarPressed = true;
            }
            if(!typingSound.isPlaying)
            {
                typingSound.Play();
            }
        }
        else if(canContinueToNextLine)
        {
            typingSound.Stop();
        }
        if (canContinueToNextLine && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            storyContinued = true;
            ContinueStory();
        }
    }
    public void OnArrowClick()
    {
        storyContinued = true;
        ContinueStory();
    }
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        dialogueVariables.StartListening(currentStory);

        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogueVariables.StopListening(currentStory);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            if(displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }
    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = line;
        dialogueText.maxVisibleCharacters = 0;

        continueIcon.SetActive(false);
        HideChoices();
        bool isAddingRichTextTag = false;
        canContinueToNextLine = false;

        foreach (char letter in line.ToCharArray())
        {
            if(spacebarPressed)
            //if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                dialogueText.maxVisibleCharacters = line.Length;
                spacebarPressed = false;
                break;
            }

            if (letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            // if not rich text, add the next letter and wait a small time
            else
            {
                dialogueText.maxVisibleCharacters++;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
        continueIcon.SetActive(true);
        DisplayChoices();
        canContinueToNextLine = true;
        //StartCoroutine(SetCanContinue());
    }
    private IEnumerator SetCanContinue()
    {
        yield return new WaitForSeconds(0.3f);
        canContinueToNextLine = true;
    }
    private void HideChoices()
    {
        foreach(GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

    private void DisplayChoices()
    {
        
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: "
                + currentChoices.Count);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        //StartCoroutine(SelectFirstChoice()); // Coroutine to Select the first choice
    }

    //private IEnumerator SelectFirstChoice()
    //{
    //    EventSystem.current.SetSelectedGameObject(null);
    //    yield return new WaitForEndOfFrame();
    //    EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    //}

    public void MakeChoice(int choiceIndex)
    {
        if(canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();

        }
    }

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if(variableValue == null)
        {
            Debug.LogWarning("Ink Variable was found to be null: " + variableName);
        }
        return variableValue;
    }

    

    public void SetVariableState(string variableName, Ink.Runtime.Object variableValue)
    {
        if(dialogueVariables.variables.ContainsKey(variableName))
        {
            dialogueVariables.variables.Remove(variableName);
            dialogueVariables.variables.Add(variableName, variableValue);
        }
        else
        {
            Debug.LogWarning("Tried to update variable that wasnt initialized by globals.ink" + variableName);
        }
    }
}
