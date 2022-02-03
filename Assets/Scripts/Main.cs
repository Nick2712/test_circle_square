using UnityEngine;


namespace CircleSquare
{
    public class Main : MonoBehaviour
    {
        private GameController _gameController;

        void Start()
        {
            var gameOptions = Resources.Load<GameOptions>(Constants.GameOptions);
            var figures = FindObjectsOfType<FigureView>();
            _gameController = new GameController(Camera.main, gameOptions, figures);
        }

        private void Update()
        {
            _gameController.Update();
        }
    }
}