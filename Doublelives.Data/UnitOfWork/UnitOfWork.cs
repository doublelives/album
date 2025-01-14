﻿using Doublelives.Domain.Pictures;
using Doublelives.Domain.Users;

namespace Doublelives.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAlbumDbContext _albumDbContext;

        public IRepository<Picture> PictureRepository { get; private set; }

        public IRepository<User> UserRepository { get; private set; }

        public UnitOfWork(IAlbumDbContext albumDbContext)
        {
            _albumDbContext = albumDbContext;
            PictureRepository = new Repository<Picture>(albumDbContext);
            UserRepository = new Repository<User>(albumDbContext);
        }

        public void Commit()
        {
            _albumDbContext.SaveChanges();
        }
    }
}
