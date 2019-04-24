using System.Collections.Generic;
using CaseNetworking;

[System.Serializable]
public class ParamsMessage : CaseNetMessage
{
    public int nbTeams;
    public int sceneId;
    public List<int> itemIds;
    public int time;

    public ParamsMessage()
    {
        messageCode = MessageCode.ParamsMessage;
    }
}