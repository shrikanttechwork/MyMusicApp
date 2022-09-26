﻿using MyMusic.Core;
using MyMusic.Core.Repositories;
using MyMusic.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyMusicDbContext _context;
        private IMusicRepository _musicRepository;
        private IArtistRepository _artistRepository;

        public UnitOfWork(MyMusicDbContext context)
        {
            this._context = context;
        }
        public IMusicRepository Musics => _musicRepository ??= new MusicRepository(_context);

        public IArtistRepository Artists => _artistRepository ??= new ArtistRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
