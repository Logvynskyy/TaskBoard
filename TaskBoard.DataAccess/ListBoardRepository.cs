﻿using TaskBoard.Core.Models;

namespace TaskBoard.DataAccess
{
    public class ListBoardRepository : IBoardRepository
    {
        private readonly List<Board> _boards = new() { new Board(0, "Board1") };
        private int _boardId = 1;
        public void Add(Board board)
        {
            board.Id = _boardId++;
            _boards.Add(board);
        }

        public void Update(int id, string name)
        {
            _boards[id].Name = name;
        }

        public void DeleteById(int id)
        {
            _boards.RemoveAt(id);
        }

        public List<Board> GetAll()
        {
            return _boards;
        }

        public Board GetById(int id)
        {
            return _boards[id];
        }   
    }
}