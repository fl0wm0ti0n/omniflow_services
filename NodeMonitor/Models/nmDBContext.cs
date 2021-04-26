using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Configuration;
using CommonLib.Toolsets;
using DatabaseLib.Entities;
using NodeMonitor.Business;

namespace NodeMonitor.Models
{
    // Um eine neu Migration auszuführen:
    // Add-Migration CreateDB -Project NodeMonitor -StartupProject NodeMonitor

    // Um die letzte Migration rückgängig zu machen:    
    // Remove-Migration -Project NodeMonitor -StartupProject NodeMonitor

    // Um die Datenbank zu erstellen oder upzudaten
    // Update-Database -Project NodeMonitor -StartupProject NodeMonitor

    public class nmDBContext : DbContext
    {
        #region DbSets
        public DbSet<NodeEntity> Nodes { get; set; }
        public DbSet<NodeLocationEntity> NodeLocations { get; set; }
        public DbSet<ReservedResourcesEntity> ReservedResources{ get; set; }
        public DbSet<TotalResourcesEntity> TotalResources { get; set; }
        public DbSet<UsedResourcesEntity> UsedResources { get; set; }
        public DbSet<ReservedResourcesHistoryEntity> ReservedResourcesHistories { get; set; }
        public DbSet<TotalResourcesHistoryEntity> TotalResourcesHistories { get; set; }
        public DbSet<UsedResourcesHistoryEntity> UsedResourcesHistories { get; set; }
        public DbSet<PublicConfigEntity> PublicConfigs { get; set; }
        public DbSet<WorkloadsEntity> Workloads { get; set; }
        public DbSet<IfaceEntity> Interfaces { get; set; }
        public DbSet<FarmEntity> Farms { get; set; }
        public DbSet<FarmLocationEntity> FarmLocations { get; set; }
        public DbSet<WalletAddressEntity> WalletAddresses { get; set; }
        public DbSet<ResourcePriceEntity> ResourcePrices { get; set; }
        public DbSet<NodeHistoryEntity> NodeHistories { get; set; }
        public DbSet<SettingsEntity> Settings { get; set; }
        public DbSet<TokenHistoryEntity> TokenHistories { get; set; }
        public DbSet<FarmerEntity> Farmers { get; set; }
        public DbSet<ThreefoldApiUriEntity> ThreefoldApiUris { get; set; }
        public DbSet<AbonementSourceTypEntity> AbonementSourceTypes { get; set; }
        public DbSet<AbonementsToSourcesEntity> AbonementsToSources { get; set; }
        public DbSet<AbonementTargetTypEntity> AbonementTargetTypes { get; set; }
        public DbSet<NodeMonSchedulesEntity> Schedules { get; set; }
        public DbSet<NodeMonSchedulesToDaysEntity> SchedulesToDays { get; set; }
        public DbSet<NodeMonScheduleDaysEntity> ScheduleDays { get; set; }

        #endregion
        #region overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            string  _connectionString = "data source=";
                    _connectionString = _connectionString + AppConfig.ReadSetting<string>("Database_Ip");
                    _connectionString = _connectionString + ",";
                    _connectionString = _connectionString + AppConfig.ReadSetting<int>("Database_Port");
                    _connectionString = _connectionString + ";";
                    _connectionString = _connectionString + "initial catalog=";
                    _connectionString = _connectionString + AppConfig.ReadSetting<string>("Database_Catalog");
                    _connectionString = _connectionString + ";";
                    _connectionString = _connectionString + "User ID=";
                    _connectionString = _connectionString + AppConfig.ReadSetting<string>("Database_User");
                    _connectionString = _connectionString + ";";
                    _connectionString = _connectionString + "Password=";
                    _connectionString = _connectionString + AppConfig.ReadSetting<string>("Database_Password");
            
            string _connectionStringFull = AppConfig.ReadSetting<string>("Database_ConnectionString");
            //optionsBuilder.UseSqlServer(@"data source=10.0.0.10,1433;initial catalog=omniflow_services;User ID=SA;Password=Pa$$word");
            optionsBuilder.UseSqlServer(_connectionString);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AbonementsToSourcesEntity>()
                .HasKey(a_s => new { a_s.AbonementEntityId, a_s.AbonementSourceTypEntityId });
            modelBuilder.Entity<AbonementsToSourcesEntity>()
                .HasOne(a_s => a_s.AbonementEntity)
                .WithMany(a => a.AbonementsToSources)
                .HasForeignKey(bc => bc.AbonementEntityId);
            modelBuilder.Entity<AbonementsToSourcesEntity>()
                .HasOne(a_s => a_s.AbonementSourceTyp)
                .WithMany(s => s.AbonementsToSources)
                .HasForeignKey(a_s => a_s.AbonementSourceTypEntityId);

            modelBuilder.Entity<NodeMonSchedulesToDaysEntity>()
                .HasKey(a_s => new { a_s.NodeMonSchedulesEntityId, a_s.NodeMonScheduleDaysEntityId });
            modelBuilder.Entity<NodeMonSchedulesToDaysEntity>()
                .HasOne(a_s => a_s.NodeMonSchedulesEntity)
                .WithMany(a => a.SchedulesToDays)
                .HasForeignKey(bc => bc.NodeMonSchedulesEntityId);
            modelBuilder.Entity<NodeMonSchedulesToDaysEntity>()
                .HasOne(a_s => a_s.NodeMonScheduleDaysEntity)
                .WithMany(s => s.SchedulesToDays)
                .HasForeignKey(a_s => a_s.NodeMonScheduleDaysEntityId);

            // macht es möglich, dass per trennzeichen getrennte Listen in ein Datenfeld gespeichert werden.
           //var splitStringConverter = new ValueConverter
           //    
           //    <IEnumerable<string>, string>
           //    (
           //    v => string.Join("; ", v), 
           //    v => v.Split(new[] { ';' })
           //    );
           //
           //    modelBuilder
           //    .Entity<IfaceEntity>()
           //    .Property(nameof(IfaceEntity.SerializedListOfAddresses))
           //    .HasConversion(splitStringConverter);
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