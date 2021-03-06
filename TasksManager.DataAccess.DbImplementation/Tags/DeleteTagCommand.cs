﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TasksManager.DataAccess.Tags;
using TasksManager.DataAccess.Tasks;
using TasksManager.Db;
using TasksManager.Entities;
using Task = System.Threading.Tasks.Task;

namespace TasksManager.DataAccess.DbImplementation.Tags
{
    public class DeleteTagCommand : IDeleteTagCommand
    {
        private TasksContext _context;
        private IMapper _mapper;
        public DeleteTagCommand(TasksContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task ExecuteAsync(string tag)
        {
            Tag tagToDelete = await _context.Tags.FirstOrDefaultAsync(t => t.Name == tag);
            if (tagToDelete != null)
            {
                //we're getting "Remove tag from tasks where it's used" for free, since .OnDelete(DeleteBehavior.Cascade)
                //is used in CodeFirst model configuration
                _context.Tags.Remove(tagToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
