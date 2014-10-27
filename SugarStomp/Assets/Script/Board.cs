using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board {

  private Dictionary<string,BoardEntity> _posToEnt = new Dictionary<string,BoardEntity>();
  
  public BoardEntity GetPieceAtTile(int tileX, int tileZ) {
    string key = CoordsToStr(tileX, tileZ);
    BoardEntity piece;
    if (_posToEnt.TryGetValue(key, out piece)) {
      return piece;
    } else {
      return null;
    }
  }

  public void UpdatePiecePosition(BoardEntity piece, int tileX, int tileZ) {
    int oldTileX = piece.GetTileX();
    int oldTileZ = piece.GetTileZ();
    string oldKey = CoordsToStr(oldTileX, oldTileZ);
    _posToEnt.Remove(oldKey);

    string newKey = CoordsToStr(tileX, tileZ);
    _posToEnt.Add(newKey, piece);
  }

  private string CoordsToStr(int tileX, int tileZ) {
    return tileX + "," + tileZ;
  }

}