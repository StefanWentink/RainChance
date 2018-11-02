﻿namespace RainChance.DAL.Context
{
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class ContextContainer : IContextContainer
    {
        private DbContext DbContextReference { get; }

        private string GetConnectionString => DbContextReference.Database.GetDbConnection().ConnectionString;

        private static readonly object ContextLock = new object();

        public DbContext GetContext
        {
            get
            {
                lock (ContextLock)
                {
                    var context = (DbContext)Activator.CreateInstance(DbContextReference.GetType(), GetConnectionString);
                    context.OpenConnection();
                    return context;
                }
            }
        }

        public ContextContainer(DbContext ctx)
        {
            DbContextReference = ctx;
        }
    }
}