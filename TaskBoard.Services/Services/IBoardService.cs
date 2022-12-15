﻿using TaskBoard.Core.Models;

namespace TaskBoard.Services.Services
{
    public interface IBoardService
    {
        Board GetById(int id);
        List<Board> GetAll();
        bool Add(Board board);
        bool Update(int id, string name);
        bool DeleteById(int id);
    }
}