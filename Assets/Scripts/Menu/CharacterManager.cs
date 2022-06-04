using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> characters;
    [SerializeField] private TextMeshProUGUI counter;

    private GameObject selectedCharacter;
    private int selectedCharacterIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectCharacter(characters[selectedCharacterIndex]);
    }

    public void NextCharacter()
    {
        if ((selectedCharacterIndex + 1) < characters.Count)
        {
            selectedCharacterIndex++;
            SelectCharacter(characters[selectedCharacterIndex]);
            ChageCounter(selectedCharacterIndex + 1);
        }
    }

    public void PreviousCharacter()
    {
        if (selectedCharacterIndex > 0)
        {
            selectedCharacterIndex--;
            SelectCharacter(characters[selectedCharacterIndex]);
            ChageCounter(selectedCharacterIndex + 1);
        }
    }

    public void EnterToWorld()
    {
        StoreManager.Instance.character = selectedCharacter;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    /// <summary>
    /// Selects the character.
    /// </summary>
    /// <param name="gameObject">The game object.</param>
    private void SelectCharacter(GameObject gameObject)
    {
        if (selectedCharacter != null)
        {
            selectedCharacter.gameObject.SetActive(false);
        }

        selectedCharacter = gameObject;
        selectedCharacter.gameObject.SetActive(true);
    }

    /// <summary>
    /// Chages the counter.
    /// </summary>
    /// <param name="count">The count.</param>
    private void ChageCounter(int count)
    {
        counter.text = string.Format("{0}/{1}", count, characters.Count);
    }
}
