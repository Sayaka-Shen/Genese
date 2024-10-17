using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogDatabase", menuName = "Database/Dialogue", order = 0)]
public class DialogDatabase : ScriptableObject
{
    public List<DialogData> dialogDatas = new();
    public List<ChoiceData> choiceDatas = new();

    public DialogData GetData(string id) => dialogDatas.Find(x => x.Id == id);
    public ChoiceData GetChoiceData(string id) => choiceDatas.Find(x => x.Id == id);
}
