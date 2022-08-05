using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTable;

    private void Awake()
    {
        GameManager.Score.AddListener(UpdateScore);
    }
    private void UpdateScore(List<IScore> members)
    {
        scoreTable.text = null;
        SortList(members);
        for(int i = 0; i < members.Count; i++)
        {
            if (members[i].Score == 0) continue;
            scoreTable.text += $"{members[i].Name}: {members[i].Score} ";
        }
    }
    private void SortList(List<IScore> members)
    {
        members.Sort((e1, e2) => 
        {
            return e2.Score.CompareTo(e1.Score);
        });
    }

}
