using Patterns.GameEvents;

namespace SpaceMarine.Model
{
    public class GameAttributes : BaseGameMechanic
    {
        public bool IsStarted { get; private set; }
        public bool IsFinished { get; private set; }
        
        public GameAttributes(IGame game) : base(game)
        {
        }
        
        //--------------------------------------------------------------------------------------------------------------

        public void StartGame()
        {
            if (IsStarted)
                return;
            
            if (IsFinished)
                return;
            
            IsStarted = true;
            OnStart();
        }

        public void EndGame()
        {
            if (!IsStarted)
                return;
            
            if (IsFinished)
                return;
            
            IsFinished = true;
            OnEnd();
        }
        
        //--------------------------------------------------------------------------------------------------------------

        /// <summary>
        ///     Dispatch start game
        /// </summary>
        void OnStart()
        {
            GameEvents.Instance.Notify<Events.IStartGame>(i => i.OnStartGame(Game));
        }
        
        /// <summary>
        ///     Dispatch end game.
        /// </summary>
        void OnEnd()
        {
            GameEvents.Instance.Notify<Events.IEndGame>(i => i.OnEndGame());
        }
    }
}