using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistance 
{
    public void LoadGame(GameData gamedata);
    public void SaveGame(ref GameData gamedata);
}
