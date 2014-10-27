sugar-stomp
===========
![Alt text](http://g.gravizo.com/g?
  class Component {}
  /**
  *@opt operations
  */
  class GameManager extends Component {
    public Board GetGameBoard();
  }
  /**
  *@opt operations
  */
  class BoardEntity extends Component {
    protected void CollideInto(BoardEntity entity);
    protected void CollideReceived(BoardEntity entity);
    protected void DestroyEntity();
  }
  /**
  *@opt operations
  */
  class Powerup extends Component {
    public void Apply();
    public void Remove();
    protected void PickedUp();
  }
  /**
  *@opt operations
  */
  class MovementBehavior extends Component {
    public void IsTileAccessible(Tile tile);
  }
  class InputBehavior extends Component {}
  class PieceEntity extends BoardEntity {}
  class PowerupEntity extends BoardEntity {}
  class PlayerInputBehavior extends InputBehavior {}
  class AIInputBehavior extends InputBehavior {}
)
