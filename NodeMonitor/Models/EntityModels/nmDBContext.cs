using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace DatabaseLib.Models.EntityModels
{
    public class nmDBContext : DbContext
    {
        #region DbSets
        public DbSet<NodeEntity> Nodes { get; set; }
        public DbSet<NodeLocationEntity> NodeLocations { get; set; }
        public DbSet<ResourcesEntity> Resources { get; set; }
        //public DbSet<ReservedResourcesEntity> ReservedResources{ get; set; }
        //public DbSet<TotalResourcesEntity> TotalResources { get; set; }
        //public DbSet<UsedResourcesEntity> UsedResources { get; set; }
        public DbSet<WorkloadsEntity> Workloads { get; set; }
        public DbSet<IfaceEntity> Ifaces { get; set; }
        public DbSet<AddrsEntity> Addresses { get; set; }
        public DbSet<GatewayEntity> Gateways { get; set; }
        public DbSet<FarmEntity> Farms { get; set; }
        public DbSet<FarmLocationEntity> FarmLocations { get; set; }
        public DbSet<WalletAddressEntity> WalletAddresses { get; set; }
        public DbSet<ResourcePriceEntity> ResourcePrices { get; set; }
        public DbSet<NodeHistoryEntity> NodeHistories { get; set; }
        public DbSet<NodeMonSettingsEntity> NodeMonSettings { get; set; }
        public DbSet<TokenHistoryEntity> TokenHistories { get; set; }
        public DbSet<FarmerEntity> Farmers { get; set; }
        public DbSet<ThreefoldApiUriEntity> ThreefoldApiUris { get; set; }
        public DbSet<AbonementSourceTypEntity> AbonementSourceTypes { get; set; }
        public DbSet<AbonementsSourcesEntity> AbonementsSources { get; set; }
        public DbSet<AbonementTargetTypEntity> AbonementTargetTypes { get; set; }

        #endregion
        #region overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=10.0.0.10,1433;initial catalog=omniflow_services;User ID=SA;Password=Pa$$word");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AbonementsSourcesEntity>()
                .HasKey(a_s => new { a_s.AbonementEntityId, a_s.AbonementSourceTypEntityId });
            modelBuilder.Entity<AbonementsSourcesEntity>()
                .HasOne(a_s => a_s.AbonementEntity)
                .WithMany(a => a.AbonementsSources)
                .HasForeignKey(bc => bc.AbonementEntityId);
            modelBuilder.Entity<AbonementsSourcesEntity>()
                .HasOne(a_s => a_s.AbonementSourceTyp)
                .WithMany(s => s.AbonementsSources)
                .HasForeignKey(a_s => a_s.AbonementSourceTypEntityId);
        }

        #endregion

        /*
         <connectionStrings>
           <!-- Verbindungsparemter.bei Fehlern Kontrollieren-->
           <!--
           Network protocol codes
           NAME        NETWORK LIBRARY
           dbnmpntw Named Pipes
        dbmslpcn    Shared Memory(local machine connections only, might fail when moving to production...)
           dbmssocn Winsock TCP/IP
        dbmsspxn    SPX/IPX
        dbmsvinn    Banyan Vines
           dbmsrpcn Multi-Protocol(Windows RPC)
           dbmsadsn Apple Talk
        dbmsgnet    VIA
           -->
           <!-- Lokale Express Instanz:  Data Source =.\SQLExpress; Integrated Security = true; AttachDbFilename=C:\MyFolder\TaskMaster.mdf;User Instance = true;-->
           <!-- Trusted Verbindung:      Server=WIN16S-MSSQL; Database=TaskMaster; Trusted_Connection=True;-->
           <!-- Standard Verbindung:     Server=WIN16S-MSSQL; Database=TaskMaster; User Id = flow; Password=eistee;-->
           <!-- Instanz Verbindung:      Server=WIN16S-MSSQL\MSSQL$SQLEXPRESS\; Database=TaskMaster; User Id = flow; Password=eistee;-->
           <!-- Über IP-Adresse:         Data Source = 10.0.0.18,1433; Network Library = DBMSSOCN; Initial Catalog = TaskMaster; User ID = flow; Password=eistee;-->
           <!-- Über NamedPipe:         Data Source = 10.0.0.18,1433; Network Library = dbnmpntw; Initial Catalog = TaskMaster; User ID = flow; Password=eistee;-->
           <!-- <add name = "tmDBContext" connectionString="data source=WIN16S-MSSQL; initial catalog=TaskMaster; User ID=flow ; Password=eistee;" providerName="System.Data.SqlClient" /> -->
           <add name = "DBContext" connectionString="data source=10.0.0.10,1433; initial catalog=TaskMaster; User ID=SA ; Password=Pa$$word;" providerName="System.Data.SqlClient" />
         </connectionStrings>
           */
    }
}