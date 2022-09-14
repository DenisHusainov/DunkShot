public class GameManager : Singleton<GameManager>
{
    public bool IsStarted { get; private set; }
    public bool IsFly { get; private set; }
    public bool IsFinished { get; private set; }

    private void OnEnable()
    {
        MainWindow.Started += MainWindow_Started;
        Ball.BallFlew += InputManager_BallFlew;
        Ball.BallFlewOut += Ball_BallFlewOut;
    }


    private void OnDisable()
    {
        MainWindow.Started -= MainWindow_Started;
        Ball.BallFlew -= InputManager_BallFlew;
        Ball.BallFlewOut -= Ball_BallFlewOut;
    }

    private void MainWindow_Started()
    {
        IsStarted = true;
    }

    private void InputManager_BallFlew()
    {
        IsFly = false;
    }

    private void Ball_BallFlewOut()
    {
        IsFly = true;
    }
}
