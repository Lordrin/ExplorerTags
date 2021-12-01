using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VideoTagPlayer.DataLayer
{
    public class ContextFactory
    {
        public VideoTagContext CreateVideoTagContext()
        {
            return new VideoTagContext();
        } 

        public VideoTagRepository Createrepository()
        {
            return new VideoTagRepository(CreateVideoTagContext());
        }
    }
}
