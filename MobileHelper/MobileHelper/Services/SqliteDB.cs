﻿using Microsoft.EntityFrameworkCore;
using MobileHelper.Models.Tables;
using System;
using System.Threading.Tasks;

namespace MobileHelper.Services
{
    public class SQLiteDB : DbContext
    {
        #region Tables
        public DbSet<TechniqueDB> Techniques { get; set; }
        public DbSet<QuotDB> Quots { get; set; }

        #endregion

        public string DbPath { get; }

        public SQLiteDB()
        {
            Environment.SpecialFolder folder = Environment.SpecialFolder.LocalApplicationData;
            string path = Environment.GetFolderPath(folder);
            this.DbPath = System.IO.Path.Join(path, "local.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            _ = options.UseSqlite($"Data Source={this.DbPath}");
        }
    }
}
