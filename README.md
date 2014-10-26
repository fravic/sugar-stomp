sugar-stomp
===========
![Alt text](http://g.gravizo.com/g?
  digraph G {
    class Component {}
    class GameManager extends Component {
      private Board _board;
      private List<BoardEntity> _boardEntities;
      public Board GetGameBoard();
    }
    class BoardEntity extends Component {
      protected void CollideInto(BoardEntity entity);
      protected void CollideReceived(BoardEntity entity);
      protected void DestroyEntity();
    }
    class Powerup extends Component {
      public void Apply();
      public void Remove();
      protected void PickedUp();
    }
    class MovementBehavior extends Component {
      public void IsTileAccessible(Tile tile);
    }
    class InputBehavior extends Component {}
    class PieceEntity extends BoardEntity {}
    class PowerupEntity extends BoardEntity {}
    class PlayerInputBehavior extends InputBehavior {}
    class AIInputBehavior extends InputBehavior {}
  }
)
