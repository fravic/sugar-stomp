using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board {

  private Dictionary<string,BoardEntity> _posToEnt = new Dictionary<string,BoardEntity>();
  private Dictionary<BoardEntity,string> _entToPos = new Dictionary<BoardEntity,string>();
  
  public BoardEntity GetEntAtTile(int tileX, int tileZ) {
    string key = CoordsToStr(tileX, tileZ);
    BoardEntity ent;
    if (_posToEnt.TryGetValue(key, out ent)) {
      return ent;
    } else {
      return null;
    }
  }

  public void UpdateEntPosition(BoardEntity ent, int tileX, int tileZ) {
    string oldPos;
    if (_entToPos.TryGetValue(ent, out oldPos)) {
      _posToEnt.Remove(oldPos);
      _entToPos.Remove(ent);
    }

    string newKey = CoordsToStr(tileX, tileZ);
    _posToEnt.Add(newKey, ent);
    _entToPos.Add(ent, newKey);
  }

  public void RemoveEnt(BoardEntity ent) {
    string oldPos;
    if (_entToPos.TryGetValue(ent, out oldPos)) {
      _posToEnt.Remove(oldPos);
      _entToPos.Remove(ent);
    }
  }

  private string CoordsToStr(int tileX, int tileZ) {
    return tileX + "," + tileZ;
  }

}