using System;

namespace sugoroku.prg
{
    public class Player
    {
        private readonly string Name;

        private int CurrentCell;

        private bool Finished;

        public Player(string name)
        {
            this.Name = name;
            this.CurrentCell = 0;
            this.Finished = false;
        }

        public string GetName() { return this.Name; }

        public int GetCurrentCell() { return this.CurrentCell; }

        public void SetCurrentCell(int cell)
        {
            if(this.CurrentCell+cell > Common.c_FinishCell)
            {
                this.CurrentCell += (cell - (Common.c_FinishCell - this.CurrentCell));
            }
            else
            {
                this.CurrentCell += cell;
            }
            if (this.CurrentCell == Common.c_FinishCell) SetFinished(finished: true);
        }

        public bool GetFinished() { return this.Finished; }

        public void SetFinished(bool finished) { this.Finished = finished; }
    }
}
