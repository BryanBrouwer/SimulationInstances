namespace Objective
{
    public interface IObjective
    {
        public int Score { get; }
        public bool IsComplete { get; }
        
        public void Complete();
        public void ResetObjective();
        public bool CanComplete();
    }
}
