using System;

namespace _06.ESGI.DesignPattern.State
{
    public class Task
    { 
        public ITaskState State { get; set; }

        public Task()
        {
            State = new TodoState();
        }

        public string Start()
        {
           return State.Start(this);
        }

        public string Close()
        {
            return State.Close(this);
        }
    }

    public class TodoState : ITaskState
    {
        public string Start(Task ctx)
        {
            ctx.State = new InProgressState();
            return "TODO -> IN PROGRESS";
        }

        public string Close(Task ctx)
        {
            return "INVALID TRANSITION";
        }
    }

    public class InProgressState : ITaskState
    {
        public string Start(Task ctx)
        {
            return "INVALID TRANSITION";
        }

        public string Close(Task ctx)
        {
            ctx.State = new ClosedState();
            return "IN PROGRESS -> CLOSED";
        }
    }

    public class ClosedState : ITaskState
    {
        public string Start(Task ctx)
        {
            return "INVALID TRANSITION";
        }

        public string Close(Task ctx)
        {
            return "INVALID TRANSITION";
        }
    }

    public interface ITaskState
    {
        string Start(Task ctx);
        string Close(Task ctx);
    }
}
