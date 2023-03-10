using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using OneAppHNI.Authorization.Roles;
using OneAppHNI.Authorization.Users;
using OneAppHNI.MultiTenancy;
using OneAppHNI.DanhMuc;
using OneAppHNI.Log;
using OneAppHNI.DienNang;
using OneAppHNI.VoTuyen;

namespace OneAppHNI.EntityFrameworkCore
{
    public class OneAppHNIDbContext : AbpZeroDbContext<Tenant, Role, User, OneAppHNIDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<TEST> TEST { get; set; }
        public virtual DbSet<LOGUPLOADFILE> LOGUPLOADFILE { get; set; }
        public virtual DbSet<DIENNANG> DIENNANG { get; set; }
        public virtual DbSet<LOGSENDEMAIL> LOGSENDEMAIL { get; set; }
        public virtual DbSet<BADCELL> BADCELL { get; set; }
        public virtual DbSet<TRAMLOAITRU> TRAMLOAITRU { get; set; }
        public virtual DbSet<LOGCALLAPI> LOGCALLAPI { get; set; }
        public OneAppHNIDbContext(DbContextOptions<OneAppHNIDbContext> options)
            : base(options)
        {
        }

    }
}
